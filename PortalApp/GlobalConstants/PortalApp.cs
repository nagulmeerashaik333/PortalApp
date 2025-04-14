using AutomationPortal.PageObjects;
using Microsoft.Playwright;
using UIAutomationPortal;
using UIAutomationPortal.PageObjects;


namespace AutomationPortal.GlobalConstants
{
    public class PortalApp
    {
        internal IPage _page;
        public PortalApp(IPage page)
        {
            this._page = page;
        }
        public LoginPage LoginPage => this.GetElement<LoginPage>(_page);
        public OnboardingPage OnboardingPage=>this.GetElement<OnboardingPage>(_page);
        public AddressInformationPage AddressInformationPage=>this.GetElement<AddressInformationPage>(_page);
        
        public T GetElement<T>(IPage page)
        {
            return (T)Activator.CreateInstance(typeof(T), new object[] { page });
        }
    }
}

