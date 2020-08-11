using System;
using System.Text;
using System.Threading;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TimeMaterialTestCases.Pages
{
    public class TMPage
    {
        public void NevigateToCreateNewPage(IWebDriver webDriver)
        {
            //Find create button and click
            IWebElement createNew = webDriver.FindElement(By.XPath("//*[@id='container']/p/a"));
            webDriver.Manage().Window.FullScreen();
            createNew.Click();

            //Valid the page turn successful 
            //IWebElement timeAndMaterials = webDriver.FindElement(By.XPath("//*[@id='container']/h2"));
            //Assert.AreEqual("Time and Materials", timeAndMaterials.Text);
        }

        public void NevigateToTheNumbericEditPage(IWebDriver webDriver, int i)
        {
            //Splice xpath
            string xpath = "//*[@id='tmsGrid']/div[3]/table/tbody/tr[" + i.ToString() + "]/td[5]/a[1]";
            Console.WriteLine("Edit Xpath - " + xpath);

            //Find the numberic button and click
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromMilliseconds(1000));
            IWebElement editRecord = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
            editRecord.Click();

        }

        public void EditTheRecordValues(IWebDriver webDriver, string typeCode, string code, string description, string price)
        {
            //Click the dropdown
            Thread.Sleep(1000);
            IWebElement selectElement = webDriver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[1]"));
            selectElement.Click();

            //Select typecode "T" or "M"
            if (typeCode.Equals("M"))
            {
                Thread.Sleep(1000);
                //WebDriverWait waitOptionElement = new WebDriverWait(webDriver, Tests.timeWaiting);
                //IWebElement optionElement = waitOptionElement.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='TypeCode_listbox']/li[1]")));
                IWebElement optionElement = webDriver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[1]"));
                //li[@role='option' and contains(text(),'Material')]
                //*[@id="TypeCode_listbox"]/li[1]
                Boolean isDisplayed = optionElement.Displayed;
                Console.WriteLine("typeCode is M, Displayed = " + isDisplayed);
                optionElement.Click();

            }
            else if (typeCode.Equals("T"))
            {
                Thread.Sleep(1000);
                IWebElement optionElement = webDriver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[2]"));
                //WebDriverWait waitOptionElement = new WebDriverWait(webDriver, timeWaiting);
                //IWebElement optionElement = waitOptionElement.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='TypeCode_listbox']/li[2]")));

                Boolean isDisplayed = optionElement.Displayed;
                Console.WriteLine("typeCode is T, Displayed = " + isDisplayed);
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

            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromMilliseconds(1000));
            IWebElement ePrice = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("Price")));
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
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromMilliseconds(1000));
            IWebElement deleteRecord = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
            deleteRecord.Click();

            //Click the alert pop-up
            IAlert alert = webDriver.SwitchTo().Alert();
            Thread.Sleep(1000);
            //webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(10000);
            alert.Accept();
        }

        //Go to the last page
        public void GoToLastPage(IWebDriver webDriver)
        {
            Thread.Sleep(1000);
            webDriver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span")).Click();
        }

        //Get the last record Code
        public String GetLastRecordCode(IWebDriver webDriver)
        {
            var getCode = webDriver.FindElement(By.XPath(".//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            return getCode.Text;
        }

        //Get the last record TypeCode
        public String GetLastRecordTypeCode(IWebDriver webDriver)
        {
            var getTypeCode = webDriver.FindElement(By.XPath(".//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[2]"));
            return getTypeCode.Text;
        }

        //Get the last record Description
        public String GetLastRecordDescription(IWebDriver webDriver)
        {
            var getDescripiton = webDriver.FindElement(By.XPath(".//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            return getDescripiton.Text;

        }

        //Get the last record Price
        public String GetLastRecordPrice(IWebDriver webDriver)
        {
            var getPrice = webDriver.FindElement(By.XPath(".//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));
            Console.WriteLine("getPrice = " + getPrice.Text);
            return getPrice.Text;
        }

        /* Format Price
         * @param price The price to be formated, 10000.123
         * @return In the format of $10,000.12
         */
        public String FormatPrice(String price)
        {
            String[] priceStrs = price.Split('.', StringSplitOptions.RemoveEmptyEntries);
            String priceNum = priceStrs[0];
            StringBuilder stringBuilder = new StringBuilder();
            for (int index = priceNum.Length - 1; index >= 0; index--)
            {
                char c = priceNum[index];
                var len = priceNum.Length - index;
                if (len > 3 && len % 3 == 1)
                {
                    stringBuilder.Insert(0, ',');
                }
                stringBuilder.Insert(0, c);
            }
            stringBuilder.Insert(0, '$');
            String priceDecimal = (priceStrs.Length > 1) ? priceStrs[1] : "00";
            return stringBuilder.Append("." + priceDecimal.Substring(0, 2)).ToString();
        }

    }
}
