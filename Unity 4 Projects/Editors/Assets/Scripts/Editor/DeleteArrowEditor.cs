using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
//test

[CustomEditor(typeof(DeleteArrowScript))]
public class DeleteArrowEditor : Editor
{
	public DeleteArrowScript _target;
	
	private Tool _tool = Tool.None;
	
	public void OnEnable()
	{
		// Blend out all tools:
		_tool = Tools.current;
		Tools.current = Tool.None;
		
		// Set target:
		_target = target as DeleteArrowScript;
		
		// Do not show this editor and directly delete the selected trackPart if the checkBox is active:
		if(_target.trackReference.deleteWithoutConfirmation == true)
		{
			DeleteTrackPart();
		}
	}
	
	public void OnDisable()
	{
		Tools.current = _tool;
	}
	
	public override void OnInspectorGUI()
	{
		// TODO: Use Enter to delete the part even faster...
		if(GUILayout.Button("Delete this TrackPart"))
		{
			DeleteTrackPart();
		}
	}
	
	private void DeleteTrackPart()
	{
		//Undo.RegisterSceneUndo("Delete Track Part");
		
		// Put the next TrackPart in the position and rotation from the deleted one (recursively):
		int delPartInd = _target.trackReference.currentTrackParts.IndexOf(_target.trackPart);
		Vector3 nextPos;
		Quaternion nextRot;
		
		for(int nextElementInd = delPartInd + 1; nextElementInd < _target.trackReference.currentTrackParts.Count; ++nextElementInd)
		{
			// REFACTOR: This IF-ELSE Construct can be removed if I delete the element first and then rearange 
			// the other ones...
			
			// Special Case: First Object of the Track shall be deleted.
			if(delPartInd == 0 && nextElementInd == 1)
			{
				nextPos = Vector3.zero;
				nextRot = Quaternion.identity;
			}
			// <First> OR <Second to last> run of the loop for deleting an element.
			else
			{
				int backSteps = 1;
				
				// Case: First run of the loop for deleting an element.
				if(delPartInd + 1 == nextElementInd)
				{
					// That's the way it works ;)
					backSteps = 2;
				}
				
				TrackPartScript beforeElement = _target.trackReference.currentTrackParts[nextElementInd - backSteps];
				nextPos = beforeElement.ReferenceObjectEnd.transform.position;
				nextRot = beforeElement.ReferenceObjectEnd.transform.rotation;
			}
			
			TrackPartScript nextElement = _target.trackReference.currentTrackParts[nextElementInd];
			nextElement.transform.position = nextPos;
			nextElement.transform.rotation = nextRot;
		}
		
		// Refresh the Arrow Positions:
		DeleteArrowScript[] arrows = _target.trackReference.changeArrowContainer.GetComponentsInChildren<DeleteArrowScript>();
		foreach(DeleteArrowScript deleteArrow in arrows)
		{
			//Debug.Log("Del Arrow Track Part Name: " + deleteArrow.trackPart.Name, deleteArrow);
			Vector3 pos = TrackEditor.CalcCenterPos(deleteArrow.trackPart.transform);
			deleteArrow.transform.position = pos + Vector3.up;
		}
		
		// Destroy the TrackPart:
		DestroyImmediate(_target.trackPart.gameObject);
		_target.trackReference.currentTrackParts.Remove(_target.trackPart);
		
		// Select the Track (Switch to the TrackEditor)
		GameObject[] selectionObjects = new GameObject[1];
		selectionObjects[0] = _target.trackReference.gameObject;
		Selection.objects = selectionObjects;
		
		// Destroy the Deletion-Arrow:
		DestroyImmediate(_target.gameObject);

		// Lets generate new spline lines:
		DestroyImmediate(_target.trackReference.splineObject);
		_target.trackReference.splineObject = null;
	}
}
