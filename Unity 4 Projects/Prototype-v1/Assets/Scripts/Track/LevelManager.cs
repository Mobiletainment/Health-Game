using UnityEngine;
using System.Collections;

[System.Serializable]
public class LevelManager : ScriptableObject
{
	[SerializeField]
	public static int CurrentLevel { get; set; }

	[SerializeField]
	private int _packNum; // Number of this level pack.
	[SerializeField]
	private LevelInfo[] _levels; // All Levels in this pack.

//	[SerializeField]
//	public float[] _userScore; // This array must be sized in the editor as big as the "LevelInfo[] _leves" Array.

	public LevelInfo[] Levels
	{
		get { return _levels; }
		private set { _levels = value; }
	}

	public int LevelPackNumber
	{
		get { return _packNum; }
		private set { _packNum = value; }
	}

	public LevelInfo GetCurrentLevel()
	{
		return Levels[CurrentLevel];
	}

	public void UpdateUserScore(int level, float score)
	{
		float currentScore = GetUserScore(level);

		// Only update score, if it is better then the last try...
		if(score > currentScore)
		{
			PlayerPrefs.SetFloat(GetKeyString(level), score);
		}
	}

	public float GetUserScore(int level)
	{
		if(PlayerPrefs.HasKey(GetKeyString(level)))
		{
			return PlayerPrefs.GetFloat(GetKeyString(level));
		}

		return 0;
	}

	public void ClearAllUserScores()
	{
		for(int i = 0; i < _levels.Length; ++i)
		{
			string key = GetKeyString(i);
			if(PlayerPrefs.HasKey(key))
			{
				PlayerPrefs.DeleteKey(key);
			}
		}
		
		SaveUserScore();
	}

	public void SaveUserScore()
	{
		PlayerPrefs.Save();
	}

	private string GetKeyString(int levelNum)
	{
		return "LevelScore_" + _packNum + "_" + levelNum;
	}
}
