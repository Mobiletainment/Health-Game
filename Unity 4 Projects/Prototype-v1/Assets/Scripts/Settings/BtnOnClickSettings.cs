using UnityEngine;
using System.Collections;


public class BtnOnClickSettings : MonoBehaviour {

    public string btnName;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        Debug.Log("OnClick");

        switch(btnName)
		{
		case "BtnGerman":
			Debug.Log("OnClick German");
            Settings.SaveSettingToFile("language", "de");
			break;
		case "BtnEnglish":
			Debug.Log("OnClick English");
            Settings.SaveSettingToFile("language", "en");
			break;
		}
		
		GameObject.Find("Scriptholder").GetComponent<SettingsMenu>().LanguageButtonPressed();
    }
}