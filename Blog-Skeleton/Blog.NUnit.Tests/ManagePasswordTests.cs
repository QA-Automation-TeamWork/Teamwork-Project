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
            this.driver.Quit();
        }

        [Test]
        public void ChangePasswordwithInvalidCurrentPassword()
        {
            LoginUser user = AccessExcelData.GetTestData("ChangePasswordwithInvalidCurrentPassword");
            LoginPage loginPage = new LoginPage(driver);
            ManagePasswordPage managePage = new ManagePasswordPage(driver);

            loginPage.NavigateTo();
            loginPage.FillCredentials(user);
            managePage.FillSubmitPasswordData(user);
            Assert.AreEqual("Incorrect password.", managePage.ErrorIncorrectPassword.Text);
        }

    }
}