using BogsySystem.Forms;
using BogsySystem.Forms.Properties;
using BogsySystem.UserForms.Strings;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BogsySystem.UserForms.Services
{
    public class UserAccountServices
    {
        private DBAccess ObjDBAccess = new DBAccess();
        public int editUser(string editfname, string editusername, string editpass, string editemail, string editgender) 
        {
            SqlCommand updateCommand = new SqlCommand(UserAccountStrings.editUserQuery(editfname, editusername, editpass,
                editemail, editgender, LoginServices.ID));

            updateCommand.Parameters.AddWithValue("@fullname", editfname);
            updateCommand.Parameters.AddWithValue("@username", editusername);
            updateCommand.Parameters.AddWithValue("@password", editpass);
            updateCommand.Parameters.AddWithValue("@email", editemail);
            updateCommand.Parameters.AddWithValue("@gender", editgender);
            int row = ObjDBAccess.executeQuery(updateCommand);
            ObjDBAccess.closeConn();

            return row;
        }

        public int deactUser(string loginID)
        {
            SqlCommand deactCommand = new SqlCommand(UserAccountStrings.deactUserQuery(loginID));
            int row = ObjDBAccess.executeQuery(deactCommand);
            ObjDBAccess.closeConn();
            return row;
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
