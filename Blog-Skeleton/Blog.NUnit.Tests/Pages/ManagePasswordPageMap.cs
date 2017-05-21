using OpenQA.Selenium;
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
    }
}
