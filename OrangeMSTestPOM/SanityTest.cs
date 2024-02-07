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
        private static AdminPage adminPage;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            SystemUtil.OpenSystem();

            loginPage = new LoginPage(SystemUtil.GetDriver());
            dashboardPage = new DashboardPage(SystemUtil.GetDriver());
            adminPage = new AdminPage(SystemUtil.GetDriver());
        }

        [TestMethod]
        [TestCategory("LoginPageTest")]
        public void LoginTest()
        {
            dashboardPage = loginPage.Login("AdminUser");
            Assert.IsTrue(SystemUtil.GetDriver().Url.Contains("https://devmini-trials711.orangehrmlive.com/client/#/dashboard"));
            Console.WriteLine("Successfully login to the system");
        }

        [TestMethod]
        [TestCategory("AdminPageTest")]

        public void LoginAdminModuleTest()
        {
            adminPage = dashboardPage.NavigateAdminModule();
            adminPage.VerifyAdminHeading();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            SystemUtil.CloseDriver();
        }

    }
}
