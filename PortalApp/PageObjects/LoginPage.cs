using AutomationPortal.DriverFactory;
using AutomationPortal.GlobalConstants;
using AutomationPortal.Utils;
using Microsoft.CodeAnalysis;
using Microsoft.Playwright;
using NUnit.Framework;
using static AutomationPortal.PageObjects.ObjectRepository;

namespace AutomationPortal.PageObjects
{
    public class LoginPage : BaseUtil
    {
        private IPage _page;
        public LoginPage(IPage page) : base(page)
        {
            this._page = page;
        }

        public async Task EnterEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("Email cannot be null or empty", nameof(email));
            }
            var usernameElement = Locator(LoginPageLocators.Username);
            //await HightlightElementAsync(usernameElement);
            await FillAsync(usernameElement, email);
        }
        public async Task EnterPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Password cannot be null or empty", nameof(password));
            }
            var passwordElement = Locator(LoginPageLocators.Password);
            //await HightlightElementAsync(passwordElement);
            await FillAsync(passwordElement, password);
        }
        public async Task ClickSignIn()
        {
            var clickSigninButton = Locator(LoginPageLocators.SignInButton);
            //await HightlightElementAsync(clickSigninButton);
            await ClickAsync(clickSigninButton);
            
        }
        public async Task Login(string? email, string? password)
        {
            await EnterEmail(email);
            await EnterPassword(password);
            await ClickSignIn();
            
        }
        //public async Task Login(string username, string password, string secretKey)
        //{
        //    await EnterEmail(username);
        //    await EnterPassword(password);
        //    await ClickSignIn();
        //}
        private async Task PassThroughLogin()
        {
            BaseTest baseTest = new BaseTest();
            await baseTest.GoToUrl();
        }
    }
}
