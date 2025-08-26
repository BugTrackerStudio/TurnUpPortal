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
        Thread.Sleep(2000);

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
        Thread.Sleep(5000);

        //check if the time record has been created successfully
        /*IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
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
        }*/


        //edit a time record

        //click on Edit button
        //IWebElement editButton = driver.FindElement(By.XPath("//a[contains(@class,'k-grid-Edit')]"));
        IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[1]/td[5]/a[1]"));
        editButton.Click();
        Thread.Sleep(2000);

        //edit a Time or Material Record Dropdown menu
        IWebElement editTypeCodeDropDown = driver.FindElement(By.XPath("//form[@id='TimeMaterialEditForm']//span[text()='select']"));
        editTypeCodeDropDown.Click();

        IWebElement editTimeOption = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[1]"));
        editTimeOption.Click();

        /*IWebElement typeDropdown = driver.FindElement(By.XPath("//span[@class='k-input']"));

        // Read the currently selected value
        string currentValue = typeDropdown.Text;
        Console.WriteLine("Current selected value: " + currentValue);

        // Logic: swap Time and Material
        if (currentValue == "Time")
        {
            Console.WriteLine("Time is selected → change to Material");

            // Click the dropdown to open
            typeDropdown.Click();
            Thread.Sleep(1000);

            // Select Material
            IWebElement materialOption = driver.FindElement(By.XPath("//li[text()='Material']"));
            materialOption.Click();
        }
        else
        {
            Console.WriteLine("Material is selected → change to Time");

            // Click the dropdown to open
            typeDropdown.Click();
            Thread.Sleep(1000);
            // Select Time
            IWebElement editTimeOption = driver.FindElement(By.XPath("//li[text()='Time']"));
            editTimeOption.Click();
        }

        Thread.Sleep(3000); // Wait for selection to register*/

        /*
         * Final logic 
         * IWebElement typeDropdown = driver.FindElement(By.XPath("//span[@class='k-input']"));
        string currentValue = typeDropdown.Text;
        Console.WriteLine("Current selected value: " + currentValue);

        // Determine the target value
        string targetValue = (currentValue == "Time") ? "Material" : "Time";

        // Only change if different
        if (currentValue != targetValue)
        {
            typeDropdown.Click();
            Thread.Sleep(1500);

            IWebElement optionToSelect = driver.FindElement(By.XPath($"//li[text()='{targetValue}']"));
            optionToSelect.Click();
            Console.WriteLine("Updated selected value: " + targetValue);

            Thread.Sleep(2500);
        }
        else
        {
            Console.WriteLine("Dropdown already has the target value. No change needed.");
            Thread.Sleep(1000);
        } */

        //edit code into codeTextBox
        IWebElement editCodeTextBox = driver.FindElement(By.Id("Code"));
        editCodeTextBox.Clear();
        editCodeTextBox.SendKeys("Edit TA Kruti");
        Thread.Sleep(2000);

        //edit Description into Description Textbox
        IWebElement editDescriptionTextBox = driver.FindElement(By.Id("Description"));
        editDescriptionTextBox.Clear();
        editDescriptionTextBox.SendKeys("This is a Edit description");
        Thread.Sleep(2000);

        //Edit price into the price textbox
        /*IWebElement editPriceTagOverlap = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
        editPriceTagOverlap.Click();

        IWebElement editPriceTextBox = driver.FindElement(By.Id("Price"));
        editPriceTextBox.Clear();
        editPriceTextBox.SendKeys("120");*/

        //Click on Save Button
        IWebElement editSaveButton = driver.FindElement(By.Id("SaveButton"));
        editSaveButton.Click();
        Thread.Sleep(2000);



        //Delete Time Record 

        //Navigate to the last page of grid 
        IWebElement llastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
        llastPageButton.Click();
        Thread.Sleep(3000);

        //click delete button of the last row
        IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
        deleteButton.Click();
        Thread.Sleep(1500);

        //Click OK to delete
        //Handle the alert
        driver.SwitchTo().Alert().Accept();
        Thread.Sleep(3000);

        //Refresh the page
        driver.Navigate().Refresh();
        Thread.Sleep(4000);

        //Check if the record is deleted (Go to last page again)
        IWebElement lastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
        lastPageButton.Click();

        IWebElement deletedCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

        if (deletedCode.Text != "TA Programme Kruti")
        {
            Console.WriteLine("Record deleted successfully");
        }
        else
        {
            Console.WriteLine("Record has not been delete.");
        }
    }
}
