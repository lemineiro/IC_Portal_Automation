using IC_Portal_Automation.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace IC_Portal_Automation.Tests
{
    public class TM_Test
    {
        private static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();

            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginActions(driver, "hari", "123123");

            HomePage homePageObj = new HomePage();
            //homePageObj.VerifyLoggedInUser(driver);
            homePageObj.NavigateToTMPage(driver);

            TMPage tMPageObj = new TMPage();
            tMPageObj.CreateTMRecord(driver);
            tMPageObj.EditTMRecord(driver);
            tMPageObj.DeleteTMRecord(driver);
        }
    }
}