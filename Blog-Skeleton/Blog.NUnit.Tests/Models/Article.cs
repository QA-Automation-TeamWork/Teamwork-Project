using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.NUnit.Tests.Models
{
    public class BlogArticle
    {
        private string targetForEdit;
        private string title;
        private string content;
        private string articleErrorMessage;
        private string additionalErrorMessage;

        public BlogArticle() { }

        public BlogArticle(String targetForEdit, String title, String content, String articleErrorMessage, String additionalErrorMessage)
        {
            this.targetForEdit = targetForEdit;
            this.title = title;
            this.content = content;
            this.articleErrorMessage = articleErrorMessage;
            this.additionalErrorMessage = additionalErrorMessage;
        }

        public string Key { get; set; }
        public string TargetForEdit { get; set; }
        public string Title { get; set; }

        public string Content { get; set; }

        public string ArticleErrorMessage { get; set; }

        public string AdditionalErrorMessage { get; set; }
    }
}
