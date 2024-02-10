using OpenQA.Selenium;
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
        public IWebElement JobSection => driver.FindElement(By.Id("menu_admin_Job"));
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
        public void AddNewJobTitle()
        {

        }
    }
}
