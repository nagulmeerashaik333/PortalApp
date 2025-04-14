using AutomationPortal.Tests;
using NUnit.Framework;
using UIAutomationPortal.LangaugeEnum;

namespace UIAutomationPortal.TestScripts
{
    [TestFixture]
    public class ReviewPersonalDetailPage : PortalApplication
    {
        //Language Specific TestScripts
        [Test]
        public async Task FillingPersonalDetailsWithDefaultLanguage()
        {
            await TC02_ValidatingAddressInformationPage(Language.Default);
        }

        [Test]
        public async Task FillingPersonalDetailsWithArabicLanguage()
        {
            await TC02_ValidatingAddressInformationPage(Language.Arabic);
        }

        [Test]
        public async Task FillingPersonalDetailsWithSpanishLanguage()
        {
            await TC02_ValidatingAddressInformationPage(Language.Spanish);
        }
    }
}
