using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(CleanTrackData))]
public class CleanTrackDataEditor : Editor 
{
	public CleanTrackData _target;

	public void OnEnable()
	{
		// Set target:
		_target = target as CleanTrackData;

		if(_target == null)
		{
			Debug.LogError("Error: Target is null.");
		}
	}

	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

		if(_target.firstRule == null)
		{
			GUILayout.Space(20);
			EditorGUILayout.LabelField("The track-rules are not yet initialized.");

			// Initialize Rule Objects:
			if(GUILayout.Button("Initialize Rules & Finish Line"))
			{
				// Create Rule Borders Parent Object:
				GameObject ruleContainer = new GameObject("RuleBorders");
				ruleContainer.transform.parent = _target.transform.parent;

				int ruleCounter = 1;
				TrackRule lastRule = null;

				foreach(CleanTrackPartData trackPart in _target.cleanTrackParts)
				{
					if(trackPart.isRule)
					{
						// Init Rule Borders: (TODO: HardCoded path...)
						GameObject curRuleObj = Instantiate(Resources.Load("Prefabs/RuleSwitchBorder", typeof(GameObject)), 
						                                 trackPart.extraPosition, 
						                                 trackPart.extraRotation) as GameObject;
						curRuleObj.transform.parent = ruleContainer.transform;
						curRuleObj.name = "RuleSwitchBorder_" + ruleCounter;
						++ruleCounter;

						// QUICK FIX: The connection points on the track seem to be rotated 180 degrees, so the editor is exporting the "wrong"
						// rotation for the rules => Rotate here for 180°, not really the best solution :/
						curRuleObj.transform.Rotate(new Vector3(0f, 1f, 0f), 180.0f);

						TrackRule curRule = curRuleObj.GetComponentInChildren<TrackRule>();

						if(lastRule == null)
						{
							// First rule found in this loop -> Set the firstRule for the Track:
							_target.firstRule = curRule;
							// Default settings:
							curRule._enableOnAwake = true;
						}
						else
						{
							// Second+ Rule found -> Set the rule reference from the last to the next (current) rule:
							lastRule._nextRule = curRule;

							// Default settings:
							curRule._enableOnAwake = false;
						}

						// Update lastRule:
						lastRule = curRule;
					}
					// Init finish line:
					if(trackPart.isFinishLine)
					{
						Debug.Log("FINISH LINE");
						// (TODO: HardCoded path...)
						GameObject finishLineObj = Instantiate(Resources.Load("Prefabs/FinishLineColliderBox", typeof(GameObject)), 
						                                    trackPart.extraPosition, 
						                                    trackPart.extraRotation) as GameObject;
						finishLineObj.transform.parent = _target.transform.parent;
						finishLineObj.name = "FinishLineColliderBox";

						// QUICK FIX: The connection points on the track seem to be rotated 180 degrees, so the editor is exporting the "wrong"
						// rotation for the finish line => Rotate here for 180°, not really the best solution :/
						finishLineObj.transform.Rotate(new Vector3(0f, 1f, 0f), 180.0f);

						// Move the box the half of its own size forward, so that it is exactly on the finish line:
						finishLineObj.transform.position += finishLineObj.transform.forward * 0.05f;
					}
				}
			}
		}
	}

//	public void ShowRuleEditorFor(CleanTrackPartData trackPart, int ruleNum)
//	{
//		EditorGUILayout.LabelField("Rule " + ruleNum + ":");
//		
//	}
}
