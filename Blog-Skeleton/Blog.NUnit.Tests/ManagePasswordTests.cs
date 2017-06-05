using Blog.NUnit.Tests.Models;
using Blog.NUnit.Tests.Attributes;
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
    public class ManagePasswordTests
    {
        public IWebDriver driver;

        [SetUp]
        public void Init()
        {
            this.driver = BrowserHost.Instance.Application.Browser;
        }

        [TearDown]
        public void closeSession()
        {
            //this.driver.Quit();
        }

        [Test]
        [Author("Stoyan")]
        [Property("ManagePassword", 1)]
        [LogResultToFileAttribute]
        public void ChangePasswordwithInvalidCurrentPassword()
        {
            LoginUser user = AccessExcelData.GetTLoginUserData("ChangePasswordwithInvalidCurrentPassword");
            LoginPage loginPage = new LoginPage(driver);
            ManagePasswordPage managePage = new ManagePasswordPage(driver);

            loginPage.NavigateTo();
            loginPage.FillCredentials(user);
            managePage.FillSubmitPasswordData(user);
            Assert.AreEqual("Incorrect password.", managePage.ErrorIncorrectPassword.Text);
        }

        [Test]
        [Author("Stoyan")]
        [Property("ManagePassword", 1)]
        [LogResultToFileAttribute]
        public void ChangePasswordwithInvalidNewPassword()
        {
            LoginUser user = AccessExcelData.GetTLoginUserData("ChangePasswordwithInvalidNewPassword");
            LoginPage loginPage = new LoginPage(driver);
            ManagePasswordPage managePage = new ManagePasswordPage(driver);

            loginPage.NavigateTo();
            loginPage.FillCredentials(user);
            managePage.FillSubmitPasswordData(user);
            Assert.AreEqual("The New password field is required.", managePage.ErrorNewPasswordMissing.Text);
            Assert.AreEqual("The new password and confirmation password do not match.", managePage.ErrorPasswordsMismatch.Text);
        }

        [Test]
        [Author("Stoyan")]
        [Property("ManagePassword", 1)]
        [LogResultToFileAttribute]
        public void ChangePasswordwithoutConfirmedNewPassword()
        {
            LoginUser user = AccessExcelData.GetTLoginUserData("ChangePasswordwithoutConfirmedNewPassword");
            LoginPage loginPage = new LoginPage(driver);
            ManagePasswordPage managePage = new ManagePasswordPage(driver);

            loginPage.NavigateTo();
            loginPage.FillCredentials(user);
            managePage.FillSubmitPasswordData(user);
            Assert.AreEqual("The new password and confirmation password do not match.", managePage.ErrorPasswordsMismatch2.Text);
        }

    }
}