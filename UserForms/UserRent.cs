using BogsySystem.Forms;
using BogsySystem.Forms.Properties;
using BogsySystem.UserForms.Services;
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

namespace BogsySystem.UserForms
{
    public partial class UserRent : Form
    {
        DBAccess ObjDBAccess = new DBAccess();
        UserRentServices services = new UserRentServices();
        private int mediaID, availableCopies;
        private string title;
        public UserRent()
        {
            InitializeComponent();
        }

        private void UserRent_Load(object sender, EventArgs e)
        {
            services.componentHide(quantitylbl, quantitytxt, rentbtn);
            try
            {
                DataTable mediaDt = services.displayMedia();

                if (mediaDt.Rows.Count > 0)
                {
                    dataGridRent.DataSource = mediaDt;
                    services.dataGridProperties(dataGridRent);
                }
                else MessageBox.Show("No records found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rentbtn_Click(object sender, EventArgs e)
        {
            int quantity = (int)quantitytxt.Value;
            int userID = int.Parse(LoginServices.ID);

            if (quantity > availableCopies) MessageBox.Show("Not enough copies available!");
            else
            {
                int row = services.userRent(userID, mediaID, quantity);

                if (row > 0)
                {
                    MessageBox.Show($"Successfully rented {quantity} copies of " + title);
                    quantitytxt.Value = 1;
                    dataGridRent.ClearSelection();
                    services.refreshDataGrid(dataGridRent);
                }
                else MessageBox.Show("There was an error with the rental.");
            }
        }

        private void filterbtn_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFilter = filterbtn.SelectedItem.ToString();

            if (selectedFilter == "All")
            {
                services.refreshDataGrid(dataGridRent);
            }
            else if (selectedFilter == "VCD" || selectedFilter == "DVD")
            {
                services.ApplyFilter("Format", selectedFilter, dataGridRent);
            }
            else if (selectedFilter.StartsWith("Max Rent"))
            {
                // Extract the number of days from the filter text
                var match = Regex.Match(selectedFilter, @"\d+");
                if (match.Success)
                {
                    string days = match.Value;
                    services.ApplyFilter("MaxRentalDays", days,dataGridRent);
                }
            }
        }

        

        private void dataGridRent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Check if the clicked event was on a valid row
                if (e.RowIndex >= 0)
                {
                    // Select the current row
                    dataGridRent.CurrentRow.Selected = true;
                    services.componentShow(quantitylbl, quantitytxt, rentbtn);

                    // Retrieve the selected data into a variable
                    mediaID = Convert.ToInt32(dataGridRent.Rows[e.RowIndex].Cells["MediaID"].Value);
                    title = dataGridRent.Rows[e.RowIndex].Cells["Title"].Value?.ToString();
                    availableCopies = Convert.ToInt32(dataGridRent.Rows[e.RowIndex].Cells["AvailableCopies"].Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void dataGridRent_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridRent.ClearSelection();
            services.componentHide(quantitylbl, quantitytxt, rentbtn);
        }

        private void dataGridRent_Click(object sender, EventArgs e)
        {
            dataGridRent.ClearSelection();
            services.componentHide(quantitylbl, quantitytxt, rentbtn);
        }

        private void searchbtn_Click(object sender, EventArgs e)
        {
            services.searchFunction(dataGridRent,searchtxt);
        }
    }
}
