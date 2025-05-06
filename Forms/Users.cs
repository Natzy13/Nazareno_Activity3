using BogsySystem.Forms.Properties;
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
using System.Windows.Controls;
using System.Windows.Forms;

namespace BogsySystem.Forms
{
    public partial class Users : Form
    {
        UsersServices services = new UsersServices();
        private int selectedUserID;
        public Users()
        {
            InitializeComponent();
        }

        private void Users_Load(object sender, EventArgs e)
        {
            filter.SelectedIndex = 0;
            services.componentHide(activatebtn, editbtn, nametxt, emailtxt, gendertxt, namelbl, emaillbl, genderlbl);
            try
            {
                DataTable usersDt = services.GetUsers();

                if (usersDt.Rows.Count > 0)
                {
                    dataGridUsers.DataSource = usersDt;
                    services.dataGridProperties(dataGridUsers);
                }
                else MessageBox.Show("No records found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void deactbtn_Click(object sender, EventArgs e)
        {
            int row = services.deactUser(selectedUserID);
            if (row == 1)
            {
                MessageBox.Show("Account Activated");
                services.refreshDataGrid(dataGridUsers);
            }

            else MessageBox.Show("There is an error deactivating");            
        }
     
        private void editbtn_Click(object sender, EventArgs e)
        {
            string displayname = nametxt.Text;
            string displayemail = emailtxt.Text;
            string displaygender = gendertxt.Text;

            if (displayname.Equals("")) MessageBox.Show("Enter Name");           
            else if (displayemail.Equals(""))MessageBox.Show("Enter Email");           
            else if (displaygender.Equals("Select Gender")) MessageBox.Show("Select Gender");           
            else
            {
                DialogResult confirmResult = MessageBox.Show("Are you sure you want to save these changes?", "Confirm Edit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    int row = services.editUser(displayname,displayemail, displaygender, selectedUserID);

                    if (row == 1)
                    {
                        MessageBox.Show("User Updated Successfully");
                        services.refreshDataGrid(dataGridUsers);
                        services.componentHide(activatebtn, editbtn, nametxt, emailtxt, gendertxt, namelbl, emaillbl, genderlbl);
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

            if (selectedFilter == "All") services.refreshDataGrid(dataGridUsers);
            else if (selectedFilter == "Activated" || selectedFilter == "Deactivated")
            {
                string bitValue = selectedFilter == "Activated" ? "1" : "0";
                ApplyFilter("IsActive", bitValue);
            }
            else if (selectedFilter == "Male" || selectedFilter == "Female") ApplyFilter("Gender", selectedFilter);            
        }

        void ApplyFilter(string column, string value)
        {
            try
            {    
               DataTable mediaDt = services.Filter(column, value);
                if (mediaDt.Rows.Count > 0)
                {
                    dataGridUsers.DataSource = mediaDt;
                    services.dataGridProperties(dataGridUsers);
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

        private void dataGridUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Check if the clicked event was on a valid row
                if (e.RowIndex >= 0)
                {
                    // Select the current row
                    dataGridUsers.CurrentRow.Selected = true;
                    services.componentShow(activatebtn, editbtn, nametxt, emailtxt, gendertxt, namelbl, emaillbl, genderlbl);

                    // Retrieve the selected data into a variable
                    selectedUserID = Convert.ToInt32(dataGridUsers.Rows[e.RowIndex].Cells["ID"].Value);
                    nametxt.Text = dataGridUsers.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                    emailtxt.Text = dataGridUsers.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                    gendertxt.Text = dataGridUsers.Rows[e.RowIndex].Cells["Gender"].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void dataGridUsers_Click(object sender, EventArgs e)
        {
            dataGridUsers.CurrentRow.Selected = false;
            services.componentHide(activatebtn,editbtn,nametxt,emailtxt,gendertxt,namelbl,emaillbl,genderlbl);
        }

        private void dataGridUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridUsers.CurrentRow.Selected = false;
            services.componentHide(activatebtn, editbtn, nametxt, emailtxt, gendertxt, namelbl, emaillbl, genderlbl);
        }      
    }
}
