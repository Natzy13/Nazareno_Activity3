using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BogsySystem.Forms.Strings
{
    public class LoginStrings
    {
       public static string searchUsername(string loginusername)
        {
            string query = $"SELECT * FROM Users WHERE Username = '{loginusername}'";
            return query ;
        }

        public static string searchUsernamePassword(string loginusername, string loginpassword)
        {
            string passquery = $"Select * from Users Where Username ='{loginusername}' AND Password ='{loginpassword}'";
            return passquery;
        }

    }
}
