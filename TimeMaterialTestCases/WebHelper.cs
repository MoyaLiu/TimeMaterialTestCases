using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TimeMaterialTestCases
{
    public class WebHelper
    {
        static TimeSpan timeWaiting = TimeSpan.FromMilliseconds(10000);
        public String Login(IWebDriver driver, String username, String password)
        {
            //Launch TurnUp portal
            driver.Navigate().GoToUrl("http://horse-dev.azurewebsites.net/");

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

        public void JumpToTimeMaterialPage(IWebDriver webDriver)
        {
            //launch to the timematerial page
            //webDriver.Navigate().GoToUrl("http://horse-dev.azurewebsites.net/TimeMaterial");
            Thread.Sleep(1000);
            webDriver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a")).Click();
            Thread.Sleep(1000);
            webDriver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a")).Click();
            webDriver.Manage().Window.FullScreen();
        }

        public void JumpToCreateNewPage(IWebDriver webDriver)
        {
            //Find create button and click
            IWebElement createNew = webDriver.FindElement(By.XPath("//*[@id='container']/p/a"));
            webDriver.Manage().Window.FullScreen();
            createNew.Click();

            //Valid the page turn successful 
            //IWebElement timeAndMaterials = webDriver.FindElement(By.XPath("//*[@id='container']/h2"));
            //Assert.AreEqual("Time and Materials", timeAndMaterials.Text);
        }
        public void JumpToTheNumbericEditPage(IWebDriver webDriver, int i)
        {
            //Splice xpath
            string xpath = "//*[@id='tmsGrid']/div[3]/table/tbody/tr[" + i.ToString() + "]/td[5]/a[1]";
            Console.WriteLine("Edit Xpath - " + xpath);

            //Find the numberic button and click
            WebDriverWait wait = new WebDriverWait(webDriver, timeWaiting);
            IWebElement editRecord = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
            editRecord.Click();

        }

        public void DeleteTheNumbericRecord(IWebDriver webDriver, int i)
        {
            //Splice xpath
            string xpath = "//*[@id='tmsGrid']/div[3]/table/tbody/tr[" + i.ToString() + "]/td[5]/a[2]";
            Console.WriteLine("Delete Xpath - " + xpath);

            //Find the numberic button and click
            WebDriverWait wait = new WebDriverWait(webDriver, timeWaiting);
            IWebElement deleteRecord = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
            deleteRecord.Click();

            //Click the alert pop-up
            IAlert alert = webDriver.SwitchTo().Alert();
            Thread.Sleep(3000);
            //webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(10000);
            alert.Accept();
        }

        public void ChangeTheRecordValues(IWebDriver webDriver, string typeCode, string code, string description, string price)
        {
            //Click the dropdown
            IWebElement selectElement = webDriver.FindElement(By.XPath("//span[@role='listbox' and @tabindex='0']"));
            selectElement.Click();
            Thread.Sleep(2000);

            //Select typecode "T" or "M"
            if (typeCode == "M")
            {
                WebDriverWait waitOptionElement = new WebDriverWait(webDriver, timeWaiting);
                IWebElement optionElement = waitOptionElement.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//li[@role='option' and contains(text(),'Material')]")));
                optionElement.Click();

            }
            else if (typeCode == "T")
            {
                IWebElement optionElement = webDriver.FindElement(By.XPath("//li[@role='option' and contains(text(),'Time')]"));
                //WebDriverWait waitOptionElement = new WebDriverWait(webDriver, timeWaiting);
                //IWebElement optionElement = waitOptionElement.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//li[@role='option' and contains(text(),'Time')]")));
                optionElement.Click();

            }

            //Find code textbox and input value
            IWebElement eCode = webDriver.FindElement(By.Id("Code"));
            eCode.Clear();
            eCode.SendKeys(code);

            //Find description textbox and input value
            IWebElement eDescription = webDriver.FindElement(By.Id("Description"));
            eDescription.Clear();
            eDescription.SendKeys(description);

            //Find price textbox and input value
            IWebElement eInputAvalible = webDriver.FindElement(By.XPath("//input[@tabindex='0']"));
            eInputAvalible.Click();

            WebDriverWait wait = new WebDriverWait(webDriver, timeWaiting);
            IWebElement ePrice = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("Price")));
            Console.WriteLine("aria-valuenow is " + ePrice.GetAttribute("aria-valuenow"));
            if (!String.IsNullOrEmpty(ePrice.GetAttribute("aria-valuenow")))
            {
                ePrice.Clear();
                eInputAvalible.Click();
            }
            ePrice.SendKeys(price);

            //Find save button and click
            IWebElement eSaveButton = webDriver.FindElement(By.Id("SaveButton"));
            eSaveButton.Click();
        }

    }
}

