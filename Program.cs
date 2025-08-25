using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class Program
    {
        public static void Main(string[] args)
        {
        //Open Chrome Browser
        ChromeOptions options = new ChromeOptions();
        options.AddUserProfilePreference("profile.password_manager_leak_detection", false);
        IWebDriver driver = new ChromeDriver(options);

        //driver = variable name (memory reference of the chromeDriver)
        //ChromeDriver = object name (anyname is fine)
        /*IWebDriver = means interface provided by Selenium
         * Think of an interface as a "contract" that says what methods/properties a class must have.
         * In this case, IWebDriver defines the standard browser automation actions 
         * (like .Navigate(), .FindElement(), .Quit(), etc.).
        */

        //launch TurnUpPortal 
        driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login");
        driver.Manage().Window.Maximize();
        Thread.Sleep(1000);

        //Identify username textbox and enter valid username
        IWebElement userNameTextBox = driver.FindElement(By.Id("UserName"));
        userNameTextBox.SendKeys("hari");

        //Identify password textbox and enter valid password
        IWebElement passwordTextBox = driver.FindElement(By.Id("Password"));
        passwordTextBox.SendKeys("123123");

        //Identify login button and click on it
        IWebElement loginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
        loginButton.Click();
        Thread.Sleep(2000);

        //Check if user has logged in successfully
        IWebElement helloHari = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));

        if (helloHari.Text == "Hello hari!")
        {
            Console.WriteLine("User has logged in successfully. Test Passed!");
        }
        else
        {
            Console.WriteLine("User has not logged in. Test failed!");
        }

        //Create a Time Record

        //Naviagte to Time and Material Page
        IWebElement administrationTab = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
        administrationTab.Click();

        IWebElement timeAndMaterialOption = driver.FindElement(By.XPath("//a[text()='Time & Materials']"));
        timeAndMaterialOption.Click();

        //Click on Create new button
        IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
        createNewButton.Click();

        //Select a Time from the dropDown
        IWebElement typeCodeDropDown = driver.FindElement(By.XPath("//form[@id='TimeMaterialEditForm']//span[text()='select']"));
        //IWebElement typeCodeDropDown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
        typeCodeDropDown.Click();

        //IWebElement timeOption = driver.FindElement(By.XPath("//form[@id='TimeMaterialEditForm']//span[text()='Time']"));
        IWebElement timeOption = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[1]"));
        timeOption.Click();

        //Type code into code TextBox
        IWebElement codeTextBox = driver.FindElement(By.Id("Code"));
        codeTextBox.SendKeys("TA Programme Kruti");

        //Type Description into Description Textbox
        IWebElement descriptionTextBox = driver.FindElement(By.Id("Description"));
        descriptionTextBox.SendKeys("This is a description");

        //Type price into the price textbox
        //Note:- the class might have multiple values (like k-formatted-value k-input).to avoid exact match problems using contains()
        IWebElement priceTagOverlap = driver.FindElement(By.XPath("//form[@id='TimeMaterialEditForm']//input[contains(@class,'k-formatted-value')]"));

        //IWebElement priceTagOverlap = driver.FindElement(By.XPath("//form[@id='TimeMaterialEditForm']//input[@class='k-formatted-value k-input']"));

        //IWebElement priceTagOverlap = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
        priceTagOverlap.Click();

        IWebElement priceTextBox = driver.FindElement(By.Id("Price"));
        priceTextBox.SendKeys("12");

        //Click on Save Button
        IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
        saveButton.Click();

        //check if the time record has been created successfully
        IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
        goToLastPageButton.Click();
        Thread.Sleep(3000);

        IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

        if(newCode.Text == "TA Programme Kruti")
        {
            Console.WriteLine("Time record created successfully!");
        }
        else
        {
            Console.WriteLine("New Time record has not been created!");
        }

    }
}
