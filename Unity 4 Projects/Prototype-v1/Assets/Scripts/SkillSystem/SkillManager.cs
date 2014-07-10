using UnityEngine;
using System.Collections;
using System;
using System.IO;


public class SkillManager {
	
//	public int UnspentPoints;
	
	private static int _noOfSkills = 5;
	public string SkillName1 = "Agility";
	public string SkillName2 = "Life";
	public string SkillName3 = "BulletTime";
	public string SkillName4 = "Sight";
	public string SkillName5 = "Fatigue";
	 
	private Skill[] _skills = new Skill[_noOfSkills];

	// TODO: Implement correct (scaleable) solution!
	// QuickSolution for "MedalPoints to SkillPoints":
//	public int[] _medalToSkillTable = new int[] {3, 6, 10, 14, 19, 24};
//	public int _curMedalPoints;
	
	public SkillManager()
	{
		
	}
	
	public void Init() // HasKey must be called at Start-Method of an Unity Script
	{
//		if(PlayerPrefs.HasKey("unspentPoints"))
//		{
//			UnspentPoints = PlayerPrefs.GetInt("unspentPoints");
//		}
//		else
//		{
//			UnspentPoints = 0;
//			PlayerPrefs.SetInt("unspentPoints", UnspentPoints);
//		}

//		if(PlayerPrefs.HasKey("medalPoints"))
//		{
//			_curMedalPoints = PlayerPrefs.GetInt("medalPoints");
//		}
//		else
//		{
//			_curMedalPoints = 0;
//			PlayerPrefs.SetInt("medalPoints", _curMedalPoints);
//		}
		
		if(PlayerPrefs.HasKey(SkillName1))
		{
			_skills[0] = CastSkillFromString(PlayerPrefs.GetString(SkillName1));
		}
		else
		{
			_skills[0] = new Skill(SkillName1, 3, 11, 3, 3);
			PlayerPrefs.SetString(SkillName1, CastSkillToString(_skills[0]));
		}
		
		if(PlayerPrefs.HasKey(SkillName2))
		{
			_skills[1] = CastSkillFromString(PlayerPrefs.GetString(SkillName2));
		}
		else
		{
			_skills[1] = new Skill(SkillName2, 1, 10, 3, 3);
			PlayerPrefs.SetString(SkillName2, CastSkillToString(_skills[1]));
		}
		
		if(PlayerPrefs.HasKey(SkillName3))
		{
			_skills[2] = CastSkillFromString(PlayerPrefs.GetString(SkillName3));
		}
		else
		{
			_skills[2] = new Skill(SkillName3, 0, 10, 1, 1);
			PlayerPrefs.SetString(SkillName3, CastSkillToString(_skills[2]));
		}
		
		if(PlayerPrefs.HasKey(SkillName4))
		{
			_skills[3] = CastSkillFromString(PlayerPrefs.GetString(SkillName4));
		}
		else
		{
			_skills[3] = new Skill(SkillName4, 1, 10, 1, 1);
			PlayerPrefs.SetString(SkillName4, CastSkillToString(_skills[3]));
		}
		
		if(PlayerPrefs.HasKey(SkillName5))
		{
			_skills[4] = CastSkillFromString(PlayerPrefs.GetString(SkillName5));
		}
		else
		{
			_skills[4] = new Skill(SkillName5, 0, 10, 0, 0);
			PlayerPrefs.SetString(SkillName5, CastSkillToString(_skills[4]));
		}
	}

	// DEBUG ONLY:
	public void CheatAddMedalPoints(int add = 10)
	{
		int curMedalPoints = 0;
		if(PlayerPrefs.HasKey("medalPoints"))
		{
			curMedalPoints = PlayerPrefs.GetInt("medalPoints");
		}

		curMedalPoints += add;

		PlayerPrefs.SetInt("medalPoints", curMedalPoints);
	}
	
	public Skill GetSkillByName(string name)
	{
		foreach(Skill s in _skills)
		{
			if(s.Name.Equals(name))
				return s;
		}
		
		return null;
	}
	
	public bool IncreaseSkill(string name)
	{

		if(GetUnspentSkillPoints() <= 0)
			return false;
		
		for(int i = 0; i < _noOfSkills; ++i)
		{
			if(_skills[i].Name.Equals(name))
			{
				bool success = _skills[i].Increase();
				
				return success;
			}
		}
		
		return false;
	}
	
	public bool DecreaseSkill(string name)
	{
		for(int i = 0; i < _noOfSkills; ++i)
		{
			if(_skills[i].Name.Equals(name))
			{
				bool success = _skills[i].Decrease();
				
				return success;
			}
		}
		
		return false;
	}
	
	private Skill CastSkillFromString(string s)
	{
//		Debug.Log("Skillmanager called CastSkillFromString for " + s);
		Skill skill = null;
		
		string[] delimiterstring = { "#" };
		string[] attributes = s.Split(delimiterstring, StringSplitOptions.None);

		skill = new Skill(attributes[0], Int32.Parse(attributes[1]), Int32.Parse(attributes[2]), Int32.Parse(attributes[3]), Int32.Parse(attributes[4]));
		return skill;
	}

	private string CastSkillToString(Skill skill)
	{
		string delimiter = "#";

		string result = skill.Name + delimiter + 
						skill.MinValue.ToString() + delimiter + 
						skill.MaxValue.ToString() + delimiter + 
						skill.DefaultValue.ToString() + delimiter + 
						skill.CurrentValue.ToString();

//		Debug.Log ("Skill2String: " + result);

		return result;
	}

	public void SaveSkills()
	{
		// Save all skills:
		for(int i = 0; i < _noOfSkills; ++i)
		{
			PlayerPrefs.SetString(_skills[i].Name, CastSkillToString(_skills[i]));
		}
		// Save the unspentPoints:
//		PlayerPrefs.SetInt("unspentPoints", UnspentPoints);
//		PlayerPrefs.SetInt("medalPoints", _curMedalPoints);
		
		Debug.Log ("Save!");
		PlayerPrefs.Save();
	}

	// DEBUG ONLY:
	public void Reset()
	{
		// Reset all skills:
		for(int i = 0; i < _noOfSkills; ++i)
		{
			PlayerPrefs.DeleteKey(_skills[i].Name);
		}
		// Reset the unspentPoints:
		PlayerPrefs.DeleteKey("unspentPoints");
		// ...and the medal Points:
		PlayerPrefs.DeleteKey("medalPoints");
		
		Init();
		Debug.Log ("Reset!");
	}

	// Add medal points. (For enough collected medal points, a skillpoint will be given):
	public void AddMedalPoints(int medalPoints)
	{
//		// Old Calculation:
//		Debug.Log ("AddMedalPoints: " + medalPoints);
//		for(int i = 0; i < _medalToSkillTable.Length; ++i)
//		{
//			if(_medalToSkillTable[i] > _curMedalPoints)
//			{
//				if(_medalToSkillTable[i] <= (_curMedalPoints + medalPoints))
//				{
//					UnspentPoints++;
//				}
//				else
//				{
//					break;
//				}
//			}
//		}
//
//		_curMedalPoints += medalPoints;
//
//		// Save the unspentPoints and medal points::
//		PlayerPrefs.SetInt("unspentPoints", UnspentPoints);
//		PlayerPrefs.SetInt("medalPoints", _curMedalPoints);
//		PlayerPrefs.Save();
//
//		return UnspentPoints;

		int curMedalPoints = 0;
		if(PlayerPrefs.HasKey("medalPoints"))
		{
			curMedalPoints = PlayerPrefs.GetInt("medalPoints");
		}
		curMedalPoints += medalPoints;
		PlayerPrefs.SetInt("medalPoints", curMedalPoints);
		PlayerPrefs.Save();
	}



	public int GetUnspentSkillPoints()
	{
//		if(PlayerPrefs.HasKey("unspentPoints"))
//		{
//			return PlayerPrefs.GetInt("unspentPoints");
//		}
//
//		return 0;

		return (CalcGivenSkillPoints() - CalcSpentSkillPoints());
	}

	// Returns the amount of all given Skillpoints (the spent and the unspent ones) on base of all collected medal points:
	private int CalcGivenSkillPoints()
	{
		// TODO: This Method has to be updated, if more skills or levels are implemented!

		// HINT: This could be also be implemented by Unity Curves and must not be linear!

		// Calculation has been done linear (this can be changed later on)
		// Basis: 25 Levels a 4 Medal points (One for each Medal, Bronze, Silver, Gold, Perfect) => max. 100 Medal points to earn.
		// Basis: 31 Skillpoints might be put into currently all of the 3 available Skills, 7 Points are given by default
		// => 31 - 7 = 24 Skillpoints are needed to fill all Skills to their max.
		// Doing a linear curve through the 2 Points: A(0|0) and B(100|24)
		// y = kx + d -> 1) 0 = 0x + d => d = 0 2) 24 = 100k + d => k = 24 / 100.
		// y = 24/100*x (where y == SkillPoints and x == earned MedalPoints)


		int curMedalPoints = 0;
		if(PlayerPrefs.HasKey("medalPoints"))
		{
			curMedalPoints = PlayerPrefs.GetInt("medalPoints");
		}

		float givenSkillPointsF = ((24.0f/100.0f) * curMedalPoints);
		int givenSkillPoints = (int)System.Math.Floor(givenSkillPointsF);

		return givenSkillPoints;
	}

	// Returns the amount of all spent skillpoints:
	private int CalcSpentSkillPoints()
	{
		// TODO: This Method has to be updated, if more skills are implemented!
		// Currently there is only Skill-0, Skill-1, and Skill-3 in use:

		int spentSkillPoints = _skills[0].CurrentValue + _skills[1].CurrentValue + _skills[3].CurrentValue;

		return spentSkillPoints;
	}
}
