using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.NUnit.Tests.Pages.CMS
{
    public partial class CMSPage
    {
        public IWebElement CreateArticleBttn
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li[1]/a"));
            }
        }

        public IWebElement Title
        {
            get
            {
                return this.Driver.FindElement(By.Id("Title"));
            }
        }

        public IWebElement Content
        {
            get
            {
                return this.Driver.FindElement(By.Id("Content"));
            }
        }

        public IWebElement BttnSubmitArticle
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[4]/div/input"));
            }
        }

        public IWebElement BttnCancel
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[4]/div/a"));
            }
        }

        //Error messages for article creation
        public string ErrorMessageForEmptyTitleOrContent
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li")));
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li")).Text;
            }
        }

        public string ErrorMessageForEmptyContentOnly
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li[2]")));
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li[2]")).Text;
            }
        }
        public IWebElement LinkToArticle
        {
            get
            {
                return this.Driver.FindElement(By.PartialLinkText("Test"));
            }
        }

        public IWebElement LinkToArticleEditNegativeTests
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/article/header/h2/a"));
            }
        }


        //Buttons for editing or deleting article; go back
        public IWebElement EditArticleButton
        {
            get
            {
                return this.Driver.FindElement(By.XPath("html/body/div[2]/div/article/footer/a[1]"));
            }
        }

        public IWebElement DeleteArticleButton
        {
            get
            {
                return this.Driver.FindElement(By.XPath("html/body/div[2]/div/article/footer/a[2]"));
            }
        }

        public IWebElement BackToHomePageButton
        {
            get
            {
                return this.Driver.FindElement(By.XPath("html/body/div[2]/div/article/footer/a[3]"));
            }
        }
        public IWebElement PermenantDeletion
        {
            get
            {
                return this.Driver.FindElement(By.XPath("html/body/div[2]/div/div/form/div[3]/div/input"));
            }
        }

        //buttons for: submiting edited article; cancel button
        public IWebElement SubmitAndEditArticle
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[4]/div/input"));
            }
        }
    }
}
