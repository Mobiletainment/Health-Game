using UnityEngine;
using System.Collections;

public class NavigateClose : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	void OnClick()
	{	
		MenuStack.CloseTop();
		MenuStack.ClickDone();

	}
	// Update is called once per frame
	void Update () {
	
	}
}
