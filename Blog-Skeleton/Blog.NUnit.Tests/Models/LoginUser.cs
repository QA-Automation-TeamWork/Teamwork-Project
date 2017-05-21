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

        public LoginUser(String username, String password)
        {
            this.username = username;
            this.password = password;
        }

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
    }
}
