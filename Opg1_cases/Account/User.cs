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

        /// <summary>
        ///
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="usedPass"></param>
        public User(string username, string password, List<string>? usedPass)
        {
            UserName = username;
            Password = password;

            if(usedPass == null)
            {
                List<string> passwords = new List<string>();
                passwords.Add(password);
                UsedPassword = passwords;
            } else
            {
                UsedPassword = usedPass;
            }


        }



    }
}
