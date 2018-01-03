using NUnit.Framework;
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
        protected IBrowserDriver broswerDriver;

        public void Setup(string browser)
        {
            var factory = new WebDriver();
            broswerDriver = factory.CreateWebDriver(browser);
        }

        [TearDown]
        public void CleanUp()
        {
            broswerDriver.Quit();
        }

        public static IEnumerable<string> SelectedBrowser()
        {
            string[] browsers = { "chrome", "firefox", "ie" };
            foreach (var item in browsers)
            {
                yield return item;
            }
        }
    }

    public interface IBrowserDriver
    {
        IWebDriver Driver();
        void SendKeys(string element, string value);
        void Quit();
    }

    public abstract class WebDriverFactory
    {
        protected IBrowserDriver driver = new InternetExplorerBrowser();
        public abstract IBrowserDriver CreateWebDriver(string browser);
    }

    public class WebDriver : WebDriverFactory
    {
        public override IBrowserDriver CreateWebDriver(string browser)
        {
            if (browser.Equals("ie"))
            {
                driver = new InternetExplorerBrowser();
            }
            else if (browser.Equals("chrome"))
            {
                driver = new InternetExplorerBrowser();
            }
            else if (browser.Equals("FireFox"))
            {
                driver = new InternetExplorerBrowser();
            }
            return driver;
        }
    }

    public class InternetExplorerBrowser : IBrowserDriver
    {
        IWebDriver _driver;

        public InternetExplorerBrowser()
        {
            _driver = new InternetExplorerDriver();
            _driver.Manage().Window.Maximize();
            //driver.Manage().Timeouts().ImplicitWait(TimeSpan.FromSeconds(20));
        }

        public void Quit()
        {
            _driver.Quit();
        }

        public void SendKeys(string element, string value)
        {
            throw new NotImplementedException();
        }

        public IWebDriver Driver()
        {
            return _driver;
        }
    }

    public class ChromerBrowser : IBrowserDriver
    {
        IWebDriver _driver;

        public ChromerBrowser()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            //_driver.Manage().Timeouts().ImplicitWait(TimeSpan.FromSeconds(20));
        }

        public IWebDriver Driver()
        {
            return _driver;
        }

        public void Quit()
        {
            _driver.Quit();
        }

        public void SendKeys(string element, string value)
        {
            throw new NotImplementedException();
        }
    }

    public class FireFoxBrowser : IBrowserDriver
    {
        IWebDriver _driver;

        public FireFoxBrowser()
        {
            _driver = new FirefoxDriver();
            _driver.Manage().Window.Maximize();
            //_driver.Manage().Timeouts().ImplicitWait(TimeSpan.FromSeconds(20));
        }

        public IWebDriver Driver()
        {
            return _driver;
        }

        public void Quit()
        {
            _driver.Quit();
        }

        public void SendKeys(string element, string value)
        {
            throw new NotImplementedException();
        }
    }
}