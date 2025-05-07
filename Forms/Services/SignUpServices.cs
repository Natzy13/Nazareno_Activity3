using BogsySystem.Forms.Strings;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BogsySystem.Forms.Properties
{
    public class SignUpServices
    {
    private DBAccess ObjDBAccess = new DBAccess();

        public static string ID { get; private set; }
        public static string Name { get; private set; }
        public static string Email { get; private set; }
        public static string Password { get; private set; }
        public static string Username { get; private set; }
        public static string Gender { get; private set; }

        public void registerButtonFunction(TextBox name, TextBox uname, TextBox pass, TextBox email, ComboBox gender, Form currentForm)
        {
            Name = name.Text;
            Username = uname.Text;
            Password = pass.Text;
            Email = email.Text;
            Gender = gender.Text;

            if (string.IsNullOrEmpty(Name))
            {
                MessageBox.Show("Fullname is required");
                return;
            }
            if (string.IsNullOrEmpty(Username))
            {
                MessageBox.Show("Username is required");
                return;
            }

            if (Password.Equals("") || Password.Length < 8)
            {
                MessageBox.Show("Password is required and must be at least 8 characters long");
                return;
            }

            if (string.IsNullOrEmpty(Email))
            {
                MessageBox.Show("Email is required");
                return;
            }

            if (Gender.Equals("Select Gender"))
            {
                MessageBox.Show("Select Gender");
                return;
            }

            else
            {
                //This method from DBAccess, execute the sql command
                int row = registerUserQuery(Name, Username, Password, Email, Gender);

                if (row == 1)
                {
                    ClearRegistrationFields(name, uname, pass, email, gender);
                    MessageBox.Show("Account Created Successfully");

                    currentForm.Hide();

                    //Transfer to this new form
                    Login login = new Login();
                    login.Show();
                }

                else MessageBox.Show("Error");

            }

        }

        public int registerUserQuery(string name, string username, string password, string email, string gender)
        {
            SqlCommand cmd = new SqlCommand(SignUpStrings.registerUserQuery);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@gender", gender);

            int result = ObjDBAccess.executeQuery(cmd);
            return result; 
        }

        public void labelLogin(Form currentForm)
        {
            currentForm.Hide();
            Login login = new Login();
            login.Show();
        }

        public void ClearRegistrationFields(
    TextBox firstName,
    TextBox username,
    TextBox password,
    TextBox email,
    ComboBox gender)
        {
            firstName.Clear();
            username.Clear();
            password.Clear();
            email.Clear();
            gender.Text = "Select Gender";
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
