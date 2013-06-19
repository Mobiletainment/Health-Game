using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;
using Localizator;

namespace LocalizatorTest
{
    /// <summary>
    /// Summary description for BasicTests
    /// </summary>
    [TestClass]
    public class BasicTests
    {
        private static Localizator.Localizator localizator;

        public BasicTests()
        {
            localizator = new Localizator.Localizator();
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void GermanTextTest()
        {
            CultureInfo ci = new CultureInfo("de-DE");
            localizator.SetCultureInfo(ci);

            string text1 = localizator.GetText("LanguageText");
            string text2 = localizator.GetText("EnglishText");
            string text3 = localizator.GetText("GermanText");

            Assert.AreEqual("Sprache", text1);
            Assert.AreEqual("Englisch", text2);
            Assert.AreEqual("Deutsch", text3);
        }

        [TestMethod]
        public void EnglishTextTest()
        {
            CultureInfo ci = new CultureInfo("en-US");
            localizator.SetCultureInfo(ci);

            string text1 = localizator.GetText("LanguageText");
            string text2 = localizator.GetText("EnglishText");
            string text3 = localizator.GetText("GermanText");

            Assert.AreEqual("Language", text1);
            Assert.AreEqual("English", text2);
            Assert.AreEqual("German", text3);
        }
    }
}
