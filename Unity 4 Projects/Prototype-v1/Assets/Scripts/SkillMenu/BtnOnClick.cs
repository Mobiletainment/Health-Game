using UnityEngine;
using System.Collections;

public class BtnOnClick : MonoBehaviour {

    public bool increase = true;
    public string skillName;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        //Debug.Log("OnClick " + skillName);

        if (skillName.Equals("Save"))
            GameObject.Find("ScriptHolder").GetComponent<skillSystem>().SaveSkills();
        else
        {

            if (increase)
                GameObject.Find("ScriptHolder").GetComponent<skillSystem>().Increase(skillName);
            else
                GameObject.Find("ScriptHolder").GetComponent<skillSystem>().Decrease(skillName);
        }
    }
}
