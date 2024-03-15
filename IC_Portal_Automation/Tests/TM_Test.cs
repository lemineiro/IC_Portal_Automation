using IC_Portal_Automation.Pages;
using IC_Portal_Automation.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace IC_Portal_Automation.Tests
{
    [TestFixture]
    public class TM_Test : CommonDriver
    {

        [OneTimeSetUp]
        public void LoginFunction()
        {
            driver = new ChromeDriver();

            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginActions(driver, "hari", "123123");

            HomePage homePageObj = new HomePage();
            //homePageObj.VerifyLoggedInUser(driver);
            homePageObj.NavigateToTMPage(driver);
        }

        [Test, Order(1), Description("This test creates a new record")]
        public void CreateTM_Test()
        {
            TMPage tMPageObj = new TMPage();
            tMPageObj.CreateTMRecord(driver);
        }

        [Test, Order(2), Description("This test edits a record")]
        public void EditTM_Test()
        {
            TMPage tMPageObj = new TMPage();
            tMPageObj.EditTMRecord(driver);
        }

        [Test, Order(3), Description("This test deletes a record")]
        public void DeleteTM_Test()
        {
            TMPage tMPageObj = new TMPage();
            tMPageObj.DeleteTMRecord(driver);
        }

        [TearDown]
        public void CloseTestRun()
        {
            driver.Quit();
        }
    }
}