using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BogsySystem.UserForms.Services
{
    public class UserRentServices
    {
        DBAccess ObjDBAccess = new DBAccess();

        public DataTable displayMedia()
        {
            String tablequery = "SELECT MediaID, Title, Format, Price, AvailableCopies, MaxRentalDays FROM MediaItems WHERE AvailableCopies > 0 AND IsAvailable = 1";
            DataTable mediaDt = new DataTable();
            ObjDBAccess.readDatathroughAdapter(tablequery, mediaDt);
            ObjDBAccess.closeConn();
            return mediaDt;
        }

        public int userRent(int userID, int mediaID, int quantity)
        {
            SqlCommand combinedCommand = new SqlCommand(@"
DECLARE @newRentalID INT;
DECLARE @pricePerMedia DECIMAL(10, 2);

-- Get the media price per piece
SELECT @pricePerMedia = Price FROM MediaItems WHERE MediaID = @mediaID;

-- Insert into Rentals with calculated fee and capture RentalID
INSERT INTO Rentals (UserID, MediaID, RentalDate, Quantity, Fee)
VALUES (@userID, @mediaID, @rentalDate, @quantity, @pricePerMedia * @quantity);

SET @newRentalID = SCOPE_IDENTITY();

-- Input the format in Rental History
DECLARE @format NVARCHAR(50);
SELECT @format = Format FROM MediaItems WHERE MediaID = @mediaID;

-- Insert into RentalHistory
INSERT INTO RentalHistory (RentalID, UserID, MediaID, Format, RentalDate, ReturnDate,IsReturned, Quantity, QuantityReturned , Fee , ChargeFee , TotalFee,IsPaid, PaidDate, Cash, Change)
VALUES (@newRentalID, @userID, @mediaID, @format,  @rentalDate, NULL, 0, @quantity, 0 , 0 , 0 , 0, 0, NULL, 0 , 0);

-- Update AvailableCopies
UPDATE MediaItems 
SET AvailableCopies = AvailableCopies - @quantity 
WHERE MediaID = @mediaID;");

            combinedCommand.Parameters.AddWithValue("@userID", userID);
            combinedCommand.Parameters.AddWithValue("@mediaID", mediaID);
            combinedCommand.Parameters.AddWithValue("@rentalDate", DateTime.Now);
            combinedCommand.Parameters.AddWithValue("@quantity", quantity);

            int row = ObjDBAccess.executeQuery(combinedCommand);
            ObjDBAccess.closeConn();

            return row;
        }

        public DataTable Filter(string column, string value) 
        {
            string tablequery = $@"
            SELECT MediaID, Title, Format, Price, AvailableCopies, MaxRentalDays 
            FROM MediaItems 
            WHERE AvailableCopies > 0 AND {column} = '{value}'";

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

        public DataTable FilterSearch(string value)
        {
            string tablequery = $@"
            SELECT MediaID, Title, Format, Price, AvailableCopies, MaxRentalDays 
            FROM MediaItems 
            WHERE AvailableCopies > 0 AND TITLE LIKE '%{value}%'";
            DataTable mediaDt = new DataTable();
            ObjDBAccess.readDatathroughAdapter(tablequery, mediaDt);
            ObjDBAccess.closeConn();
            return mediaDt;
        }

        public void searchFunction(DataGridView grid,TextBox searchtxt)
        {
            string filterValue = searchtxt.Text.Trim();

            try
            {
                DataTable filteredMedia = FilterSearch(filterValue);
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

        public void refreshDataGrid(DataGridView grid)
        {
            String tableQuery = "SELECT MediaID, Title, Format, AvailableCopies, Price, MaxRentalDays FROM MediaItems WHERE AvailableCopies > 0 AND IsAvailable = 1";
            DataTable mediaDt = new DataTable();
            ObjDBAccess.readDatathroughAdapter(tableQuery, mediaDt);
            ObjDBAccess.closeConn();
            grid.DataSource = mediaDt;
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
