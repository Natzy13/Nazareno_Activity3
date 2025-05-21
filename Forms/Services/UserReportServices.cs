using BogsySystem.Forms.Strings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BogsySystem.Forms.Services
{
    public class UserReportServices
    {
        private DBAccess ObjDBAccess = new DBAccess();

        public static int selectedUserID { get; private set; }

        public void userReportLoadFunction( DataGridView gridUsers, DataGridView activeRent, Label active,
            Label history, DataGridView userHistory, Label backlbl)
        {
            try
            {
                DataTable usersDisplay = GetUsersQuery();

                if (usersDisplay.Rows.Count > 0)
                {
                    gridUsers.DataSource = usersDisplay;
                    DataGridProperties1(gridUsers);
                }
                else MessageBox.Show("No active users found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            hideDataGrid(active, activeRent, history, userHistory,backlbl);
        }

        public DataTable GetUsersQuery()
        {
            DataTable usersDisplay = new DataTable();
            ObjDBAccess.readDatathroughAdapter(UserReportStrings.queryUsers, usersDisplay);
            return usersDisplay;
        }

        public void cellClickFunction(DataGridViewCellEventArgs e, DataGridView gridUsers, Label activerentlbl, 
            DataGridView activeRent, Label historylbl,DataGridView userHistory, Label backlbl)
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
                    UserActiveRent(activerentlbl, activeRent,backlbl);
                    UserHistory(historylbl, userHistory, backlbl);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        public void UserActiveRent(Label activerentlbl, DataGridView activeRent, Label backlbl)
        {
           
            DataTable usersActiveRent = GetUsersActiveRentalsQuery(selectedUserID);

            if (usersActiveRent.Rows.Count > 0)
            {
                showDataGridRent(activerentlbl, activeRent, backlbl);
                activeRent.DataSource = usersActiveRent;
                DataGridProperties2(activeRent);
            }
            else
            {
                hideDataGridRent(activerentlbl, activeRent, backlbl);
                activeRent.ClearSelection();                
                MessageBox.Show("User have no active rent", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //activeRent.DataSource = null;
            }
        }

        public DataTable GetUsersActiveRentalsQuery(int selectedUser)
        {
            DataTable usersActiveRent = new DataTable();
            ObjDBAccess.readDatathroughAdapter(UserReportStrings.getUsersActiveRentals(selectedUser), usersActiveRent);
            return usersActiveRent;
        }

        public void UserHistory(Label historylbl, DataGridView userHistory, Label backlbl)
        {
         
            DataTable usersHistory = GetUsersHistoryQuery(selectedUserID);

            if (usersHistory.Rows.Count > 0)
            {
                showDataGridHistory(historylbl, userHistory, backlbl);
                userHistory.DataSource = usersHistory;
                DataGridProperties3(userHistory);
            }
            else
            {
                hideDataGridHistory(historylbl, userHistory, backlbl);
                //userHistory.DataSource = null;
                userHistory.ClearSelection();
                MessageBox.Show("User have no history", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public DataTable GetUsersHistoryQuery(int selectedUser)
        {
            DataTable GetUsersHistoryQuery = new DataTable();
            ObjDBAccess.readDatathroughAdapter(UserReportStrings.getUsersHistoryQuery(selectedUser), GetUsersHistoryQuery);
            return GetUsersHistoryQuery;
        }

        public void searchButtonFunction(DataGridView grid, ComboBox searchfilter, TextBox searchtxt)
        {
            string filterColumn = searchfilter.SelectedItem?.ToString();
            string filterValue = searchtxt.Text.Trim();

            if (filterValue.Equals("all", StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    DataTable allUsers = GetUsersQuery();
                    grid.DataSource = allUsers;
                    DataGridProperties1(grid);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
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
                    DataGridProperties1(grid);
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
            ObjDBAccess.readDatathroughAdapter(UserReportStrings.filterSearch(column, value), searchQuery);
            ObjDBAccess.closeConn();
            return searchQuery;
        }

        public void hideDataGrid(Label active, DataGridView activeRent, Label history, DataGridView userHistory,
            Label backlbl)
        {
            active.Visible = false;
            activeRent.Visible = false;
            history.Visible = false;
            userHistory.Visible = false;
            backlbl.Visible = true;
        }

        public void hideDataGridRent(Label active, DataGridView activeRent, Label backlbl)
        {
            active.Visible = false;
            activeRent.Visible = false;          
            backlbl.Visible = true;
        }

        public void showDataGridRent(Label active, DataGridView activeRent,Label backlbl)
        {
            active.Visible = true;
            activeRent.Visible = true;           
            backlbl.Visible = false;
        }

        public void hideDataGridHistory(Label history, DataGridView userHistory,Label backlbl)
        {
           
            history.Visible = false;
            userHistory.Visible = false;
            backlbl.Visible = true;
        }

        public void showDataGridHistory(Label history, DataGridView userHistory,Label backlbl)
        {
            history.Visible = true;
            userHistory.Visible = true;
            backlbl.Visible = false;
        }

        public void DataGridProperties1(DataGridView grid)
        {
            grid.Columns["ID"].SortMode = DataGridViewColumnSortMode.NotSortable;
            grid.Columns["Name"].SortMode = DataGridViewColumnSortMode.NotSortable;
            grid.Columns["Username"].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        public void DataGridProperties2(DataGridView grid)
        {
            grid.Columns["Title"].SortMode = DataGridViewColumnSortMode.NotSortable;
            grid.Columns["Quantity"].SortMode = DataGridViewColumnSortMode.NotSortable;
            grid.Columns["RentalDate"].HeaderText = "Rent Date";
            grid.Columns["RentalDate"].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        public void DataGridProperties3(DataGridView grid)
        {
            grid.Columns["RentalDetailID"].Visible = false;
       
            grid.Columns["Title"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["TotalFee"].HeaderText = "Total";
            grid.Columns["TotalFee"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["RentalDate"].HeaderText = "Rent Date";
            grid.Columns["RentalDate"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["ReturnDate"].HeaderText = "Return Date";
            grid.Columns["ReturnDate"].SortMode = DataGridViewColumnSortMode.NotSortable;
        }
    }
}
