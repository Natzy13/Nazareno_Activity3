using BogsySystem.Forms.Strings;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BogsySystem.Forms.Properties
{
    public class UsersServices
    {
        private DBAccess ObjDBAccess = new DBAccess();
        private int selectedUserID { get; set; }

        public void userLoadFunction(ComboBox filter, Button activatebtn, Button editbtn, TextBox nametxt, TextBox emailtxt,
            ComboBox gendertxt, Label namelbl, Label emaillbl, Label genderlbl, DataGridView grid)
        {
            filter.SelectedIndex = 0;
            componentHide(activatebtn, editbtn, nametxt, emailtxt, gendertxt, namelbl, emaillbl, genderlbl);
            try
            {
                DataTable usersDisplay = GetUsersQuery();

                if (usersDisplay.Rows.Count > 0)
                {
                    grid.DataSource = usersDisplay;
                    dataGridProperties(grid);
                }
                else MessageBox.Show("No records found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable GetUsersQuery()
        {
            DataTable GetUsersQuery = new DataTable();
            ObjDBAccess.readDatathroughAdapter(UsersStrings.getUsersQuery, GetUsersQuery);
            ObjDBAccess.closeConn();
            return GetUsersQuery;
        }

        public void ActivateButtonFunction(DataGridView grid)
        {
            int rowActiveUser = activateUserQuery(selectedUserID);
            if (rowActiveUser == 1)
            {
                MessageBox.Show("Account Activated");
                refreshDataGridQuery(grid);
            }

            else MessageBox.Show("There is an error deactivating");
        }

        public int activateUserQuery(int selectedUser)
        {
            SqlCommand activateCommand = new SqlCommand(UsersStrings.activateUserQuery(selectedUser));
            int activateUserQuery = ObjDBAccess.executeQuery(activateCommand);
            ObjDBAccess.closeConn();
            return activateUserQuery;
        }

        public void EditButtonFunction(TextBox nametxt, TextBox emailtxt, ComboBox gendertxt, Label namelbl, Label emaillbl,
            Label genderlbl, Button activatebtn, Button editbtn ,DataGridView grid)
        {
            string displayname = nametxt.Text;
            string displayemail = emailtxt.Text;
            string displaygender = gendertxt.Text;

            if (displayname.Equals("")) MessageBox.Show("Enter Name");
            else if (displayemail.Equals("")) MessageBox.Show("Enter Email");
            else if (displaygender.Equals("Select Gender")) MessageBox.Show("Select Gender");
            else
            {
                DialogResult confirmResult = MessageBox.Show("Are you sure you want to save these changes?", 
                    "Confirm Edit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    int rowEditUser = editUserQuery(displayname, displayemail, displaygender, selectedUserID);

                    if (rowEditUser == 1)
                    {
                        MessageBox.Show("User Updated Successfully");
                        refreshDataGridQuery(grid);
                        componentHide(activatebtn, editbtn, nametxt, emailtxt, gendertxt, namelbl, emaillbl, genderlbl);
                    }

                    else MessageBox.Show("There is an error updating");                    
                }
            }
        }

        public int editUserQuery(string name, string email, string gender, int selectedUser) 
        {
            SqlCommand editCommand = new SqlCommand(UsersStrings.editUserQuery(name, email, gender, selectedUser));
            editCommand.Parameters.AddWithValue("Name", name);
            editCommand.Parameters.AddWithValue("Email", email);
            editCommand.Parameters.AddWithValue("Gender", gender);
            int editUserQuery = ObjDBAccess.executeQuery(editCommand);
            return editUserQuery;
        }

        public void cellClickFunction(DataGridViewCellEventArgs e, DataGridView grid, Button activatebtn, Button editbtn,
            TextBox nametxt, TextBox emailtxt, ComboBox gendertxt, Label namelbl, Label emaillbl, Label genderlbl)
        {
            try
            {               
                if (e.RowIndex >= 0)
                {           
                    grid.CurrentRow.Selected = true;
                    componentShow(activatebtn, editbtn, nametxt, emailtxt, gendertxt, namelbl, emaillbl, genderlbl);
                    DataGridViewRow row = grid.Rows[e.RowIndex];
                    selectedUserID = Convert.ToInt32(grid.Rows[e.RowIndex].Cells["ID"].Value);
                    nametxt.Text = row.Cells["Name"].Value.ToString();
                    emailtxt.Text = row.Cells["Email"].Value.ToString();
                    gendertxt.Text = row.Cells["Gender"].Value.ToString();                   
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        public void filterComboboxFunction(ComboBox filter, DataGridView grid)
        {
            string selectedFilter = filter.SelectedItem.ToString();

            if (selectedFilter == "All") refreshDataGridQuery(grid);
            else if (selectedFilter == "Activated" || selectedFilter == "Deactivated")
            {                
                comboboxApplyFilter("IsActive", UsersStrings.bitValueFilter(selectedFilter), grid);
            }
            else if (selectedFilter == "Male" || selectedFilter == "Female")
            {
                comboboxApplyFilter("Gender", selectedFilter, grid);
            }
        }

        public void comboboxApplyFilter(string column, string value, DataGridView grid)
        {
            try
            {
                DataTable comboboxFilter = comboBoxFilterQuery(column, value);
                if (comboboxFilter.Rows.Count > 0)
                {
                    grid.DataSource = comboboxFilter;
                    dataGridProperties(grid);
                }
                else
                {                  
                    MessageBox.Show(UsersStrings.comboFilterMesage(column,value), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable comboBoxFilterQuery(string column, string value)
        {           
            DataTable comboBoxFilterQuery = new DataTable();
            ObjDBAccess.readDatathroughAdapter(UsersStrings.comboFilterQuery(column,value), comboBoxFilterQuery);
            ObjDBAccess.closeConn();
            return comboBoxFilterQuery;
        }

        public void searchButtonFunction(DataGridView grid, ComboBox searchfilter, TextBox searchtxt)
        {
            string filterColumn = searchfilter.SelectedItem?.ToString();
            string filterValue = searchtxt.Text.Trim();

            if (string.IsNullOrEmpty(filterColumn) || string.IsNullOrEmpty(filterValue))
            {
                MessageBox.Show("Please select a filter and enter a value.");
                return;
            }

            if (filterColumn == "ID")
            {
                if (!int.TryParse(filterValue, out _))
                {
                    MessageBox.Show("Please enter a valid numeric ID.");
                    return;
                }
            }

            try
            {
                DataTable filteredUsers = searchButtonQuery(filterColumn, filterValue);
                if (filteredUsers.Rows.Count > 0)
                {
                    grid.DataSource = filteredUsers;
                    dataGridProperties(grid);
                }
                else MessageBox.Show("No matching users found.");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public DataTable searchButtonQuery(string column, string value)
        {          
            DataTable searchButtonQuery = new DataTable();
            ObjDBAccess.readDatathroughAdapter(UsersStrings.searchFilterQuery(column,value), searchButtonQuery);
            ObjDBAccess.closeConn();
            return searchButtonQuery;
        }

        public void refreshDataGridQuery(DataGridView grid)
        {
            DataTable refreshDataGrid = new DataTable();
            ObjDBAccess.readDatathroughAdapter(UsersStrings.getUsersQuery, refreshDataGrid);
            ObjDBAccess.closeConn();
            grid.DataSource = refreshDataGrid;           
        }

        public void componentHide(
    Button activateBtn,
    Button editBtn,
    TextBox nameTxt,
    TextBox emailTxt,
    ComboBox genderTxt,
    Label nameLbl,
    Label emailLbl,
    Label genderLbl)
        {
            activateBtn.Visible = false;
            editBtn.Visible = false;
            nameTxt.Visible = false;
            emailTxt.Visible = false;
            genderTxt.Visible = false;
            nameLbl.Visible = false;
            emailLbl.Visible = false;
            genderLbl.Visible = false;
        }

        public void componentShow(
   Button activateBtn,
   Button editBtn,
   TextBox nameTxt,
   TextBox emailTxt,
   ComboBox genderTxt,
   Label nameLbl,
   Label emailLbl,
   Label genderLbl)
        {
            activateBtn.Visible = true;
            editBtn.Visible = true;
            nameTxt.Visible = true;
            emailTxt.Visible = true;
            genderTxt.Visible = true;
            nameLbl.Visible = true;
            emailLbl.Visible = true;
            genderLbl.Visible = true;
        }

        public void dataGridProperties(DataGridView grid)
        {
            grid.Columns["ID"].SortMode = DataGridViewColumnSortMode.NotSortable;
            grid.Columns["Name"].SortMode = DataGridViewColumnSortMode.NotSortable;
            grid.Columns["Username"].SortMode = DataGridViewColumnSortMode.NotSortable;
            grid.Columns["Email"].SortMode = DataGridViewColumnSortMode.NotSortable;
            grid.Columns["Gender"].SortMode = DataGridViewColumnSortMode.NotSortable;
        }
    }
}
