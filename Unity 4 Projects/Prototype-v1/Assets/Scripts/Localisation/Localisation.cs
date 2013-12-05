using System;
using System.IO;
using UnityEngine;

//TextFiles: http://answers.unity3d.com/questions/540203/how-do-i-read-unicode-text-file-on-ios-from-resour.html
// http://forum.unity3d.com/threads/189649-Read-text-file-that-is-included-in-the-project


enum Languages { en, de }

static class Localisation
{
    //private static string _language = Settings.LoadSettingFromFile("language");
    //private static Languages _currentLanguage = Languages.en;
    private static Languages _currentLanguage = GetLanguageFromFile();

    private static Languages GetLanguageFromFile()
    {
		//Debug.Log("Localisation GetLanguageFromFile");
        string language = Settings.LoadSettingFromFile("language");

        switch (language)
        {
            case "en":
                return Languages.en;
            case "de":
		//Debug.Log("Localisation GetLanguageFromFile DONE - DE");
                return Languages.de;
            default:
                return Languages.en;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns>Returns <b>true</b> if language has changed. <b>False</b> if language has not changed.</returns>
    public static void UpdateLanguage()
    {
        _currentLanguage = GetLanguageFromFile();
    }

    public static string GetTextFromFile(string filename, string textIdentifier)
    {
		TextAsset bindata = Resources.Load("lang_menu") as TextAsset;
		string text = bindata.text;
		Debug.Log("Filename: " + filename + " Text: " + text);
		
		string[] delimiterstring = { "\r\n" };
		string[] lines = text.Split(delimiterstring, StringSplitOptions.None);
		int numberOfLines = lines.Length;
		
		for (int i = 0; i < numberOfLines; ++i)
		{
			if(String.IsNullOrEmpty(lines[i]))
				break;
			
			string[] parts = lines[i].Split('#');
			
			if (parts[0].Equals(textIdentifier))
            {
                switch (_currentLanguage)
                {
                    case Languages.en:
                        return parts[1];
                    case Languages.de:
                        return parts[2];
                    default:
                        return parts[1];
                }
            }
		}
		
		return "#EMPTY#";
	
		/*
        if (File.Exists(filename))
        {
			
            //filename = Application.dataPath + "/Resources/" + filename;
		
            using (StreamReader sr = new StreamReader(filename))
            {
                while (!sr.EndOfStream)
                {
                    string s = sr.ReadLine();

                    if (String.IsNullOrEmpty(s))
                        break;

                    string[] parts = s.Split('#');

                    if (parts[0].Equals(textIdentifier))
                    {
                        switch (_currentLanguage)
                        {
                            case Languages.en:
                                return parts[1];
                            case Languages.de:
                                return parts[2];
                            default:
                                return parts[1];
                        }
                    }
                }
            }

            return "#EMPTY#";
        }

        return "#FILE_NOT_FOUND#";
        */
    }
}
