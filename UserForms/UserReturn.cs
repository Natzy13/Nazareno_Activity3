using BogsySystem.Forms;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BogsySystem.UserForms
{
    public partial class UserReturn : Form
    {
        DBAccess ObjDBAccess = new DBAccess();
        private int mediaID, rentalID,quantityRent;
        private string title;
        public UserReturn()
        {
            InitializeComponent();
        }

        private void UserReturn_Load(object sender, EventArgs e)
        {           
            componentHide();

            try
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
                          WHERE Rentals.UserID = '"+Login.ID+"' AND RentalHistory.IsReturned = 0 ORDER BY Rentals.RentalDate DESC;";
                DataTable mediaDt = new DataTable();
                ObjDBAccess.readDatathroughAdapter(tablequery, mediaDt);
                ObjDBAccess.closeConn();

                if (mediaDt.Rows.Count > 0)
                {
                    dataGridReturn.DataSource = mediaDt;
                    dataGridProperties();
                }
                else
                {
                    MessageBox.Show("No rented media found, so there are no media for return.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void returnbtn_Click(object sender, EventArgs e)
        {
            decimal overdueChargePerDay = 5;

            string tablequery = @"
DECLARE @maxRentalDays INT;
DECLARE @pricePerMedia DECIMAL(10, 2);
DECLARE @mediaID INT;

-- Get MediaID from Rentals table
SELECT @mediaID = MediaID FROM Rentals WHERE RentalID = @rentalID;

-- Get the price per media and max rental days from MediaItems table
SELECT 
    @pricePerMedia = Price, 
    @maxRentalDays = MaxRentalDays
FROM MediaItems
WHERE MediaID = @mediaID;

-- Calculate the Fee (price * quantity)
DECLARE @baseRentalFee DECIMAL(10, 2);
SET @baseRentalFee = @pricePerMedia * @quantityRent;

-- Calculate the overdue fee if applicable
DECLARE @overdueFee DECIMAL(10, 2) = 0;
IF DATEDIFF(DAY, (SELECT RentalDate FROM Rentals WHERE RentalID = @rentalID), GETDATE()) > @maxRentalDays
BEGIN
    SET @overdueFee = (DATEDIFF(DAY, (SELECT RentalDate FROM Rentals WHERE RentalID = @rentalID), GETDATE()) - @maxRentalDays) * @overdueChargePerDay * @quantityRent;
END

-- Update RentalHistory table 
UPDATE RentalHistory
SET 
    ReturnDate = GETDATE(),
    IsReturned = 1,
    QuantityReturned = @quantityRent,
    Fee = @baseRentalFee,
    ChargeFee = @overdueFee,
    TotalFee = @baseRentalFee + @overdueFee
WHERE RentalID = @rentalID;

-- Update AvailableCopies in MediaItems
UPDATE MediaItems
SET AvailableCopies = AvailableCopies + @quantityRent
WHERE MediaID = @mediaID;";

            SqlCommand cmdReturn = new SqlCommand(tablequery);

            // Add parameters to the SqlCommand
            cmdReturn.Parameters.AddWithValue("@rentalID", rentalID);
            cmdReturn.Parameters.AddWithValue("@quantityRent", quantityRent);
            cmdReturn.Parameters.AddWithValue("@overdueChargePerDay", overdueChargePerDay);

            int rowsAffected = ObjDBAccess.executeQuery(cmdReturn);
            ObjDBAccess.closeConn();
            if (rowsAffected > 0)
            {
                MessageBox.Show($"Successfully returned {quantityRent} copies of " + title); ;
                refreshDataGrid();
            }
            else
            {
                MessageBox.Show("Error occurred while returning the media");
            }

        }

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
