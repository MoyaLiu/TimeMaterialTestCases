using System;
using System.Net;
using System.Threading;
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
            Assert.AreEqual(tMPage.FormatPrice("123123"), tMPage.GetLastRecordPrice(driver));
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
            Assert.AreEqual(tMPage.FormatPrice("987987.12"), tMPage.GetLastRecordPrice(driver));
        }

        [Test, Description("Check if the user is able to edit an existing record successfully with valid details")]
        public void TM_003_Edit_Existing_Record_With_Valid_Values()
        {
            HomePage homePage = new HomePage();
            homePage.NevigateToTMPage(driver);

            TMPage tMPage = new TMPage();
            tMPage.NevigateToTheNumbericEditPage(driver, 1);
            tMPage.EditTheRecordValues(driver, "M", "AA A E", "Editing", "456456");
            Console.WriteLine("Edit existing record successful");
        }

        [Test, Description("Check if the user is able to delete an existing record successfully")]
        public void TM_004_Delete_Existing_Record()
        {
            HomePage homePage = new HomePage();
            homePage.NevigateToTMPage(driver);

            TMPage tMPage = new TMPage();
            tMPage.DeleteTheNumbericRecord(driver, 1);
            Console.WriteLine("Delete existing record successful");
        }

        //[Test]
        public void TestParseString()
        {
            TMPage tMPage = new TMPage();
            var formated = tMPage.FormatPrice("10000.123");
            Assert.AreEqual(formated, "$10,000.12");
        }

        //[Test]
        public void TestParseString2()
        {
            TMPage tMPage = new TMPage();
            var formated = tMPage.FormatPrice("10000");
            Assert.AreEqual(formated, "$10,000.00");
        }
    }
}