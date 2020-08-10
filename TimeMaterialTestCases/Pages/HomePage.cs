using System;
using System.Threading;
using OpenQA.Selenium;

namespace TimeMaterialTestCases.Pages
{
    public class HomePage
    {

        public void NevigateToTMPage(IWebDriver webDriver)
        {
            //launch to the timematerial page
            //webDriver.Navigate().GoToUrl("http://horse-dev.azurewebsites.net/TimeMaterial");
            Thread.Sleep(1000);
            webDriver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a")).Click();
            Thread.Sleep(1000);
            webDriver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a")).Click();
            webDriver.Manage().Window.FullScreen();
        }
    }
}
