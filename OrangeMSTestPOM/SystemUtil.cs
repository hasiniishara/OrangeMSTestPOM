using Microsoft.Extensions.Configuration;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeMSTestPOM
{
    public static class SystemUtil
    {
        private static IWebDriver driver;
        private static IConfigurationRoot configuration;


        static SystemUtil()
        {
            // Set up configuration
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            configuration = builder.Build();
        }

        public static IWebDriver GetDriver()
        {
            if (driver == null)
            {
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            }
            return driver;
        }

        public static void OpenSystem()
        {
            GetDriver().Navigate().GoToUrl("https://devmini-trials711.orangehrmlive.com/");
        }

        public static string GetUsername(string userKey)
        {
            return configuration[$"{userKey}:Username"];
        }

        public static string GetPassword(string userKey)
        {
            return configuration[$"{userKey}:Password"];
        }


        public static void CloseDriver()
        {
            if (driver != null)
            {
                driver.Quit();
                driver = null;
            }
        }
    }
}
