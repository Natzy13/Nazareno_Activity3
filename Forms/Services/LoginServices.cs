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
            string query = $"SELECT * FROM Users WHERE Username = '{loginusername}'";
            DataTable usersDt = new DataTable();
            ObjDBAccess.readDatathroughAdapter(query, usersDt);
            return usersDt;
        }
        public DataTable searchUsernamePassword(string loginpassword, string loginusername) 
        {
            string passquery = $"Select * from Users Where Username ='{loginusername}' AND Password ='{loginpassword}'";
            DataTable usersPass = new DataTable();
            ObjDBAccess.readDatathroughAdapter(passquery, usersPass);
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
