using UnityEngine;
using System.Collections;

[System.Serializable]
public class LevelManager : ScriptableObject
{
	[SerializeField]
	public static int CurrentLevel { get; set; }

	[SerializeField]
	private LevelInfo[] _levels;

	public LevelInfo[] Levels
	{
		get { return _levels; }
		private set { _levels = value; }
	}

	public LevelInfo GetCurrentLevel()
	{
		return Levels[CurrentLevel];
	}
}
