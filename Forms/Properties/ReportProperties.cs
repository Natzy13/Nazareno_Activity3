using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BogsySystem.Forms
{
    public partial class Report : Form
    {
        private void dataGridUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Check if the clicked event was on a valid row
                if (e.RowIndex >= 0)
                {
                    // Select the current row
                    dataGridUsers.CurrentRow.Selected = true;

                    // Retrieve the selected data into a variable
                    selectedUserID = Convert.ToInt32(dataGridUsers.Rows[e.RowIndex].Cells["ID"].Value);
                    refreshUserActiveRent();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void dataGridUsers_Click(object sender, EventArgs e)
        {
            dataGridUsers.ClearSelection();
        }

        public void refreshUserActiveRent()
        {
            activerentlbl.Visible = true;
            dataGridUserRented.Visible = true;

            string tablequery = @"
SELECT 
    MediaItems.Title,
    Rentals.Quantity,
    Rentals.RentalDate    
FROM Rentals
INNER JOIN MediaItems ON Rentals.MediaID = MediaItems.MediaID
LEFT JOIN RentalHistory ON Rentals.RentalID = RentalHistory.RentalID
WHERE Rentals.UserID = '" + selectedUserID + "' AND RentalHistory.IsReturned = 0;";
            DataTable mediaDt3 = new DataTable();
            ObjDBAccess.readDatathroughAdapter(tablequery, mediaDt3);

            if (mediaDt3.Rows.Count > 0)
            {
                dataGridUserRented.DataSource = mediaDt3;
                dataGridProperties3();
            }
            else
            {
                activerentlbl.Visible = false;
                dataGridUserRented.Visible = false;
                dataGridUsers.ClearSelection();
                MessageBox.Show("User have no active rent", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
        }

        public void dataGridProperties1()
        {
            dataGridReport.Columns["Title"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridReport.Columns["AvailableCopies"].HeaderText = "IN";
            dataGridReport.Columns["AvailableCopies"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridReport.Columns["RentedCopies"].HeaderText = "OUT";
            dataGridReport.Columns["RentedCopies"].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        public void dataGridProperties2()
        {

            dataGridUsers.Columns["ID"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridUsers.Columns["Name"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridUsers.Columns["Username"].SortMode = DataGridViewColumnSortMode.NotSortable;

        }

        public void dataGridProperties3()
        {
            dataGridUserRented.Columns["Title"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridUserRented.Columns["Quantity"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridUserRented.Columns["RentalDate"].HeaderText = "Rent Date";
            dataGridUserRented.Columns["RentalDate"].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

    }
}
