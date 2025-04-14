using AutomationPortal.Utils;
using Microsoft.Playwright;
using static AutomationPortal.PageObjects.ObjectRepository;

namespace UIAutomationPortal.PageObjects
{
    public class OnboardingPage:BaseUtil
    {
        private IPage _page;
        public OnboardingPage(IPage page) : base(page)
        {
            this._page = page;
        }

        public async Task EnterFirstName(string firstName)
        {
            var firstNameElement = Locator(LoginPageLocators.Username);
            await FillAsync(firstNameElement, firstName);
        }
        public async Task EnterMiddleName(string middleName)
        {
            var middleNameElement = Locator(LoginPageLocators.Password);
            await FillAsync(middleNameElement,middleName);
        }
        public async Task ClickNext()
        {
            var nextButtonElement = Locator(LoginPageLocators.SignInButton);
            await ClickAsync(nextButtonElement);
        }
        
    }

}
