using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading;

namespace Localizator
{
    public class Localizator
    {
        public Localizator()
        {
            CultureInfo ci = new CultureInfo("en-US");
            SetCultureInfo(ci);
        }

        public void SetCultureInfo(CultureInfo ci)
        {
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }

        public string GetText(string textName)
        {
            return LanguageResources.ResourceManager.GetString(textName);
        }
    }
}
