using UnityEngine;
using System.Collections;

public class Back : MonoBehaviour {
	public MenuStack _menuStack;

	// Use this for initialization
	void Start () {
	
	}
	void OnClick(){
		
		_menuStack.ClickBack();
	}
	// Update is called once per frame
	void Update () {
	
	}
}
