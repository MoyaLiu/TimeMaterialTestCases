using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TimeMaterialTestCases.Helpers
{
    public class WaitHelper
    {
        public static void WaitClickable(IWebDriver webDriver, String attribute, String value, int seconds)
        {
            var wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, seconds));
            if (attribute.Equals("Id"))
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id(value)));
            }
            if (attribute.Equals("XPath"))
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(value)));
            } 
        }
    }
}
