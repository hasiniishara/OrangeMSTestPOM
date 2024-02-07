using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeMSTestPOM
{
    public class AdminPage
    {
        private readonly IWebDriver driver;

        public AdminPage(IWebDriver driver) { 
            this.driver = driver;
        }

        public IWebElement AdminHeader => driver.FindElement(By.XPath("//*[@id=\"topbar\"]/ul[1]/li/div"));
        
        public void VerifyAdminHeading()
        {
            string AdminHeaderText = AdminHeader.Text;
            string ExpectedAdmin = "HR Administration";

            Assert.AreEqual(AdminHeaderText, ExpectedAdmin, "Admin heading doesn't match expected.");
        }
    }
}
