using BogsySystem.UserForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace BogsySystem.Forms
{
    public partial class Login : Form
    {
        DBAccess ObjDBAccess = new DBAccess();
        public static string ID, username, password, name, email, gender;
        public Login()
        {
            InitializeComponent();
        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            string loginusername = unamelogintxt.Text;
            string loginpass = passlogintxt.Text;

            if (loginusername.Equals(""))
            {
                MessageBox.Show("Email is required");
            }
            else if (loginpass.Equals(""))
            {
                MessageBox.Show("Password is required");
            }
            else
            {
                //Query to select if the email is in the database
                string emailquery = "Select * from Users Where Username ='" + loginusername + "'";

                //This will be the storage for the data fetch from database
                DataTable usersDt = new DataTable();

                // This function retrieves data from the database and fills it into the DataTable
                ObjDBAccess.readDatathroughAdapter(emailquery, usersDt);

                if (usersDt.Rows.Count == 0) MessageBox.Show("Email is incorrect");
                else
                {
                    string passquery = "Select * from Users Where Username ='" + loginusername + "' AND Password ='" + loginpass + "'";
                    DataTable usersPass = new DataTable();
                    ObjDBAccess.readDatathroughAdapter(passquery, usersPass);

                    if (usersPass.Rows.Count == 1)
                    {
                        //This will get the data from data table and assign to the given variables
                        ID = usersDt.Rows[0]["ID"].ToString();
                        name = usersDt.Rows[0]["Name"].ToString();
                        email = usersDt.Rows[0]["Email"].ToString();
                        password = usersDt.Rows[0]["Password"].ToString();
                        username = usersDt.Rows[0]["Username"].ToString();
                        gender = usersDt.Rows[0]["Gender"].ToString();
                        bool isAdmin = Convert.ToBoolean(usersDt.Rows[0]["IsAdmin"]);
                        bool isActive = Convert.ToBoolean(usersDt.Rows[0]["IsActive"]);

                        ObjDBAccess.closeConn();

                        if (!isActive)
                        {
                            unamelogintxt.Text = "";
                            passlogintxt.Text = "";
                            MessageBox.Show("Account is deactivated contact admin.");

                        }
                        else
                        {
                            if (isAdmin)
                            {
                                this.Close();
                                Dashboard dashboardadmin = new Dashboard();
                                dashboardadmin.Show();
                            }
                            else
                            {
                                this.Close();
                                UserDashboard userDashboard = new UserDashboard();
                                userDashboard.Show();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Password is incorrect");
                        passlogintxt.Text = "";
                    }
                }
            }
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
            SignUp signup = new SignUp();
            signup.Show();
        }

   
            
        
    }
}
