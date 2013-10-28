using UnityEngine;
using System.Collections;

public class SettingsMenu : MonoBehaviour {
	
	public UILabel LabelSetting;
	public UILabel LabelLanguage;
	public UILabel LabelButtonGerman;
	public UILabel LabelButtonEnglish;
	
	public string LocalisationDataFile;
	
	
	// Use this for initialization
	void Start () {
		//string language = Settings.LoadSettingFromFile("language");
		//Debug.Log("out1: " + language);
		
		TextUpdate();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void TextUpdate()
    {
		//Localisation.UpdateLanguage();
		LabelSetting.text = Localisation.GetTextFromFile(LocalisationDataFile, "SettingsText");
		LabelLanguage.text = Localisation.GetTextFromFile(LocalisationDataFile, "LanguageText");
		LabelButtonGerman.text = Localisation.GetTextFromFile(LocalisationDataFile, "GermanText");
		LabelButtonEnglish.text = Localisation.GetTextFromFile(LocalisationDataFile, "EnglishText");
	}
	
	public void LanguageButtonPressed()
	{
		//string language = Settings.LoadSettingFromFile("language");
		Localisation.UpdateLanguage();
		TextUpdate();
	}
}
