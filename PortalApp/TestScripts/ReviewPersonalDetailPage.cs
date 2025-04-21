using AutomationPortal.DriverFactory;
using AutomationPortal.Tests;
using AutomationPortal.Utils;
using NUnit.Framework;
using UIAutomationPortal.LangaugeEnum;

namespace UIAutomationPortal.TestScripts
{
    [TestFixture]
    public class ReviewPersonalDetailPage : BaseTest
    {
        [Test]
        public async Task FillingPersonalDetailsWithDefaultLanguage()
        {
            ReportUtil.CreateTest("Filling personal details with Default language");
            ReportUtil.AssignCategory("Smoke");
            PortalApplication portalApplication = new PortalApplication(page);
            await portalApplication.TC01_ValidateAddressInformationPage(Language.Default);
        }

        [Test]
        public async Task FillingPersonalDetailsWithArabictLanguage()
        {
            ReportUtil.CreateTest("Filling personal details with Arabic language");
            ReportUtil.AssignCategory("Smoke");
            PortalApplication portalApplication = new PortalApplication(page);
            await portalApplication.TC01_ValidateAddressInformationPage(Language.Arabic);
        }
    }
}
