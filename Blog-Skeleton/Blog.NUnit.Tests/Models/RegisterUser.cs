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
        private string fullName;
        private string password;
        private string confirmPassword;
        private string errormessage;

        public RegisterUser() { }

        public RegisterUser(String email, String fullName, String password, String confirmPassword, String errormessage)
        {
            email = this.email;
            fullName = this.fullName;
            password = this.password;
            confirmPassword = this.confirmPassword;
            errormessage = this.errormessage;
        }

        public string Email {
            get { return DateTime.Now.Millisecond + this.email; }  set { this.email = value; }
        }

        public string FullName
        {
            get { return this.fullName; }
            set { this.fullName = value; }
        }

        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }

        public string ConfirmPassword
        {
            get { return this.confirmPassword; }
            set { this.confirmPassword = value; }
        }

        public string ErrorMessage
        {
            get { return this.errormessage; }
            set { this.errormessage = value; }
        }
    }
}
