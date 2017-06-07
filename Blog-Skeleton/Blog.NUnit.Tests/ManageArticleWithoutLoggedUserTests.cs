
using Blog.NUnit.Tests.Pages.ArticlePage;
using Blog.NUnit.Tests.Seleno;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.NUnit.Tests
{
    [TestFixture]

    public class ManageArticleWithoutLoggedUserTests
    {

        public IWebDriver driver;

        [SetUp]
        public void Init()
        {
            this.driver = BrowserHost.Instance.Application.Browser;
        }

        [TearDown]
        public void closeSession()
        {
            //this.driver.Quit();
        }

        [Test]
        public void EditArticleWithOutLoggedUser()
        {

            ArticlePage articlePage = new ArticlePage(driver);
            articlePage.NavigateTo();
            articlePage.EditArticle();

            Assert.IsTrue(driver.Url.Contains("Login"));
        }
        [Test]
        public void DeleteArticleWithOutLoggedUser()
        {

            ArticlePage articlePage = new ArticlePage(driver);

            articlePage.NavigateTo();
            articlePage.DeleteArticle();

            Assert.IsTrue(driver.Url.Contains("Login"));
        }

        [Test]
        public void AccessArticleWithOutLoggedUser()
        {

            ArticlePage articlePage = new ArticlePage(driver);

            articlePage.NavigateTo();
            articlePage.Article.Click();
            

            Assert.AreEqual("demo",articlePage.ArticleHeader.Text);
        }
    }
}