using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TimeMaterialTestCases.Pages;

namespace TimeMaterialTestCases.Helpers
{
    public class CommonDriver
    {
        public IWebDriver driver;
        public static TimeSpan timeWaiting = TimeSpan.FromMilliseconds(1000);
        public String loginUrl = "http://horse-dev.azurewebsites.net/";

        [OneTimeSetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver();
            LoginPage loginPage = new LoginPage();
            loginPage.Login(driver, loginUrl, "hari", "123123");
        }

        [OneTimeTearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}
