using AutomationPortal.DriverFactory;
using AutomationPortal.Tests;
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
            PortalApplication portalApplication = new PortalApplication(page);
            await portalApplication.TC01_ValidatingAddressInformationPage(Language.Default);
        }

        //[Test]
        //public async Task FillingPersonalDetailsWithArabicLanguage()
        //{
        //    PortalApplication portalApplication = new PortalApplication(page);
        //    await portalApplication.TC02_ValidatingAddressInformationPage(Language.Arabic);
        //}
    }
}
