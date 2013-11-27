using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(PickupActivityScript))]
public class PickupActivityEditor : Editor
{
	private PickupActivityScript _target;
	private Tool _tool = Tool.None;

	public void OnEnable()
	{
		// Blend out all tools:
		_tool = Tools.current;
		Tools.current = Tool.None;
		
		// Set target:
		_target = target as PickupActivityScript;

		// Change activity:
		bool active = _target.pickupElement.active;
		_target.pickupElement.active = !active;

		// Change color:
		// HACK: Use different colors with shared materials without unity-complining-warnings...
		// I just needed a gameObject, that has a renderer, so I took the Ref.Obj.Start, because it was easy to get.
		Material mat = new Material(_target.trackReference.currentTrackParts[0].ReferenceObjectStart.renderer.sharedMaterial);
		if(!active)
		{
			mat.color = Color.green;
		}
		else
		{
			mat.color = Color.red;
		}
		_target.pickupElement.position.renderer.material = mat;

		// Switch back to main editor:
		BackToTrackEditor();
	}

	public void OnDisable()
	{
		Tools.current = _tool;
	}

	private void BackToTrackEditor()
	{
		// Select the Track (Switch to the TrackEditor)
		GameObject[] selectionObjects = new GameObject[1];
		selectionObjects[0] = _target.trackReference.gameObject;
		Selection.objects = selectionObjects;
	}
}
