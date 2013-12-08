using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuStack : MonoBehaviour {
	
	private static MenuStack _instance;
	public Stack<GameObject> _panels;
	public GameObject _start;
	public GameObject _errorPanel;
	void Awake ()
	{
		_instance = MenuStack.Instance;
	}

	public static MenuStack Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = GameObject.Find("ComponentManager").GetComponent<MenuStack>();
				
				if(_instance == null)
				{
					Debug.LogError("No MenuStack Component attached to ComponentManager! Error creating MenuStack Singleton");
				}
				
			}

			return _instance;
		}
	}

	// Use this for initialization
	void Start () {
		_instance._panels=new Stack<GameObject>();
		_instance._panels.Push(_start);
		NGUITools.SetActive(_instance._panels.Peek(), true);

	}
	public static void ShowError(string errorMsg){
		NGUITools.SetActive (_instance._errorPanel,true);
		PopUpError err = _instance._errorPanel.GetComponent<PopUpError> ();
		err.setErrorMsg (errorMsg);
	}
	public static void ClickForward(GameObject obj){
		
		NGUITools.SetActive(_instance._panels.Peek(), false);
		NGUITools.SetActive(obj, true);
		_instance._panels.Push(obj);

	}
	public static void CloseTop() {
		NGUITools.SetActive(_instance._panels.Peek(), false);

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
