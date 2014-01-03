using UnityEngine;
using System.Collections;

[System.Serializable]
public class LevelContainer : ScriptableObject
{
	[SerializeField]
	private CleanTrackData[] _levels;

	public CleanTrackData[] Levels
	{
		get { return _levels; }
		private set { _levels = value; }
	}
}
