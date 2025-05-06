using BogsySystem.Forms;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BogsySystem.UserForms
{
    public partial class UserReturn : Form
    {
        private void dataGridReturn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Check if the clicked event was on a valid row
                if (e.RowIndex >= 0)
                {
                    // Select the current row
                    dataGridReturn.CurrentRow.Selected = true;
                    componentShow();

                    // Retrieve the selected data into a variable
                    rentalID = Convert.ToInt32(dataGridReturn.Rows[e.RowIndex].Cells["RentalID"].Value);
                    mediaID = Convert.ToInt32(dataGridReturn.Rows[e.RowIndex].Cells["MediaID"].Value);
                    title = dataGridReturn.Rows[e.RowIndex].Cells["Title"].Value?.ToString();
                    quantityRent = Convert.ToInt32(dataGridReturn.Rows[e.RowIndex].Cells["Quantity"].Value); //Assign to variable

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void dataGridReturn_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridReturn.ClearSelection();
            componentHide();
        }

        private void dataGridReturn_Click(object sender, EventArgs e)
        {
            dataGridReturn.ClearSelection();
            componentHide();
        }

        private void componentHide()
        {

            returnbtn.Visible = false;
        }
        private void componentShow()
        {
            returnbtn.Visible = true;
        }

        private void dataGridProperties()
        {
            dataGridReturn.Columns["RentalID"].Visible = false;
            dataGridReturn.Columns["MediaID"].Visible = false;

            dataGridReturn.Columns["Title"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridReturn.Columns["Format"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridReturn.Columns["Price"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridReturn.Columns["RentalDate"].HeaderText = "Rent Date";
            dataGridReturn.Columns["RentalDate"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridReturn.Columns["Quantity"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridReturn.Columns["MaxRentalDays"].HeaderText = "Max Rent Days";
            dataGridReturn.Columns["MaxRentalDays"].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void refreshDataGrid()
        {
            String tablequery = @"SELECT 
                              Rentals.RentalID, 
                              Rentals.MediaID, 
                              MediaItems.Title,
                              MediaItems.Format,
                              MediaItems.Price,
                              Rentals.RentalDate,
                              Rentals.Quantity,
                              MediaItems.MaxRentalDays                                                        
                          FROM Rentals
                          INNER JOIN MediaItems ON Rentals.MediaID = MediaItems.MediaID
                          INNER JOIN RentalHistory ON RentalHistory.RentalID = Rentals.RentalID
                          WHERE Rentals.UserID = '" + Login.ID + "' AND RentalHistory.IsReturned = 0 ORDER BY Rentals.RentalDate DESC;";
            DataTable mediaDt = new DataTable();
            ObjDBAccess.readDatathroughAdapter(tablequery, mediaDt);
            dataGridReturn.DataSource = mediaDt;
        }
    }
}
