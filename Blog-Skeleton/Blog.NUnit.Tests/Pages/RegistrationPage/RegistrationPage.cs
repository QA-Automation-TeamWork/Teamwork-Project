using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Blog.NUnit.Tests.Models;

namespace Blog.NUnit.Tests.Pages
{
    public partial class RegistrationPage : BasePage
    {
        public RegistrationPage(IWebDriver driver) : base(driver)
        {
        }

        public string URL
        {
            get
            {
                return base.url + "Account/Register/";
            }
        }

        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl(this.URL);
        }

        public void OpenFillSubmitRegistrationForm(RegisterUser user)
        {
            Driver.Navigate().GoToUrl(this.URL);
            EnterText(Email, user.Email);
            EnterText(FullName, user.FullName);
            EnterText(Password, user.Password);
            EnterText(ConfirmPassword, user.ConfirmPassword);
            RegisterBtn.Click();
        }

        public void OpenAndFillRegistrationFormWithoutEmail(RegisterUser user)
        {
            Driver.Navigate().GoToUrl(this.URL);
            EnterText(FullName, user.FullName);
            EnterText(Password, user.Password);
            EnterText(ConfirmPassword, user.ConfirmPassword);
        }
    }
}
