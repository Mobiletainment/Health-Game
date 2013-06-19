using UnityEngine;
using System.Collections;
using SkillSystem;

public class skills : MonoBehaviour {

    private SkillManager _sm;
	private UILabel skillsVisLabel;

	// Use this for initialization
	void Start () {
        _sm = new SkillManager();
		//TODO: refactor hardcoded skill names
		
        if(_sm.LoadSkillsFromFile())
        {
            Debug.Log("Geschwindigkeit Value = " + _sm.GetSkillByName("Geschwindigkeit").Value.ToString());
        }
        else
        {
            Debug.Log("Skills could not be loaded!");
        }
		
		skillsVisLabel = GameObject.Find("SkillsLabel").GetComponent<UILabel>();
		
		int beweglichkeit = _sm.GetSkillByName("Beweglichkeit").Value;
		GameObject.Find("Beweglichkeit").transform.localScale = new Vector3(beweglichkeit * 0.5f, 1.0f, 0.5f);
		skillsVisLabel.text = string.Format("[4b853d]Beweglichkeit: {0}[-]\nGeschwindigkeit: {1}", beweglichkeit, _sm.GetSkillByName("Geschwindigkeit").Value);
	}

    public int GetSkillValueByName(string skillname)
    {
        return _sm.GetSkillByName(skillname).Value;
    }
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
