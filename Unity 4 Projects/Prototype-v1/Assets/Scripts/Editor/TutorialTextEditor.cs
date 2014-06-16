using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(TutorialTextManager))]
public class TutorialTextEditor : Editor
{
	public TutorialTextManager _target;

	public void OnEnable()
	{
		// Set target:
		_target = target as TutorialTextManager;
		
		if(_target == null)
		{
			Debug.LogError("Error: Target is null.");
		}
	}

	public override void OnInspectorGUI()
	{
		int tutSize = EditorGUILayout.IntField("Array Size", _target.TutTexts.Length);

		EditorGUILayout.Space();

		for(int i = 0; i < _target.TutTexts.Length; ++i)
		{
			EditorGUILayout.LabelField("Tut Text " + i);
			int height = _target.AreaHeight[i] = EditorGUILayout.IntField("Area Height", _target.AreaHeight[i]);
			if(height == 0)
			{
				height = 40; // Height Default value.
			}
			_target.TutTexts[i] = EditorGUILayout.TextArea(_target.TutTexts[i], GUILayout.Height(height));

			EditorGUILayout.Space();
		}

		// Array Size has been changed:
		if(tutSize != _target.TutTexts.Length)
		{
			// Allocate Memory:
			string[] buffer = new string[tutSize];
			int[] heightBuffer = new int[tutSize];

			// Initialize values from original:
			for(int i = 0; i < tutSize; ++i)
			{
				if(i < _target.TutTexts.Length)
				{
					buffer[i] = _target.TutTexts[i];
					heightBuffer[i] = _target.AreaHeight[i];
				}
				else
				{
					break;
				}
			}

			// Swap:
			_target.TutTexts = buffer;
			_target.AreaHeight = heightBuffer;
		}

		if(GUI.changed)
		{
			EditorUtility.SetDirty(_target);
		}
	}
}
