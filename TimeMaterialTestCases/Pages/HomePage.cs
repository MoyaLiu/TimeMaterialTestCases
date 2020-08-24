using System;
using OpenQA.Selenium;
using TimeMaterialTestCases.Helpers;

namespace TimeMaterialTestCases.Pages
{
    public class HomePage
    {

        public Boolean NevigateToTMPage(IWebDriver webDriver)
        {
            //Find Administration button and click
            WebHelper.WaitClickable(webDriver, "XPath", "/html/body/div[3]/div/div/ul/li[5]/a", 5);
            WebHelper.FindElement(webDriver, By.XPath("/html/body/div[3]/div/div/ul/li[5]/a")).Click();

            //Find TM button and click
            WebHelper.WaitClickable(webDriver, "XPath", "/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a", 10);
            WebHelper.FindElement(webDriver, By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a")).Click();
            webDriver.Manage().Window.FullScreen();

            //Find "Price", to validate nevigate to the TM page
            return WebHelper.FindElement(webDriver, By.XPath("//*[@id='tmsGrid']/div[2]/div/table/thead/tr/th[4]/a")).Text.Equals("Price");
        }

        public Boolean NevigateToEmployeePage(IWebDriver webDriver)
        {
            //Find Administration button and click
            WebHelper.WaitClickable(webDriver, "XPath", "/html/body/div[3]/div/div/ul/li[5]/a", 5);
            WebHelper.FindElement(webDriver, By.XPath("/html/body/div[3]/div/div/ul/li[5]/a")).Click();

            //Find Employees button and click
            WebHelper.WaitClickable(webDriver, "XPath", "/html/body/div[3]/div/div/ul/li[5]/ul/li[2]/a", 10);
            WebHelper.FindElement(webDriver,By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[2]/a")).Click();
            webDriver.Manage().Window.FullScreen();

            return WebHelper.FindElement(webDriver, By.XPath("//*[@id='usersGrid']/div[2]/div/table/thead/tr/th[2]/a")).Text.Equals("Username");
        }
    }
}
