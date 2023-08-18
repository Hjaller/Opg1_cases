using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opg1_cases
{
    internal class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<string> UsedPassword { get; set; }
        public User(string username, string password)
        {
            UserName = username;
            Password = password;

            List<string> passwords = new List<string>();
            passwords.Add(password);
            UsedPassword = passwords;

        }
    }
}
