using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.NUnit.Tests.Pages
{
    public partial class LoginPage
    {
        public IWebElement Email
        {
            get
            {
                return this.Driver.FindElement(By.Id("Email"));
            }
        }

        public IWebElement Password
        {
            get
            {
                return this.Driver.FindElement(By.Id("Password"));
            }
        }

        public IWebElement SubmitLoginBtn
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[4]/div/input"));
            }
        }

        public IWebElement RememberMeCheck
        {
            get
            {
                return this.Driver.FindElement(By.Id("RememberMe"));
            }
        }

        /*Displayed message on user, when is logged: Hello user1@abv.bg!*/
        public IWebElement LoggedUserMessage
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li[2]/a"));
            }
        }

        public IWebElement LoginButton
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"loginLink\"]"));
            }
        }

        public IWebElement LogoffButton
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li[3]/a"));
            }
        }

        /*The Email field is not a valid e-mail address.*/
        public IWebElement InvalidEmailMessage
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/div/span/span"));
            }
        }

        /*Invalid login attempt.*/
        public IWebElement InvalidPasswordMessage
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li"));
            }
        }
    }
}
