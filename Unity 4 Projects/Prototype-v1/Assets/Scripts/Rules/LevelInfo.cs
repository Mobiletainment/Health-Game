using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelInfo : MonoBehaviour
{
	private static int[] LevelDurationConfig = new int[] { 5, 30, 45, 60 }; //Level 1 = 15s, Level2 = 30s, etc.
	private static int[] RuleChangeConfig = new int[] { 1, 2, 3, 6, 3, 6, 6, 3, 3 }; //Level 1 = 1 Rule, Level 2 = 2 Rules, etc.
	private static int[] PositiveItemCountConfig = new int[] { 8, 12, 18, 28, 40 }; //Level 1 = 8 good Items in total, etc.
	private static int[] TotalItemCountConfig = new int[] { 70, 90, 110, 120, 140 };
	private static int[] TotalPositiveItemCountConfig = new int[] { 35, 45, 55, 60, 70 };
	
	
	public int Level;
	public int LevelDuration { get { return LevelDurationConfig[Level]; } }
	public int RuleChanges { get { return RuleChangeConfig[Level]; } }
	public int NecessaryPositiveItems { get { return PositiveItemCountConfig[Level]; } }
	public int TotalItemCount { get { return TotalItemCountConfig[Level]; } }
	public int TotalPositiveItemCount { get { return TotalPositiveItemCountConfig[Level]; } }
	public float RuleDuration
	{
		get { return LevelDuration / RuleChanges; }
	}

	
}
