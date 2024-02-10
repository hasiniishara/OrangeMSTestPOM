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
        
        //Verifying the AdminPage heading
        public void VerifyAdminHeading()
        {
            string AdminHeaderText = AdminHeader.Text;
            string ExpectedAdmin = "HR Administration";

            Assert.AreEqual(AdminHeaderText, ExpectedAdmin, "Admin heading doesn't match expected.");
        }
    }
}
