using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opg1_cases
{
    internal class Account
    {

        public void Login(string username, string pass)
        {
            


        }

        public bool PassStrong(string pass)
        {
    
            if (pass.Length <= 12) return false;
            if (char.IsDigit(pass[0])) return false;
            if (char.IsDigit(pass[pass.Length])) return false;
            if (pass.Contains(" ")) return false;
            
            

            return true;
        }

        


    }
}
