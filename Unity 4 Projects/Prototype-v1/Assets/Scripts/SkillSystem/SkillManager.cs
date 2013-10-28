using UnityEngine;
using System.Collections;
using System;
using System.IO;


public class SkillManager : MonoBehaviour {
	
	public int UnspentPoints;
	
	public string SkillName1;
	public string SkillName2;
	public string SkillName3;
	public string SkillName4;
	public string SkillName5;
	 
	private Skill[] _skills = new Skill[5];
	
	// Use this for initialization
	void Start () {
		//Skill-Test
		
		if(PlayerPrefs.HasKey("unspentPoints"))
		{
			UnspentPoints = PlayerPrefs.GetInt("unspentPoints");
		}
		else
		{
			UnspentPoints = 0;
		}
		
		if(PlayerPrefs.HasKey(SkillName1))
		{
			
		}
	
		Skill life = new Skill("skillLife");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	private Skill CastSkillFromString(string s)
	{
		Skill skill = null;
		
		string[] delimiterstring = { "#" };
		string[] attributes = s.Split(delimiterstring, StringSplitOptions.None);

		skill = new Skill(attributes[0], Int32.Parse(attributes[1]), Int32.Parse(attributes[2]), Int32.Parse(attributes[3]), Int32.Parse(attributes[4]));
		return skill;
	}
}
