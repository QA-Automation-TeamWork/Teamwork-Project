using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.NUnit.Tests.Models
{
    public class LoginUser
    {
        private string username;
        private string password;
        private string newpassword;
        private string confirmnewpassword;
        private string currentpassword;
        private Boolean rememberMeCheck;

        public LoginUser() { }

        public LoginUser(String username, String password)
        {
            this.username = username;
            this.password = password;
        }

        public string Key { get; set; }

        public string Username
        {
            get { return this.username; }
            set { this.username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string NewPassword
        {
            get { return newpassword; }
            set { newpassword = value; }
        }

        public string ConfirmNewPassword
        {
            get { return confirmnewpassword; }
            set { confirmnewpassword = value; }
        }

        public string CurrentPassword
        {
            get { return currentpassword; }
            set { currentpassword = value; }
        }

        public Boolean RememberMeCheck
        {
            get { return rememberMeCheck; }
            set { rememberMeCheck = value; }
        }
    }
}
