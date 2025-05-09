﻿using BogsySystem.Forms.Properties;
using BogsySystem.UserForms.Strings;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BogsySystem.UserForms.Services
{
    public class UserRentServices
    {
        DBAccess ObjDBAccess = new DBAccess();
        private string Title { get; set; }
        private int MediaID { get; set; }
        private int AvailableCopies { get; set; }

        public void userRentLoad(Label quantitylbl, NumericUpDown quantitytxt, Button rentbtn, DataGridView grid)
        {
            componentHide(quantitylbl, quantitytxt, rentbtn);
            try
            {
                DataTable displayRent = displayMediaQuery();

                if (displayRent.Rows.Count > 0)
                {
                    grid.DataSource = displayRent;
                    dataGridProperties(grid);
                }
                else MessageBox.Show("No records found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable displayMediaQuery()
        {
            DataTable displayMediaQuery = new DataTable();
            ObjDBAccess.readDatathroughAdapter(UserRentStrings.displayMediaQuery, displayMediaQuery);
            ObjDBAccess.closeConn();
            return displayMediaQuery;
        }

        public void rentButtonFunction(NumericUpDown quantitytxt, DataGridView grid)
        {
            int quantity = (int)quantitytxt.Value;
            int userID = int.Parse(LoginServices.ID);

            if (quantity > AvailableCopies) MessageBox.Show("Not enough copies available!");
            else
            {
                int rowUserRent = userRentQuery(userID, MediaID, quantity);

                if (rowUserRent > 0)
                {
                    MessageBox.Show($"Successfully rented {quantity} copies of " + Title);
                    quantitytxt.Value = 1;
                    grid.ClearSelection();
                    refreshDataGridQuery(grid);
                }
                else MessageBox.Show("There was an error with the rental.");
            }
        }

        public int userRentQuery(int userID, int mediaID, int quantity)
        {
            SqlCommand combinedCommand = new SqlCommand(UserRentStrings.userRentQuery);
            combinedCommand.Parameters.AddWithValue("@userID", userID);
            combinedCommand.Parameters.AddWithValue("@mediaID", mediaID);
            combinedCommand.Parameters.AddWithValue("@rentalDate", DateTime.Now);
            combinedCommand.Parameters.AddWithValue("@quantity", quantity);
            int userRentQuery = ObjDBAccess.executeQuery(combinedCommand);
            ObjDBAccess.closeConn();
            return userRentQuery;
        }

        public void cellClickFunction(DataGridViewCellEventArgs e, DataGridView grid, Label quantitylbl, 
            NumericUpDown quantitytxt, Button rentbtn)
        {
            try
            {
                // Check if the clicked event was on a valid row
                if (e.RowIndex >= 0)
                {
                    // Select the current row
                    grid.CurrentRow.Selected = true;
                    componentShow(quantitylbl, quantitytxt, rentbtn);

                    DataGridViewRow row = grid.Rows[e.RowIndex];
                    // Retrieve the selected data into a variable
                    MediaID = Convert.ToInt32(row.Cells["MediaID"].Value);
                    Title = row.Cells["Title"].Value.ToString();
                    AvailableCopies = Convert.ToInt32(row.Cells["AvailableCopies"].Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        public void filterComboboxFunction(ComboBox filterbtn, DataGridView grid)
        {
            string selectedFilter = filterbtn.SelectedItem.ToString();

            if (selectedFilter == "All")
            {
                refreshDataGridQuery(grid);
            }
            else if (selectedFilter == "VCD" || selectedFilter == "DVD")
            {
                comboboxApplyFilter("Format", selectedFilter, grid);
            }
            else if (selectedFilter.StartsWith("Max Rent"))
            {
                // Extract the number of days from the filter text
                var match = Regex.Match(selectedFilter, @"\d+");
                if (match.Success)
                {
                    string days = match.Value;
                    comboboxApplyFilter("MaxRentalDays", days, grid);
                }
            }
        }

        public void comboboxApplyFilter(string column, string value, DataGridView grid)
        {
            try
            {
                DataTable comboboxFilter = comboboxFilterQuery(column, value);

                if (comboboxFilter.Rows.Count > 0)
                {
                    grid.DataSource = comboboxFilter;
                    dataGridProperties(grid);
                }
                else
                {
                    
                    MessageBox.Show(UserRentStrings.comboFilterMessage(column,value), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable comboboxFilterQuery(string column, string value)
        {
            DataTable comboboxFilterQuery = new DataTable();
            ObjDBAccess.readDatathroughAdapter(UserRentStrings.comboFilterQuery(column, value), comboboxFilterQuery);
            ObjDBAccess.closeConn();
            return comboboxFilterQuery;
        }

        public void searchButtonFunction(DataGridView grid, TextBox searchtxt)
        {
            string filterValue = searchtxt.Text.Trim();

            try
            {
                DataTable filteredMedia = searchButtonQuery(filterValue);
                if (filteredMedia.Rows.Count > 0)
                {
                    grid.DataSource = filteredMedia;
                    dataGridProperties(grid);
                }
                else MessageBox.Show("No matching media found.");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public DataTable searchButtonQuery(string value)
        {           
            DataTable searchButtonQuery = new DataTable();
            ObjDBAccess.readDatathroughAdapter(UserRentStrings.filterSearch(value), searchButtonQuery);
            ObjDBAccess.closeConn();
            return searchButtonQuery;
        }

        public void refreshDataGridQuery(DataGridView grid)
        {           
            DataTable refreshDataGrid = new DataTable();
            ObjDBAccess.readDatathroughAdapter(UserRentStrings.displayMediaQuery, refreshDataGrid);
            ObjDBAccess.closeConn();
            grid.DataSource = refreshDataGrid;
            dataGridProperties(grid);
        }

        public void componentHide(Label quantitylbl,Control quantitytxt, Button rentbtn)
        {
            quantitylbl.Visible = false;
            quantitytxt.Visible = false;
            rentbtn.Visible = false;
        }

        public void componentShow(Label quantitylbl, Control quantitytxt, Button rentbtn)
        {
            quantitylbl.Visible = true;
            quantitytxt.Visible = true;
            rentbtn.Visible = true;
        }

        public void dataGridProperties(DataGridView grid)
        {
            grid.Columns["MediaID"].Visible = false;

            grid.Columns["Title"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["Format"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["AvailableCopies"].HeaderText = "Available";
            grid.Columns["AvailableCopies"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["Price"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["MaxRentalDays"].HeaderText = "Max Rent Days";
            grid.Columns["MaxRentalDays"].SortMode = DataGridViewColumnSortMode.NotSortable;
        }
    }
}
