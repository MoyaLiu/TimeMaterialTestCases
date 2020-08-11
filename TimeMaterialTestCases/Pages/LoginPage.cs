using System;
using OpenQA.Selenium;

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
            driver.FindElement(By.Id("UserName")).SendKeys(username);

            //Find password textbox and input password
            driver.FindElement(By.Id("Password")).SendKeys(password);

            //Find login button and click
            driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]")).Click();

            driver.Manage().Window.FullScreen();
            IWebElement helloUserName = driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));
            return helloUserName.Text;
        }
    }
}
