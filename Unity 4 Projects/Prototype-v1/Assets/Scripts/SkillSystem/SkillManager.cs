using UnityEngine;
using System.Collections;
using System;
using System.IO;


public class SkillManager {
	
	public int UnspentPoints;
	
	private static int _noOfSkills = 5;
	public string SkillName1 = "Agility";
	public string SkillName2 = "Life";
	public string SkillName3 = "BulletTime";
	public string SkillName4 = "Sight";
	public string SkillName5 = "Fatigue";
	 
	private Skill[] _skills = new Skill[_noOfSkills];
	
	public SkillManager()
	{
		
	}
	
	public void Init() //HasKey must be called at Start-Method of an Unity Script
	{
		if(PlayerPrefs.HasKey("unspentPoints"))
		{
			UnspentPoints = PlayerPrefs.GetInt("unspentPoints");
		}
		else
		{
			//TODO: usually 0 - for testing increased to 13
			UnspentPoints = 13;
		}
		
		if(PlayerPrefs.HasKey(SkillName1))
		{
			_skills[0] = CastSkillFromString(PlayerPrefs.GetString(SkillName1));
		}
		else
		{
			_skills[0] = new Skill(SkillName1, 3, 10, 3, 3);
		}
		
		if(PlayerPrefs.HasKey(SkillName2))
		{
			_skills[1] = CastSkillFromString(PlayerPrefs.GetString(SkillName2));
		}
		else
		{
			_skills[1] = new Skill(SkillName2, 1, 10, 3, 3);
		}
		
		if(PlayerPrefs.HasKey(SkillName3))
		{
			_skills[2] = CastSkillFromString(PlayerPrefs.GetString(SkillName3));
		}
		else
		{
			_skills[2] = new Skill(SkillName3, 0, 10, 1, 1);
		}
		
		if(PlayerPrefs.HasKey(SkillName4))
		{
			_skills[3] = CastSkillFromString(PlayerPrefs.GetString(SkillName4));
		}
		else
		{
			_skills[3] = new Skill(SkillName4, 1, 10, 1, 1);
		}
		
		if(PlayerPrefs.HasKey(SkillName5))
		{
			_skills[4] = CastSkillFromString(PlayerPrefs.GetString(SkillName5));
		}
		else
		{
			_skills[4] = new Skill(SkillName5, 0, 10, 0, 0);
		}
	}
	/*
	// Use this for initialization
	private void Start () {
		
	}
	
	// Update is called once per frame
	private void Update () {
	
	}*/
	
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
		if(UnspentPoints <= 0)
			return false;
		
		for(int i = 0; i < _noOfSkills; ++i)
		{
			if(_skills[i].Name.Equals(name))
			{
				bool success = _skills[i].Increase();
				
				if(success)
					--UnspentPoints;
				
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
				
				if(success)
					++UnspentPoints;
				
				return success;
			}
		}
		
		return false;
	}
	
	private Skill CastSkillFromString(string s)
	{
		Debug.Log("Skillmanager called CastSkillFromString for " + s);
		Skill skill = null;
		
		string[] delimiterstring = { "#" };
		string[] attributes = s.Split(delimiterstring, StringSplitOptions.None);

		skill = new Skill(attributes[0], Int32.Parse(attributes[1]), Int32.Parse(attributes[2]), Int32.Parse(attributes[3]), Int32.Parse(attributes[4]));
		return skill;
	}
}
