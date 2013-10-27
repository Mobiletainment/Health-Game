using System;
using System.IO;
using UnityEngine;

//namespace HealthGameLib
//{
public static class Settings
{
    //private static string _filename = Application.dataPath + "/Resources/settings.ini";
    private static string _filename = "settings";


    public static bool SaveSettingToFile(string settingName, string settingValue)
    {
		if(PlayerPrefs.HasKey(settingName))
		{
			PlayerPrefs.SetString(settingName, settingValue);
			PlayerPrefs.Save();
			return true;
		}
		
		return false;
		
		
		/*
        if (File.Exists(_filename))
        {
			TextAsset bindata = Resources.Load(_filename) as TextAsset;
            string text = bindata.text;
            Debug.Log("Settings Save -> Filename: " + _filename + " Text: " + text);
		
            string content;
            string[] delimiterstring = { "\r\n" };

            using (StreamReader sr = new StreamReader(_filename))
            {
                content = sr.ReadToEnd();
            }

            string[] lines = content.Split(delimiterstring, StringSplitOptions.None);
            int numberOfLines = lines.Length;
            content = "";

            for (int i = 0; i < numberOfLines; ++i)
            {
                if (lines[i].Contains(settingName))
                {
                    lines[i] = "#" + settingName + ":" + settingValue;
                }

                content += lines[i];

                if (i < numberOfLines - 1)
                    content += "\r\n";
            }

            using (StreamWriter sw = new StreamWriter(_filename))
            {
                sw.Write(content);
            }
        }
	
		//Debug.Log("Settings file " + _filename + " not found!");

        return false;*/
	}

	public static string LoadSettingFromFile(string settingName)
	{
		Debug.Log("Settings Load");
		
		string lang = "en";
		
		if(PlayerPrefs.HasKey(settingName))
			lang = PlayerPrefs.GetString(settingName);
		else
		{
			PlayerPrefs.SetString(settingName, lang);
			PlayerPrefs.Save();
		}
		
		Debug.Log("PlayerPrefs " + lang);
		
		return lang;
	
		/*
		TextAsset bindata = Resources.Load(_filename) as TextAsset;
        string text = bindata.text;
        Debug.Log("Settings Load -> Filename: " + _filename + " Text: " + text);
		
		string[] delimiterstring = { "\r\n" };
		string[] lines = text.Split(delimiterstring, StringSplitOptions.None);
		int numberOfLines = lines.Length;
	
		for (int i = 0; i < numberOfLines; ++i)
		{
			if(String.IsNullOrEmpty(lines[i]))
				break;
				
			if (lines[i][0] == '#') //not a valid entry without # at the beginning
            {
				if (lines[i].Contains(settingName))
                {
                    string[] parts = lines[i].Split(':');
					Debug.Log("Settings Load -> Value: " + parts[1]);
                    return parts[1];
                }
			}
		}*/
		
        /*if (File.Exists(_filename))
        {
			
		
            using (StreamReader sr = new StreamReader(_filename))
            {
                while (!sr.EndOfStream)
                {
                    string s = sr.ReadLine();

                    if (String.IsNullOrEmpty(s))
                        break;

                    if (s[0] == '#') //not a valid entry without # at the beginning
                    {
                        if (s.Contains(settingName))
                        {
                            string[] parts = s.Split(':');
                            return parts[1];
                        }
                    }
                }
            }
        }*/
	
		//Debug.Log("Settings file " + _filename + " not found! Dir: " + Directory.GetDirectoryRoot(_filename) );

        return null;
    }
}