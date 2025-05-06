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

        public int RegisterUser(string name, string username, string password, string email, string gender)
        {
            string query = @"
        INSERT INTO Users (Name, Username, Password, Email, Gender, IsAdmin, IsActive) 
        VALUES (@name, @username, @password, @email, @gender, 0, 1);";

            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@gender", gender);

            int result = ObjDBAccess.executeQuery(cmd);
            return result; 
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
