using BogsySystem.Forms.Properties;
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
        VideoLibraryServices services = new VideoLibraryServices();
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

            if (title.Equals("")) MessageBox.Show("Enter Title");            
            else if (format.Equals("Select"))  MessageBox.Show("Select media format");            
            else if (maxRent == 0) MessageBox.Show("Select max rent");           
            else
            {
                int row = services.addMedia(title, format, available, total, price, maxRent);
                if (row == 1)
                {
                    MessageBox.Show("Media Created Successfully");
                    services.refreshDataGrid(dataGridVid);
                    clearDataFields();
                }
                else MessageBox.Show("Error creating media");               
            }
        }

        private void VideoLibrary_Load(object sender, EventArgs e)
        {
            filterbtn.SelectedIndex = 0;
            editbtn.Visible = false;    
            try
            {
                DataTable mediaDt = services.displayMedia();
                if (mediaDt.Rows.Count > 0)
                {
                    dataGridVid.DataSource = mediaDt;
                    services.refreshDataGrid(dataGridVid);
                }
                else MessageBox.Show("No records found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);               
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

            if (displaytitle.Equals("")) MessageBox.Show("Enter Title");           
            else if (displayformat.Equals("Select")) MessageBox.Show("Select media format");          
            else if (displaymaxRent == 0) MessageBox.Show("Select max rent");           
            else if (displaynewavailablecopies < 0 || displaynewtotalcopies < activeRent) MessageBox.Show("You can't reduce below rented copies");      
            else
            {
                DialogResult confirmResult = MessageBox.Show("Are you sure you want to save these changes?","Confirm Edit",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    int row = services.editMedia(displaytitle, displayformat, displaynewavailablecopies,displaynewtotalcopies,price, displaymaxRent,mediaID);
                    if (row == 1)
                    {
                        MessageBox.Show("Media Updated Successfully");
                        services.refreshDataGrid(dataGridVid); 
                        clearDataFields();
                    }
                    else MessageBox.Show("There is an error updating");                   
                }
            }

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
                    int row = services.removeMedia(mediaID);
                    if (row == 1)
                    {
                        MessageBox.Show("Media Remove Successfully");
                        clearDataFields();
                        services.refreshDataGrid(dataGridVid);
                    }
                    else MessageBox.Show("Deletion Error");                  
                }
            }
        }

        private void filterbtn_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFilter = filterbtn.SelectedItem.ToString();

            if (selectedFilter == "All")
            {
                services.refreshDataGrid(dataGridVid);
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
                DataTable mediaDt = services.Filter(column, value);

                if (mediaDt.Rows.Count > 0)
                {
                    dataGridVid.DataSource = mediaDt;
                    services.dataGridProperties(dataGridVid);
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

        private void dataGridVid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            editbtn.Visible = true;
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
            editbtn.Visible = false;
        }

        void clearDataFields()
        {
            vidtitletxt.Clear();
            formatxt.Text = "Select";
            maxrenttxt.Text = "0";
            quantitytxt.Value = 1;
        }

        private void dataGridVid_Click(object sender, EventArgs e)
        {
            dataGridVid.ClearSelection();
            clearDataFields();
            addbtn.Visible = true;
            editbtn.Visible = false;
        }
    }
}
