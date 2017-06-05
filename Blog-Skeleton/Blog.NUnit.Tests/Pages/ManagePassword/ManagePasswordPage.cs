using Blog.NUnit.Tests.Models;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.NUnit.Tests.Pages
{
    public partial class ManagePasswordPage: BasePage
    {
        public ManagePasswordPage(IWebDriver driver)
            :base(driver)
        {
        }

        public string URL
        {
            get
            {
                return base.url + "Manage";
            }
        }

        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl(this.URL);

        }

        public void FillSubmitPasswordData(LoginUser user)
        {
            UserManagement.Click();
            changePasswordBtn.Click();
            Type(CurrentPassword, user.CurrentPassword);
            Type(NewPassword, user.NewPassword);
            Type(ConfirmPassword, user.ConfirmNewPassword);
            SubmitPasswordChange.Click();
        }
    }
}
