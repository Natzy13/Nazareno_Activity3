using BogsySystem.Forms;
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
        private int mediaID, availableCopies;
        private string title;
        public UserRent()
        {
            InitializeComponent();
        }

        private void UserRent_Load(object sender, EventArgs e)
        {
            componentHide();
            try
            {
                String tablequery = "SELECT MediaID, Title, Format, Price, AvailableCopies, MaxRentalDays FROM MediaItems WHERE AvailableCopies > 0";
                DataTable mediaDt = new DataTable();
                ObjDBAccess.readDatathroughAdapter(tablequery, mediaDt);
                ObjDBAccess.closeConn();

                if (mediaDt.Rows.Count > 0)
                {
                    dataGridRent.DataSource = mediaDt;
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

        private void rentbtn_Click(object sender, EventArgs e)
        {
            int quantity = (int)quantitytxt.Value;
            int userID = int.Parse(Login.ID);


            if (quantity > availableCopies) MessageBox.Show("Not enough copies available!");
            else
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
INSERT INTO RentalHistory (RentalID, UserID, MediaID, Format, RentalDate, ReturnDate,IsReturned, Quantity, QuantityReturned , Fee , ChargeFee , TotalFee,IsPaid)
VALUES (@newRentalID, @userID, @mediaID, @format,  @rentalDate, NULL, 0, @quantity, 0 , 0 , 0 , 0, 0);

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

                if (row > 0)
                {
                    MessageBox.Show($"Successfully rented {quantity} copies of " + title);
                    quantitytxt.Value = 1;
                    dataGridRent.ClearSelection();
                    refreshDataGrid();
                }
                else
                {
                    MessageBox.Show("There was an error with the rental.");
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
                string tablequery = $@"
            SELECT MediaID, Title, Format, Price, AvailableCopies, MaxRentalDays 
            FROM MediaItems 
            WHERE AvailableCopies > 0 AND {column} = '{value}'";

                DataTable mediaDt = new DataTable();
                ObjDBAccess.readDatathroughAdapter(tablequery, mediaDt);
                ObjDBAccess.closeConn();

                if (mediaDt.Rows.Count > 0)
                {
                    dataGridRent.DataSource = mediaDt;
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
