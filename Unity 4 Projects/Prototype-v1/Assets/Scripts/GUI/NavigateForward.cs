using UnityEngine;
using System.Collections;

public class NavigateForward : MonoBehaviour {
	public GameObject _next;
	private ECPNManager ecpnManager;

	public ECPNManager Backend {
			get
			{
			if (ecpnManager == null)
				ecpnManager = GameObject.Find("ComponentManager").GetComponent<ECPNManager>();

			return ecpnManager;
			}
	}


	public enum ActionType
	{
		NotSpecified,
		NoAction,
		RegisterChild,
		RegisterParent,
		CheckIfParentAndChildRegistered
	}
	
	// Use this for initialization
	void Start () {
	
	}

	void OnClick(){
		ClickForward();
	}
	public void ClickForward(){

		MenuStack.ClickForward(_next);

	}
	// Update is called once per frame
	void Update () {
		//Debug.Log(Backend.GetUsername());
	}
}
