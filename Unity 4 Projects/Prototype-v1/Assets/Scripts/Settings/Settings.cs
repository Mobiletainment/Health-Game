using System;
using System.IO;
using UnityEngine;

//namespace HealthGameLib
//{
    public static class Settings
    {
        private static string _filename = Application.dataPath + "/Resources/settings.ini";

        public static bool SaveSettingToFile(string settingName, string settingValue)
        {
            if (File.Exists(_filename))
            {
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

            return false;
        }

        public static string LoadSettingFromFile(string settingName)
        {
            if (File.Exists(_filename))
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
            }
		
			//Debug.Log("Settings file " + _filename + " not found! Dir: " + Directory.GetDirectoryRoot(_filename) );

            return null;
        }
    }
//}