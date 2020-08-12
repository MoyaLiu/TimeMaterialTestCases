using System;
using System.Net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TimeMaterialTestCases.Helpers;
using TimeMaterialTestCases.Pages;

namespace TimeMaterialTestCases
{
    [TestFixture]
    [Parallelizable]
    public class TMTestCases : CommonDriver
    {

        [Test, Description("Check if the user is able to create a new time record successfully with valid details")]
        public void TM_001_Create_New_Time_Record_With_Valid_Values()
        {
            HomePage homePage = new HomePage();
            homePage.NevigateToTMPage(driver);

            TMPage tMPage = new TMPage();
            tMPage.NevigateToCreateNewPage(driver);
            tMPage.EditTheRecordValues(driver, "T", "A AA T", "Add New Time", "123123");

            //Validate
            tMPage.GoToLastPage(driver);
            Assert.AreEqual("A AA T", tMPage.GetLastRecordCode(driver));
            Assert.AreEqual("T", tMPage.GetLastRecordTypeCode(driver));
            Assert.AreEqual("Add New Time", tMPage.GetLastRecordDescription(driver));
            Assert.AreEqual(Tools.FormatPrice("123123"), tMPage.GetLastRecordPrice(driver));
        }

        [Test, Description("Check if the user is able to create a new material record successfully with valid details")]
        public void TM_002_Create_New_Material_Record_With_Valid_Values()
        {
            HomePage homePage = new HomePage();
            homePage.NevigateToTMPage(driver);

            TMPage tMPage = new TMPage();
            tMPage.NevigateToCreateNewPage(driver);
            tMPage.EditTheRecordValues(driver, "M", "A AA M", "Add New Mater", "987987.12");

            //Validate
            tMPage.GoToLastPage(driver);
            Assert.AreEqual("A AA M", tMPage.GetLastRecordCode(driver));
            Assert.AreEqual("M", tMPage.GetLastRecordTypeCode(driver));
            Assert.AreEqual("Add New Mater", tMPage.GetLastRecordDescription(driver));
            Assert.AreEqual(Tools.FormatPrice("987987.12"), tMPage.GetLastRecordPrice(driver));
        }

        [Test, Description("Check if the user is able to edit an existing record successfully with valid details")]
        public void TM_003_Edit_Existing_Record_With_Valid_Values()
        {
            HomePage homePage = new HomePage();
            homePage.NevigateToTMPage(driver);

            TMPage tMPage = new TMPage();
            tMPage.NevigateToTheNumbericEditPage(driver, 2);
            tMPage.EditTheRecordValues(driver, "M", "AA A E", "Editing", "456456");

            //Validate
            Assert.AreEqual("AA A E", tMPage.GetTheNumbericRecordCode(driver, 2));
            Assert.AreEqual("M", tMPage.GetTheNumbericRecordTypeCode(driver, 2));
            Assert.AreEqual("Editing", tMPage.GetTheNumbericRecordDescription(driver, 2));
            Assert.AreEqual(Tools.FormatPrice("456456"), tMPage.GetTheNumbericRecordPrice(driver, 2));
        }

        [Test, Description("Check if the user is able to delete an existing record successfully")]
        public void TM_004_Delete_Existing_Record()
        {
            HomePage homePage = new HomePage();
            homePage.NevigateToTMPage(driver);

            //Precondition:press edit to save the record url.
            TMPage tMPage = new TMPage();
            tMPage.NevigateToTheNumbericEditPage(driver, 1);
            var recordURL = WebHelper.GetCurrentPageURL(driver, 5, By.XPath("//*[@id='container']/h2"));
            Console.WriteLine("Record url is " + recordURL);
            WebHelper.WaitClickable(driver, "XPath", "//*[@id='container']/div/a", 10);
            WebHelper.FindElement(driver, By.XPath("//*[@id='container']/div/a")).Click();

            //Delete the record
            tMPage.DeleteTheNumbericRecord(driver, 1);

            //Validate
            driver.Navigate().GoToUrl(recordURL);
            var noRecordText = WebHelper.FindElement(driver, By.XPath("/html/body"));
            Assert.AreEqual("The resource you are looking for has been removed, had its name changed, or is temporarily unavailable.", noRecordText.Text);
        }

        //[Test]
        public void TestParseString()
        {
            TMPage tMPage = new TMPage();
            var formated = Tools.FormatPrice("10000.123");
            Assert.AreEqual(formated, "$10,000.12");
        }

        //[Test]
        public void TestParseString2()
        {
            TMPage tMPage = new TMPage();
            var formated = Tools.FormatPrice("10000");
            Assert.AreEqual(formated, "$10,000.00");
        }
    }
}