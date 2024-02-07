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
    }
}
