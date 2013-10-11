using System;
using System.IO;

//namespace HealthGameLib
//{
    enum Languages { en, de }

    static class Localisation
    {
        //private static string _language = Settings.LoadSettingFromFile("language");
        //private static Languages _currentLanguage = Languages.en;
        private static Languages _currentLanguage = GetLanguageFromFile();

        private static Languages GetLanguageFromFile()
        {
            string language = Settings.LoadSettingFromFile("language");

            switch (language)
            {
                case "en":
                    return Languages.en;
                case "de":
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
            if (File.Exists(filename))
            {
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
        }
    }
//}
