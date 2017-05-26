using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Blog.NUnit.Tests.Models;

namespace Blog.NUnit.Tests.Pages
{
    public abstract class BasePage
    {
        protected string url = ConfigurationManager.AppSettings["URL"];
        private IWebDriver driver;
        private WebDriverWait wait;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            this.driver.Manage().Window.Maximize();
            this.wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(30));
        }

        public IWebDriver Driver
        {
            get
            {
                return this.driver;
            }
        }

        public WebDriverWait Wait
        {
            get
            {
                return this.wait;
            }
        }

        protected void Type(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        protected void EnterText(IWebElement element, string text)
        {
            element.Clear();
            if (text != null)
            {
                element.SendKeys(text);
            }
        }
    }
}
