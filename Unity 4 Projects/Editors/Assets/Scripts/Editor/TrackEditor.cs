using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

// Known Bugs:
// - Splines are not shown constantly. After adding/inserting/removing they are refreshed but do not show up
//	 until something else is used in the GUI (e.g. button press).

[System.Serializable]
[CustomEditor(typeof(MasterTrackScript))]
public class TrackEditor : Editor 
{
	[SerializeField]
	private MasterTrackScript _data = null;
	
	// This list will be initialized each time, the editor is enabled. It will contain all trackPart names.
	private List<string> _partNames = null;
	// This list will be initialized each time, the editor is enabled. It will contain all saved Tracks names.
	private List<string> _savedTrackNames = null;
	
	public void OnEnable()
	{
		// Initialize the target (data):
		_data = target as MasterTrackScript;
		
		if(_data == null)
		{
			Debug.LogError("No target data is initialized...");
		}
		else if(EditorUtility.IsPersistent(_data))
		{
			// Do not initialize anything, if the target is a prefab. (It won't work anyway.)
			return;
		}
		else if(_data.gameObject.activeInHierarchy == false)
		{
			// Do not init anything, if the target is deactivated. (It won't work anyway.)
			return;
		}
		
		// Initialize the trackPart Names:
		_partNames = new List<string>();

		if(_data.trackPartManager != null)
		{
			if(_data.trackPartManager._parts != null)
			{
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
			}
			else
			{
				Debug.LogError("The TrackPartManager is not configured. Please add some TrackParts to the Manager.");
			}
		}
		else
		{
			Debug.LogError("TrackPartManager has not been set yet.\n" +
				"Go to Menu: TrackEditor -> Create Asset -> TrackPartMgr Asset.");
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
		
		// Initialize the savedTrackNames List:
		if(_data.saveTracks != null)
		{
			if(_data.saveTracks.trackList.Count > 0)
			{
				_savedTrackNames = new List<string>(_data.saveTracks.trackList.Count);
				
				for(int i = 0; i < _data.saveTracks.trackList.Count; ++i)
				{
					MasterTrackScript masterTrack = _data.saveTracks.trackList[i];
					if(masterTrack == null)
					{
						_data.saveTracks.trackList.RemoveAt(i);
						--i;
					}
					else
					{
						_savedTrackNames.Add(masterTrack.trackName);
					}
				}
			}
			else
			{
				_savedTrackNames = new List<string>();
			}
		}
		else
		{
			Debug.LogError("The SaveTracks-Asset has not been set yet.\n" +
			               "Go to Menu: TrackEditor -> Create Asset -> SaveTracks Asset.");
		}
	}
	
	public override void OnInspectorGUI()
	{
		// Do not show the Editor, if the target is a prefab. (It only works for scene objects!)
		if(EditorUtility.IsPersistent(_data))
		{
			EditorGUILayout.LabelField("This editor is deactivated for prefabs.");
			return;
		}
		else if(_data.gameObject.activeInHierarchy == false)
		{
			// Do not show anything, if the target is deactivated. (It won't work anyway.)
			return;
		}

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
		else if(_data.editorMode == MasterTrackScript.Mode.PICKUP)
		{
			EditorInPickupMode();
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

			// Config, if splines shall be shown or not:
			_data.showSplines = EditorGUILayout.Toggle("Show Splines: ", _data.showSplines);

			// Config the environment object (Stones, Shells, etc.) that are put on the track for export:
			// TODO: If this is changed to a list, presenting must be rewritten...
			_data.environmentObject = EditorGUILayout.ObjectField("Environment: ", _data.environmentObject, typeof(GameObject), false) as GameObject;

			EditorGUI.indentLevel--;
		}

		// Spline Drawin-Check for Track:
		ManageSplines(_data.showSplines);
		
		EditorGUILayout.Space();
		
		// DropDown of all trackParts, that can be added to the track:
		_data.partSelectionInd = EditorGUILayout.Popup("Chose next TrackPart: ", _data.partSelectionInd, _partNames.ToArray());
		
		if(GUILayout.Button("Add part to track"))
		{
			//Undo.RegisterSceneUndo("Add part to track");
			
			TrackPartScript trackPart = Instantiate(_data.trackPartManager._parts[_data.partSelectionInd]) as TrackPartScript;
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

			// Lets generate new spline lines:
			DestroyImmediate(_data.splineObject);
			_data.splineObject = null;
		}
		
		EditorGUILayout.Space();
		
		if(GUILayout.Button("Enter Erase-Mode..."))
		{
			//Undo.RegisterSceneUndo("Enter Erase Mode");
			
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
					Transform arrowTrans = Instantiate(_data.arrowAsset, centerPos + Vector3.up * 0.2f, Quaternion.identity) as Transform;
					arrowTrans.localScale = new Vector3(0.2f, 0.2f, 0.2f);
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
			//Undo.RegisterSceneUndo("Enter Insert Mode");
			
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

		if(GUILayout.Button ("Enter Pickup-Mode..."))
		{
			_data.editorMode = MasterTrackScript.Mode.PICKUP;

			// HACK: Use different colors with shared materials without unity-complining-warnings...
			// I just needed a gameObject, that has a renderer, so I took the Ref.Obj.Start, because it was easy to get.
			Material matGreen = new Material(_data.currentTrackParts[0].ReferenceObjectStart.renderer.sharedMaterial);
			matGreen.color = Color.green;
			Material matRed = new Material(_data.currentTrackParts[0].ReferenceObjectStart.renderer.sharedMaterial);
			matRed.color = Color.red;

			foreach(TrackPartScript part in _data.currentTrackParts)
			{
				PickupContainerTrans pickups = part.GetPickupContainer();
				foreach(KeyValuePair<PickupLine, List<PickupElementTrans>> pickupKV in pickups.GetLineDict())
				{
					foreach(PickupElementTrans puElement in pickupKV.Value)
					{
						if(puElement.active)
						{
							puElement.position.renderer.sharedMaterial = matGreen;
						}
						else
						{
							puElement.position.renderer.sharedMaterial = matRed;
						}

						PickupActivityScript pickupAS = puElement.position.gameObject.AddComponent<PickupActivityScript>();
						pickupAS.trackReference = _data;
						pickupAS.pickupElement = puElement;
					}
				}
			}
		}

		if(GUILayout.Button("Save or Load Track..."))
		{
			//Undo.RegisterSceneUndo("Enter Save Mode");
			
			_data.editorMode = MasterTrackScript.Mode.SAVE;
			
			if(_data.saveTracks == null)
			{
				Debug.LogError("No SaveTracks Asset has been configured to save the Tracks.\n" +
					"See the Config-Section in the TrackEditor.");
			}
		}
	}

/*
	public override bool HasPreviewGUI()
	{
		if(_data.editorMode == MasterTrackScript.Mode.NORMAL)
		{
			return true;
		}
		
		return false;
	}

	public override void OnPreviewGUI(Rect r, GUIStyle background)
	{
		if(_data.editorMode == MasterTrackScript.Mode.NORMAL)
		{
			Transform meshTrans = _data.trackPartManager._parts[_data.partSelectionInd].transform.GetChild(0);
			Mesh mesh = meshTrans.GetComponent<MeshFilter>().sharedMesh;
			
			// TODO: Preview!!
			
//			if(mesh == null)
//			{
//				Debug.Log("NULL");
//			}
			if(mesh != null)
			{
//				Graphics.DrawMeshNow(mesh, Vector3.zero, Quaternion.identity);
//				//Graphics.DrawMeshNow(mesh, Matrix4x4.TRS(_data.transform.position,_data.transform.rotation,_data.transform.localScale));
//				
//				RenderTexture rt = new RenderTexture(256, 256, 16, RenderTextureFormat.ARGB32);
//				rt.Create();
//				
//				GUI.Box(r, rt);
			}
		}
	}
*/

	public void EditorInEraseMode()
	{
		_data.deleteWithoutConfirmation = EditorGUILayout.Toggle("Delete Part without confirmation", _data.deleteWithoutConfirmation); 
		
		if(GUILayout.Button("Delete complete Track."))
		{
			//Undo.RegisterSceneUndo("Delete complete Track");
			
			for(int i = _data.currentTrackParts.Count - 1; i >= 0; --i)
			{
				DestroyImmediate(_data.currentTrackParts[i].gameObject);
			}
			
			_data.currentTrackParts.Clear();
			DestroyImmediate(_data.splineObject);
			_data.splineObject = null;
			
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
		//Undo.RegisterSceneUndo("Enter Normal Mode");
		
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
			//Undo.RegisterSceneUndo("Enter Normal Mode");
			
			_data.editorMode = MasterTrackScript.Mode.NORMAL;
			
			DestroyImmediate(_data.changeArrowContainer);
			_data.changeArrowContainer = null;
		}
	}

	public void EditorInPickupMode()
	{
		EditorGUILayout.LabelField("Just click on a Pickup-Cube to change its\nactivity. Only active (green) " +
		                           "Pickup-Cubes\nwill spawn pickup-elements at runtime.", GUILayout.Height(50.0f));

		if(GUILayout.Button("Leave Pickup-Mode"))
		{
			_data.editorMode = MasterTrackScript.Mode.NORMAL;

			foreach(TrackPartScript part in _data.currentTrackParts)
			{
				PickupContainerTrans pickups = part.GetPickupContainer();
				foreach(KeyValuePair<PickupLine, List<PickupElementTrans>> pickupKV in pickups.GetLineDict())
				{
					foreach(PickupElementTrans puElement in pickupKV.Value)
					{
						// Switch back color:
						Color tempColor = Color.white;
						tempColor.a = 0.5f;
						puElement.position.renderer.sharedMaterial.color = tempColor;

						// Remove Script Component:
						DestroyImmediate(puElement.position.gameObject.GetComponent<PickupActivityScript>());
					}
				}
			}
		}
	}
	
	public void EditorInSaveMode()
	{
		// Foldout for saving:
		_data.showSaveOptions = EditorGUILayout.Foldout(_data.showSaveOptions, "Save Track");
		if(_data.showSaveOptions)
		{
			EditorGUI.indentLevel++;
			
			// Name to save the Track:
			if(_data.trackName == null || _data.trackName.Length == 0)
			{
				// Create a default name:
				_data.trackName = "TrackName" + _data.saveTracks.trackList.Count;
				// TODO: If the name already exists in the list, create count+++...
			}
			_data.trackName = EditorGUILayout.TextField("Track Name: ", _data.trackName);
			
			// Check, if the Name already exists in the Saved-List:
			int otherIndex = _data.saveTracks.trackList.FindIndex(
				delegate(MasterTrackScript other)
				{
					if(other != null)
					{	
						return _data.trackName.Equals(other.trackName);
					}
					else
					{
						return false;
					}
				}
			);
			if(otherIndex != -1)
			{
				// The name is already in the list:
				EditorGUILayout.LabelField("Warning: An item with the name "+_data.trackName+"\nalready exists. If you do not" +
					"enter another name,\nthis track will be overwritten.", GUILayout.Height(50.0f));
			}
			
			GUILayout.BeginHorizontal();
			GUILayout.Space(13); // IndentLevel
			if(GUILayout.Button("Save Track"))
			{
//				AssetDatabase.StartAssetEditing();
				
				// TODO: Hardcoded Path -> Make it configureable (instead of "Assets/Resources/Prefabs/SavedTracks/")
				GameObject prefab = PrefabUtility.CreatePrefab("Assets/Resources/Prefabs/SavedTracks/"+_data.trackName+".prefab", _data.gameObject);
				
				if(otherIndex == -1)
				{
					// Add the saved track to the SaveAsset List:
					_data.saveTracks.trackList.Add(prefab.GetComponent<MasterTrackScript>());
				}
				else
				{
					// Overwrite (now missing reference) in the SaveAsset List:
					_data.saveTracks.trackList[otherIndex] = prefab.GetComponent<MasterTrackScript>();
				}
				
//				AssetDatabase.StopAssetEditing();
				EditorUtility.SetDirty(_data.saveTracks);
				AssetDatabase.SaveAssets();
				
				AssetDatabase.Refresh();
				
				// Add the Name of the saved item to the list:
				_savedTrackNames.Add(_data.trackName);
				
				Debug.Log("Track has been saved as Assets/Resources/Prefabs/SavedTracks/"+_data.trackName+".prefab\n" +
					"Note: This is a Debug-Asset that can be loaded and changed by the editor at any time.\n" +
					"For a prefab Track Asset use the \"Export Clean Track\" Button.", prefab);
			}
			GUILayout.EndHorizontal();
			
			GUILayout.BeginHorizontal();
			GUILayout.Space(13); // IndentLevel
			if(GUILayout.Button("Export Clean Track (Prefab)"))
			{
				// First, make a deep copy of the original object:
				MasterTrackScript copy = Instantiate(_data, _data.gameObject.transform.position, 
				                                     _data.gameObject.transform.rotation) as MasterTrackScript;
				GameObject copyObj = copy.gameObject;
				copyObj.name = _data.trackName;

				// Create the environment on the track:
				GameObject realEnvContainer = new GameObject("EnvironmentContainer");
				realEnvContainer.transform.parent = copyObj.transform;

				foreach(Transform trackPart in copyObj.transform)
				{
					TrackPartScript tps = trackPart.gameObject.GetComponent<TrackPartScript>();
					// Not all items in the masterTrack are TrackParts. (e.g. the EnvironmentContainer is not...)
					if(tps != null)
					{
						// Replace the Environment placeholder with the real objects:
						foreach(Transform envTrans in tps.ReferenceObjectEnvironment.transform)
						{
							// TODO: if the environmentObject will be changed to list, a random object must be chosen
							// from this list...
							envTrans.RotateAround(envTrans.position, envTrans.up, Random.Range(0.0f, 359.9f));
							GameObject realEnv = Instantiate(copy.environmentObject, envTrans.position, envTrans.rotation) as GameObject;
							realEnv.transform.parent = realEnvContainer.transform;
						}
					}
				}

				// Destroy everything, that isn't needed in the clean prefab:
				foreach(Transform trackPart in copy.transform)
				{
					TrackPartScript tps = trackPart.GetComponent<TrackPartScript>();
					// Check, if the item is realy a TPS:
					if(tps != null)
					{
						DestroyImmediate(tps.ReferenceObjectStart);
						DestroyImmediate(tps.ReferenceObjectEnd);
						DestroyImmediate(tps.ReferenceObjectSpline);
						DestroyImmediate(tps.ReferenceObjectPickup);
						DestroyImmediate(tps.ReferenceObjectEnvironment);

						DestroyImmediate(trackPart.GetComponent<TrackPartScript>());
					}
				}

				// Remove the Editor-Script:
				DestroyImmediate(copyObj.GetComponent<MasterTrackScript>());

				// Add the Clean-Data Script to add Spline information:
				CleanTrackData cleanData = copyObj.AddComponent<CleanTrackData>();

				// Gather all information and get the full spline & all Pickups (Transform-Based):
				SplineContainerTrans fullSpline = new SplineContainerTrans();
				PickupContainerTrans allPickups = new PickupContainerTrans();
				foreach(TrackPartScript trackPart in _data.currentTrackParts)
				{
					fullSpline.AddSplineContainer(trackPart.GetSplineContainer());
					allPickups.AddPickupContainer(trackPart.GetPickupContainer());
				}
				// Add the controlPoints of all TrackParts to the Clean-Data script (Vector3-Based):
				foreach(KeyValuePair<SplineLine, List<Transform>> entry in fullSpline.GetSplineDict())
				{
					List<Vector3> curSpline = cleanData.splineContainer.GetSpline(entry.Key);
					foreach(Transform ctrlPnt in entry.Value)
					{
						curSpline.Add(ctrlPnt.position);
					}
				}
				// Add all active Pickups to the Clean-Data script (Vector3-Based):
				foreach(KeyValuePair<PickupLine, List<PickupElementTrans>> entry in allPickups.GetLineDict())
				{
					List<PickupElementVec3> pickupList = cleanData.pickupContainer.GetLine(entry.Key);
					foreach(PickupElementTrans pickupElement in entry.Value)
					{
						// Only add active ones!
						if(pickupElement.active)
						{
							PickupElementVec3 tempElement = new PickupElementVec3();
							tempElement.active = pickupElement.active;
							tempElement.position = pickupElement.position.position;
							tempElement.rotation = pickupElement.position.rotation;
							pickupList.Add(tempElement);
						}
					}
				}

				// Copy is clean, create the prefab:
				// TODO: Hardcoded Path -> Make it configureable (instead of "Assets/Resources/Prefabs/SavedTracks/")
				GameObject prefab = PrefabUtility.CreatePrefab("Assets/Resources/Prefabs/CleanTracks/"+copyObj.name+".prefab", copyObj);
				// TODO: Warn, if the asset already exists it will be overwritten!

				// Finally remove the copy:
				DestroyImmediate(copyObj);
				
				Debug.Log("Track has been saved as Assets/Resources/Prefabs/CleanTracks/"+_data.trackName+".prefab", prefab);
			}
			GUILayout.EndHorizontal();
			
			EditorGUI.indentLevel--;
		}
		
		// Foldout for loading:
		_data.showLoadOptions = EditorGUILayout.Foldout(_data.showLoadOptions, "Load Track");
		if(_data.showLoadOptions)
		{
			EditorGUI.indentLevel++;
			
			if(_data.saveTracks.trackList.Count == 0)
			{
				EditorGUILayout.LabelField("No Tracks available...");
			}
			else
			{
				// Present all trackNames:
				_data.loadTrackIndex = EditorGUILayout.Popup(_data.loadTrackIndex, _savedTrackNames.ToArray());
				
				GUILayout.BeginHorizontal();
				GUILayout.Space(13); // IndentLevel
				if(GUILayout.Button("Load Track"))
				{
					// Instantiate chosen Debug-Track Asset:
					MasterTrackScript loadedTrack = Instantiate(_data.saveTracks.trackList[_data.loadTrackIndex], Vector3.zero, Quaternion.identity) as MasterTrackScript;
					
					if(loadedTrack != null)
					{
						loadedTrack.name = "MasterTrackObject";
						Debug.Log("Loaded Track "+_savedTrackNames[_data.loadTrackIndex]+" successfully.", loadedTrack);
					
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
		_data.showDeleteOptions = EditorGUILayout.Foldout(_data.showDeleteOptions, "Delete Existing Track");
		if(_data.showDeleteOptions)
		{
			EditorGUI.indentLevel++;
			
			if(_data.saveTracks.trackList.Count == 0)
			{
				EditorGUILayout.LabelField("No Tracks available...");
			}
			else
			{
				// Present all trackNames:
				_data.deleteTrackIndex = EditorGUILayout.Popup(_data.deleteTrackIndex, _savedTrackNames.ToArray());
				
				GUILayout.BeginHorizontal();
				GUILayout.Space(13); // IndentLevel
				if(GUILayout.Button("Delete Track"))
				{
					AssetDatabase.StartAssetEditing();
					
					// Delete the asset (prefab):
					DestroyImmediate(_data.saveTracks.trackList[_data.deleteTrackIndex], true);
					DestroyImmediate(_data.saveTracks.trackList[_data.deleteTrackIndex].gameObject, true);
					_data.saveTracks.trackList.RemoveAt(_data.deleteTrackIndex);
					
					AssetDatabase.StopAssetEditing();
					EditorUtility.SetDirty(_data.saveTracks);
					AssetDatabase.SaveAssets();
					
					AssetDatabase.Refresh();
					
					// Remove from name-list:
					Debug.Log("Deleted Track "+_savedTrackNames[_data.deleteTrackIndex]+" successfully.");
					_savedTrackNames.RemoveAt(_data.deleteTrackIndex);
					_data.deleteTrackIndex = -1;
				}
				GUILayout.EndHorizontal();
			}
			
			EditorGUI.indentLevel--;
		}
		
		EditorGUILayout.Space();
		
		if(GUILayout.Button("Leave Save-Mode"))
		{
			//Undo.RegisterSceneUndo("Enter Normal Mode");
			
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
			Transform arrowTrans = Instantiate(trackReference.arrowAsset, trackPart.ReferenceObjectStart.transform.position + Vector3.up * 0.2f, Quaternion.identity) as Transform;
			arrowTrans.localScale = new Vector3(0.2f, 0.2f, 0.2f);
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

	private void ManageSplines(bool showSplines)
	{
		if(showSplines == true)
		{
			if(_data.splineObject == null)
			{
				_data.splineObject = new GameObject("SplineObject");
				ShowSplineEditor showSpline = _data.splineObject.AddComponent<ShowSplineEditor>();

				// Add Points of all TrackParts to the drawer:
				SplineContainerTrans fullSpline = new SplineContainerTrans();
				foreach(TrackPartScript trackPart in _data.currentTrackParts)
				{
					fullSpline.AddSplineContainer(trackPart.GetSplineContainer());
				}
				showSpline.SetSplineContainer(fullSpline);
			}
		}
		else
		{
			if(_data.splineObject != null)
			{
				DestroyImmediate(_data.splineObject);
				_data.splineObject = null;
			}
		}
	}
}
