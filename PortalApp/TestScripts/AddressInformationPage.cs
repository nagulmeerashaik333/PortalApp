using AutomationPortal.DriverFactory;
using AutomationPortal.Utils;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AutomationPortal.PageObjects.ObjectRepository;

namespace UIAutomationPortal
{
    public class AddressInformationPage : BaseUtil
    {
        public AddressInformationPage(IPage page) : base(page) { }
        
        public async Task EnterFirstName(string firstName)
        {
            var firstNameElement = Locator(LoginPageLocators.Username);
            await FillAsync(firstNameElement, firstName);
        }
        public async Task EnterMiddleName(string middleName)
        {

        }
        public async Task EnterLastName(string lastName)
        {

        }
        public async Task EnterSecondlastName(string secondLastName)
        {

        }
        public async Task SelectNationality(string nationality)
        {

        }
        public async Task SelectDateOfBirth(string dateOfBirth)
        {

        }
        public async Task SelectRelegion(string relegion)
        {

        }
        public async Task SelectGender(string gender)
        {

        }
        public async Task SelectState(string state)
        {

        }
        public async Task SelectDistrict(string district)
        {

        }

    }
}
