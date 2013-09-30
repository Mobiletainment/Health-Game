using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

// TODO: Implement an insertion preview if "Instant insertion" is not activated.

[CustomEditor(typeof(InsertArrowScript))]
public class InsertArrowEditor : Editor
{
	public InsertArrowScript _target;
	
	private List<string> _partNames = null;
	
	private Tool _tool = Tool.None;
	
	public void OnEnable()
	{
		// Blend out all tools:
		_tool = Tools.current;
		Tools.current = Tool.None;
		
		// Set target:
		_target = target as InsertArrowScript;
		
		// Initialize the trackPart Names:
		_partNames = new List<string>();
		
		foreach(TrackPartScript trackPart in _target.trackReference.trackPartManager._parts)
		{
			_partNames.Add(trackPart.Name);
		}
		if(_partNames.Count == 0)
		{
			Debug.LogError("No TrackParts are connected to the TrackPartManager.");
		}
		else if(_target.trackReference.partSelectionInd >= _partNames.Count)
		{
			_target.trackReference.partSelectionInd = 0;
		}
		
		// Instant insertion: (Note: This editor is not shown...)
		if(_target.trackReference.instantInsertion == true)
		{
			InsertTrackPart();
			BackToTrackEditor();
		}
	}
	
	public void OnDisable()
	{
		Tools.current = _tool;
	}
	
	public override void OnInspectorGUI()
	{
		_target.trackReference.partSelectionInd = EditorGUILayout.Popup("Insert TrackPart: ", _target.trackReference.partSelectionInd, _partNames.ToArray());
		
		if(GUILayout.Button("Insert TrackPart here!"))
		{
			InsertTrackPart();
		}
		
		if(GUILayout.Button("Back to TrackEditor."))
		{
			BackToTrackEditor();
		}
	}
	
	// Put the next TrackPart in the position and rotation of the old one (recursively):
	private void InsertTrackPart()
	{
		Undo.RegisterSceneUndo("Insert Track Part");
		
		int insPartInd = _target.trackReference.currentTrackParts.IndexOf(_target.trackPart);
		
		// Instatiate the new TrackPart:
		TrackPartScript trackPart = Instantiate(_target.trackReference.trackPartManager._parts[_target.trackReference.partSelectionInd]) as TrackPartScript;
		trackPart.transform.parent = _target.trackReference.transform;
		trackPart.gameObject.name = "TrackPart_" + _target.trackReference.nameCounter.ToString() + "_" + trackPart.Name;
		_target.trackReference.nameCounter++;
		
		// Put the TrackPart at the insert-position:
		Vector3 posChange = _target.trackPart.ReferenceObjectStart.transform.position - trackPart.ReferenceObjectStart.transform.position;
		trackPart.transform.position += posChange;
		trackPart.transform.rotation = _target.trackPart.ReferenceObjectStart.transform.rotation;
		
		// Rearange the other trackParts behind the new one:
		TrackPartScript tempPart = trackPart;
		for(int idx = insPartInd; idx < _target.trackReference.currentTrackParts.Count; ++idx)
		{
			posChange = tempPart.ReferenceObjectEnd.transform.position - _target.trackReference.currentTrackParts[idx].ReferenceObjectStart.transform.position;
			_target.trackReference.currentTrackParts[idx].transform.position += posChange;
			_target.trackReference.currentTrackParts[idx].transform.rotation = tempPart.ReferenceObjectEnd.transform.rotation;
			tempPart = _target.trackReference.currentTrackParts[idx];
		}
		
		// Refresh the Arrow Positions:
		InsertArrowScript[] arrows = _target.trackReference.changeArrowContainer.GetComponentsInChildren<InsertArrowScript>();
		foreach(InsertArrowScript insertArrow in arrows)
		{
			insertArrow.transform.position = insertArrow.trackPart.ReferenceObjectStart.transform.position + Vector3.up;
		}
		
		// Add insertion Arrow over the new trackPart:
		TrackEditor.CreateInsertionArrow(trackPart, _target.trackReference);
		
		// Insert the new trackPart in currentTrackParts at correct position:
		_target.trackReference.currentTrackParts.Insert(insPartInd, trackPart);
	}
	
	private void BackToTrackEditor()
	{
		// Select the Track (Switch to the TrackEditor)
		GameObject[] selectionObjects = new GameObject[1];
		selectionObjects[0] = _target.trackReference.gameObject;
		Selection.objects = selectionObjects;
	}
}
