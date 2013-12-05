using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelInfo : MonoBehaviour
{
	private static int[] LevelDurationConfig = new int[] { 58, 58, 58, 60, 75, 90, 90, 90, 90 }; //Level 1 = 15s, Level2 = 30s, etc.
	private static int[] RuleChangeConfig = new int[] { 1, 1, 1, 6, 3, 6, 6, 3, 3 }; //Level 1 = 1 Rule, Level 2 = 2 Rules, etc.
	private static int[] PositiveItemCountConfig = new int[] { 20, 20, 20, 28, 40 }; //Level 1 = 8 good Items in total, etc.
	private static int[] TotalItemCountConfig = new int[] { 70, 90, 110, 120, 140, 150, 170 };
	private static int[] TotalPositiveItemCountConfig = new int[] { 35, 45, 55, 60, 70, 90, 120 };
	
	public static Rule Rule1 = new Rule(0, 0, 0, 1, 1);
	public static Rule Rule2 = new Rule(1, 0, 2, 1, 3);
	public static Rule Rule3 = new Rule(2, 1, 3, 0, 2);
	public static Rule Rule4 = new Rule(3, 0, 3, 1, 2);
	
	protected static List<List<Rule>> RuleSets = new List<List<Rule>>()
	{
		new List<Rule>() { Rule1 }, 				//Level 1: only first Rule
		new List<Rule>() { Rule1, Rule2 },			//Level 2: two rules, first and second
		new List<Rule>() { Rule1, Rule2, Rule1 },	//Level 3
		new List<Rule>() { Rule2, Rule3, Rule3 },	//Level 4
		new List<Rule>() { Rule3, Rule3, Rule1, Rule2, Rule2, Rule3 },  //Level 5
		new List<Rule>() { Rule4, Rule2, Rule1 },						//Level 6
		new List<Rule>() { Rule4, Rule4, Rule1, Rule1, Rule3, Rule2 },  //Level 7
		new List<Rule>() { Rule4, Rule4, Rule1, Rule3, Rule2, Rule2 }
	};
	
	public static List<Color> SignalColors = new List<Color>()
	{ 
		new Color(160.0f/255, 82.0f/255, 45.0f/255, 255.0f/255),
		new Color(147.0f/255, 190.0f/255, 200.0f/255, 255.0f/255),
		new Color(0.0f, 0.4f, 0.0f, 1.0f),
		Color.gray
	};
	
	public int Level;
	public int LevelDuration { get { return LevelDurationConfig[Level]; } }
	public int RuleChanges { get { return RuleChangeConfig[Level]; } }
	public int NecessaryPositiveItems { get { return PositiveItemCountConfig[Level]; } }
	public int TotalItemCount { get { return TotalItemCountConfig[Level]; } }
	public int TotalPositiveItemCount { get { return TotalPositiveItemCountConfig[Level]; } }
	public List<Rule> CurrentRuleSet { get { return new List<Rule>(RuleSets[Level]); } } // Return as copy
	
	public float RuleDuration
	{
		get { return LevelDuration / RuleChanges; }
	}

	
}
