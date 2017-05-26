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
            get { return this.email; }
            set
            {
                if (value != null)
                {
                    this.email = DateTime.Now.Millisecond + value;
                }
                else
                {
                    this.email = string.Empty;
                }
            }
        }

        public string FullName;

        public string Password;

        public string ConfirmPassword;

        public string ErrorMessage;
    }
}
