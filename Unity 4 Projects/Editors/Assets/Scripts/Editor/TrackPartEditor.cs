using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
[CustomEditor(typeof(TrackPartScript))]
public class TrackPartEditor : Editor 
{
	[SerializeField]
	private TrackPartScript _data = null;

	public void OnEnable()
	{
		// Initialize the target (data):
		_data = target as TrackPartScript;

		if(_data == null)
		{
			Debug.LogError("No target data is initialized...");
		}
	}

	public override void OnInspectorGUI()
	{
		if(_data.ReferenceObjectSpline == null || _data.ReferenceObjectPickup == null)
		{
			EditorGUILayout.LabelField("Please configure the Spline- and Pickup-Container\n" +
			                           "to get the Auto-Configuration.", GUILayout.Height(40.0f));
		}
		else
		{
			if(GUILayout.Button("Configure TrackPart"))
			{
				ConfigureTrackPart();
			}
		}

		EditorGUILayout.Space();

		DrawDefaultInspector();
	}

	private void ConfigureTrackPart()
	{
		// TODO: There are no checks, if the DataStruction (of the Track) is correct.
		// Maybe a check, if the names of the groups and elemnts are in alphabetical order.
		// Maybe a check, if there are realy 11 splines and 12 lines.

		// Configure Spline Control Points:
		SplineLine spline = SplineLine.LEFT5;
		// Each group is a splineLine:
		foreach(Transform splineGroup in _data.ReferenceObjectSpline.transform)
		{
			// Get, Clear, and Fill the current line:
			List<Transform> splineLine = _data.GetSplineContainer().GetSpline(spline);
			splineLine.Clear();
			foreach(Transform ctrlPoint in splineGroup)
			{
				splineLine.Add(ctrlPoint);
			}
			// Next line please:
			spline++;
		}

		// Configure PickUp Points:
		PickupLine line = PickupLine.LEFT6;
		// Each group is a pickupLine:
		foreach(Transform pickupGroup in _data.ReferenceObjectPickup.transform)
		{
			// Get, Clear, and Fill the current line:
			List<PickupElementTrans> pickupLine = _data.GetPickupContainer().GetLine(line);
			pickupLine.Clear();
			foreach(Transform pickupPoint in pickupGroup)
			{
				// I only need the position (transform) at this point...
				PickupElementTrans pickupElement = new PickupElementTrans();
				pickupElement.position = pickupPoint;
				pickupLine.Add(pickupElement);
			}
			// Next:
			line++;
		}

		Debug.Log("Configuration was done.");
	}
}
