using UnityEngine;
using UnityEditor;
using System;

// Creates AssetInstances and other Assets for the TrackEditor.
public class TrackEditorMenu
{
    [MenuItem("TrackEditor/Create Asset/TrackPartMgr Asset")]
    public static void CreateTrackPartManagerAsset()
    {
        CustomAssetUtility.CreateAsset<TrackPartMgr>();
    }
	
    [MenuItem("TrackEditor/Create Asset/SaveTracks Asset")]
	public static void CreateSaveTracksAsset()
	{
		CustomAssetUtility.CreateAsset<SaveTracks>();
	}
	
    [MenuItem("TrackEditor/Create TrackEditor Asset")]
	public static void CreateTrackEditorObject()
	{
		// TODO: It would be nice to open a window here to directly configure a (given or new) TrackPartManager
		// and a (given or new) SaveTracks Asset and the Arrow-Asset.
		// Including Help-Directions...
		
		GameObject trackEditor = new GameObject("TrackEditorObject");
		trackEditor.AddComponent<MasterTrackScript>();
	}
}