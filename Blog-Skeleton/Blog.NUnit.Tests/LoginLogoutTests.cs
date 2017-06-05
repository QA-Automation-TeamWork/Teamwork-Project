using Blog.NUnit.Tests.Models;
using Blog.NUnit.Tests.Pages;
using Blog.NUnit.Tests.Seleno;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.NUnit.Tests
{
    [TestFixture]
    class LoginLogoutTests
    {
        public IWebDriver driver;

        [SetUp]
        public void Init()
        {
            this.driver = BrowserHost.Instance.Application.Browser;
        }

        [Test]
        [AuthorAttribute("Ginka Kyoseva")]
        [Property("LoginLogout", 1)]
        public void LoginWithRememberMeCheck()
        {
            LoginUser user = AccessExcelData.GetLoginData("LoginWithRememberMeCheck");
            LoginPage loginPage = new LoginPage(driver);

            loginPage.NavigateTo();
            loginPage.LogOut();
            loginPage.FillCredentialsWithRememberMe(user);

            Assert.AreEqual("Hello user1@abv.bg!", loginPage.LoggedUserMessage.Text);
        }

        [Test]
        [AuthorAttribute("Ginka Kyoseva")]
        [Property("LoginLogout", 1)]
        public void LogoutOfBlog()
        {
            LoginUser user = AccessExcelData.GetLoginData("LogoutOfBlog");
            LoginPage loginPage = new LoginPage(driver);

            loginPage.NavigateTo();
            loginPage.FillCredentialsWithRememberMe(user);
            loginPage.LogOut();

            Assert.AreEqual("Log in", loginPage.LoginButton.Text);
        }

        [Test]
        [AuthorAttribute("Ginka Kyoseva")]
        [Property("LoginLogout", 1)]
        public void LoginWithInvalidEmailAndValidPassword()
        {
            LoginUser user = AccessExcelData.GetLoginData("LoginWithInvalidEmailAndValidPassword");
            LoginPage loginPage = new LoginPage(driver);

            loginPage.NavigateTo();
            loginPage.FillCredentialsWithRememberMe(user);

            Assert.AreEqual("The Email field is not a valid e-mail address.", loginPage.InvalidEmailMessage.Text);
        }

        [Test]
        [AuthorAttribute("Ginka Kyoseva")]
        [Property("LoginLogout", 1)]
        public void LoginWithValidEmailAndInvalidPassword()
        {
            LoginUser user = AccessExcelData.GetLoginData("LoginWithValidEmailAndInvalidPassword");
            LoginPage loginPage = new LoginPage(driver);

            loginPage.NavigateTo();
            loginPage.FillCredentialsWithRememberMe(user);

            Assert.AreEqual("Invalid login attempt.", loginPage.InvalidPasswordMessage.Text);
        }

        [Test]
        [AuthorAttribute("Ginka Kyoseva")]
        [Property("LoginLogout", 1)]
        public void LoginWithInvalidEmailAndInvalidPassword()
        {
            LoginUser user = AccessExcelData.GetLoginData("LoginWithInvalidEmailAndInvalidPassword");
            LoginPage loginPage = new LoginPage(driver);

            loginPage.NavigateTo();
            loginPage.FillCredentialsWithRememberMe(user);

            Assert.AreEqual("The Email field is not a valid e-mail address.", loginPage.InvalidEmailMessage.Text);
        }
    }
}
