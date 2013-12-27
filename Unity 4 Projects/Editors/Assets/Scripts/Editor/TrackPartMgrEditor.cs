using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(TrackPartMgr))]
public class TrackPartMgrEditor : Editor
{
	TrackPartMgr _target = null;

	public void OnEnable()
	{
		// Initialize the target (data):
		_target = target as TrackPartMgr;
		
		if(_target == null)
		{
			Debug.LogError("No target data is initialized...");
		}
	}
	
	public override void OnInspectorGUI()
	{
		// Show the array (TrackPart Container):
		DrawDefaultInspector();

		EditorGUILayout.Space();

		// TODO: Think about an option box: Automatically update indices.
		// If the check box is false, show the button.
		// Else do the things, that are done in the button in an OnDisable (or whatever the callback is called) Method...

		if(GUILayout.Button("Update TrackPart indices"))
		{
			// Iterate through all trackParts and tell them their index:
			for(int i = 0; i < _target._parts.Length; ++i)
			{
				_target._parts[i].TrackPartMgrIndex = i;
				EditorUtility.SetDirty(_target._parts[i]);
			}

			Debug.Log ("Done: Updated TrackPart indices.");
		}
	}
}
