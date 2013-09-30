using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class SaveTracks : ScriptableObject 
{
	// All tracks, that have been made with the TrackEditor can be saved here:
	[SerializeField]
	public Dictionary<string, List<TrackPartScript>> trackMap;
}
