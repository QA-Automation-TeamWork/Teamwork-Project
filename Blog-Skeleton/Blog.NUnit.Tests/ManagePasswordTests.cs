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

        [Test] //demo test
        public void VerifyMainPage()
        {
            HomePage homePage = new HomePage(driver);
            homePage.NavigateTo();
            Assert.AreEqual("SOFTUNI BLOG", homePage.HeaderTitle.Text);

        }

        [Test] //demo test2
        public void GotoManagePassWithoutLoggedUser()
        {
            LoginUser user = new LoginUser("stoyanski@mail.com", "password");
            LoginPage loginPage = new LoginPage(driver);
            ManagePasswordPage managePage = new ManagePasswordPage(driver);

            managePage.NavigateTo();
            loginPage.FillCredentials(user);
            managePage.FillPasswordData();
            Assert.AreEqual("Change password", managePage.SubmitPasswordChange.Text);
        }

    }
}