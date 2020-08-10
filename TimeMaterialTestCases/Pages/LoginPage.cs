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
            IWebElement userName = driver.FindElement(By.Id("UserName"));
            userName.SendKeys(username);

            //Find password textbox and input password
            IWebElement passWord = driver.FindElement(By.Id("Password"));
            passWord.SendKeys(password);

            //Find login button and click
            IWebElement loginButton = driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
            loginButton.Click();

            driver.Manage().Window.FullScreen();
            IWebElement helloUserName = driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));
            return helloUserName.Text;
        }
    }
}
