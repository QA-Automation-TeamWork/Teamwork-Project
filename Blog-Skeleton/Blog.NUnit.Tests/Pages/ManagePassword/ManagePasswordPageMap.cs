using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.NUnit.Tests.Pages
{
    public partial class ManagePasswordPage
    {
        public IWebElement changePasswordBtn
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/dl/dd/a"));
            }
        }

        public IWebElement UserManagement
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li[2]/a"));
            }
        }

        public IWebElement SubmitPasswordChange
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[5]/div/input"));
            }
        }

        public IWebElement CurrentPassword
        {
            get
            {
                return this.Driver.FindElement(By.Id("OldPassword"));
            }
        }

        public IWebElement NewPassword
        {
            get
            {
                return this.Driver.FindElement(By.Id("NewPassword"));
            }
        }

        public IWebElement ConfirmPassword
        {
            get
            {
                return this.Driver.FindElement(By.Id("ConfirmPassword"));
            }
        }

        public IWebElement ErrorIncorrectPassword
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li")));
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li"));
            }
        }

        public IWebElement ErrorNewPasswordMissing
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li[1]")));
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li[1]"));
            }
        }

        public IWebElement ErrorPasswordsMismatch
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li[2]")));
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li[2]"));
            }
        }

        public IWebElement ErrorPasswordsMismatch2
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li")));
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li"));
            }
        }
 
    }
}
