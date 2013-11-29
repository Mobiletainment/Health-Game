using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuStack : MonoBehaviour {
	
	private static MenuStack _instance;
	public Stack<GameObject> _panels;
	public GameObject _start;

	void Awake ()
	{
		if (_instance == null)
		{
			_instance = GameObject.Find("ComponentManager").GetComponent<MenuStack>();

			if(_instance == null)
			{
				Debug.LogError("No MenuStack Component attached to ComponentManager! Error creating MenuStack Singleton");
			}

		}
	}

	// Use this for initialization
	void Start () {
		_instance._panels=new Stack<GameObject>();
		_instance._panels.Push(_start);
		NGUITools.SetActive(_instance._panels.Peek(), true);

	}

	public static void ClickForward(GameObject obj){

		NGUITools.SetActive(_instance._panels.Peek(), false);
		NGUITools.SetActive(obj, true);
		_instance._panels.Push(obj);

	}
	public static void ClickBack()
	{

		NGUITools.SetActive(_instance._panels.Peek(), false);
		_instance._panels.Pop();
		NGUITools.SetActive(_instance._panels.Peek(), true);

	}

	public static void ClickDone(){
		_instance._panels.Clear();
	}


	// Update is called once per frame
	void Update () {
	
	}
}
