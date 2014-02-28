 using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class NavigateForwardWithCheckboxAction : NavigateForward
{

	public string screenName;
	public UILabel infoLabel;
	public UILabel customFeedback;
    public UISlider slider;
	// Use this for initialization
	void Start()
	{
		Backend.Callback = ActionPerformed;
		ResetButton ();
    
	}

	
	void OnClick()
	{
        ActionPerformed("Success: Fine");
        return;

		DisableButton ();
		if (infoLabel != null)
            infoLabel.text = "Bitte warten ...";

		UIToggle[] toggles=transform.parent.GetComponentsInChildren<UIToggle> ();

		Debug.Log(toggles);

		IList<bool> checkboxFeedback = new List<bool>();
		                     

		for (int i = 0; i < toggles.Count(); ++i)
			checkboxFeedback.Add(false);

		//toggles = toggles.OrderBy(l => l.transform.name).ToArray(); //causes memory leak on iphone ^^ manual workaround instead

		                       
		foreach (var toggle in toggles)
		{
			int index = Convert.ToInt32(toggle.transform.name.Remove(0, 3));
			Debug.Log("Index: " + index);
			checkboxFeedback[index] = toggle.value;
			Debug.Log("Index: " + index + ", Name: " + toggle.transform.name);
			//UILabel lab = toggles [i].GetComponentInChildren<UILabel>();
			//Debug.Log (toggle.value + "  "+lab.text);
		}


		//string customFeedback = toggles[toggles.Length-1].GetComponentInChildren<UILabel>().text; //TODO: error handling -> too insecure because too generic, assigning custom feedback as public gameobject now

		Debug.Log("Checks: " + checkboxFeedback);

        string feedback;

        if (slider != null)
            feedback = slider.value.ToString();
        else if (customFeedback != null)
            feedback = customFeedback.text;
        else
            feedback = "";

        Debug.Log("Custom: " + feedback);

        Backend.SendCheckboxFeedbackToServer(screenName, checkboxFeedback, feedback);
	}

	public void ActionPerformed(string response)
	{
		Debug.Log("Action performed: " + response);

        if (infoLabel != null)
		    infoLabel.text = response;

		if (response.StartsWith("Error:")) //TODO: refactor response as a class with errorcode and body
		{
			infoLabel.text = response;
			MenuStack.ShowError(response);
			ResetButton();
		}
		else
		{
			ClickForward();
		}
		
	}

	// Update is called once per frame
	void Update () {
		UpdatePoints ();
		//Debug.Log(Backend.GetUsername());
	}
}
