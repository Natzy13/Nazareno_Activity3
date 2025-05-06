using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace BogsySystem.Forms
{
    public partial class SignUp : Form
    {
        DBAccess ObjDBAccess = new DBAccess();

        public SignUp()
        {
            InitializeComponent();
        }

        private void regbtn_Click(object sender, EventArgs e)
        {
            string fullname = fnameregtxt.Text;
            string username = unameregtxt.Text;
            string password = passregtxt.Text;
            string email = emailregtxt.Text;
            string gender = genderregtxt.Text;

            if (fullname.Equals(""))
            {
                MessageBox.Show("Enter Your Full Name");
            }
            else if (username.Equals(""))
            {
                MessageBox.Show("Enter Your Username");
            }
            else if (password.Equals("") || password.Length < 8)
            {
                MessageBox.Show("Password is required and must be at least 8 characters long");
            }
            else if (email.Equals(""))
            {
                MessageBox.Show("Enter Your Email");
            }
            else if (gender.Equals("Select Gender"))
            {
                MessageBox.Show("Select Gender");
            }
            else
            {

                SqlCommand insertCommand = new SqlCommand("Insert into Users(Name,Username,Password,Email,Gender,IsAdmin,IsActive) values (@fullname, @username, @password, @email, @gender,0,1)");

                insertCommand.Parameters.AddWithValue("@fullname", username);
                insertCommand.Parameters.AddWithValue("@username", username);
                insertCommand.Parameters.AddWithValue("@password", password);
                insertCommand.Parameters.AddWithValue("@email", email);
                insertCommand.Parameters.AddWithValue("@gender", gender);


                //This method from DBAccess, execute the sql command
                int row = ObjDBAccess.executeQuery(insertCommand);

                if (row == 1)
                {
                    clearDataFields();
                    MessageBox.Show("Account Created Successfully");

                    this.Hide();

                    //Transfer to this new form
                    Login login = new Login();
                    login.Show();
                }

                else MessageBox.Show("Error");
                
            }
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }
    }
}
