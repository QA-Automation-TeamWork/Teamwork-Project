using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.NUnit.Tests.Pages.ArticlePage
{
    public partial class ArticlePage : BasePage
    {
        public ArticlePage(IWebDriver driver) : base(driver)
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

        public void EditArticle()
        {

            Article.Click();
            EditButton.Click();

        }

        public void DeleteArticle()
        {

            Article.Click();
            DeleteButton.Click();

        }
    }
}

