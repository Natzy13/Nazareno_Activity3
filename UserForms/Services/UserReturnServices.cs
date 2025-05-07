using BogsySystem.Forms;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BogsySystem.UserForms.Services
{
    public class UserReturnServices
    {
        private DBAccess ObjDBAccess = new DBAccess();

        public DataTable displayReturn (int loginID)
        {
            String tablequery = $@"SELECT 
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
                          WHERE Rentals.UserID = {loginID} AND RentalHistory.IsReturned = 0 ORDER BY Rentals.RentalDate DESC;";
            DataTable mediaDt = new DataTable();
            ObjDBAccess.readDatathroughAdapter(tablequery, mediaDt);
            ObjDBAccess.closeConn();
            return mediaDt;
        }

        public int userReturn(int rentalID, int quantityRent) 
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

            int rows = ObjDBAccess.executeQuery(cmdReturn);
            ObjDBAccess.closeConn();

            return rows;
        }

        public DataTable refreshDataGrid(int loginID, DataGridView grid)
        {
            String tablequery = $@"SELECT 
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
                          WHERE Rentals.UserID = {loginID} AND RentalHistory.IsReturned = 0 ORDER BY Rentals.RentalDate DESC;";
            DataTable mediaDt = new DataTable();
            ObjDBAccess.readDatathroughAdapter(tablequery, mediaDt);           
            ObjDBAccess.closeConn();
            grid.DataSource = mediaDt;
            dataGridProperties(grid);
            return mediaDt;
        }

        public void componentHide(Button returnbtn)
        {
            returnbtn.Visible = false;
        }

        public void componentShow(Button returnbtn)
        {
            returnbtn.Visible = true;
        }

        public void dataGridProperties(DataGridView grid)
        {
            grid.Columns["RentalID"].Visible = false;
            grid.Columns["MediaID"].Visible = false;

            grid.Columns["Title"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["Format"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["Price"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["RentalDate"].HeaderText = "Rent Date";
            grid.Columns["RentalDate"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["Quantity"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["MaxRentalDays"].HeaderText = "Max Rent Days";
            grid.Columns["MaxRentalDays"].SortMode = DataGridViewColumnSortMode.NotSortable;
        }
    }
}
