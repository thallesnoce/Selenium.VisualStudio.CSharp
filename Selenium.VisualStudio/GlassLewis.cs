
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;

namespace Selenium.VisualStudio
{

    [TestFixture]
    //[Parallelizable]
    public class GlassLewis : TestBase
    {
        [Test]
        [TestCaseSource(typeof(TestBase), "SelectedBrowser")]
        public void Login_Sucess(string browser)
        {
            Setup(browser);

            broswerDriver.Driver().Navigate().GoToUrl("https://www.google.ie/");

            Actions actions = new Actions(broswerDriver.Driver());
            var element = broswerDriver.Driver().FindElement(By.Id("lst-ib"));
            actions.MoveToElement(element);
            actions.Click();
            actions.SendKeys("Glass Lewis");
            actions.Build().Perform();

            Actions actions3 = new Actions(broswerDriver.Driver());
            var element3 = broswerDriver.Driver().FindElement(By.Name("btnK"));
            actions3.MoveToElement(element3);
            actions3.Click();
            actions3.Build().Perform();
        }
    }
}