using UnityEngine;
using System.Collections;

public class NavigateForwardWithAction : NavigateForward
{

	public ActionType PerformAction = ActionType.NotSpecified;
	public UIInput input;
	public UILabel errorMessage;
	public UILabel output;


	// Use this for initialization
	void Start ()
	{
		Backend.Callback = ActionPerformed;
		ResetButton ();
	}

	void OnClick ()
	{
		Debug.Log ("Push Type: " + PerformAction.ToString ());

		DisableButton ();
		
		switch (PerformAction) {
			case ActionType.NotSpecified:
				Debug.LogError ("PushType not specified!");
				break;
			case ActionType.NoAction:
				ActionCompleted ();
				break;
			case ActionType.RegisterChild:
				Backend.RegisterUser (getInput (), true);
				break;
			case ActionType.RegisterParent:

			#if UNITY_EDITOR || WINDOWS
			//ActionPerformed("Success: For Test purpose only! TODO");
			Backend.RegisterUser(getInput(), false);
			#else
				Backend.RegisterUser (getInput (), false);
			#endif
				break;
			case ActionType.CheckIfParentAndChildRegistered:
				Backend.CheckIfParentAndChildAreRegistered ();
			//TODO: this is for test purposes only and is just a convenience hack if you don't have 2 devices to perform the whole process
#if UNITY_EDITOR || WIDNDOWS
			ActionPerformed("Success: For Test purpose only! TODO");
#endif
				break;
			case ActionType.SendInGameBonus:
				string rewardMessage = "Du hast " + GetContextInfo () + " von deinen Eltern bekommen, weil du " + input.value;
				Debug.Log(rewardMessage);
				Backend.SendPushMessage (rewardMessage);
				ActionCompleted();
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

	public void ActionPerformed (string response)
	{
		Debug.Log ("Action performed: " + response);
	
		if (response.StartsWith ("Error:")) { //TODO: refactor response as a class with errorcode and body
			ActionFailed (response);
		} else {
			ActionCompleted ();
		}

	}

	void ActionFailed (string response)
	{
		Debug.LogError (response);
			
		ResetButton ();
		//TODO: Show Popup with error message 
		MenuStack.ShowError (response);

		errorMessage.text = response;
	}

	void ActionCompleted ()
	{
		switch (PerformAction) {
			case ActionType.RegisterChild:
				output.text = string.Format ("Hallo, {0}!\nDein Benutzername {0} ist zugleich dein Team-Name.", getInput ());
				break;
			case ActionType.RegisterParent:
				//send push notification to child
				Backend.SendPushMessage ("Deine Eltern haben das Team-Passwort eingegeben. Das Spiel kann beginnen!");
				break;
			default:
				break;
		}

		ClickForward ();
	}





	string getInput ()
	{
		if (input == null) {
			Debug.LogError ("Trying to access UIInput, but not assigned!");
		}

		return NGUIText.StripSymbols (input.value);
	}

	void Update ()
	{
		UpdatePoints ();
		//Debug.Log(Backend.GetUsername());
	}
}

