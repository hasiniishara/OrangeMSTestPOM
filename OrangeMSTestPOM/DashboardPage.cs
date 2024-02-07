using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeMSTestPOM
{
    public class DashboardPage
    {
        private readonly IWebDriver driver;

        public DashboardPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement AdminNaviBtn => driver.FindElement(By.XPath("//*[@id=\"menu_item_101\"]/span"));


        public AdminPage NavigateAdminModule() {
            AdminNaviBtn.Click();
            return new AdminPage(driver);
        }

    }
}
