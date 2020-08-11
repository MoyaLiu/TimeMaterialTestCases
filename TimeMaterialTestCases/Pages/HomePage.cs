using System;
using OpenQA.Selenium;
using TimeMaterialTestCases.Helpers;

namespace TimeMaterialTestCases.Pages
{
    public class HomePage
    {

        public void NevigateToTMPage(IWebDriver webDriver)
        {
            webDriver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a")).Click();

            WaitHelper.WaitClickable(webDriver, "XPath", "/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a", 5);
            webDriver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a")).Click();
            webDriver.Manage().Window.FullScreen();
        }

        public void NevigateToEmployeePage(IWebDriver webDriver)
        {
            webDriver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a")).Click();

            WaitHelper.WaitClickable(webDriver, "XPath", "/html/body/div[3]/div/div/ul/li[5]/ul/li[2]/a", 5);
            webDriver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[2]/a")).Click();
            webDriver.Manage().Window.FullScreen();
        }
    }
}
