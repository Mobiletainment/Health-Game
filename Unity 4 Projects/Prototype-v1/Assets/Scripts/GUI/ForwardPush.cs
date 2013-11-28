using UnityEngine;
using System.Collections;

public class ForwardPush : Forward {

	public enum PushType
	{
		None,
		RegisterChild,
		RegisterParent
	}

	public PushType PerformAction = PushType.None;
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
			case PushType.None:
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
