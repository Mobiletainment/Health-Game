using UnityEngine;
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

    /* Einmal durchgehen 
	UIToggle[]	toggles=transform.parent.GetComponentsInChildren<UIToggle> ();
		 	for (int i=0; i<toggles.Length; i++) {
			UILabel lab = toggles [i].GetComponentInChildren<UILabel>();
			Debug.Log (toggles [i].value + "  "+lab.text);
		}*/
		MenuStack.ClickForward(_next);

	}
	// Update is called once per frame
	void Update () {
	
	}
}
