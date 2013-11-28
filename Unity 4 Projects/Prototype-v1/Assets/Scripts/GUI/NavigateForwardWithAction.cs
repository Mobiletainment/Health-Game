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
	bool _done=false;
	private BackendManager backendManager;

	// Use this for initialization
	void Start ()
	{
		backendManager = FindObjectOfType(typeof(BackendManager)) as BackendManager; //get reference to Server-Communication GameObject
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
				_done = true;
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
	// Update is called once per frame
	void Update () {
		//oder hier..
		if (_done){
			ClickForward();
		}
	}
}
