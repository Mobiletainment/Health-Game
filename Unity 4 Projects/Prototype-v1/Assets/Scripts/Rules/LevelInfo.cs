using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelInfo : MonoBehaviour
{
	private static int[] LevelDurationConfig = new int[] { 15, 30, 45, 60 }; //Level 1 = 15s, Level2 = 30s, etc.
	private static int[] RuleChangeConfig = new int[] { 1, 2, 3, 6, 3, 6, 6, 3, 3 }; //Level 1 = 1 Rule, Level 2 = 2 Rules, etc.
	
	public int Level;
	public int LevelDuration { get { return LevelDurationConfig[Level]; } }
	public int RuleChanges { get { return RuleChangeConfig[Level]; } }
	public float RuleDuration
	{
		get { return LevelDuration / RuleChanges; }
	}

	
}
