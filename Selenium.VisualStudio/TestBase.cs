using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;

namespace Selenium.VisualStudio
{
    public class TestBase
    {
        protected IWebDriver driver;

        public void Setup(string browser)
        {
            if (browser.Equals("ie"))
            {
                driver = new InternetExplorerDriver();
            }
            else if (browser.Equals("chrome"))
            {
                driver = new ChromeDriver();
            }
            else if (browser.Equals("FireFox"))
            {
                driver = new FirefoxDriver();
            }

            driver.Manage().Window.Maximize();
            //driver.Manage().Timeouts().ImplicitWait(TimeSpan.FromSeconds(20));
        }

        public void CleanUp()
        {
            driver.Quit();
        }

        public static IEnumerable<string> SelectedBrowser()
        {
            string[] browsers = { "chrome", "firefox" };
            foreach (var item in browsers)
            {
                yield return item;
            }
        }
    }
}