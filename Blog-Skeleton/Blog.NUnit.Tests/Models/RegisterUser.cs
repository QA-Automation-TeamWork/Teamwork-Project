using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.NUnit.Tests.Models
{
    public class RegisterUser
    {
        private string email;

        public string Email
        {
            get { return DateTime.Now.Millisecond + this.email; }
            set { this.email = value; }
        }

        public int MyProperty { get; set; }

        public string FullName { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string ErrorMessage { get; set; }
    }
}
