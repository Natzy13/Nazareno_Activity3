using BogsySystem.Forms;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BogsySystem.UserForms
{
    public partial class UserAccount : Form
    {

        DBAccess ObjDBAccess = new DBAccess();
        private static string origpass = Login.password;
        public UserAccount()
        {
            InitializeComponent();
        }

        private void UserAccount_Load(object sender, EventArgs e)
        {
            idtxt.Text = Login.ID;
            fnametxt.Text = Login.name;
            usernametxt.Text = Login.username;
            passtxt.Text = Login.password;
            emailtxt.Text = Login.email;
            gendertxt.Text = Login.gender;
        }

        private void editbtn_Click(object sender, EventArgs e)
        {
            string editfname = fnametxt.Text;
            string editusername = usernametxt.Text;
            string editpass = passtxt.Text;
            string editemail = emailtxt.Text;
            string editgender = gendertxt.Text;

            if (editfname.Equals(""))
            {
                MessageBox.Show("Enter Your Name");
            }
            else if (editusername.Equals(""))
            {
                MessageBox.Show("Enter Your Username");
            }
            else if (editpass.Equals("") || editpass.Length < 8)
            {
                MessageBox.Show("Password is required and must be at least 8 characters long");
            }
            else if (editemail.Equals(""))
            {
                MessageBox.Show("Enter Your Email");
            }
            else if (editemail.Equals("Select Gender"))
            {
                MessageBox.Show("Select Gender");
            }
            else
            {

                // This function used is same in the sign up the query is different
                //Command for updating data to the database
                SqlCommand updateCommand = new SqlCommand("Update Users SET Name= '" + @editfname + "',Username= '" + @editusername + "',Password= '" + @editpass + "',Email= '" + @editemail + "',Gender= '" + @editgender + "' where ID = '" + Login.ID + "'");

                updateCommand.Parameters.AddWithValue("@fullname", editfname);
                updateCommand.Parameters.AddWithValue("@username", editusername);
                updateCommand.Parameters.AddWithValue("@password", editpass);
                updateCommand.Parameters.AddWithValue("@email", editemail);
                updateCommand.Parameters.AddWithValue("@gender", editgender);

                //This method from DBAccess, execute the sql command
                int row = ObjDBAccess.executeQuery(updateCommand);
                ObjDBAccess.closeConn();

                if (row == 1)
                {
                    MessageBox.Show("Account Updated Successfully");

                    if (editpass != origpass)
                    {
                        MessageBox.Show("Password changed. Please log in again.");

                        ParentForm.Close();

                        Login login = new Login();
                        login.Show();
                    }
                }

                else
                {
                    MessageBox.Show("There is an error updating");
                }
            }
        }

        private void deactbtn_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you want to deactivate account ?", "Deactivate Account", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                SqlCommand deactCommand = new SqlCommand("Update Users SET IsActive= 0 where ID = '" + Login.ID + "'");
                int row = ObjDBAccess.executeQuery(deactCommand);
                ObjDBAccess.closeConn();

                if (row == 1)
                {
                    MessageBox.Show("Account Deactivated, contact admin for activation");
                    ParentForm.Close();

                    Login login = new Login();
                    login.Show();
                }

                else
                {
                    MessageBox.Show("There is an error deactivating");
                }
            }

        }
    }
}
