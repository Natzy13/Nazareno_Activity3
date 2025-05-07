using BogsySystem.Forms.Strings;
using BogsySystem.UserForms;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BogsySystem.Forms.Properties
{
    public class LoginServices
    {
        private DBAccess ObjDBAccess = new DBAccess();

        public DataTable searchUsername(string loginusername)
        {       
            DataTable usersDt = new DataTable();
            ObjDBAccess.readDatathroughAdapter(LoginStrings.searchUsername(loginusername), usersDt);
            return usersDt;
        }
        public DataTable searchUsernamePassword(string loginpassword, string loginusername) 
        {
            DataTable usersPass = new DataTable();
            ObjDBAccess.readDatathroughAdapter(LoginStrings.searchUsernamePassword(loginusername,loginpassword), usersPass);
            return usersPass;
        }

        public void showPass(TextBox passwordShow, Button passwordHide)
        {
            if (passwordShow.PasswordChar == '*')
            {
                passwordHide.BringToFront();
                passwordShow.PasswordChar = '\0';
            }
        }

        public void hidePass(TextBox passwordShow, Button passwordHide)
        {
            if (passwordShow.PasswordChar == '\0')
            {
                passwordHide.BringToFront();
                passwordShow.PasswordChar = '*';
            }
        }
    }
}
