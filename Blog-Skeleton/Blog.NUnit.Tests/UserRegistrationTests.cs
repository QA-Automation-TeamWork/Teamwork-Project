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
    public class UserRegistrationTests
    {
        public IWebDriver driver;

        [SetUp]
        public void Init()
        {
            this.driver = BrowserHost.Instance.Application.Browser;
        }

        [Test]
        [AuthorAttribute("Manoela")]
        [Property("RegistrationPage", 1)]
        public void ValidRegistration()
        {
            RegisterUser user = AccessExcelData.GetRegistrationData(TestContext.CurrentContext.Test.MethodName);
            RegistrationPage registrationPage = new RegistrationPage(driver);
            registrationPage.OpenAndFillRegistrationForm(user);
            
            Assert.IsTrue(registrationPage.loggOff.Contains("Log off"));
        }

        [Test]
        [AuthorAttribute("Manoela")]
        [Property("RegistrationPage",1)]
        public void AllFieldsAreRequiredToRegister()
        {
            RegistrationPage registrationPage = new RegistrationPage(driver);
            registrationPage.NavigateTo();
            registrationPage.RegisterBtn.Click();

            Assert.IsTrue(registrationPage.errors.Contains("The Email field is required."));
            Assert.IsTrue(registrationPage.errors.Contains("The Full Name field is required."));
            Assert.IsTrue(registrationPage.errors.Contains("The Password field is required."));
        }

        [Test]
        [AuthorAttribute("Manoela")]
        [Property("RegistrationPage", 2)]
        public void RegisterWithoutEmail()
        {
            RegisterUser user = AccessExcelData.GetRegistrationData(TestContext.CurrentContext.Test.MethodName);
            RegistrationPage registrationPage = new RegistrationPage(driver);
            registrationPage.OpenAndFillRegistrationForm(user);
            registrationPage.Email.Clear();
            registrationPage.RegisterBtn.Click();
            Assert.IsTrue(registrationPage.errors.Contains(user.ErrorMessage));
        }

        [Test]
        [AuthorAttribute("Manoela")]
        [Property("RegistrationPage", 2)]
        public void RegisterWithoutFullName()
        {
            RegisterUser user = AccessExcelData.GetRegistrationData(TestContext.CurrentContext.Test.MethodName);
            RegistrationPage registrationPage = new RegistrationPage(driver);
            registrationPage.OpenAndFillRegistrationForm(user);

            Assert.IsTrue(registrationPage.errors.Contains(user.ErrorMessage));
        }

        [Test]
        [AuthorAttribute("Manoela")]
        [Property("RegistrationPage", 2)]
        public void RegisterWithoutPassword()
        {
            RegisterUser user = AccessExcelData.GetRegistrationData(TestContext.CurrentContext.Test.MethodName);
            RegistrationPage registrationPage = new RegistrationPage(driver);
            registrationPage.OpenAndFillRegistrationForm(user);

            Assert.IsTrue(registrationPage.errors.Contains(user.ErrorMessage));
        }
        [Test]
        [AuthorAttribute("Manoela")]
        [Property("RegistrationPage", 2)]
        public void RegisterWithoutConfirmPassword()
        {
            RegisterUser user = AccessExcelData.GetRegistrationData(TestContext.CurrentContext.Test.MethodName);
            RegistrationPage registrationPage = new RegistrationPage(driver);
            registrationPage.OpenAndFillRegistrationForm(user);

            Assert.IsTrue(registrationPage.errors.Contains(user.ErrorMessage));
        }
        [Test]
        [AuthorAttribute("Manoela")]
        [Property("RegistrationPage", 2)]
        public void RegisterWithMissMatchedPasswords()
        {
            RegisterUser user = AccessExcelData.GetRegistrationData(TestContext.CurrentContext.Test.MethodName);
            RegistrationPage registrationPage = new RegistrationPage(driver);
            registrationPage.OpenAndFillRegistrationForm(user);

            Assert.IsTrue(registrationPage.errors.Contains(user.ErrorMessage));
        }
        [Test]
        [AuthorAttribute("Manoela")]
        [Property("RegistrationPage", 2)]
        public void RegisterWithInvalidEmail()
        {
            RegisterUser user = AccessExcelData.GetRegistrationData(TestContext.CurrentContext.Test.MethodName);
            RegistrationPage registrationPage = new RegistrationPage(driver);
            registrationPage.OpenAndFillRegistrationForm(user);

            Assert.IsTrue(registrationPage.errors.Contains(user.ErrorMessage));
        }
    }
}
