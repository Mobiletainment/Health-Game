using UnityEngine;
using UnityEditor;
using System;

// Creates AssetInstances and other Assets via Menu:
public class CustomMenu
{
	[MenuItem("CustomMenu/Create Asset/RoadIndicator Asset")]
	public static void CreateTrackPartManagerAsset()
	{
		CustomAssetUtility.CreateAsset<RoadIndicatorTextures>();
	}
}