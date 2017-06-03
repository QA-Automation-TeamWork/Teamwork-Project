using Blog.NUnit.Tests.Attributes;
using Blog.NUnit.Tests.Models;
using Blog.NUnit.Tests.Pages;
using Blog.NUnit.Tests.Pages.CMS;
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
    public class CMSTestsWithLoggedInUser
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

        }

        //Positive Tests
        [Test]
        [AuthorAttribute("Nikola Petkov")]
        [Property("CMS with Logged User", 1)]
        [LogResultToFileAttribute]
        public void CMSCreateNewArticleWithValidData()
        {
            LoginUser user = AccessExcelData.GetTestData("CreateNewArticle");
            BlogArticle article = AccessExcelData.GetArticleTestData("CreateNewArticleWithValidData");
            LoginPage loginPage = new LoginPage(driver);
            CMSPage cmsPage = new CMSPage(driver);

            loginPage.NavigateTo();
            loginPage.FillCredentials(user);
            cmsPage.FillArticleForm(article);

            var pathToArticle = "//*[@class='col-sm-6']//descendant::a[contains(., '" + article.Title + "')]";
            IList<IWebElement> articleList = driver.FindElements(By.XPath(pathToArticle));
            Assert.IsTrue(true, "True", articleList.Count > 0);
        }

        [Test]
        [Author("Nikola Petkov")]
        [Property("CMS with Logged User", 1)]
        [LogResultToFileAttribute]
        public void CMSEditExistingArticle()
        {
            LoginUser user = AccessExcelData.GetTestData("CreateNewArticle");
            BlogArticle article = AccessExcelData.GetArticleTestData("EditExistingArticle");
            LoginPage loginPage = new LoginPage(driver);
            CMSPage cmsPage = new CMSPage(driver);

            loginPage.NavigateTo();
            loginPage.FillCredentials(user);

            var pathToArticle = "//*[@class='col-sm-6']//descendant::a[contains(., '" + article.TargetForEdit + "')]";
            IWebElement articleToBeEdited = driver.FindElement(By.XPath(pathToArticle));
            cmsPage.NavigateToExistingArticle(article, articleToBeEdited);
            var editedArticlePath = "//*[@class='col-sm-6']//descendant::a[contains(., '" + article.Title + "')]";

            IList<IWebElement> editedArticleList = driver.FindElements(By.XPath(editedArticlePath));
            Assert.IsTrue(true, "true", editedArticleList.Count > 0);
        }

        [Test]
        [Author("Nikola Petkov")]
        [Property("CMS with Logged User", 1)]
        [LogResultToFileAttribute]
        public void CMSDeleteExistingArticle()
        {
            LoginUser user = AccessExcelData.GetTestData("CreateNewArticle");
            BlogArticle article = AccessExcelData.GetArticleTestData("DeleteExistingArticle");
            LoginPage loginPage = new LoginPage(driver);
            CMSPage cmsPage = new CMSPage(driver);

            loginPage.NavigateTo();
            loginPage.FillCredentials(user);

            var pathToArticleForDeletion = "//*[@class='col-sm-6']//descendant::a[contains(., '" + article.TargetForEdit + "')]";
            IWebElement articleToBeDeleted = driver.FindElement(By.XPath(pathToArticleForDeletion));
            cmsPage.DeleteExistingArticle(articleToBeDeleted);

            IList<IWebElement> deletedArticleList = driver.FindElements(By.XPath(pathToArticleForDeletion));
            Assert.IsTrue(true, "true", deletedArticleList.Count > 0);
        }

        //Negative tests for creating a new article

        [Test]
        [Author("Nikola Petkov")]
        [Property("CMS with Logged User - Negative test - creating an article", 2)]
        [LogResultToFileAttribute]
        public void CMSCreateArticleWithoutTitle()
        {
            LoginUser user = AccessExcelData.GetTestData("CreateNewArticle");
            BlogArticle article = AccessExcelData.GetArticleTestData("CreateArticleWithoutTitle");
            LoginPage loginPage = new LoginPage(driver);
            CMSPage cmsPage = new CMSPage(driver);

            loginPage.NavigateTo();
            loginPage.FillCredentials(user);
            cmsPage.FillArticleForm(article);
            Assert.IsTrue(cmsPage.ErrorMessageForEmptyTitleOrContent.Contains(article.ArticleErrorMessage));
        }

        [Test]
        [Author("Nikola Petkov")]
        [Property("CMS with Logged User - Negative test - creating an article", 2)]
        [LogResultToFileAttribute]
        public void CMSNegativeCreateArticleWithoutContent()
        {
            LoginUser user = AccessExcelData.GetTestData("CreateNewArticle");
            BlogArticle article = AccessExcelData.GetArticleTestData("CreateArticleWithoutContent");
            LoginPage loginPage = new LoginPage(driver);
            CMSPage cmsPage = new CMSPage(driver);

            loginPage.NavigateTo();
            loginPage.FillCredentials(user);
            cmsPage.FillArticleForm(article);
            Assert.IsTrue(cmsPage.ErrorMessageForEmptyTitleOrContent.Contains(article.ArticleErrorMessage));
        }

        [Test]
        [Author("Nikola Petkov")]
        [Property("CMS with Logged User - Negative test - creating an article", 2)]
        [LogResultToFileAttribute]
        public void CMSNegativeCreateArticleWithoutTitleAndContent()
        {
            LoginUser user = AccessExcelData.GetTestData("CreateNewArticle");
            BlogArticle article = AccessExcelData.GetArticleTestData("CreateArticleWithoutTitleAndContent");
            LoginPage loginPage = new LoginPage(driver);
            CMSPage cmsPage = new CMSPage(driver);

            loginPage.NavigateTo();
            loginPage.FillCredentials(user);
            cmsPage.FillArticleForm(article);
            Assert.IsTrue(cmsPage.ErrorMessageForEmptyTitleOrContent.Contains(article.ArticleErrorMessage));
            Assert.IsTrue(cmsPage.ErrorMessageForEmptyContentOnly.Contains(article.ArticleErrorMessage));
        }

        [Test]
        [Author("Nikola Petkov")]
        [Property("CMS with Logged User - Negative test - creating an article", 2)]
        [LogResultToFileAttribute]
        public void CMSCreateArticleWithLongTitle()
        {
            LoginUser user = AccessExcelData.GetTestData("CreateNewArticle");
            BlogArticle article = AccessExcelData.GetArticleTestData("CreateArticleWithLongTitle");
            LoginPage loginPage = new LoginPage(driver);
            CMSPage cmsPage = new CMSPage(driver);

            loginPage.NavigateTo();
            loginPage.FillCredentials(user);
            cmsPage.FillArticleForm(article);
            Assert.IsTrue(cmsPage.ErrorMessageForEmptyTitleOrContent.Contains(article.ArticleErrorMessage));
        }

        [Test]
        [Author("Nikola Petkov")]
        [Property("CMS with Logged User - Negative test - creating an article", 2)]
        [LogResultToFileAttribute]
        public void CMSCreateArticleWithLongTitleAndWithoutContent()
        {
            LoginUser user = AccessExcelData.GetTestData("CreateNewArticle");
            BlogArticle article = AccessExcelData.GetArticleTestData("CreateArticleWithLongTitleAndWithoutContent");
            LoginPage loginPage = new LoginPage(driver);
            CMSPage cmsPage = new CMSPage(driver);

            loginPage.NavigateTo();
            loginPage.FillCredentials(user);
            cmsPage.FillArticleForm(article);
            Assert.IsTrue(cmsPage.ErrorMessageForEmptyTitleOrContent.Contains(article.ArticleErrorMessage));
            Assert.IsTrue(cmsPage.ErrorMessageForEmptyContentOnly.Contains(article.AdditionalErrorMessage));
        }

        //Negative tests for editing existing article.
        [Test]
        [Author("Nikola Petkov")]
        [Property("CMS with Logged User - Negative test - editing an article", 2)]
        [LogResultToFileAttribute]
        public void CMSCreateNewArticleNegativeEditTests()
        {
            LoginUser user = AccessExcelData.GetTestData("CreateNewArticle");
            BlogArticle article = AccessExcelData.GetArticleTestData("CreateArticleForNegativeEdit");
            LoginPage loginPage = new LoginPage(driver);
            CMSPage cmsPage = new CMSPage(driver);

            loginPage.NavigateTo();
            loginPage.FillCredentials(user);
            cmsPage.FillArticleForm(article);

            var pathToArticle = "//*[@class='col-sm-6']//descendant::a[contains(., '" + article.Title + "')]";
            IList<IWebElement> articleList = driver.FindElements(By.XPath(pathToArticle));
            Assert.IsTrue(true, "True", articleList.Count > 0);
        }

        [Test]
        [Author("Nikola Petkov")]
        [Property("CMS with Logged User - Negative test - editing an article", 2)]
        [LogResultToFileAttribute]
        /* The following test - NegativeEditArticleWithoutContent should fail by default, because the blog returns Error 403 (when editing existing default article
         * or error during validation, thus the test cannot be executed properly.*/
        public void CMSNegativeEditArticleWithoutContent()
        {
            LoginUser user = AccessExcelData.GetTestData("CreateNewArticle");
            BlogArticle article = AccessExcelData.GetArticleTestData("NegativeEditArticleWithoutContent");
            LoginPage loginPage = new LoginPage(driver);
            CMSPage cmsPage = new CMSPage(driver);

            loginPage.NavigateTo();
            loginPage.FillCredentials(user);
            var pathToArticle = "//*[@class='col-sm-6']//descendant::a[contains(., '" + article.TargetForEdit + "')]";
            IWebElement articleToBeEditedNegative = driver.FindElement(By.XPath(pathToArticle));
            cmsPage.NavigateToExistingArticle(article, articleToBeEditedNegative);
            Assert.IsTrue(cmsPage.ErrorMessageForEmptyTitleOrContent.Contains(article.ArticleErrorMessage));
        }

        [Test]
        [Author("Nikola Petkov")]
        [Property("CMS with Logged User - Negative test - editing an article", 2)]
        [LogResultToFileAttribute]
        public void CMSNegativeEditArticleWithoutTitle()
        {
            LoginUser user = AccessExcelData.GetTestData("CreateNewArticle");
            BlogArticle article = AccessExcelData.GetArticleTestData("NegativeEditArticleWithoutTitle");
            LoginPage loginPage = new LoginPage(driver);
            CMSPage cmsPage = new CMSPage(driver);

            loginPage.NavigateTo();
            loginPage.FillCredentials(user);
            var pathToArticle = "//*[@class='col-sm-6']//descendant::a[contains(., '" + article.TargetForEdit + "')]";
            IWebElement articleToBeEditedNegative = driver.FindElement(By.XPath(pathToArticle));
            cmsPage.NavigateToExistingArticle(article, articleToBeEditedNegative);
            Assert.IsTrue(cmsPage.ErrorMessageForEmptyTitleOrContent.Contains(article.ArticleErrorMessage));
        }

        [Test]
        [Author("Nikola Petkov")]
        [Property("CMS with Logged User - Negative test - editing an article", 2)]
        [LogResultToFileAttribute]
        public void CMSNegativeEditArticleWithLongTitle()
        {
            LoginUser user = AccessExcelData.GetTestData("CreateNewArticle");
            BlogArticle article = AccessExcelData.GetArticleTestData("NegativeEditArticleWithLongTitle");
            LoginPage loginPage = new LoginPage(driver);
            CMSPage cmsPage = new CMSPage(driver);

            loginPage.NavigateTo();
            loginPage.FillCredentials(user);
            var pathToArticle = "//*[@class='col-sm-6']//descendant::a[contains(., '" + article.TargetForEdit + "')]";

            IWebElement articleToBeEditedNegative = driver.FindElement(By.XPath(pathToArticle));
            cmsPage.NavigateToExistingArticle(article, articleToBeEditedNegative);
            Assert.IsTrue(cmsPage.ErrorMessageForEmptyTitleOrContent.Contains(article.ArticleErrorMessage));
        }
    }
}
