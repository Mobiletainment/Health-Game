﻿using UnityEngine;
using System.Collections;

public class NavigateForward : MonoBehaviour {
	public GameObject _next;


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
	
	}
}