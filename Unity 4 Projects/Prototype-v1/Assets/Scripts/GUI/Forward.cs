using UnityEngine;
using System.Collections;

public class Forward : MonoBehaviour {
	public MenuStack _menuStack;
	public GameObject _next;


	// Use this for initialization
	void Start () {
	
	}

	void OnClick(){
		ClickForward();
	}
	public void ClickForward(){
		_menuStack.ClickForward(_next);

	}
	// Update is called once per frame
	void Update () {
	
	}
}
