using Blog.NUnit.Tests.Models;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.NUnit.Tests.Pages
{
    public partial class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver)
            :base(driver)
        {
        }

        public string URL
        {
            get
            {
                return base.url + "Account/Login/";
            }
        }

        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl(this.URL);
        }

        public void FillCredentials(LoginUser user)
        {
            Type(Email, user.Username);
            Type(Password, user.Password);
            SubmitLoginBtn.Click();
        }
    }
}
