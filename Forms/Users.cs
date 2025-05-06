using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BogsySystem.Forms
{
    public partial class Users : Form
    {
        DBAccess ObjDBAccess = new DBAccess();
        private int selectedUserID;
        public Users()
        {
            InitializeComponent();
        }

        private void Users_Load(object sender, EventArgs e)
        {
            filter.SelectedIndex = 0;
            componentHide();
            try
            {
                string tablequery = "SELECT ID, Name, Username, Email, Gender FROM Users WHERE IsAdmin = 0";
                DataTable usersDt = new DataTable();

                ObjDBAccess.readDatathroughAdapter(tablequery, usersDt);
                ObjDBAccess.closeConn();

                if (usersDt.Rows.Count > 0)
                {
                    dataGridUsers.DataSource = usersDt;
                    dataGridProperties();
                }
                else
                {
                    MessageBox.Show("No records found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void deactbtn_Click(object sender, EventArgs e)
        {
            SqlCommand activateCommand = new SqlCommand("Update Users SET IsActive= 1 where ID = '" + selectedUserID + "'");
            int row = ObjDBAccess.executeQuery(activateCommand);
            ObjDBAccess.closeConn();

            if (row == 1)
            {
                MessageBox.Show("Account Activated");
                refreshDataGrid();
            }

            else
            {
                MessageBox.Show("There is an error deactivating");
            }
        }
     
        private void editbtn_Click(object sender, EventArgs e)
        {
            string displayname = nametxt.Text;
            string displayemail = emailtxt.Text;
            string displaygender = gendertxt.Text;

            if (displayname.Equals(""))
            {
                MessageBox.Show("Enter Name");
            }
            else if (displayemail.Equals(""))
            {
                MessageBox.Show("Enter Email");
            }
            else if (displaygender.Equals("Select Gender"))
            {
                MessageBox.Show("Select Gender");
            }
            else
            {
                DialogResult confirmResult = MessageBox.Show("Are you sure you want to save these changes?", "Confirm Edit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    SqlCommand editCommand = new SqlCommand("Update Users SET Name= '" + @displayname + "',Email= '" + @displayemail + "',Gender= '" + @displaygender + "' where ID = '" + selectedUserID + "'");

                    editCommand.Parameters.AddWithValue("Name", @displayname);
                    editCommand.Parameters.AddWithValue("Email", @displayemail);
                    editCommand.Parameters.AddWithValue("Gender", @displaygender);

                    int row = ObjDBAccess.executeQuery(editCommand);

                    if (row == 1)
                    {
                        MessageBox.Show("User Updated Successfully");
                        refreshDataGrid();
                        componentHide();
                    }

                    else
                    {
                        MessageBox.Show("There is an error updating");
                    }
                }
            }
        }

        private void filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFilter = filter.SelectedItem.ToString();

            if (selectedFilter == "All")
            {
                refreshDataGrid();
            }
            else if (selectedFilter == "Activated" || selectedFilter == "Deactivated")
            {
                string bitValue = selectedFilter == "Activated" ? "1" : "0";
                ApplyFilter("IsActive", bitValue);
            }
            else if (selectedFilter == "Male" || selectedFilter == "Female")
            {
                ApplyFilter("Gender", selectedFilter);
            }
        }

        void ApplyFilter(string column, string value)
        {
            try
            {    
                string tablequery = $"SELECT ID, Name, Username, Email, Gender FROM Users WHERE IsAdmin = 0 AND {column} = '{value}'";

                DataTable mediaDt = new DataTable();
                ObjDBAccess.readDatathroughAdapter(tablequery, mediaDt);
                ObjDBAccess.closeConn();

                if (mediaDt.Rows.Count > 0)
                {
                    dataGridUsers.DataSource = mediaDt;
                    dataGridProperties();
                }
                else
                {
                    string statusText = (column == "IsActive" && value == "1") ? "Activated" :
                    (column == "IsActive" && value == "0") ? "Deactivated" :
                    value;

                    string message = column == "IsActive"
                        ? $"No {statusText} user found."
                        : $"No {value} user found.";

                    MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
