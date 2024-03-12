using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

internal class Program
{
    private static void Main(string[] args)
    {
        //Open Chrome browser
        IWebDriver driver = new ChromeDriver();
        driver.Manage().Window.Maximize();

        //Launch TurnUp portal and navigate to website login page
        driver.Navigate().GoToUrl("http://horse.industryconnect.io/");

        //Identify username textbox and enter valid username
        IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
        usernameTextbox.SendKeys("hari");

        //Identify password textbox and enter password
        IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
        passwordTextbox.SendKeys("123123");

        //Identify login button and click on Login Button
        IWebElement loginButton = driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
        loginButton.Click();

        //Check if the user has logged in successfully
        IWebElement helloHari = driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));
        if (helloHari.Text == "Hello hari!")
        {
            Console.WriteLine("User has logged in successfully");
        }
        else
        {
            Console.WriteLine("User has not logged in");
        }

        //Create a new Time record
        //Click on the Admin dropdown menu and navigate to Time and Material module
        IWebElement administrationDropdwon = driver.FindElement(By.XPath("//*[contains(text(),'Administration')]"));
        administrationDropdwon.Click();

        IWebElement timeAndMaterialOption = driver.FindElement(By.XPath("//a[contains(text(),'Time & Materials')]"));
        timeAndMaterialOption.Click();
        ///html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a

        //Click on the Create New button
        IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
        createNewButton.Click();
        ////a[contains(text(),'Create New')]

        //Select Time on TypeCode
        IWebElement typeCodeMainDropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span"));
        typeCodeMainDropdown.Click();
        Thread.Sleep(2000);
        IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
        typeCodeDropdown.Click();

        //Enter Code
        IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
        codeTextbox.SendKeys("CodeTest");

        //Enter Description
        IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
        descriptionTextbox.SendKeys("DescriptionTest");

        //Enter Price Unit
        IWebElement priceTextbox = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
        priceTextbox.SendKeys("10");

        //Click on Save
        IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
        saveButton.Click();

        Thread.Sleep(2000);

        //Check if the new time record has been created
        IWebElement goToTheLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
        goToTheLastPageButton.Click();

        IWebElement newRecordCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
        if (newRecordCode.Text == "CodeTest")
        {
            Console.WriteLine("New Time record has been created successfully");
        }
        else
        {
            Console.WriteLine("Test failed");
        }
    }
}