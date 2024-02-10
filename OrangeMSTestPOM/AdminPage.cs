using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeMSTestPOM
{
    //Create class
    public class AdminPage
    {
        //Create web driver object
        private readonly IWebDriver driver;

        //Create AdminPage Constructor
        public AdminPage(IWebDriver driver) { 
            this.driver = driver;
        }

        //Crate AdminPage web elements
        public IWebElement AdminHeader => driver.FindElement(By.XPath("//*[@id=\"topbar\"]/ul[1]/li/div"));
        public IWebElement JobSection => driver.FindElement(By.XPath("//*[@id=\"top_level_menu_item_menu_item_102\"]/a"));
        public IWebElement JobTitleSection => driver.FindElement(By.XPath("//*[@id=\"top_level_menu_item_menu_item_102\"]/sub-menu-container/div/div[2]/a"));
        public IWebElement AddJobTitleButton => driver.FindElement(By.XPath("//*[@id=\"jobTitlesDiv\"]/div[1]/a/i"));
        public IWebElement JobTitleText => driver.FindElement(By.Id("jobTitleName"));
        public IWebElement JobDescriptionText => driver.FindElement(By.Id("jobDescription"));
        public IWebElement JobNoteText => driver.FindElement(By.Id("note"));
        public IWebElement JobTitleSaveBtn => driver.FindElement(By.Id("modal-save-button"));

        //Verifying the AdminPage heading
        public void VerifyAdminHeading()
        {
            string AdminHeaderText = AdminHeader.Text;
            string ExpectedAdmin = "HR Administration";

            Assert.AreEqual(AdminHeaderText, ExpectedAdmin, "Admin heading doesn't match expected.");
        }

        //Add new job title to the system
        public void AddNewJobTitle(string job,string des, string note)
        {
            JobSection.Click();
            JobTitleSection.Click();
            AddJobTitleButton.Click();
            JobTitleText.SendKeys(job);
            JobDescriptionText.SendKeys(des);
            JobNoteText.SendKeys(note);
            JobTitleSaveBtn.Click();
            WaitForSuccessMessage();

        }

        //Checking the toast message
        private void WaitForSuccessMessage()
        {
            Console.WriteLine("Access message method");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //If Adding Success then Toast Message should appeared
            try
            {
                bool successMessageDisplayed = wait.Until(driver => (bool)((IJavaScriptExecutor)driver).ExecuteScript("return document.querySelector('.toast-message') !== null"));
                Console.WriteLine(successMessageDisplayed);
                Assert.IsTrue(successMessageDisplayed, "Job Title is not adding successfully");
                Console.WriteLine("Successfully Add new job title");
            }
            //If adding fail, then validation should appeared & toast message should not
            catch(WebDriverTimeoutException)
            {
                bool errorMessageDisplayed = driver.FindElements(By.XPath("//*[@id=\"modal-holder\"]/div/div/div/div[2]/form/oxd-decorator/div/div[1]/div[2]/span")).Any();
                Assert.IsTrue(errorMessageDisplayed, "Validation error message not displayed");
                Console.WriteLine("Duplicate Data Entry");
            }
        }
    }
}
