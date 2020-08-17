using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TimeMaterialTestCases.Helpers;

namespace TimeMaterialTestCases.Pages
{
    public class EmployeePage
    {
        public Boolean NevigateToCreateNewPage(IWebDriver webDriver)
        {
            //Find create button and click
            IWebElement createNew = WebHelper.FindElement(webDriver, By.XPath("//*[@id='container']/p/a"));
            webDriver.Manage().Window.FullScreen();
            createNew.Click();

            return WebHelper.FindElement(webDriver, By.XPath("//*[@id='container']/h2")).Text.Equals("Employee Details");
        }

        public void NevigateToTheNumbericEditPage(IWebDriver webDriver, int i)
        {
            //Splice xpath
            string xpath = "//*[@id='tmsGrid']/div[3]/table/tbody/tr[" + i.ToString() + "]/td[3]/a[1]";
            Console.WriteLine("Edit Xpath - " + xpath);

            //Find the numberic button and click
            WebHelper.WaitClickable(webDriver, "XPath", xpath, 5);
            WebHelper.FindElement(webDriver, By.XPath(xpath)).Click();

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
            WebHelper.WaitClickable(webDriver, "XPath", xpath, 5);
            WebHelper.FindElement(webDriver, By.XPath(xpath)).Click();

            //Click the alert pop-up
            IAlert alert = webDriver.SwitchTo().Alert();
            alert.Accept();
        }
    }
}
