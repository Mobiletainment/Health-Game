using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Rule
{
	public int Index;
	public List<int> GoodItems;
	public List<int> BadItems;
	
	public Rule(int ruleIndex, int goodItemIndex1, int goodItemIndex2, int badItemIndex1, int badItemIndex2)
	{
		Index = ruleIndex;
		GoodItems = new List<int>() { goodItemIndex1, goodItemIndex2 };
		BadItems  = new List<int>() { badItemIndex1, badItemIndex2 };
	}
}
