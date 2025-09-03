using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TurnUpPortal.Pages;

public class Program
{
    public static void Main(string[] args)
    {
        //Open Chrome Browser
        ChromeOptions options = new ChromeOptions();
        options.AddUserProfilePreference("profile.password_manager_leak_detection", false);
        IWebDriver driver = new ChromeDriver(options);

        //Login page object initialization and definition
        LoginPage loginPageObj = new LoginPage();
        loginPageObj.LoginAction(driver);

        //Home page object intialization and defination
        HomePage homePageObj = new HomePage();
        homePageObj.NavigateToTMPage(driver);

        //TM Page object intialization and defination 
        TMPage tMPageObj = new TMPage();
        tMPageObj.CreateTimeRecord(driver);

        //Edit TM Record
        tMPageObj.EditTimeRecord(driver);

        //Delete TM Record
        tMPageObj.DeleteTimeRecord(driver);
    }    
}
