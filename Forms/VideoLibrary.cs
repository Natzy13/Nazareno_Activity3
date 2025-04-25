using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace BogsySystem.Forms
{
    public partial class VideoLibrary : Form
    {
        DBAccess ObjDBAccess = new DBAccess();
        private int mediaID, currentAvailablecopies, currentTotalcopies, activeRent;
        private decimal price;

        public VideoLibrary()
        {
            InitializeComponent();
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            string title = vidtitletxt.Text;
            string format = formatxt.Text;
            int maxRent = int.Parse(maxrenttxt.Text);
            int total = (int)quantitytxt.Value;
            int available = total;

            if (title.Equals(""))
            {
                MessageBox.Show("Enter Title");
            }
            else if (format.Equals("Select"))
            {
                MessageBox.Show("Select media format");
            }
            else if (maxRent == 0)
            {
                MessageBox.Show("Select max rent");
            }
            else
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

                if (row == 1)
                {
                    MessageBox.Show("Media Created Successfully");
                    refreshDataGrid();
                    clearDataFields();
                }

                else
                {
                    MessageBox.Show("Error creating media");
                }
            }
        }

        private void VideoLibrary_Load(object sender, EventArgs e)
        {
            try
            {
                String tablequery = "SELECT * FROM MediaItems WHERE IsAvailable = 1";
                DataTable mediaDt = new DataTable();
                ObjDBAccess.readDatathroughAdapter(tablequery, mediaDt);

                if (mediaDt.Rows.Count > 0)
                {
                    dataGridVid.DataSource = mediaDt;
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

        private void editbtn_Click(object sender, EventArgs e)
        {
            string displaytitle = vidtitletxt.Text;
            string displayformat = formatxt.Text;
            int displaymaxRent = int.Parse(maxrenttxt.Text);
            int displaynewtotalcopies = (int)quantitytxt.Value;

            activeRent = currentTotalcopies - currentAvailablecopies; //Check for how many copies rented
            int addedCopies = displaynewtotalcopies - currentTotalcopies; //New copies to be added
            int displaynewavailablecopies = currentAvailablecopies + addedCopies; //This will be added to the database for new available copies

            if (displaytitle.Equals(""))
            {
                MessageBox.Show("Enter Title");
            }
            else if (displayformat.Equals("Select"))
            {
                MessageBox.Show("Select media format");
            }
            else if (displaymaxRent == 0)
            {
                MessageBox.Show("Select max rent");
            }
            else if (displaynewavailablecopies < 0 || displaynewtotalcopies < activeRent)
            {
                MessageBox.Show("You can't reduce below rented copies");

            }
            else
            {
                price = (displayformat == "VCD") ? 25 : 50;
                SqlCommand editCommand = new SqlCommand("Update MediaItems SET Title= '" + @displaytitle + "',Format= '" + @displayformat + "',AvailableCopies= '" + displaynewavailablecopies + "',TotalCopies= '" + @displaynewtotalcopies + "',Price= '" + @price + "',MaxRentalDays= '" + @displaymaxRent + "' where MediaID = '" + mediaID + "'");

                editCommand.Parameters.AddWithValue("@title", @displaytitle);
                editCommand.Parameters.AddWithValue("@format", @displayformat);
                editCommand.Parameters.AddWithValue("@total", @displaynewtotalcopies);
                editCommand.Parameters.AddWithValue("@price", @price);
                editCommand.Parameters.AddWithValue("@maxRent", @displaymaxRent);

                //This method from DBAccess, execute the sql command
                int row = ObjDBAccess.executeQuery(editCommand);

                if (row == 1)
                {
                    MessageBox.Show("Account Updated Successfully");
                    refreshDataGrid();
                    clearDataFields();
                }

                else
                {
                    MessageBox.Show("There is an error updating");
                }
            }

        }

        private void dataGridVid_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                // Check if the clicked event was on a valid row
                if (e.RowIndex >= 0)
                {
                    // Select the current row
                    dataGridVid.CurrentRow.Selected = true;
                    addbtn.Visible = false;
                    // Retrieve and display data from the selected row
                    mediaID = Convert.ToInt32(dataGridVid.Rows[e.RowIndex].Cells["MediaID"].Value);
                    vidtitletxt.Text = dataGridVid.Rows[e.RowIndex].Cells["Title"].Value.ToString();
                    formatxt.Text = dataGridVid.Rows[e.RowIndex].Cells["Format"].Value.ToString();
                    currentAvailablecopies = Convert.ToInt32(dataGridVid.Rows[e.RowIndex].Cells["AvailableCopies"].Value); //Current available copies
                    quantitytxt.Value = Convert.ToInt32(dataGridVid.Rows[e.RowIndex].Cells["TotalCopies"].Value);
                    currentTotalcopies = Convert.ToInt32(dataGridVid.Rows[e.RowIndex].Cells["TotalCopies"].Value); //Current total copies
                    maxrenttxt.Text = Convert.ToInt32(dataGridVid.Rows[e.RowIndex].Cells["MaxRentalDays"].Value).ToString();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void dataGridVid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridVid.ClearSelection();  // Deselect the row            
            clearDataFields();
            addbtn.Visible = true;

        }

        private void refreshDataGrid() //Method to refresh data grid
        {
            string tableQuery = "SELECT * FROM MediaItems WHERE IsAvailable = 1";
            DataTable mediaDt = new DataTable();
            ObjDBAccess.readDatathroughAdapter(tableQuery, mediaDt);
            dataGridVid.DataSource = mediaDt;
            dataGridProperties();
        }

        void clearDataFields()
        {
            vidtitletxt.Clear();
            formatxt.Text = "Select";
            maxrenttxt.Text = "0";
            quantitytxt.Value = 1;
        }

        void dataGridProperties()
        {
            dataGridVid.Columns["MediaID"].HeaderText = "ID";
            dataGridVid.Columns["MediaID"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridVid.Columns["Title"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridVid.Columns["Format"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridVid.Columns["AvailableCopies"].HeaderText = "Available";
            dataGridVid.Columns["AvailableCopies"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridVid.Columns["TotalCopies"].HeaderText = "Total Quantity";
            dataGridVid.Columns["TotalCopies"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridVid.Columns["Price"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridVid.Columns["MaxRentalDays"].HeaderText = "Max Rent Days";
            dataGridVid.Columns["MaxRentalDays"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridVid.Columns["IsAvailable"].Visible = false;
        }

        private void dataGridVid_Click(object sender, EventArgs e)
        {
            dataGridVid.ClearSelection();
            clearDataFields();
            addbtn.Visible = true;
        }

        private void removebtn_Click(object sender, EventArgs e)
        {
            activeRent = currentTotalcopies - currentAvailablecopies;
            if (currentAvailablecopies != currentTotalcopies)
            {
                MessageBox.Show("Media cannot be removed since there are " + activeRent + " active rentals");
            }
            else
            {
                DialogResult dialog = MessageBox.Show("Do you want to remove this media", "Remove Media", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialog == DialogResult.Yes)
                {
                    SqlCommand deleteMedia = new SqlCommand("UPDATE MediaItems SET IsAvailable = 0 WHERE MediaID = '" + mediaID + "' ");

                    int row = ObjDBAccess.executeQuery(deleteMedia);

                    if (row == 1)
                    {
                        MessageBox.Show("Media Remove Successfully");
                        clearDataFields();
                        refreshDataGrid();
                    }

                    else
                    {
                        MessageBox.Show("Deletion Error");
                    }
                }
            }
        }

        private void filterbtn_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFilter = filterbtn.SelectedItem.ToString();

            if (selectedFilter == "All")
            {
                refreshDataGrid();
            }
            else if (selectedFilter == "VCD" || selectedFilter == "DVD")
            {    
                ApplyFilter("Format", selectedFilter);
            }
            else if (selectedFilter.StartsWith("Max Rent"))
            {
                // Extract the number of days from the filter text
                var match = Regex.Match(selectedFilter, @"\d+");
                if (match.Success)
                {
                    string days = match.Value;
                    ApplyFilter("MaxRentalDays", days);
                }
            }
        }

        void ApplyFilter(string column, string value)
        {
            try
            {
                String tablequery = $"SELECT * FROM MediaItems WHERE IsAvailable = 1 AND {column} = '{value}'";
                DataTable mediaDt = new DataTable();
                ObjDBAccess.readDatathroughAdapter(tablequery, mediaDt);
                ObjDBAccess.closeConn();

                if (mediaDt.Rows.Count > 0)
                {
                    dataGridVid.DataSource = mediaDt;
                    dataGridProperties();
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
    }
}
