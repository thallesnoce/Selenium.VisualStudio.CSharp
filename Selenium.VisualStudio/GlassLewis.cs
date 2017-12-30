using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;

namespace Selenium.VisualStudio
{
    [TestClass]
    public class GlassLewis : TestBase
    {
        [TestMethod]
        public void Login_Sucess_FireFox()
        {
            using (var driver = new FirefoxDriver())
            {
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://viewpoint.glasslewis.com/");
                var userName = driver.FindElementById("lbl-username");
                userName.SendKeys("tnoce@glasslewis.com");

                var password = driver.FindElementById("lbl-password");
                password.SendKeys("Thalles6632");

                var searchButton = driver.FindElementById("btn-submit-login");

                searchButton.Submit();

                //var searchResults = driver.FindElementById("resultStats");
            }
        }
    }
}