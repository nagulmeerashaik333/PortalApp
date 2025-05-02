using AutomationPortal.Utils;
using Microsoft.Playwright;
using UIAutomationPortal.LoginResultEnum;
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

        public async Task EnterEmailAsync(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("Email cannot be null or empty", nameof(email));
            var usernameElement = Locator(LoginPageLocators.Username);
            await HightlightElementAsync(usernameElement);
            await FillAsync(usernameElement, email);
        }
        public async Task EnterPasswordAsync(string password)
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentException("Password cannot be null or empty", nameof(password));
            var passwordElement = Locator(LoginPageLocators.Password);
            await HightlightElementAsync(passwordElement);
            await FillAsync(passwordElement, password);
        }
        public async Task ClickSignInAsync()
        {
            var clickSigninButton = Locator(LoginPageLocators.SignInButton);
            await HightlightElementAsync(clickSigninButton);
            await ClickAsync(clickSigninButton);

        }
        public async Task<LoginResult> LoginAsync(string? email, string? password)
        {
            await EnterEmailAsync(email);
            await EnterPasswordAsync(password);
            await ClickSignInAsync();
            return LoginResult.Success;
        }
    }
}
