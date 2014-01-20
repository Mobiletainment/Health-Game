using UnityEngine;
using System.Collections;

public class BtnOnClick : MonoBehaviour {

    public bool increase = true;
    public string skillName;

	private skillSystem _skillSystem;

	public void Start() 
	{
		_skillSystem = GameObject.Find("ScriptHolder").GetComponent<skillSystem>() as skillSystem;

		if(_skillSystem == null)
		{
			Debug.LogError("No ScriptHolder Object with attended skillSystem script was found in the scene!");
		}
	}

    public void OnClick()
    {
        Debug.Log("OnClick " + skillName);

        if (skillName.Equals("Save"))
		{
			_skillSystem.SaveSkills();
			Application.LoadLevel("GameOver");
		}
		else if(skillName.Equals("Cancel"))
		{
			Application.LoadLevel("GameOver");
		}
		else if(skillName.Equals("Reset"))
		{
			_skillSystem.Reset();
		}
		else if(skillName.Equals("Cheat"))
		{
			_skillSystem.AddCheatPoints();
		}
        else
        {
            if (increase)
			{
				_skillSystem.Increase(skillName);
			}
            else
			{
				_skillSystem.Decrease(skillName);
			}
        }
    }
}
