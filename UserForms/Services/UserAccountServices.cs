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

        private string origpass = LoginServices.Password;

        public void userAccountLoad(Label idtxt, TextBox fnametxt, TextBox usernametxt, TextBox passtxt, TextBox emailtxt,
            ComboBox gendertxt)
        {
            idtxt.Text = LoginServices.ID;
            fnametxt.Text = LoginServices.Name;
            usernametxt.Text = LoginServices.Username;
            passtxt.Text = LoginServices.Password;
            emailtxt.Text = LoginServices.Email;
            gendertxt.Text = LoginServices.Gender;
        }

        public void editButtonFunction(TextBox fnametxt, TextBox usernametxt, TextBox passtxt, TextBox emailtxt, 
            ComboBox gendertxt, Form parentForm)
        {

            string editfname = fnametxt.Text;
            string editusername = usernametxt.Text;
            string editpass = passtxt.Text;
            string editemail = emailtxt.Text;
            string editgender = gendertxt.Text;

            if (string.IsNullOrEmpty(editfname))
            {
                MessageBox.Show("Name is required");
                return;
            }

            if (string.IsNullOrEmpty(editusername))
            {
                MessageBox.Show("Username is required");
                return;
            }

            if (string.IsNullOrEmpty(editemail))
            {
                MessageBox.Show("Email is required");
                return;
            }

            if (editpass.Equals("") || editpass.Length < 8)
            {
                MessageBox.Show("Password is required and must be at least 8 characters long");
                return;
            }

            if (editemail.Equals("Select Gender"))
            {
                MessageBox.Show("Email is required");
                return;
            }
            else
            {
                DialogResult confirmResult = MessageBox.Show("Are you sure you want to save these changes?", "Confirm Edit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    int row = editUserQuery(editfname, editusername, editpass, editemail, editgender);
                    if (row == 1) MessageBox.Show("Account Updated Successfully");
                    if (editpass != origpass)
                    {
                        MessageBox.Show("Password changed. Please log in again.");
                      
                        parentForm.Close();

                        Login login = new Login();
                        login.Show();
                    }
                }
            }
        }

        public int editUserQuery(string editfname, string editusername, string editpass, string editemail, string editgender) 
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

        public void deactButtonFunction(Form parentForm)
        {
            DialogResult dialog = MessageBox.Show("Do you want to deactivate account ?", "Deactivate Account", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                int row = deactUserQuery(LoginServices.ID);

                if (row == 1)
                {
                    MessageBox.Show("Account Deactivated, contact admin for activation");
                    parentForm.Close();

                    Login login = new Login();
                    login.Show();
                }
               else MessageBox.Show("There is an error deactivating");               
            }
        }

        public int deactUserQuery(string loginID)
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
