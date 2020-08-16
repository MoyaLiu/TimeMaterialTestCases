using System;
using NUnit.Framework;
using TimeMaterialTestCases.Helpers;
using TimeMaterialTestCases.Pages;

namespace TimeMaterialTestCases.Tests
{
    [TestFixture]
    [Parallelizable]
    public class EmployeesTestCases : CommonDriver
    {
        [Test, Description("Check if the user is able to create a new employee record successfully with valid details")]
        public void EM_001_Create_New_Employee_Record_With_Valid_Values()
        {
            HomePage homePage = new HomePage();
            Assert.AreEqual(true, homePage.NevigateToEmployeePage(driver));

            EmployeePage employeePage = new EmployeePage();
            Assert.AreEqual(true, employeePage.NevigateToCreateNewPage(driver));


        }

        [Test, Description("Check if the user is able to edit an existing employee record successfully with valid details")]
        public void EM_002_Edit_Existing_Record_With_Valid_Values()
        {
            HomePage homePage = new HomePage();
            Assert.AreEqual(true, homePage.NevigateToEmployeePage(driver));


        }

        [Test, Description("Check if the user is able to delete an existing employee record successfully")]
        public void EM_003_Delete_Existing_Record()
        {
            HomePage homePage = new HomePage();
            Assert.AreEqual(true, homePage.NevigateToEmployeePage(driver));

        }
    }
}
