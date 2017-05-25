﻿using Blog.NUnit.Tests.Models;
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
            registrationPage.OpenFillSubmitRegistrationForm(user);
            
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
            registrationPage.OpenFillSubmitRegistrationForm(user);
            registrationPage.Email.Clear();
            registrationPage.RegisterBtn.Click();
            Assert.IsTrue(registrationPage.errors.Contains(user.ErrorMessage));
        }

        public void RegisterWithMissingInfo(string testName)
        {
            RegisterUser user = AccessExcelData.GetRegistrationData(testName);
            RegistrationPage registrationPage = new RegistrationPage(driver);
            registrationPage.OpenFillSubmitRegistrationForm(user);

            Assert.IsTrue(registrationPage.errors.Contains(user.ErrorMessage));
        }

        [Test]
        [AuthorAttribute("Manoela")]
        [Property("RegistrationPage", 2)]
        public void RegisterWithoutFullName()
        {
            RegisterWithMissingInfo(TestContext.CurrentContext.Test.MethodName);
        }

        [Test]
        [AuthorAttribute("Manoela")]
        [Property("RegistrationPage", 2)]
        public void RegisterWithoutPassword()
        {
            RegisterWithMissingInfo(TestContext.CurrentContext.Test.MethodName);
        }

        [Test]
        [AuthorAttribute("Manoela")]
        [Property("RegistrationPage", 2)]
        public void RegisterWithoutConfirmPassword()
        {
            RegisterWithMissingInfo(TestContext.CurrentContext.Test.MethodName);
        }

        [Test]
        [AuthorAttribute("Manoela")]
        [Property("RegistrationPage", 2)]
        public void RegisterWithMissMatchedPasswords()
        {
            RegisterWithMissingInfo(TestContext.CurrentContext.Test.MethodName);
        }

        [Test]
        [AuthorAttribute("Manoela")]
        [Property("RegistrationPage", 2)]
        public void RegisterWithInvalidEmail()
        {
            RegisterWithMissingInfo(TestContext.CurrentContext.Test.MethodName);
        }

        [Test]
        [AuthorAttribute("Manoela")]
        [Property("RegistrationPage", 2)]
        public void RegisterWithTheSameEmail()
        {
            RegisterUser user = AccessExcelData.GetRegistrationData(TestContext.CurrentContext.Test.MethodName);
            RegistrationPage registrationPage = new RegistrationPage(driver);
            string email = user.Email;
            registrationPage.OpenAndFillRegistrationFormWithoutEmail(user);
            registrationPage.Email.SendKeys(email);
            registrationPage.RegisterBtn.Click();

            registrationPage.loggOffBtn.Click();
            registrationPage.OpenAndFillRegistrationFormWithoutEmail(user);
            registrationPage.Email.SendKeys(email);
            registrationPage.RegisterBtn.Click();
            Assert.AreEqual(user.ErrorMessage,registrationPage.userIdNotFound);
        }
    }
}
