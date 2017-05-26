using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.NUnit.Tests.Models
{
    public class RegisterUser
    {
        public string email;

        public string Email
        {
            get { return DateTime.Now.Millisecond + this.email; }
            set { this.email = value; }
        }

        public string FullName;

        public string Password;

        public string ConfirmPassword;

        public string ErrorMessage;
    }
}
