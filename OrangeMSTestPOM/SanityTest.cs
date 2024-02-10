namespace OrangeMSTestPOM
{
    [TestClass]
    public class SanityTest
    {
        //Create Page Objects
        private static LoginPage loginPage;
        private static DashboardPage dashboardPage;
        private static AdminPage adminPage;

        [TestInitialize]
        public void SetUp()
        {
            // Initialize WebDriver
            SystemUtil.OpenSystem();
            loginPage = new LoginPage(SystemUtil.GetDriver());
            dashboardPage = new DashboardPage(SystemUtil.GetDriver());
            adminPage = new AdminPage(SystemUtil.GetDriver());
        }

        [TestMethod]
        [TestCategory("LoginPageTest")]
        [Priority(1)]
        public void LoginTest()
        {
            // Perform login
            dashboardPage = loginPage.Login("AdminUser");
            Assert.IsTrue(SystemUtil.GetDriver().Url.Contains("https://devmini-trials711.orangehrmlive.com/client/#/dashboard"));
            Console.WriteLine("Successfully logged in.");
        }

        [TestMethod]
        [TestCategory("AdminPageTest")]
        [Priority(2)]
        public void NavigateToAdminModuleTest()
        {
            // Perform login
            dashboardPage = loginPage.Login("AdminUser");
            // Navigate to admin module
            adminPage = dashboardPage.NavigateAdminModule();
            adminPage.VerifyAdminHeading();

            Console.WriteLine("Successfully navigated to Admin module.");
        }
        //Verifying New Job Title Adding
        [TestMethod]
        [TestCategory("AdminPageTest")]
        [Priority(3)]
        public void VerifyJobTitleAdd()
        {
            dashboardPage = loginPage.Login("AdminUser");
            adminPage = dashboardPage.NavigateAdminModule();
            adminPage.AddNewJobTitle("HasQA1","This is a test job title","Need to add to assign new employee");
            Console.WriteLine("Successfully Add new job title");
        }

        [TestCleanup]
        public void TearDown()
        {
            // Clean up WebDriver
            SystemUtil.CloseDriver();
        }
    }
}