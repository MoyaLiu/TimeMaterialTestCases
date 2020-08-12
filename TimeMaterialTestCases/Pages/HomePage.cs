using System;
using OpenQA.Selenium;
using TimeMaterialTestCases.Helpers;

namespace TimeMaterialTestCases.Pages
{
    public class HomePage
    {

        public void NevigateToTMPage(IWebDriver webDriver)
        {
            //Find Administration button and click
            WebHelper.FindElement(webDriver, By.XPath("/html/body/div[3]/div/div/ul/li[5]/a")).Click();

            //Find TM button and click
            WebHelper.WaitClickable(webDriver, "XPath", "/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a", 10);
            WebHelper.FindElement(webDriver, By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a")).Click();
            webDriver.Manage().Window.FullScreen();
        }

        public void NevigateToEmployeePage(IWebDriver webDriver)
        {
            //Find Administration button and click
            WebHelper.FindElement(webDriver, By.XPath("/html/body/div[3]/div/div/ul/li[5]/a")).Click();

            //Find Employees button and click
            WebHelper.WaitClickable(webDriver, "XPath", "/html/body/div[3]/div/div/ul/li[5]/ul/li[2]/a", 10);
            WebHelper.FindElement(webDriver,By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[2]/a")).Click();
            webDriver.Manage().Window.FullScreen();
        }
    }
}
