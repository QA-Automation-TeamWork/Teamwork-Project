using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.NUnit.Tests.Pages
{
    public partial class HomePage
    {
        public IWebElement HeaderTitle
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/a"));
            }
        }

        public IWebElement LoginBtn
        {
            get
            {
                return this.Driver.FindElement(By.Id("loginLink"));
            }
        }

        public IWebElement RegisterBtn
        {
            get
            {
                return this.Driver.FindElement(By.Id("registerLink"));
            }
        }        
    }
}
