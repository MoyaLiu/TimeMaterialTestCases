using System;
using NUnit.Framework;
using TimeMaterialTestCases.Helpers;
using TimeMaterialTestCases.Pages;

namespace TimeMaterialTestCases.Tests
{
    public class LoginTestCases:CommonDriver
    {
        //[Test, Description("Check if the user is able to login with the valid username and password")]
        public void TEST_001_Login_With_Valid_Values()
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Login(driver, loginUrl, "hari", "123123");
            String returnText = loginPage.Login(driver, loginUrl, "hari", "123123");
            Assert.AreEqual("Hello hari!", returnText);
        }
    }
}
