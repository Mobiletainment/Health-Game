using UnityEngine;
using System.Collections;

public class NavigateForward : MonoBehaviour
{
	public GameObject _next;
	private ECPNManager ecpnManager;
	public string customInfoForNextScreen = "";
	UIButton button;
	UILabel lable;
	float time=0.0f;
	int pointsHelper=0;
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
		
		DisableButton ();
		MenuStack.ClickForward (_next);
		UILabel test = transform.GetComponentInChildren<UILabel> ();
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

	public void ResetButton()
	{
		button = transform.GetComponent<UIButton> ();
		button.isEnabled = true;
		lable = transform.GetComponentInChildren<UILabel> ();
		lable.text = lable.text.Replace (".", "");
		pointsHelper = 0;
		time = 0;
	}
	public void DisableButton()
	{
		time = 0;
		button.isEnabled = false;
	}
	void OnEnable(){
		ResetButton ();

	}

	public void UpdatePoints()
	{
		if (!button.isEnabled)
			time+=Time.deltaTime;;
		if (time > 0.33) 
		{
			if (pointsHelper>2){
				lable.text=lable.text.Replace(".","");
				pointsHelper=0;
			}else {
				lable.text += ".";
				pointsHelper++;
			}
			time=0;
		}
	}
	// Update is called once per frame
	void Update ()
	{
		UpdatePoints ();

	}
}
