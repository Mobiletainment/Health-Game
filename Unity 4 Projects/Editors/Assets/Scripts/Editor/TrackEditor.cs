using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
[CustomEditor(typeof(MasterTrackScript))]
public class TrackEditor : Editor 
{
	[SerializeField]
	private MasterTrackScript _data = null;
	
	// This list will be initialized each time, the editor is enabled. It will contain all trackPart names.
	private List<string> _partNames = null;
	
	public void OnEnable()
	{
		// Initialize the target (data):
		_data = target as MasterTrackScript;
		
		if(_data == null)
		{
			Debug.LogError("No target data is initialized...");
		}
		
		// Initialize the trackPart Names:
		_partNames = new List<string>();
		
		foreach(TrackPartScript trackPart in _data.trackPartManager._parts)
		{
			_partNames.Add(trackPart.Name);
		}
		if(_partNames.Count == 0)
		{
			Debug.LogError("No TrackParts are connected to the TrackPartManager.");
		}
		else if(_data.partSelectionInd >= _partNames.Count)
		{
			_data.partSelectionInd = 0;
		}
		
		// Check if the current Track was manipulated:
		TrackPartScript[] currentTrackObjects = _data.GetComponentsInChildren<TrackPartScript>();
		if(currentTrackObjects.Length != _data.currentTrackParts.Count)
		{
			Debug.LogError("The Track was manipulated outside of this editor.\n" +
				"Please only remove or add TrackParts via this editor.\n" +
				"To solve this error, clear the whole track.");
			// TODO: Make an auto-solver for this. (Maybe, there is a way to fix this, e.g. remove all children and
			// reInstantiate them via the references in the list. Or cross-check the list with the given TrackParts
			// and move them together, if one in the middle was removed by hand...
		}
		
		// FIX: Refresh Color after Undo / Redo:
		if(_data.changeArrowContainer != null)
		{
			if(_data.editorMode == MasterTrackScript.Mode.ERASE)
			{
				foreach(Transform arrow in _data.changeArrowContainer.transform)
				{
					// TODO: Hardcoded red -> This is not nice, if the color changes...
					arrow.renderer.sharedMaterial.color = Color.red;
				}
			}
			else if(_data.editorMode == MasterTrackScript.Mode.INSERT)
			{
				foreach(Transform arrow in _data.changeArrowContainer.transform)
				{
					// TODO: Hardcoded green -> This is not nice, if the color changes...
					arrow.renderer.sharedMaterial.color = Color.green;
				}
			}
		}
		
		// REFACTOR: Remove this after debugging the Save-Mode!
		if(_data.saveTracks != null)
		{
			if(_data.saveTracks.trackList == null)
			{
				Debug.Log("SaveTracks.trackList is null!");
			}
		}
	}
	
	public override void OnInspectorGUI()
	{	
		// --- GUI START ---
		EditorGUILayout.Space();
		
		if(_data.editorMode == MasterTrackScript.Mode.NORMAL)
		{
			EditorInNormalMode();
		}
		else if(_data.editorMode == MasterTrackScript.Mode.ERASE)
		{
			EditorInEraseMode();
		}
		else if(_data.editorMode == MasterTrackScript.Mode.INSERT)
		{
			EditorInInsertMode();
		}
		else if(_data.editorMode == MasterTrackScript.Mode.SAVE)
		{
			EditorInSaveMode();
		}
		
		GUILayout.Space(20);
		// --- GUI END ---
		
		// Player Confort - Use Keys:
//		if(Event.current.type == EventType.KeyDown)
//		{
//			if(Event.current.keyCode == KeyCode.Return)
//			{
//				// ...
//			}
//		}
		
		// Finally: Save all chances:
		// Info: data is null, if the object got destroyed (e.g. when loading another track).
		if(GUI.changed && _data != null)
		{
			EditorUtility.SetDirty(_data);
		}
	}
	
	public void EditorInNormalMode()
	{
		_data.showConfig = EditorGUILayout.Foldout(_data.showConfig, "Configuration");
		if(_data.showConfig)
		{
			EditorGUI.indentLevel++;
			
			// A TrackPartManager Field, to config the TrackParts.
			_data.trackPartManager = EditorGUILayout.ObjectField("TrackPartManager: ", _data.trackPartManager, typeof(TrackPartMgr), false) as TrackPartMgr;
			
			// A SaveTracks Field, to configure, where the tracks shall be saved.
			_data.saveTracks = EditorGUILayout.ObjectField("SaveTracks: ", _data.saveTracks, typeof(SaveTracks), false) as SaveTracks;
			
			// A Arrow Asset Field, to config the arrow, that should be loaded for erase / insert.
			_data.arrowAsset = EditorGUILayout.ObjectField("Arrow Asset: ", _data.arrowAsset, typeof(Transform), false) as Transform;
			
			EditorGUI.indentLevel--;
		}
		
		EditorGUILayout.Space();
		
		// DropDown of all trackParts, that can be added to the track:
		_data.partSelectionInd = EditorGUILayout.Popup("Chose next TrackPart: ", _data.partSelectionInd, _partNames.ToArray());
		
		if(GUILayout.Button("Add part to track"))
		{
			Undo.RegisterSceneUndo("Add part to track");
			
			// GameObject trackPart = Instantiate(Resources.Load("Prefabs/TrackParts/Part1")) as GameObject;
			TrackPartScript trackPart = Instantiate(_data.trackPartManager._parts[_data.partSelectionInd]) as TrackPartScript;
			// TrackPartScript trackPartScript = trackPart.GetComponent<TrackPartScript>();
			trackPart.transform.parent = Selection.activeTransform;
			
			// Put the new TrackPart in the correct position and rotation:
			if(_data.currentTrackParts.Count == 0)
			{
				trackPart.transform.position = Vector3.zero;
			}
			else
			{
				TrackPartScript lastTrackPart = _data.currentTrackParts[_data.currentTrackParts.Count - 1];

				trackPart.transform.position = lastTrackPart.ReferenceObjectEnd.transform.position;
				trackPart.transform.rotation = lastTrackPart.ReferenceObjectEnd.transform.rotation;
			}
			
			trackPart.gameObject.name = "TrackPart_" + _data.nameCounter.ToString() + "_" + trackPart.Name;
			_data.nameCounter++;
			
			// Add the new TrackPart to the list:
			_data.currentTrackParts.Add(trackPart);
		}
		
		EditorGUILayout.Space();
		
		if(GUILayout.Button("Enter Erase-Mode..."))
		{
			Undo.RegisterSceneUndo("Enter Erase Mode");
			
			_data.editorMode = MasterTrackScript.Mode.ERASE;
			
			if(_data.arrowAsset == null)
			{
				Debug.LogWarning("No Asset for an Arrow (Erase / Insert) has been set.\n" +
					"Look into the Editor-Configuration to fix this issue.");
			}
			
			// Initialze the Arrows:
			_data.changeArrowContainer = new GameObject("ArrowContainer");
			
			foreach(TrackPartScript part in _data.currentTrackParts)
			{
				GameObject arrow = null;
				Vector3 centerPos = CalcCenterPos(part.transform);
				
				if(_data.arrowAsset != null)
				{
					Transform arrowTrans = Instantiate(_data.arrowAsset, centerPos + Vector3.up, Quaternion.identity) as Transform;
					arrow = arrowTrans.gameObject;
				}
				else // No arrow asset has been set:
				{
					// Alternative: Creating a cube instead of an arrow.
					arrow = GameObject.CreatePrimitive(PrimitiveType.Cube);
					arrow.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
					arrow.transform.position = centerPos + Vector3.up;
				}
				
				DeleteArrowScript deleteArrow = arrow.AddComponent<DeleteArrowScript>();
				deleteArrow.trackPart = part;
				deleteArrow.trackReference = _data;
				
				deleteArrow.transform.parent = _data.changeArrowContainer.transform;
				deleteArrow.gameObject.renderer.sharedMaterial.color = Color.red;
			}
		}
		
		if(GUILayout.Button("Enter Insertion-Mode..."))
		{
			Undo.RegisterSceneUndo("Enter Insert Mode");
			
			_data.editorMode = MasterTrackScript.Mode.INSERT;
			
			if(_data.arrowAsset == null)
			{
				Debug.LogWarning("No Asset for an Arrow (Erase / Insert) has been set.\n" +
					"Look into the Editor-Configuration to fix this issue.");
			}
			
			// Initialze the Arrows:
			_data.changeArrowContainer = new GameObject("ArrowContainer");
			
			foreach(TrackPartScript part in _data.currentTrackParts)
			{
				CreateInsertionArrow(part, _data);
			}
		}
		
		// TODO: Save Button... (Clean and Normal)
		if(GUILayout.Button("Save or Load Track..."))
		{
			Undo.RegisterSceneUndo("Enter Save Mode");
			
			_data.editorMode = MasterTrackScript.Mode.SAVE;
			
			if(_data.saveTracks == null)
			{
				Debug.LogError("No SaveTracks Asset has been configured to save the Tracks.\n" +
					"See the Config-Section in the TrackEditor.");
			}
			// TODO: Give User two options: Clean Save and Debug Save.
			// Clean Save erases all the Meta-Information like "Reference Object Start".
			// Debug Save does not erase these data.
			// TODO: Make an Asset, that can handle this Track and the list (data.currentTrackList) to save this.
			// Alternatively I could simply save the Track as Prefab.
		}
		
		// TODO: Maybe, a "Load Track"-button would be nice...
	}
	
	public void EditorInEraseMode()
	{
		_data.deleteWithoutConfirmation = EditorGUILayout.Toggle("Delete Part without confirmation", _data.deleteWithoutConfirmation); 
		
		if(GUILayout.Button("Delete complete Track."))
		{
			Undo.RegisterSceneUndo("Delete complete Track");
			
			for(int i = _data.currentTrackParts.Count - 1; i >= 0; --i)
			{
				DestroyImmediate(_data.currentTrackParts[i].gameObject);
			}
			
			_data.currentTrackParts.Clear();
			
			_data.nameCounter = 0;
			
			SwitchFromEraseToNormal();
		}
		
		// Switch back to Normal Editor Mode:
		if(GUILayout.Button("Leave Erase-Mode"))
		{
			SwitchFromEraseToNormal();
		}
	}
	
	public void SwitchFromEraseToNormal()
	{
		Undo.RegisterSceneUndo("Enter Normal Mode");
		
		_data.editorMode = MasterTrackScript.Mode.NORMAL;
			
		DestroyImmediate(_data.changeArrowContainer);
		_data.changeArrowContainer = null;
	}
	
	public void EditorInInsertMode()
	{
		_data.instantInsertion = EditorGUILayout.Toggle("Insert TrackPart instantly", _data.instantInsertion);
		
		if(_data.instantInsertion == true)
		{
			_data.partSelectionInd = EditorGUILayout.Popup("Insert TrackPart: ", _data.partSelectionInd, _partNames.ToArray());
		}
		
		// TODO: Label to inform user to use a arrow to insert the selected trackpart.
		
		if(GUILayout.Button("Leave Insertion-Mode"))
		{
			Undo.RegisterSceneUndo("Enter Normal Mode");
			
			_data.editorMode = MasterTrackScript.Mode.NORMAL;
			
			DestroyImmediate(_data.changeArrowContainer);
			_data.changeArrowContainer = null;
		}
	}
	
	public void EditorInSaveMode()
	{
		// Foldout for saving:
		_data.showSaveOptions = EditorGUILayout.Foldout(_data.showSaveOptions, "Save Track:");
		if(_data.showSaveOptions)
		{
			EditorGUI.indentLevel++;
			
			// Name to save the Track:
			if(_data.trackName == null || _data.trackName.Length == 0)
			{
				// Create a default name:
				_data.trackName = "TrackName" + _data.saveTracks.trackList.Count;
				// TODO: If the name already exists in the map, create count+++...
			}
			_data.trackName = EditorGUILayout.TextField("Track Name: ", _data.trackName);
			
			GUILayout.BeginHorizontal();
			GUILayout.Space(13); // IndentLevel
			if(GUILayout.Button("Save Track"))
			{
				AssetDatabase.StartAssetEditing();
				
				// TODO: Hardcoded Path -> Make it configureable (instead of "Assets/Resources/Prefabs/SavedTracks/")
				GameObject prefab = PrefabUtility.CreatePrefab("Assets/Resources/Prefabs/SavedTracks/"+_data.trackName+".prefab", _data.gameObject);
				
				_data.saveTracks.trackList.Add(prefab.GetComponent<MasterTrackScript>());
				
				AssetDatabase.StopAssetEditing();
				EditorUtility.SetDirty(_data.saveTracks);
				AssetDatabase.SaveAssets();
				
				AssetDatabase.Refresh();
				
				Debug.Log("Track has been saved as Assets/Resources/Prefabs/SavedTracks/"+_data.trackName+".prefab\n" +
					"Note: This is an Debug-Asset that can be loaded and changed by the editor at any time.\n" +
					"For a save Track Asset use the \"Export Clean Track\" Button.", prefab);
			}
			GUILayout.EndHorizontal();
			
			GUILayout.BeginHorizontal();
			GUILayout.Space(13); // IndentLevel
			if(GUILayout.Button("Export Clean Track (Prefab)"))
			{
				// TODO: Hardcoded Path -> Make it configureable (instead of "Assets/Resources/Prefabs/SavedTracks/")
				GameObject prefab = PrefabUtility.CreatePrefab("Assets/Resources/Prefabs/CleanTracks/"+_data.trackName+".prefab", _data.gameObject);
				
				foreach(Transform trackPart in prefab.transform)
				{
					TrackPartScript tps = trackPart.GetComponent<TrackPartScript>();
					DestroyImmediate(tps.ReferenceObjectStart, true);
					DestroyImmediate(tps.ReferenceObjectEnd, true);
					DestroyImmediate(trackPart.GetComponent<TrackPartScript>(), true);
				}
				
				DestroyImmediate(prefab.GetComponent<MasterTrackScript>(), true);
				
				Debug.Log("Track has been saved as Assets/Resources/Prefabs/CleanTracks/"+_data.trackName+".prefab", prefab);
			}
			GUILayout.EndHorizontal();
			
			EditorGUI.indentLevel--;
		}
		
		// Foldout for loading:
		_data.showLoadOptions = EditorGUILayout.Foldout(_data.showLoadOptions, "Load Track:");
		if(_data.showLoadOptions)
		{
			EditorGUI.indentLevel++;
			
			if(_data.saveTracks.trackList.Count == 0)
			{
				EditorGUILayout.LabelField("No Tracks available...");
			}
			else
			{
				// TODO: Load a given track from the SaveTracks-List...
				// Present all trackNames:
				//List<string> keyList = new List<string>(_data.saveTracks.trackMap.Keys);
				
				// REFACTOR: It is not performant to create this List each time, OnGUI is called!
				List<string> trackNameList = new List<string>(_data.saveTracks.trackList.Count);
				foreach(MasterTrackScript masterTrack in _data.saveTracks.trackList)
				{
					trackNameList.Add(masterTrack.trackName);
				}
				
				_data.loadTrackIndex = EditorGUILayout.Popup(_data.loadTrackIndex, trackNameList.ToArray());
				
				GUILayout.BeginHorizontal();
				GUILayout.Space(13); // IndentLevel
				if(GUILayout.Button("Load Track"))
				{
					// Instantiate chosen Debug-Track Asset:
					MasterTrackScript loadedTrack = Instantiate(_data.saveTracks.trackList[_data.loadTrackIndex], Vector3.zero, Quaternion.identity) as MasterTrackScript;
					
					if(loadedTrack != null)
					{
						loadedTrack.name = "MasterTrackObject";
						Debug.Log("Loaded Track "+trackNameList[_data.loadTrackIndex]+" successfully.", loadedTrack);
					
						// Destroy the current track...
						// TODO: IMPORTANT: Warn user, that he will lose the current track if he loads another one!
						// If he wants to keep the track, he must save it before loading!
						DestroyImmediate(_data.gameObject);
						
						// Select the loaded track:
						GameObject[] selection = new GameObject[1];
						selection[0] = loadedTrack.gameObject;
						Selection.objects = selection;
					}
				}
				GUILayout.EndHorizontal();
			}
			
			EditorGUI.indentLevel--;
		}
		
		// Foldout for deleting an existing Track:
		_data.showDeleteOptions = EditorGUILayout.Foldout(_data.showDeleteOptions, "Delete Existing Track:");
		if(_data.showLoadOptions)
		{
			EditorGUI.indentLevel++;
			
			// TODO: Delete a given Track from the SaveTracks-List...
			
			EditorGUI.indentLevel--;
		}
		
		EditorGUILayout.Space();
		
		if(GUILayout.Button("Leave Save-Mode"))
		{
			Undo.RegisterSceneUndo("Enter Normal Mode");
			
			_data.editorMode = MasterTrackScript.Mode.NORMAL;
		}
	}
	
	public static Vector3 CalcCenterPos(Transform parentTransform)
	{
		Vector3 center = new Vector3(0, 0, 0);
		
		if(parentTransform.childCount > 0)
		{
			foreach(Transform child in parentTransform)
			{
				center += child.position;
			}
			
			center /= parentTransform.childCount;
		}
		
		return center;
	}
	
	public static void CreateInsertionArrow(TrackPartScript trackPart, MasterTrackScript trackReference)
	{
		GameObject arrow = null;
		
		if(trackReference.arrowAsset != null)
		{
			Transform arrowTrans = Instantiate(trackReference.arrowAsset, trackPart.ReferenceObjectStart.transform.position + Vector3.up, Quaternion.identity) as Transform;
			arrow = arrowTrans.gameObject;
		}
		else // No arrow asset has been set:
		{
			// Alternative: Creating a cube instead of instantiating arrow-prefabs.
			arrow = GameObject.CreatePrimitive(PrimitiveType.Cube);
			arrow.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
			arrow.transform.position = trackPart.ReferenceObjectStart.transform.position + Vector3.up;
		}
		
		InsertArrowScript insertArrow = arrow.AddComponent<InsertArrowScript>();
		insertArrow.trackPart = trackPart;
		insertArrow.trackReference = trackReference;
		
		insertArrow.gameObject.renderer.sharedMaterial.color = Color.green;
		insertArrow.transform.parent = trackReference.changeArrowContainer.transform;
	}
}
