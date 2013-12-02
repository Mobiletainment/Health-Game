using UnityEngine;
using System.Collections;

public class NavigateDone : MonoBehaviour {
	public GameObject _next;

	// Use this for initialization
	void Start () {
	
	}
	void OnClick()
	{	
		MenuStack.ClickDone();
		MenuStack.ClickForward(_next);

	}
	// Update is called once per frame
	void Update () {
	
	}
}
