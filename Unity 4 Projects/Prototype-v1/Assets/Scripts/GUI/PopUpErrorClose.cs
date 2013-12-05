using UnityEngine;
using System.Collections;

public class PopUpErrorClose : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	void OnClick(){

		NGUITools.SetActive (transform.parent.gameObject, false);

	}
	// Update is called once per frame
	void Update () {
	
	}
}
