using UnityEngine;
using System.Collections;

public class NavigateForwardWithAction : NavigateForward {

	public enum ActionType
	{
		NotSpecified,
		NoAction,
		RegisterChild,
		RegisterParent
	}

	public ActionType PerformAction = ActionType.NotSpecified;
	public UIInput input;
	public UILabel errorMessage;
	

	// Use this for initialization
	void Start()
	{
		BackendManager.Instance.callback = ActionPerformed;
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
		errorMessage.text = response;

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
		//TODO: Show Popup with error message
		errorMessage.text = response;
	}

	void ActionCompleted ()
	{
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
}

