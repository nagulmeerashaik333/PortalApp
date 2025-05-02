using AutomationPortal.Constants;
using AutomationPortal.DriverFactory;
using AutomationPortal.Utils;
using Microsoft.Playwright;
using NUnit.Framework;


namespace UIAutomationPortal.TestScripts
{
    [TestFixture]
    public class LoginTest : BaseTest
    {
        string? username = TestContext.Parameters[Property.Username];
        string? password = TestContext.Parameters[Property.Password];

        [Test]
        public async Task ValidateIfValidUserIsAbleToLogin()
        {
            ReportUtil.CreateTest("Login with valid username and valid password");
            ReportUtil.AssignCategory("Smoke");
            try
            {
                var portal = new Portal(page);
                await portal.LoginPage.LoginAsync(username, password);
            }
            catch (PlaywrightException ex)
            {
                Assert.Fail(ex.Message);
            }

        }

    }
}
