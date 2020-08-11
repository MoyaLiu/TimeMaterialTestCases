using System;
using System.Text;
using System.Threading;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TimeMaterialTestCases.Helpers;

namespace TimeMaterialTestCases.Pages
{
    public class TMPage
    {
        public void NevigateToCreateNewPage(IWebDriver webDriver)
        {
            //Find create button and click
            webDriver.FindElement(By.XPath("//*[@id='container']/p/a")).Click(); ;
            webDriver.Manage().Window.FullScreen();
        }

        public void NevigateToTheNumbericEditPage(IWebDriver webDriver, int i)
        {
            //Splice xpath
            string xpath = "//*[@id='tmsGrid']/div[3]/table/tbody/tr[" + i.ToString() + "]/td[5]/a[1]";
            Console.WriteLine("Edit Xpath - " + xpath);

            //Find the numberic button and click
            WaitHelper.WaitClickable(webDriver, "XPath", xpath, 5);
            webDriver.FindElement(By.XPath(xpath)).Click();

        }

        public void EditTheRecordValues(IWebDriver webDriver, string typeCode, string code, string description, string price)
        {
            //Click the dropdown
            WaitHelper.WaitClickable(webDriver, "XPath", "//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[1]", 10);
            webDriver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[1]")).Click();

            //Select typecode "T" or "M"
            if (typeCode.Equals("M"))
            {
                WaitHelper.WaitClickable(webDriver, "XPath", "//*[@id='TypeCode_listbox']/li[1]", 10);
                webDriver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[1]")).Click();
            }
            else if (typeCode.Equals("T"))
            {
                WaitHelper.WaitClickable(webDriver, "XPath", "//*[@id='TypeCode_listbox']/li[2]", 10);
                webDriver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[2]")).Click();
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

            WaitHelper.WaitClickable(webDriver, "Id", "Price", 5);
            IWebElement ePrice = webDriver.FindElement(By.Id("Price"));
            if (!String.IsNullOrEmpty(ePrice.GetAttribute("aria-valuenow")))
            {
                ePrice.Clear();
                eInputAvalible.Click();
            }
            ePrice.SendKeys(price);

            //Find save button and click
            webDriver.FindElement(By.Id("SaveButton")).Click();
        }

        /* Delete the numberic record
         * @param The number of the record in the page list
         */
        public void DeleteTheNumbericRecord(IWebDriver webDriver, int i)
        {
            //Splice xpath
            string xpath = "//*[@id='tmsGrid']/div[3]/table/tbody/tr[" + i.ToString() + "]/td[5]/a[2]";
            Console.WriteLine("Delete Xpath - " + xpath);

            //Find the numberic button and click
            WaitHelper.WaitClickable(webDriver, "XPath", xpath, 5);
            webDriver.FindElement(By.XPath(xpath)).Click();

            //Click the alert pop-up
            IAlert alert = webDriver.SwitchTo().Alert();
            alert.Accept();
        }

        //Go to the last page
        public void GoToLastPage(IWebDriver webDriver)
        {
            Thread.Sleep(2000);
            //webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //WaitHelper.WaitClickable(webDriver, "XPath", "//*[@id='tmsGrid']/div[4]/a[4]/span", 10);
            webDriver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span")).Click();

        }

        //Get the last record Code
        public String GetLastRecordCode(IWebDriver webDriver)
        {

            WaitHelper.WaitClickable(webDriver, "XPath", ".//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]", 5);
            var getCode = webDriver.FindElement(By.XPath(".//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            return getCode.Text;
        }

        //Get the last record TypeCode
        public String GetLastRecordTypeCode(IWebDriver webDriver)
        {
            WaitHelper.WaitClickable(webDriver, "XPath", ".//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[2]", 5);
            var getTypeCode = webDriver.FindElement(By.XPath(".//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[2]"));
            return getTypeCode.Text;
        }

        //Get the last record Description
        public String GetLastRecordDescription(IWebDriver webDriver)
        {
            WaitHelper.WaitClickable(webDriver, "XPath", ".//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]", 5);
            var getDescripiton = webDriver.FindElement(By.XPath(".//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            return getDescripiton.Text;

        }

        //Get the last record Price
        public String GetLastRecordPrice(IWebDriver webDriver)
        {
            WaitHelper.WaitClickable(webDriver, "XPath", ".//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]", 5);
            var getPrice = webDriver.FindElement(By.XPath(".//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));
            Console.WriteLine("getPrice = " + getPrice.Text);
            return getPrice.Text;
        }
    }
}
