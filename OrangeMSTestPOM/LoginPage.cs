using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeMSTestPOM
{
    //class creating
    public class LoginPage
    {
        private readonly IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement UserName => driver.FindElement(By.Id("txtUsername"));
        public IWebElement UserPassword => driver.FindElement(By.Id("txtPassword"));
        public IWebElement LoginButton => driver.FindElement(By.XPath("//*[@id=\"frmLogin\"]/div[4]/button"));

        public DashboardPage Login(string userKey)
        {
            string UName = SystemUtil.GetUsername(userKey);
            string UPassword = SystemUtil.GetPassword(userKey);

            UserName.SendKeys(UName);
            UserPassword.SendKeys(UPassword);
            LoginButton.Click();

            return new DashboardPage(driver);
        }

    }
}
