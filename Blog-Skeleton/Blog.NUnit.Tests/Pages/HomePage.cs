using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.NUnit.Tests.Pages
{
    public partial class HomePage : BasePage
    {
        public HomePage(IWebDriver driver)
            :base(driver)
        {
        }

        public string URL
        {
            get
            {
                return base.url + "Article/List/";
            }
        }

        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl(this.URL);
        }
    }
}
