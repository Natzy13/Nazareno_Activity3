using BogsySystem.Forms;
using BogsySystem.Forms.Properties;
using BogsySystem.UserForms.Services;
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
        UserAccountServices services = new UserAccountServices();
        private string origpass = LoginServices.Password;
        public UserAccount()
        {
            InitializeComponent();
        }

        private void UserAccount_Load(object sender, EventArgs e)
        {
            idtxt.Text = LoginServices.ID;
            fnametxt.Text = LoginServices.Name;
            usernametxt.Text = LoginServices.Username;
            passtxt.Text = LoginServices.Password;
            emailtxt.Text = LoginServices.Email;
            gendertxt.Text = LoginServices.Gender;
        }

        private void editbtn_Click(object sender, EventArgs e)
        {
            string editfname = fnametxt.Text;
            string editusername = usernametxt.Text;
            string editpass = passtxt.Text;
            string editemail = emailtxt.Text;
            string editgender = gendertxt.Text;

            if (editfname.Equals("")) MessageBox.Show("Enter Your Name");       
            else if (editusername.Equals("")) MessageBox.Show("Enter Your Username");  
            else if (editpass.Equals("") || editpass.Length < 8) MessageBox.Show("Password is required and must be at least 8 characters long");          
            else if (editemail.Equals("")) MessageBox.Show("Enter Your Email");           
            else if (editemail.Equals("Select Gender")) MessageBox.Show("Select Gender");           
            else
            {
                DialogResult confirmResult = MessageBox.Show("Are you sure you want to save these changes?", "Confirm Edit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    int row = services.editUser(editfname, editusername, editpass, editemail, editgender);
                    if (row == 1) MessageBox.Show("Account Updated Successfully");
                    if (editpass != origpass)
                    {
                        MessageBox.Show("Password changed. Please log in again.");
                        MessageBox.Show($"Edit: {editpass} | Original: {origpass}");

                        ParentForm.Close();

                        Login login = new Login();
                        login.Show();
                    }                   
                }              
            }
        }

        private void deactbtn_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you want to deactivate account ?", "Deactivate Account", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                int row = services.deactUser(LoginServices.ID);

                if (row == 1)
                {
                    MessageBox.Show("Account Deactivated, contact admin for activation");
                    ParentForm.Close();

                    Login login = new Login();
                    login.Show();
                }
               else MessageBox.Show("There is an error deactivating");               
            }
        }

        private void showpassbtn_Click(object sender, EventArgs e)
        {
            services.showPass(passtxt, hidepassbtn);
        }

        private void hidepassbtn_Click(object sender, EventArgs e)
        {
            services.hidePass(passtxt, showpassbtn);
        }
    }
}
