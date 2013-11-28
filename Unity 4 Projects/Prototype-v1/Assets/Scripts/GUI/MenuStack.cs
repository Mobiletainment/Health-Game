using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuStack : MonoBehaviour {

	Stack<GameObject> _panels;
	public GameObject _start;

	// Use this for initialization
	void Start () {
		_panels=new Stack<GameObject>();
		_panels.Push(_start);
	}

	public void ClickForward(GameObject obj){

		NGUITools.SetActive(_panels.Peek(), false);
		NGUITools.SetActive(obj, true);
		_panels.Push(obj);

	}
	public void ClickBack(){

		NGUITools.SetActive(_panels.Peek(), false);
		_panels.Pop();
		NGUITools.SetActive(_panels.Peek(), true);

	}

	public void ClickDone(){
		_panels.Clear();
	}


	// Update is called once per frame
	void Update () {
	
	}
}
