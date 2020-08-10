using System;
using System.Net;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TimeMaterialTestCases
{
    public class Tests
    {
        IWebDriver driver;
        WebHelper webHelper;

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver();
            webHelper = new WebHelper();
            webHelper.Login(driver, "hari", "123123");
        }

        [TearDown]
        public void CloseBrowser()
        {
            //driver.Close();
        }

        /*Check if the user is able to login with the valid username and password
         * The return string should be "Hello hari!"
         */
        //[Test]
        public void TEST_001_Login_With_Valid_Values()
        {
            String returnText = webHelper.Login(driver, "hari", "123123");
            Assert.AreEqual("Hello hari!", returnText);
        }

        /*Check if the user is able to create a new time record successfully with valid details
         * Expected: The returned the text equal
         */
        [Test]
        public void TEST_002_Create_New_Time_Record_With_Valid_Values()
        {          
            webHelper.JumpToTimeMaterialPage(driver);
            webHelper.JumpToCreateNewPage(driver);
            webHelper.ChangeTheRecordValues(driver, "T", "A AA T", "Add New Time", "123123");

            //Go to the last page
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span")).Click();

            //Get the last record code
            var getCode = driver.FindElement(By.XPath(".//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            Assert.AreEqual("A AA T", getCode.Text);

        }

        /*Check if the user is able to create a new material record successfully with valid details
        * No check
        */
        [Test]
        public void TEST_003_Create_New_Material_Record_With_Valid_Values()
        {
            webHelper.JumpToTimeMaterialPage(driver);
            webHelper.JumpToCreateNewPage(driver);
            webHelper.ChangeTheRecordValues(driver, "M", "A AA M", "Add New Mater", "987987");

            //Go to the last page
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span")).Click();

            //Get the last record code
            var getCode = driver.FindElement(By.XPath(".//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            Assert.AreEqual("A AA M", getCode.Text);
        }

        /*Check if the user is able to edit an existing record successfully with valid details
        * No check
        */
        [Test]
        public void TEST_004_Edit_Existing_Record_With_Valid_Values()
        {
            webHelper.JumpToTimeMaterialPage(driver);
            webHelper.JumpToTheNumbericEditPage(driver, 1);
            webHelper.ChangeTheRecordValues(driver, "M", "AA A E", "Editing", "456456");
            Console.WriteLine("Edit existing record successful");
        }

        /*Check if the user is able to edit an existing record successfully with valid details
        * No check
        */
        [Test]
        public void TEST_005_Delete_Existing_Record()
        {
            webHelper.JumpToTimeMaterialPage(driver);
            webHelper.DeleteTheNumbericRecord(driver, 1);
            Console.WriteLine("Delete existing record successful");
        }
    }
}