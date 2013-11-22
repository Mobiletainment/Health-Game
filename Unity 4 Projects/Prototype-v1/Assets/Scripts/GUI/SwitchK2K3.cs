using UnityEngine;
using System.Collections;

public class SwitchK2K3 : MonoBehaviour {

	public GameObject currentPanelObject;
    public GameObject nextPanelObject;
		
	public UIInput input;
	public UILabel label;
	public UIInput inputPW;

    void OnClick() {
        NGUITools.SetActive(nextPanelObject, true);
        NGUITools.SetActive(currentPanelObject, false);
		label.text="Hallo, "+NGUIText.StripSymbols(input.value)+"!\n"+"Hier hast du ein geheimes Team-Passowort!";
		inputPW.value=Random.Range(10000000,99999999).ToString();
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
