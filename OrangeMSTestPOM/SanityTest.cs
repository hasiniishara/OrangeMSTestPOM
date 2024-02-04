using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeMSTestPOM
{
    [TestClass]
    public class SanityTest
    {
        private static LoginPage loginPage;
        private static DashboardPage dashboardPage;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            SystemUtil.OpenSystem();

            loginPage = new LoginPage(SystemUtil.GetDriver());
            dashboardPage = new DashboardPage(SystemUtil.GetDriver());
        }

        [TestMethod]
        public void LoginTest()
        {
            dashboardPage = loginPage.Login("AdminUser");
            Assert.IsTrue(SystemUtil.GetDriver().Url.Contains("https://devmini-trials711.orangehrmlive.com/client/#/dashboard"));
            Console.WriteLine("Successfully login to the system");
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            SystemUtil.CloseDriver();
        }

    }
}
