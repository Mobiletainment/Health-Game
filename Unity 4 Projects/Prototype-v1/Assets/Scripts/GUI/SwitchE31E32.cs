using UnityEngine;
using System.Collections;

public class SwitchE31E32 : MonoBehaviour {

	
	public GameObject currentPanelObject;
    public GameObject nextPanelObject;
	
	public UISlider slider;
	// Use this for initialization
	
	void OnClick() {
        NGUITools.SetActive(nextPanelObject, true);
        NGUITools.SetActive(currentPanelObject, false);
		slider.value=0.5f;
    }
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
