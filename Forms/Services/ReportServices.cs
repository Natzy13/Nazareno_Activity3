using BogsySystem.Forms.Strings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BogsySystem.Forms.Properties
{
    public class ReportServices
    {
        private DBAccess ObjDBAccess = new DBAccess();

        public static int selectedUserID { get; private set; }

        public void reportLoadFunction(DataGridView gridReport, DataGridView gridUsers, DataGridView activeRent, Label active)
        {
            try
            {
                DataTable media = GetMediaReport();

                if (media.Rows.Count > 0)
                {
                    gridReport.DataSource = media;
                    DataGridProperties1(gridReport);
                }
                else MessageBox.Show("No media found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                DataTable users = GetUsers();

                if (users.Rows.Count > 0)
                {
                    gridUsers.DataSource = users;
                    DataGridProperties2(gridUsers);
                }
                else MessageBox.Show("No active users found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            active.Visible = false;
            activeRent.Visible = false;
        }

        public void userGridFunction(DataGridViewCellEventArgs e, DataGridView gridUsers, Label activerentlbl, DataGridView activeRent)
        {
            try
            {
                // Check if the clicked event was on a valid row
                if (e.RowIndex >= 0)
                {
                    // Select the current row
                    gridUsers.CurrentRow.Selected = true;

                    // Retrieve the selected data into a variable
                    selectedUserID = Convert.ToInt32(gridUsers.Rows[e.RowIndex].Cells["ID"].Value);
                    UserActiveRent(activerentlbl, activeRent);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        public void UserActiveRent(Label activerentlbl, DataGridView activeRent)
        {
            activerentlbl.Visible = true;
            activeRent.Visible = true;

            DataTable rentMedia = GetUsersActiveRentals(selectedUserID);

            if (rentMedia.Rows.Count > 0)
            {
                activeRent.DataSource = rentMedia;
                DataGridProperties3(activeRent);
            }
            else
            {
                activerentlbl.Visible = false;
                activeRent.Visible = false;
                activeRent.ClearSelection();
                MessageBox.Show("User have no active rent", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public DataTable GetMediaReport()
        {           
            DataTable mediaDt = new DataTable();
            ObjDBAccess.readDatathroughAdapter(ReportStrings.queryReport, mediaDt);
            return mediaDt;
        }

        public DataTable GetUsers() 
        {           
            DataTable mediaDt2 = new DataTable();
            ObjDBAccess.readDatathroughAdapter(ReportStrings.queryUsers, mediaDt2);
            return mediaDt2;
        }

        public DataTable GetUsersActiveRentals(int selectedUser)
        {        
            DataTable mediaDt3 = new DataTable();
            ObjDBAccess.readDatathroughAdapter(ReportStrings.getUsersActiveRentals(selectedUser), mediaDt3);
            return mediaDt3;
        }

        public void searchButtonFunction(DataGridView grid, ComboBox searchfilter, TextBox searchtxt)
        {
            string filterColumn = searchfilter.SelectedItem?.ToString();
            string filterValue = searchtxt.Text.Trim();

            if (filterColumn == "ID")
            {
                if (!int.TryParse(filterValue, out _))
                {
                    MessageBox.Show("Please enter a valid numeric ID.");
                    return;
                }
            }

            if (string.IsNullOrEmpty(filterColumn) || string.IsNullOrEmpty(filterValue))
            {
                MessageBox.Show("Please select a filter and enter a value.");
                return;
            }

            try
            {
                DataTable filteredUsers = searchButtonQuery(filterColumn, filterValue);
                if (filteredUsers.Rows.Count > 0)
                {
                    grid.DataSource = filteredUsers;
                    DataGridProperties2(grid);
                }
                else MessageBox.Show("No matching media found.");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public DataTable searchButtonQuery(string column, string value)
        {
            DataTable mediaDt = new DataTable();
            ObjDBAccess.readDatathroughAdapter(ReportStrings.filterSearch(column, value), mediaDt);
            ObjDBAccess.closeConn();
            return mediaDt;
        }

        public void DataGridProperties1(DataGridView grid)
        {
            grid.Columns["Title"].SortMode = DataGridViewColumnSortMode.NotSortable;
            grid.Columns["AvailableCopies"].HeaderText = "IN";
            grid.Columns["AvailableCopies"].SortMode = DataGridViewColumnSortMode.NotSortable;
            grid.Columns["RentedCopies"].HeaderText = "OUT";
            grid.Columns["RentedCopies"].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        public void DataGridProperties2(DataGridView grid)
        {
            grid.Columns["ID"].SortMode = DataGridViewColumnSortMode.NotSortable;
            grid.Columns["Name"].SortMode = DataGridViewColumnSortMode.NotSortable;
            grid.Columns["Username"].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        public void DataGridProperties3(DataGridView grid)
        {
            grid.Columns["Title"].SortMode = DataGridViewColumnSortMode.NotSortable;
            grid.Columns["Quantity"].SortMode = DataGridViewColumnSortMode.NotSortable;
            grid.Columns["RentalDate"].HeaderText = "Rent Date";
            grid.Columns["RentalDate"].SortMode = DataGridViewColumnSortMode.NotSortable;
        }
    }
}
