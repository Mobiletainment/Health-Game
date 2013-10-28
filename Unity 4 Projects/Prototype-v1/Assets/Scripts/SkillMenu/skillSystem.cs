using UnityEngine;
using System.Collections;
//using SkillSystem;

public class skillSystem : MonoBehaviour 
{
	
	private SkillManager _sm;
	
    //private SkillManager _sm;

    public UILabel unusedSkillpoints;
    public UILabel skill1Name;
    public UILabel skill2Name;
    public UILabel skill3Name;
    public UILabel skill4Name;
    public UILabel skill5Name;
    //public UILabel skill6Name;
    public UILabel skill1Value;
    public UILabel skill2Value;
    public UILabel skill3Value;
    public UILabel skill4Value;
    public UILabel skill5Value;
    //public UILabel skill6Value;

	// Use this for initialization
	void Start (){

		_sm = new SkillManager();
		_sm.Init();
		//_sm = GameObject.Find("Scriptholder").GetComponent<SkillManager>();
		
		/*
        _sm = new SkillManager();
		
		if (_sm.LoadSkillsFromFile() == false)
		{
	        _sm.AddSkill(new BasicSkill("Beweglichkeit",       "min", "max", 5, 0, 10, 5));
	        _sm.AddSkill(new BasicSkill("Geschwindigkeit",     "min", "max", 5, 0, 10, 5));
	        _sm.AddSkill(new BasicSkill("Boost",               "min", "max", 5, 0, 10, 5));
	        _sm.AddSkill(new BasicSkill("Ausdauer", "min", "max", 5, 0, 10, 5));
	        _sm.AddSkill(new BasicSkill("Sichtweite",          "min", "max", 5, 0, 10, 5));
	        _sm.AddSkill(new BasicSkill("Fitness",             "min", "max", 5, 0, 10, 5));
	
	        _sm.GetSkillByName("Beweglichkeit").Value = 5;
	        _sm.GetSkillByName("Geschwindigkeit").Value = 3;
	        _sm.GetSkillByName("Boost").Value = 8;
	        _sm.GetSkillByName("Ausdauer").Value = 2;
	        _sm.GetSkillByName("Sichtweite").Value = 6;
	        _sm.GetSkillByName("Fitness").Value = 4;
		}*/
		
        TextUpdate();
	}
	
	// Update is called once per frame
	void Update () {
	}

    void TextUpdate()
    {
        unusedSkillpoints.text = _sm.UnspentPoints.ToString();
		
		//Debug.Log("SM -> " + _sm);
		
		skill1Name.text = _sm.SkillName1;
		skill1Value.text = _sm.GetSkillByName(_sm.SkillName1).CurrentValue.ToString();
		
		skill2Name.text = _sm.SkillName2;
		skill2Value.text = _sm.GetSkillByName(_sm.SkillName2).CurrentValue.ToString();
		
		skill3Name.text = _sm.SkillName3;
		skill3Value.text = _sm.GetSkillByName(_sm.SkillName3).CurrentValue.ToString();
		
		skill4Name.text = _sm.SkillName4;
		skill4Value.text = _sm.GetSkillByName(_sm.SkillName4).CurrentValue.ToString();
		
		skill5Name.text = _sm.SkillName5;
		skill5Value.text = _sm.GetSkillByName(_sm.SkillName5).CurrentValue.ToString();
		
		/*
        skill1Name.text = _sm.GetSkillByName("Beweglichkeit").Name;
        skill1Value.text = _sm.GetSkillByName("Beweglichkeit").Value.ToString();

        skill2Name.text = _sm.GetSkillByName("Geschwindigkeit").Name;
        skill2Value.text = _sm.GetSkillByName("Geschwindigkeit").Value.ToString();

        skill3Name.text = _sm.GetSkillByName("Boost").Name;
        skill3Value.text = _sm.GetSkillByName("Boost").Value.ToString();

        skill4Name.text = _sm.GetSkillByName("Ausdauer").Name;
        skill4Value.text = _sm.GetSkillByName("Ausdauer").Value.ToString();

        skill5Name.text = _sm.GetSkillByName("Sichtweite").Name;
        skill5Value.text = _sm.GetSkillByName("Sichtweite").Value.ToString();

        skill6Name.text = _sm.GetSkillByName("Fitness").Name;
        skill6Value.text = _sm.GetSkillByName("Fitness").Value.ToString();*/
    }

    public void SaveSkills()
    {
        //_sm.SaveSkillsToFile();
    }

    public void Increase(string skillName)
    {
        Debug.Log("Inc - SN: " + skillName);
		
		_sm.IncreaseSkill(skillName);
		TextUpdate();
		
        /*if (_sm.GetSkillByName(skillName).Value < _sm.GetSkillByName(skillName).MaxValue && _unusedSP > 0)
        {
            --_unusedSP;
            ++_sm.GetSkillByName(skillName).Value;
            TextUpdate();
            //skill1Value.text = _sm.GetSkillByName(skillName).Value.ToString();
        }*/
    }

    public void Decrease(string skillName)
    {
        Debug.Log("Dec - SN: " + skillName);
		
		_sm.DecreaseSkill(skillName);
		TextUpdate();
		
		/*
        if (_sm.GetSkillByName(skillName).Value > _sm.GetSkillByName(skillName).MinValue)
        {
            ++_unusedSP;
            --_sm.GetSkillByName(skillName).Value;
            TextUpdate();
            //skill1Value.text = _sm.GetSkillByName(skillName).Value.ToString();
        }*/
    }
}
