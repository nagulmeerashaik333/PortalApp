using AutomationPortal.Constants;
using AutomationPortal.Settings;
using AutomationPortal.Utils;
using AventStack.ExtentReports;
using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
using NUnit.Framework;


namespace AutomationPortal.DriverFactory
{
    public class BaseTest : PageTest
    {
        public IBrowser browser;

        protected IPage page;

        private ExtentReports _extentReports;

        private string _timestamp;

        private IBrowserContext _browserContext;

        [OneTimeSetUp]
        public void InitializeExtentReport()
        {
            String timestamp = DateUtil.GetTimeStamp("yyyyMMddHHmmss");
            string projectRoot = TestContextUtil.GetProjectRootDir();
            string executionReportFolderPath = Path.Combine(projectRoot, TestContext.Parameters[Property.ExecutionReportsFolderPath]);
            string extentFilePath = Path.Combine(executionReportFolderPath, "Test_Execution_Report" + timestamp + ".html");
            _extentReports = ReportUtil.GetInstance(extentFilePath);
        }

        [SetUp]
        public async Task OpenBrowser()
        {
            _timestamp = DateUtil.GetTimeStamp("yyyyMMddHHmmss");
            browser = await OpenBrowser(TestContextUtil.GetBrowser());

            _browserContext = await browser.NewContextAsync(TestSettings.BrowserNewContextOptions()).ConfigureAwait(false);
            page = await _browserContext.NewPageAsync().ConfigureAwait(false);
        }

        [SetUp]
        public async Task GoToUrl()
        {
            string? url = TestContext.Parameters[Property.Url];
            await page.GotoAsync(url);
        }

        [TearDown]
        public async Task CloseBrowserInstance()
        {
            await page.CloseAsync();
            await _browserContext.CloseAsync();
            await browser.CloseAsync();
        }

        [TearDown]
        public async Task AfterTest()
        {
            ReportUtil.SetTheme(AventStack.ExtentReports.Reporter.Config.Theme.Dark);
            ReportUtil.AssignDevice(Environment.OSVersion.ToString());
            ReportUtil.AssignAuthor(Environment.UserName);
            string projectRoot = TestContextUtil.GetProjectRootDir();
            string screenshotsFolderPath = Path.Combine(projectRoot, TestContext.Parameters[Property.ScreenshotsFolderPath]);
            string testCaseName = TestContext.CurrentContext.Test.Name;
            string screenshotPath = Path.Combine(screenshotsFolderPath, testCaseName + _timestamp + ".png");
            await new BaseUtil(page).PageScreenshotAsync(screenshotPath);
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                ReportUtil.FailTest("Test failed");
                bool needScreenshotForFailedTests = bool.Parse(TestContext.Parameters[Property.ScreenshotsForFailedTests]);
                if (needScreenshotForFailedTests)
                    ReportUtil.AddScreenCaptureFromPath(screenshotPath);
            }
            else if (status == NUnit.Framework.Interfaces.TestStatus.Skipped)
            {
                ReportUtil.SkipTest("Test skipped");
            }
            else if (status == NUnit.Framework.Interfaces.TestStatus.Passed)
            {
                ReportUtil.PassTest("Test passed");
                bool needScreenshotForPassedTests = bool.Parse(TestContext.Parameters[Property.ScreenshotsForPassedTests]);
                if (needScreenshotForPassedTests)
                    ReportUtil.AddScreenCaptureFromPath(screenshotPath);
            }
        }

        [OneTimeTearDown]
        public void SaveReport()
        {
            if (_extentReports != null)
            {
                ReportUtil.Info("Test Ended");
                _extentReports.Flush();
            }
        }

        public async Task<IBrowser> OpenBrowser(string browser)
        {
            switch (browser.ToLower())
            {
                case "msedge":
                case "chrome":
                    return await Playwright.Chromium.LaunchAsync(TestSettings.BrowserTypeLaunchOptions());
                case "firefox":
                    return await Playwright.Firefox.LaunchAsync(TestSettings.BrowserTypeLaunchOptions());
                default:
                    throw new ArgumentException("Invalid browser name is given. Given browser is " + browser);
            }
        }

    }
}
