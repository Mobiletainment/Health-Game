using UnityEngine;
using UnityEditor;
using System;

// Creates AssetInstances and other Assets via Menu:
public class CustomMenu
{
	[MenuItem("CustomMenu/Create Asset/RoadIndicator Asset")]
	public static void CreateRoadIndicatorAsset()
	{
		CustomAssetUtility.CreateAsset<RoadIndicatorTextures>();
	}

	[MenuItem("CustomMenu/Create Asset/RuleConfig Asset")]
	public static void CreateRuleConfigAsset()
	{
		CustomAssetUtility.CreateAsset<RuleConfig>();
	}
}