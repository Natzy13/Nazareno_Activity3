using BogsySystem.Forms.Strings;
using BogsySystem.UserForms;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BogsySystem.Forms.Properties
{
    public class LoginServices
    {
        private DBAccess ObjDBAccess = new DBAccess();
        public static string ID { get; private set; }
        public static string Name { get; private set; }
        public static string Email { get; private set; }
        public static string Password { get; private set; }
        public static string Username { get; private set; }
        public static string Gender { get; private set; }
        public static bool IsAdmin { get; private set; }
        public static bool IsActive { get; private set; }

        public void LoginButtonFunction(TextBox unamelogintxt, TextBox passlogintxt, Form currentForm)
        {
            string loginUsername = unamelogintxt.Text.Trim();
            string loginPass = passlogintxt.Text.Trim();

            if (string.IsNullOrEmpty(loginUsername))
            {
                MessageBox.Show("Email is required");
                return;
            }

            if (string.IsNullOrEmpty(loginPass))
            {
                MessageBox.Show("Password is required");
                return;
            }

            DataTable usersDt = searchUsernameQuery(loginUsername);

            if (usersDt.Rows.Count == 0)
            {
                MessageBox.Show("Email is incorrect");
                return;
            }

            DataTable usersPass = searchUsernamePasswordQuery(loginPass, loginUsername);

            if (usersPass.Rows.Count != 1)
            {
                MessageBox.Show("Password is incorrect");
                passlogintxt.Text = "";
                return;
            }

            DataRow row = usersDt.Rows[0];
            ID = row["ID"].ToString();
            Name = row["Name"].ToString();
            Email = row["Email"].ToString();
            Password = row["Password"].ToString();
            Username = row["Username"].ToString();
            Gender = row["Gender"].ToString();
            IsAdmin = Convert.ToBoolean(row["IsAdmin"]);
            IsActive = Convert.ToBoolean(row["IsActive"]);

            ObjDBAccess.closeConn();

            if (!IsActive)
            {
                unamelogintxt.Text = "";
                passlogintxt.Text = "";
                MessageBox.Show("Account is deactivated. Contact admin.");
                return;
            }

            currentForm.Close();

            if (IsAdmin)
            {
                new Dashboard().Show();
            }
            else
            {
                new UserDashboard().Show();
            }
        }

        public DataTable searchUsernameQuery(string loginusername)
        {       
            DataTable usersUsername = new DataTable();
            ObjDBAccess.readDatathroughAdapter(LoginStrings.searchUsername(loginusername), usersUsername);
            return usersUsername;
        }
        public DataTable searchUsernamePasswordQuery(string loginpassword, string loginusername) 
        {
            DataTable usersPass = new DataTable();
            ObjDBAccess.readDatathroughAdapter(LoginStrings.searchUsernamePassword(loginusername,loginpassword), usersPass);
            return usersPass;
        }

        public void labelSignup(Form currentForm)
        {
            currentForm.Close();
            SignUp signup = new SignUp();
            signup.Show();
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
