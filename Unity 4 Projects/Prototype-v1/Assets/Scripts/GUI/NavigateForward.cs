using UnityEngine;
using System.Collections;

public class NavigateForward : MonoBehaviour
{
	public GameObject _next;
	private ECPNManager ecpnManager;
	public string customInfoForNextScreen = "";

	public ECPNManager Backend {
		get {
			if (ecpnManager == null)
				ecpnManager = GameObject.Find ("ComponentManager").GetComponent<ECPNManager> ();

			return ecpnManager;
		}
	}


	public enum ActionType
	{
		NotSpecified,
		NoAction,
		RegisterChild,
		RegisterParent,
		CheckIfParentAndChildRegistered,
		SendInGameBonus
	}
	
	// Use this for initialization
	void Start ()
	{
	
	}

	void OnClick ()
	{
		ClickForward ();
	}

	public void ClickForward ()
	{

		MenuStack.ClickForward (_next);

		if (customInfoForNextScreen.Length > 0) {
			ContextInfo contextInfo = _next.GetComponent<ContextInfo> ();
			contextInfo.contextInfo = customInfoForNextScreen;
		}
	}

	public string GetContextInfo()
	{
		ContextInfo contextInfo = transform.parent.GetComponent<ContextInfo>();

		if (contextInfo == null)
			return "";

		return contextInfo.contextInfo;
	}

	// Update is called once per frame
	void Update ()
	{
		//Debug.Log(Backend.GetUsername());
	}
}
