using UnityEngine;
using System.Collections;
using SkillSystem;

public class skills : MonoBehaviour {

    //private SkillManager _sm;
	private UILabel skillsVisLabel;

	// Use this for initialization
	void Start () {
        //_sm = new SkillManager();
		//TODO: refactor hardcoded skill names
		
        /*if(_sm.LoadSkillsFromFile())
        {
            Debug.Log("Geschwindigkeit Value = " + _sm.GetSkillByName("Geschwindigkeit").Value.ToString());
        }
        else
        {
            Debug.Log("Skills could not be loaded!");
        }
		
		skillsVisLabel = GameObject.Find("SkillsLabel").GetComponent<UILabel>();
		
		int beweglichkeit = _sm.GetSkillByName("Beweglichkeit").Value;
		int geschwindigkeit = _sm.GetSkillByName("Geschwindigkeit").Value;
		float boost = _sm.GetSkillByName("Boost").Value;
		
		GameObject.Find("Beweglichkeit").transform.localScale = new Vector3(beweglichkeit * 0.75f, 1.0f, 0.5f);
		GameObject.Find("Geschwindigkeit").transform.localScale = new Vector3(0.5f, 1.0f, beweglichkeit * 0.5f);
		GameObject.Find("Boost").transform.localScale = new Vector3(boost * 0.5f, boost * 0.5f, boost * 0.5f);
		
		skillsVisLabel.text = string.Format("[4b853d]Beweglichkeit: {0}[-]\n[d6c991]Geschwindigkeit: {1}[-]\n[FF0000]Boost: {2}[-]", beweglichkeit, geschwindigkeit, boost);
		
		PathItems pathItemScript = GameObject.Find("PathVisualizer").GetComponent<PathItems>();
		pathItemScript._directionMultiplier = 0.3f + 0.2f * beweglichkeit;*/
	}

    public int GetSkillValueByName(string skillname)
    {
		return 0;
        //return _sm.GetSkillByName(skillname).Value;
    }
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
