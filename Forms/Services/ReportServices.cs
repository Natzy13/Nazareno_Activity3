using BogsySystem.Forms.Strings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BogsySystem.Forms.Properties
{
    public class ReportServices
    {
        private DBAccess ObjDBAccess = new DBAccess();

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

        public DataTable FilterSearch(string column, string value)
        {           
            DataTable mediaDt = new DataTable();
            ObjDBAccess.readDatathroughAdapter(ReportStrings.filterSearch(column,value), mediaDt);
            ObjDBAccess.closeConn();
            return mediaDt;
        }

        public void searchFunction(DataGridView grid, ComboBox searchfilter, TextBox searchtxt)
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
                DataTable filteredUsers = FilterSearch(filterColumn, filterValue);
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
