using System;
using OpenQA.Selenium;
using TimeMaterialTestCases.Helpers;

namespace TimeMaterialTestCases.Pages
{
    public class LoginPage
    {
        public String Login(IWebDriver driver, String loginUrl, String username, String password)
        {
            //Launch TurnUp portal
            driver.Navigate().GoToUrl(loginUrl);

            //Maximize the browser
            driver.Manage().Window.FullScreen();

            //Find username textbox and input username
            WebHelper.FindElement(driver, By.Id("UserName")).SendKeys(username);

            //Find password textbox and input password
            WebHelper.FindElement(driver, By.Id("Password")).SendKeys(password);

            //Find login button and click
            WebHelper.FindElement(driver, By.XPath("//*[@id='loginForm']/form/div[3]/input[1]")).Click();

            driver.Manage().Window.FullScreen();
            return WebHelper.FindElement(driver, By.XPath("//*[@id='logoutForm']/ul/li/a")).Text;
        }
    }
}
