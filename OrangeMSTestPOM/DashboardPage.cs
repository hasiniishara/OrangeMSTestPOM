using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeMSTestPOM
{
    //Create Class
    public class DashboardPage
    {
        //Create web driver object
        private readonly IWebDriver driver;

        //Call DashboardPage Constructor
        public DashboardPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Create DashboardPage web elements
        public IWebElement AdminNaviBtn => driver.FindElement(By.XPath("//*[@id=\"menu_item_101\"]/span"));


        //Navigate to the Admin Module
        public AdminPage NavigateAdminModule() {
            AdminNaviBtn.Click();
            return new AdminPage(driver);
        }

    }
}
