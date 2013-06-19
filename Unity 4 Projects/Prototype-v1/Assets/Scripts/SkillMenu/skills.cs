using UnityEngine;
using System.Collections;
using SkillSystem;

public class skills : MonoBehaviour {

    private SkillManager _sm;

	// Use this for initialization
	void Start () {
        _sm = new SkillManager();

        if(_sm.LoadSkillsFromFile())
        {
            Debug.Log("Geschwindigkeit Value = " + _sm.GetSkillByName("Geschwindigkeit").Value.ToString());
        }
        else
        {
            Debug.Log("Skills could not be loaded!");
        }
	
	}

    public int GetSkillValueByName(string skillname)
    {
        return _sm.GetSkillByName(skillname).Value;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
