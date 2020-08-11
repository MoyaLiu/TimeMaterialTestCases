using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TimeMaterialTestCases.Pages
{
    public class EmployeePage
    {
        public void NevigateToCreateNewPage(IWebDriver webDriver)
        {
            //Find create button and click
            IWebElement createNew = webDriver.FindElement(By.XPath("//*[@id='container']/p/a"));
            webDriver.Manage().Window.FullScreen();
            createNew.Click();
        }

        public void NevigateToTheNumbericEditPage(IWebDriver webDriver, int i)
        {
            //Splice xpath
            string xpath = "//*[@id='tmsGrid']/div[3]/table/tbody/tr[" + i.ToString() + "]/td[3]/a[1]";
            Console.WriteLine("Edit Xpath - " + xpath);

            //Find the numberic button and click
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromMilliseconds(1000));
            IWebElement editRecord = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
            editRecord.Click();

            //Fill in the details

        }

        public void EditTheRecordValues(IWebDriver webDriver)
        {
  
        }

        /* Delete the numberic record
         * @param The number of the record in the page list
         */
        public void DeleteTheNumbericRecord(IWebDriver webDriver, int i)
        {
            //Splice xpath
            string xpath = "//*[@id='tmsGrid']/div[3]/table/tbody/tr[" + i.ToString() + "]/td[3]/a[2]";
            Console.WriteLine("Delete Xpath - " + xpath);

            //Find the numberic button and click
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromMilliseconds(1000));
            IWebElement deleteRecord = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
            deleteRecord.Click();

            //Click the alert pop-up
            IAlert alert = webDriver.SwitchTo().Alert();
            Thread.Sleep(1000);
            alert.Accept();
        }
    }
}
