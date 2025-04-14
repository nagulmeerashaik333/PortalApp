using AutomationPortal.GlobalConstants;
using AutomationPortal.TestData;
using AutomationPortal.Utils;
using NUnit.Framework;
using Microsoft.Playwright;
using UIAutomationPortal.LangaugeEnum;

namespace AutomationPortal.Tests
{
    [TestFixture]
    public class PortalApplication 
    {
        private IPage page;
        public PortalApplication(IPage page)
        {
            this.page = page;
        }
        string? username = TestContext.Parameters[Property.Username];
        string? password = TestContext.Parameters[Property.Password];

        [Test]
        public async Task LoginTest()
        {
            try
            {
                var dataRead = TestDataManager.GetTestData<TestDataManager.Data>("TestData/TestData.json");
                var portalApp = new PortalApp(page);
                await portalApp.LoginPage.Login(username, password);
            }
            catch (PlaywrightException ex)
            {
                Assert.Fail(string.Format(ex.Message, ex.StackTrace));
            }

        }

        [TestCase(Language.Default)]
        [TestCase(Language.Arabic)]
        [TestCase(Language.Spanish)]
        [Test]
        public async Task TC01_ValidatingAddressInformationPage(Language language)
        {
            try
            {
                var portalApp = new PortalApp(page);
                await portalApp.LoginPage.Login(username, password);
                await portalApp.AddressInformationPage.EnterFirstName("");
                switch (language)
                {
                    case Language.Default:
                        await portalApp.AddressInformationPage.EnterMiddleName("");
                        await portalApp.AddressInformationPage.EnterLastName("");
                        await portalApp.AddressInformationPage.EnterSecondlastName("");
                        break;
                }
                switch (language)
                {
                    case Language.Arabic:
                        await portalApp.AddressInformationPage.EnterLastName("");
                        break;
                }
                switch (language)
                {
                    case Language.Spanish:
                        await portalApp.AddressInformationPage.EnterMiddleName("");
                        break;
                }
                await portalApp.AddressInformationPage.SelectDistrict("");
                await portalApp.AddressInformationPage.SelectState("");
                await portalApp.AddressInformationPage.SelectDateOfBirth("");
                await portalApp.AddressInformationPage.SelectGender("");
                await portalApp.AddressInformationPage.SelectNationality("");
                await portalApp.AddressInformationPage.SelectRelegion("");
            }
            catch (PlaywrightException ex)
            {
                Assert.Fail(string.Format(ex.Message, ex.StackTrace));
            }

        }

    }

}
