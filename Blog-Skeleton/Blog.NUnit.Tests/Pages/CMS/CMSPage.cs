using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Blog.NUnit.Tests.Models;

namespace Blog.NUnit.Tests.Pages.CMS
{
    public partial class CMSPage : BasePage
    {
        public CMSPage(IWebDriver driver) : base(driver)
        {

        }
        public string URL
        {
            get
            {
                return base.url + "Article/Create";
            }
        }
        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl(this.URL);
        }
        public void FillArticleForm(BlogArticle article)
        {
            CreateArticleBttn.Click();
            Type(Title, article.Title);
            Type(Content, article.Content);
            BttnSubmitArticle.Click();
        }

        public void NavigateToExistingArticle(BlogArticle article, IWebElement i)
        {
            i.Click();
            EditArticleButton.Click();
            Title.Clear();
            Content.Clear();
            Type(Title, article.Title);
            Type(Content, article.Content);
            SubmitAndEditArticle.Click();
        }
        public void DeleteExistingArticle(IWebElement i)
        {
            i.Click();
            DeleteArticleButton.Click();
            PermenantDeletion.Click();
        }
    }
}
