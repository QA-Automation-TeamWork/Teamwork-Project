using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Blog.NUnit.Tests.Pages
{
    public partial class RegistrationPage
    {
        public IWebElement Email { get { return this.Driver.FindElement(By.Id("Email")); } }

        public IWebElement FullName { get { return this.Driver.FindElement(By.Id("FullName")); } }

        public IWebElement Password { get { return this.Driver.FindElement(By.Id("Password")); } }

        public IWebElement ConfirmPassword { get { return this.Driver.FindElement(By.Id("ConfirmPassword")); } }

        public IWebElement RegisterBtn { get { return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[6]/div/input")); } }

        public IWebElement loggOffBtn { get { return this.Driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li[3]/a")); } }

        // Error Messages

        public string errors { get { return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul")).Text; } }

        public string loggOff { get { return this.Driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li[3]/a")).Text; } }

        public string userIdNotFound { get { return this.Driver.FindElement(By.XPath("/html/body/span/h2/i")).Text; } }

    }
}
