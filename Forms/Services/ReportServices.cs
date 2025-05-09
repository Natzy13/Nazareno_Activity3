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
                DataTable mediaReport = GetMediaReportQuery();

                if (mediaReport.Rows.Count > 0)
                {
                    gridReport.DataSource = mediaReport;
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
                DataTable usersDisplay = GetUsersQuery();

                if (usersDisplay.Rows.Count > 0)
                {
                    gridUsers.DataSource = usersDisplay;
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

        public void cellClickFunction(DataGridViewCellEventArgs e, DataGridView gridUsers, Label activerentlbl, DataGridView activeRent)
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

            DataTable usersActiveRent = GetUsersActiveRentalsQuery(selectedUserID);

            if (usersActiveRent.Rows.Count > 0)
            {
                activeRent.DataSource = usersActiveRent;
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

        public DataTable GetMediaReportQuery()
        {           
            DataTable mediaReport = new DataTable();
            ObjDBAccess.readDatathroughAdapter(ReportStrings.queryReport, mediaReport);
            return mediaReport;
        }

        public DataTable GetUsersQuery() 
        {           
            DataTable usersDisplay = new DataTable();
            ObjDBAccess.readDatathroughAdapter(ReportStrings.queryUsers, usersDisplay);
            return usersDisplay;
        }

        public DataTable GetUsersActiveRentalsQuery(int selectedUser)
        {        
            DataTable usersActiveRent = new DataTable();
            ObjDBAccess.readDatathroughAdapter(ReportStrings.getUsersActiveRentals(selectedUser), usersActiveRent);
            return usersActiveRent;
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
            DataTable searchQuery = new DataTable();
            ObjDBAccess.readDatathroughAdapter(ReportStrings.filterSearch(column, value), searchQuery);
            ObjDBAccess.closeConn();
            return searchQuery;
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
