using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(RuleArrowScript))]
public class RuleArrowEditor : Editor
{
	public RuleArrowScript _target;
	
	private Tool _tool = Tool.None;
	
	public void OnEnable()
	{
		// Blend out all tools:
		_tool = Tools.current;
		Tools.current = Tool.None;
		
		// Set target:
		_target = target as RuleArrowScript;
	}
	
	public void OnDisable()
	{
		Tools.current = _tool;
	}
	
	public override void OnInspectorGUI()
	{
		// For Color-Change after (de)activation...
		Material mat = new Material(_target.trackReference.currentTrackParts[0].ReferenceObjectStart.renderer.sharedMaterial);

		if(_target.trackPart.IsRule == false)
		{
			if(GUILayout.Button("Add rule here!"))
			{
				_target.trackPart.IsRule = true;

				mat.color = Color.yellow;
				_target.transform.renderer.sharedMaterial = mat;
			}
		}
		else
		{
			if(GUILayout.Button("Remove rule here!"))
			{
				_target.trackPart.IsRule = false;

				mat.color = Color.blue;
				_target.transform.renderer.sharedMaterial = mat;
			}
		}
		
		if(GUILayout.Button("Back to TrackEditor."))
		{
			BackToTrackEditor();
		}
	}
	
	private void BackToTrackEditor()
	{
		// Select the Track (Switch to the TrackEditor)
		GameObject[] selectionObjects = new GameObject[1];
		selectionObjects[0] = _target.trackReference.gameObject;
		Selection.objects = selectionObjects;
	}
}
