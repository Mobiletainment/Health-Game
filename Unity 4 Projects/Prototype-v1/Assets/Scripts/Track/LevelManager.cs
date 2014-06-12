using UnityEngine;
using System.Collections;

[System.Serializable]
public class LevelManager : ScriptableObject
{
	[SerializeField]
	public static int CurrentLevel { get; set; }

	[SerializeField]
	private LevelInfo[] _levels;

	[SerializeField]
	public float[] _userScore; // This array must be sized in the editor as big as the "LevelInfo[] _leves" Array.

	public LevelInfo[] Levels
	{
		get { return _levels; }
		private set { _levels = value; }
	}

	public LevelInfo GetCurrentLevel()
	{
		return Levels[CurrentLevel];
	}

	// TEST!
	public void Save()
	{
		this.GetType().GetField("_userScore").SetValue(this, this._userScore);
	}
}
