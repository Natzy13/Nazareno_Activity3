using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BogsySystem.Forms.Properties
{
    public class VideoLibraryServices
    {
        private DBAccess ObjDBAccess = new DBAccess();
        public DataTable displayMedia()
        {
            String tablequery = "SELECT * FROM MediaItems WHERE IsAvailable = 1";
            DataTable mediaDt = new DataTable();
            ObjDBAccess.readDatathroughAdapter(tablequery, mediaDt);
            return mediaDt;
        }

        public int addMedia(string title,string format, int available, int total, decimal price, int maxRent)
        {
            price = (format == "VCD") ? 25 : 50;
            SqlCommand insertMedia = new SqlCommand("Insert into MediaItems(Title, Format, AvailableCopies, TotalCopies, Price, MaxRentalDays) Values (@title, @format, @available, @total, @price, @maxRent)");
            insertMedia.Parameters.AddWithValue("@title", title);
            insertMedia.Parameters.AddWithValue("@format", format);
            insertMedia.Parameters.AddWithValue("@available", available);
            insertMedia.Parameters.AddWithValue("@total", total);
            insertMedia.Parameters.AddWithValue("@price", price);
            insertMedia.Parameters.AddWithValue("@maxRent", maxRent);
            int row = ObjDBAccess.executeQuery(insertMedia);
            return row;
        }

        public int editMedia(string displaytitle, string displayformat, int displaynewavailablecopies, int displaynewtotalcopies, decimal price, int displaymaxRent, int mediaID)
        {
            price = (displayformat == "VCD") ? 25 : 50;

            SqlCommand editCommand = new SqlCommand(
                "Update MediaItems SET Title = @title, Format = @format, AvailableCopies = @available, TotalCopies = @total, Price = @price, MaxRentalDays = @maxRent WHERE MediaID = @mediaID"
            );
            editCommand.Parameters.AddWithValue("@title", displaytitle);
            editCommand.Parameters.AddWithValue("@format", displayformat);
            editCommand.Parameters.AddWithValue("@available", displaynewavailablecopies);
            editCommand.Parameters.AddWithValue("@total", displaynewtotalcopies);
            editCommand.Parameters.AddWithValue("@price", price);
            editCommand.Parameters.AddWithValue("@maxRent", displaymaxRent);
            editCommand.Parameters.AddWithValue("@mediaID", mediaID);
            int row = ObjDBAccess.executeQuery(editCommand);
            return row;
        }

        public int removeMedia(int mediaID)
        {
            SqlCommand deleteMedia = new SqlCommand("UPDATE MediaItems SET IsAvailable = 0 WHERE MediaID = '" + mediaID + "' ");
            int row = ObjDBAccess.executeQuery(deleteMedia);
            return row;
        }

        public DataTable Filter(string column, string value)
        {
            String tablequery = $"SELECT * FROM MediaItems WHERE IsAvailable = 1 AND {column} = '{value}'";
            DataTable mediaDt = new DataTable();
            ObjDBAccess.readDatathroughAdapter(tablequery, mediaDt);
            ObjDBAccess.closeConn();
            return mediaDt;
        }

        public void ApplyFilter(string column, string value, DataGridView grid)
        {
            try
            {
                DataTable mediaDt = Filter(column, value);

                if (mediaDt.Rows.Count > 0)
                {
                    grid.DataSource = mediaDt;
                    dataGridProperties(grid);
                }
                else
                {
                    string message = column == "Format"
                    ? $"No {value} media found."
                    : $"No media found with a {value}-day maximum rental period.";

                    MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable FilterSearch(string column, string value)
        {
            string condition = column == "MediaID"
                ? $"{column} = '{value}'"
                : $"{column} LIKE '%{value}%'";
         
            String tablequery = $"SELECT * FROM MediaItems WHERE IsAvailable = 1 AND {condition}";
            DataTable mediaDt = new DataTable();
            ObjDBAccess.readDatathroughAdapter(tablequery, mediaDt);
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

                filterColumn = "MediaID";
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
                    dataGridProperties(grid);
                }
                else MessageBox.Show("No matching media found.");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public void refreshDataGrid(DataGridView grid)
        {
            string tableQuery = "SELECT * FROM MediaItems WHERE IsAvailable = 1";
            DataTable mediaDt = new DataTable();
            ObjDBAccess.readDatathroughAdapter(tableQuery, mediaDt);
            grid.DataSource = mediaDt;
            dataGridProperties(grid);
        }

        public void clearDataFields(TextBox vidtitletxt, ComboBox formatxt, ComboBox maxrenttxt, NumericUpDown quantitytxt)
        {
            vidtitletxt.Clear();
            formatxt.Text = "Select";
            maxrenttxt.Text = "0";
            quantitytxt.Value = 1;
        }

        public void componentProperties(Button addbtn, Button editbtn, Button removebtn)
        {
            addbtn.Visible = true;
            editbtn.Visible = false;
            removebtn.Visible = false;
        }

        public void componentProperties2(Button addbtn, Button editbtn, Button removebtn)
        {
            addbtn.Visible = false;
            editbtn.Visible = true;
            removebtn.Visible = true;
        }

        public void componentProperties3(ComboBox filterbtn,Button editbtn, Button removebtn)
        {

            filterbtn.SelectedIndex = 0;
            editbtn.Visible = false;
            removebtn.Visible = false;
        }
     

        public void dataGridProperties(DataGridView grid)
        {
            grid.Columns["MediaID"].HeaderText = "ID";
            grid.Columns["MediaID"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["Title"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["Format"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["AvailableCopies"].HeaderText = "Available";
            grid.Columns["AvailableCopies"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["TotalCopies"].HeaderText = "Total Quantity";
            grid.Columns["TotalCopies"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["Price"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["MaxRentalDays"].HeaderText = "Max Rent Days";
            grid.Columns["MaxRentalDays"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["IsAvailable"].Visible = false;
        }

      
    }
}
