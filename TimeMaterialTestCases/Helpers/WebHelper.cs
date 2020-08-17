using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TimeMaterialTestCases.Helpers
{
    public class WebHelper
    {
        public static void WaitClickable(IWebDriver webDriver, String attribute, String value, int seconds)
        {
            try {
                var wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, seconds));
                if(attribute.Equals("Id"))
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id(value)));
                }
                else if(attribute.Equals("XPath"))
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(value)));
                }
            }
            catch(TimeoutException ex)
            {
                Console.WriteLine("The element is not clickable, time out, " + ex.Message);
            }
        }

        public static void WaitVisible(IWebDriver webDriver, String attribute, String value, int seconds)
        {
            try
            {
                var wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, seconds));
                if (attribute.Equals("Id"))
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(value)));
                }
                else if (attribute.Equals("XPath"))
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(value)));
                }
            }
            catch (TimeoutException ex)
            {
                Console.WriteLine("The element is not clickable, time out, " + ex.Message);
            }
        }

        public static IWebElement FindElement(IWebDriver webDriver,By by)
        {
            try
            {
                var webElement = webDriver.FindElement(by);
                return webElement;
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine("Did not find the element." + ex.Message);
                return null;
            }
        }

        public static String GetCurrentPageURL(IWebDriver driver, int seconds,By by)
        {
            try {
                var wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                return driver.Url;
            }catch(TimeoutException ex)
            {
                Console.WriteLine("Get current page url "+ seconds + "seconds time out." + ex.Message);
                return null;
            }
        }
    }
}
