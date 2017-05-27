
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.NUnit.Tests.Pages.ArticlePage
{
    public partial class ArticlePage

    {
        public IWebElement Article
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[4]/article/header/h2/a"));
            }
        }


        public IWebElement EditButton
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/article/footer/a[1]"));
            }
        }

        public IWebElement DeleteButton
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/article/footer/a[2]"));
            }
        }
    }
}



