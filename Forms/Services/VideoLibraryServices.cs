using BogsySystem.Forms.Strings;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BogsySystem.Forms.Properties
{
    public class VideoLibraryServices
    {
        private DBAccess ObjDBAccess = new DBAccess();

        private int MediaID { get; set; }
        private string Title { get;  set; }
        private string Format { get; set; }
        private int MaxRent { get; set; }
        private int Total { get; set; }
        private decimal Price { get; set; }
        private int CurrentAvailablecopies { get; set; }
        private int CurrentTotalcopies { get; set; }
        private int ActiveRent { get; set; }

        public DataTable displayMedia()
        {           
            DataTable mediaDt = new DataTable();
            ObjDBAccess.readDatathroughAdapter(VideoLibraryStrings.displayMedia, mediaDt);
            return mediaDt;
        }

        public void vidLoadFunction(ComboBox filter, Button edit, Button remove, DataGridView grid)
        {
            componentProperties3(filter, edit, remove);
            try
            {
                DataTable mediaDt = displayMedia();
                if (mediaDt.Rows.Count > 0)
                {
                    grid.DataSource = mediaDt;
                    refreshDataGrid(grid);
                }
                else MessageBox.Show("No records found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AddButtonFunction(TextBox vidtitle, ComboBox format, ComboBox maxrent, NumericUpDown total, DataGridView grid)
        {           
            Title = vidtitle.Text;
            Format = format.Text;
            MaxRent = int.Parse(maxrent.Text);
            Total = (int)total.Value;
            int available = Total;

            if (string.IsNullOrEmpty(Title))
            {
                MessageBox.Show("Title is required");
                return;
            }
            if (Format.Equals("Select"))
            {
                MessageBox.Show("Format is required");
                return;
            }
            if (MaxRent.Equals(0))
            {
                MessageBox.Show("Select max rent");
                return;
            }

            else
            {
                int row = addMediaQuery(Title, Format, available, Total, Price, MaxRent);
                if (row == 1)
                {
                    MessageBox.Show("Media Created Successfully");
                    refreshDataGrid(grid);
                    clearDataFields(vidtitle, format, maxrent, total);
                }
                else MessageBox.Show("Error creating media");
            }
        }

        public int addMediaQuery(string title,string format, int available, int total, decimal price, int maxRent)
        {         
            price = (format == "VCD") ? 25 : 50;
            SqlCommand insertMedia = new SqlCommand(VideoLibraryStrings.addMedia);
            insertMedia.Parameters.AddWithValue("@title", title);
            insertMedia.Parameters.AddWithValue("@format", format);
            insertMedia.Parameters.AddWithValue("@available", available);
            insertMedia.Parameters.AddWithValue("@total", total);
            insertMedia.Parameters.AddWithValue("@price", price);
            insertMedia.Parameters.AddWithValue("@maxRent", maxRent);
            int row = ObjDBAccess.executeQuery(insertMedia);
            return row;
        }

        public void EditButtonFunction(TextBox vidtitle, ComboBox format, ComboBox maxrent, NumericUpDown total, DataGridView grid)
        {
            string displayTitle = vidtitle.Text;
            string displayFormat = format.Text;
            int displayMaxRent = int.Parse(maxrent.Text);
            int newTotal = (int)total.Value;

            ActiveRent = CurrentTotalcopies - CurrentAvailablecopies; //Check for how many copies rented
            int addedCopies = newTotal - CurrentTotalcopies; //New copies to be added
            int displaynewavailablecopies = CurrentAvailablecopies + addedCopies; //This will be added to the database for new available copies
            
            if (string.IsNullOrEmpty(displayTitle))
            {
                MessageBox.Show("Title is required");
                return;
            }
            if (displayFormat.Equals("Select"))
            {
                MessageBox.Show("Format is required");
                return;
            }
            if (displayMaxRent.Equals(0))
            {
                MessageBox.Show("Max Rent is required");
                return;
            }
            if (displaynewavailablecopies < 0 || newTotal < ActiveRent)
            {
                MessageBox.Show("You can't reduce below rented copies");
                return;
            }

            else
            {
                DialogResult confirmResult = MessageBox.Show("Are you sure you want to save these changes?", "Confirm Edit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    int row = editMediaQuery(displayTitle, displayFormat, displaynewavailablecopies, newTotal, Price, displayMaxRent, MediaID);
                    if (row == 1)
                    {
                        MessageBox.Show("Media Updated Successfully");
                        refreshDataGrid(grid);
                        clearDataFields(vidtitle, format, maxrent, total);
                    }
                    else MessageBox.Show("There is an error updating");
                }
            }
        }

        public int editMediaQuery(string displaytitle, string displayformat, int displaynewavailablecopies, int displaynewtotalcopies, decimal price, int displaymaxRent, int mediaID)
        {
            price = (displayformat == "VCD") ? 25 : 50;

            SqlCommand editCommand = new SqlCommand(VideoLibraryStrings.editMedia);
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

        public void RemoveButtonFunction(DataGridView grid, TextBox vidtitle, ComboBox format, ComboBox maxrent, NumericUpDown total)
        {
            ActiveRent = CurrentTotalcopies - CurrentAvailablecopies;
            if (CurrentAvailablecopies != CurrentTotalcopies) MessageBox.Show("Media cannot be removed since there are " + ActiveRent + " active rentals");
            else
            {
                DialogResult dialog = MessageBox.Show("Do you want to remove this media", "Remove Media", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialog == DialogResult.Yes)
                {
                    int row = removeMediaQuery(MediaID);
                    if (row == 1)
                    {
                        MessageBox.Show("Media Remove Successfully");
                       clearDataFields(vidtitle, format, maxrent, total);
                       refreshDataGrid(grid);
                    }
                    else MessageBox.Show("Deletion Error");
                }
            }
        }

        public int removeMediaQuery(int mediaID)
        {
            SqlCommand deleteMedia = new SqlCommand(VideoLibraryStrings.removeMedia(mediaID));
            int row = ObjDBAccess.executeQuery(deleteMedia);
            return row;
        }

        public void cellClickFunction(DataGridViewCellEventArgs e, DataGridView grid, Button addbtn, 
            Button editbtn, Button removebtn, TextBox vidtitle, ComboBox format, ComboBox maxrent, NumericUpDown total)
        {
            try
            {
                // Check if the clicked event was on a valid row
                if (e.RowIndex >= 0)
                {
                    // Select the current row
                    grid.CurrentRow.Selected = true;
                    componentProperties2(addbtn, editbtn, removebtn);
                    // Retrieve and display data from the selected row
                    DataGridViewRow row = grid.Rows[e.RowIndex];

                    MediaID = Convert.ToInt32(row.Cells["MediaID"].Value);
                    vidtitle.Text = row.Cells["Title"].Value.ToString();
                    format.Text = row.Cells["Format"].Value.ToString();
                    CurrentAvailablecopies = Convert.ToInt32(row.Cells["AvailableCopies"].Value);
                    total.Value = Convert.ToInt32(row.Cells["TotalCopies"].Value);
                    CurrentTotalcopies = Convert.ToInt32(row.Cells["TotalCopies"].Value);
                    maxrent.Text = Convert.ToInt32(row.Cells["MaxRentalDays"].Value).ToString();
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
               refreshDataGrid(grid);
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
                DataTable mediaDt = comboBoxFilterQuery(column, value);

                if (mediaDt.Rows.Count > 0)
                {
                    grid.DataSource = mediaDt;
                    dataGridProperties(grid);
                }
                else
                {
                    MessageBox.Show(VideoLibraryStrings.comboFilterMessage(column, value), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable comboBoxFilterQuery(string column, string value)
        {
            DataTable mediaDt = new DataTable();
            ObjDBAccess.readDatathroughAdapter(VideoLibraryStrings.comboFilterQuery(column, value), mediaDt);
            ObjDBAccess.closeConn();
            return mediaDt;
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

                filterColumn = "MediaID";
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
                    dataGridProperties(grid);
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
            ObjDBAccess.readDatathroughAdapter(VideoLibraryStrings.filterSearch(), mediaDt);
            ObjDBAccess.closeConn();
            return mediaDt;
        }

        public void refreshDataGrid(DataGridView grid)
        {            
            DataTable mediaDt = new DataTable();
            ObjDBAccess.readDatathroughAdapter(VideoLibraryStrings.displayMedia, mediaDt);
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
