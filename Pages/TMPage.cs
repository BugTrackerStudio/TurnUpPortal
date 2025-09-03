using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnUpPortal.Utilities;

namespace TurnUpPortal.Pages
{
    public class TMPage
    {
        public void CreateTimeRecord(IWebDriver driver)
        {
            //Click on Create new button
            IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            createNewButton.Click();

            //Select a Time from the dropDown
            IWebElement typeCodeDropDown = driver.FindElement(By.XPath("//form[@id='TimeMaterialEditForm']//span[text()='select']"));
            typeCodeDropDown.Click();
            Thread.Sleep(2000);

            IWebElement timeOption = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[1]"));
            timeOption.Click();

            //Type code into code TextBox
            IWebElement codeTextBox = driver.FindElement(By.Id("Code"));
            codeTextBox.SendKeys("TA Programme Kruti");

            //Type Description into Description Textbox
            IWebElement descriptionTextBox = driver.FindElement(By.Id("Description"));
            descriptionTextBox.SendKeys("This is a description");

            //Type price into the price textbox
            IWebElement priceTagOverlap = driver.FindElement(By.XPath("//form[@id='TimeMaterialEditForm']//input[contains(@class,'k-formatted-value')]"));
            priceTagOverlap.Click();

            IWebElement priceTextBox = driver.FindElement(By.Id("Price"));
            priceTextBox.SendKeys("12");

            WaitHelpers.WaitToBeClickable(driver, "Id", "SaveButton", 3);
            //Click on Save Button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Thread.Sleep(5000);

            /******Last Page check the Record has been Successfully Created****/
            //check if the time record has been created successfully
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            Thread.Sleep(3000);

            IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            if (newCode.Text == "TA Programme Kruti")
            {
                Console.WriteLine("Time record created successfully!");
            }
            else
            {
                Console.WriteLine("New Time record has not been created!");
            }
        }

        public void EditTimeRecord(IWebDriver driver)
        {
            //click on Edit button
            IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[1]/td[5]/a[1]"));
            editButton.Click();
            Thread.Sleep(2000);

            //edit a Time or Material Record Dropdown menu
            IWebElement editTypeCodeDropDown = driver.FindElement(By.XPath("//form[@id='TimeMaterialEditForm']//span[text()='select']"));
            editTypeCodeDropDown.Click();

            IWebElement editTimeOption = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[1]"));
            editTimeOption.Click();

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
            IWebElement editPriceTagOverlap = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            editPriceTagOverlap.Click();

            IWebElement editPriceTextBox = driver.FindElement(By.Id("Price"));
            editPriceTextBox.Clear();
            editPriceTagOverlap.Clear();
            editPriceTagOverlap.SendKeys("120");

            //Click on Save Button
            IWebElement editSaveButton = driver.FindElement(By.Id("SaveButton"));
            editSaveButton.Click();
            Thread.Sleep(2000);
        }

        public void DeleteTimeRecord(IWebDriver driver) 
        {
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
}
