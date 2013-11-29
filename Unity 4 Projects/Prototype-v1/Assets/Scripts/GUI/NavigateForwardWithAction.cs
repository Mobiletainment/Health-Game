﻿using UnityEngine;
using System.Collections;

public class NavigateForwardWithAction : NavigateForward {

	public enum ActionType
	{
		NotSpecified,
		NoAction,
		RegisterChild,
		RegisterParent,
		CheckIfParentAndChildRegistered
	}

	public ActionType PerformAction = ActionType.NotSpecified;
	public UIInput input;
	public UILabel errorMessage;
	public UILabel output;
	

	// Use this for initialization
	void Start()
	{
		BackendManager.Instance.Callback = ActionPerformed;
	}

	void OnClick()
	{
		Debug.Log("Push Type: " + PerformAction.ToString());

		switch (PerformAction)
		{
			case ActionType.NotSpecified:
				Debug.LogError("PushType not specified!");
				break;
			case ActionType.NoAction:
				ActionCompleted();
				break;
		case ActionType.RegisterChild:
			BackendManager.Instance.RegisterUser(getInput(), true);
			break;
		case ActionType.RegisterParent:

			#if UNITY_EDITOR
			ActionPerformed("Success: For Test purpose only! TODO");
			#elif
			BackendManager.Instance.RegisterUser(getInput(), false);
			#endif
			break;
		case ActionType.CheckIfParentAndChildRegistered:
			BackendManager.Instance.CheckIfParentAndChildAreRegistered();
			//TODO: this is for test purposes only and is just a convenience hack if you don't have 2 devices to perform the whole process
#if UNITY_EDITOR
			ActionPerformed("Success: For Test purpose only! TODO");
#endif
			break;
		default:
				break;
		}

		//hier push zeug einfügen
		//Eventuell anzeigen des "BitteWarten" Fensters
		//Eventuell hier warten oder im Update dann erst
		//if (_done)
		//	Forward.OnClick();

	}

	public void ActionPerformed(string response)
	{
		Debug.Log("Action performed: " + response);
	
		if (response.StartsWith("Error:")) //TODO: refactor response as a class with errorcode and body
		{
			ActionFailed(response);
		}
		else
		{
			ActionCompleted();
		}

	}

	void ActionFailed(string response)
	{
		Debug.LogError(response);

		//TODO: Show Popup with error message
		errorMessage.text = response;
	}

	void ActionCompleted ()
	{
		switch (PerformAction) {
			case ActionType.RegisterChild:
				output.text = string.Format("Hallo, {0}!\nDein Benutzername {0} ist zugleich dein Team-Name.", getInput());
				break;
			default:
				break;
		}

		ClickForward();
	}

	string getInput()
	{
		if (input == null)
		{
			Debug.LogError("Trying to access UIInput, but not assigned!");
		}

		return NGUIText.StripSymbols(input.value);
	}

	void Update()
	{

	}
}

