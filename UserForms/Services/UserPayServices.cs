using BogsySystem.Forms;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BogsySystem.UserForms.Services
{
    public class UserPayServices
    {
        private DBAccess ObjDBAccess = new DBAccess();

        public DataTable displayPay(int userID)
        {
            string payquery = @"
SELECT
    Rentals.RentalID,
    MediaItems.Title,
    MediaItems.Format,
    MediaItems.Price AS PricePerPiece,
    RentalHistory.Fee,
    RentalHistory.ChargeFee,
    RentalHistory.TotalFee,
    RentalHistory.RentalDate,
    RentalHistory.ReturnDate,
    RentalHistory.QuantityReturned,
    MediaItems.MaxRentalDays
FROM RentalHistory 
JOIN Rentals  ON RentalHistory.RentalID = Rentals.RentalID
JOIN MediaItems ON RentalHistory.MediaID = MediaItems.MediaID
WHERE RentalHistory.UserID = @userID
  AND RentalHistory.IsPaid = 0
  AND RentalHistory.IsReturned = 1
ORDER BY RentalHistory.ReturnDate DESC;";

            DataTable mediaDt = new DataTable();
            ObjDBAccess.readDatathroughAdapter(payquery, mediaDt, userID);
            ObjDBAccess.closeConn();

            return mediaDt;
        }

        public int userPay(int rentalID, int userID,decimal pay,decimal changeAmount) 
        {
            SqlCommand payRental = new SqlCommand(@"
    UPDATE RentalHistory 
    SET 
        IsPaid = 1,
        PaidDate = @paidDate,
        Cash = @cash,
        Change = @change
    WHERE 
        RentalID = @rentalID AND 
        UserID = @userID;
");
            payRental.Parameters.AddWithValue("@paidDate", DateTime.Now);
            payRental.Parameters.AddWithValue("@cash", pay);
            payRental.Parameters.AddWithValue("@change", changeAmount);
            payRental.Parameters.AddWithValue("@rentalID", rentalID);
            payRental.Parameters.AddWithValue("@userID", userID);
            int row = ObjDBAccess.executeQuery(payRental);
            ObjDBAccess.closeConn();

            return row;
        }

        public void refreshDataGrid(int userID, DataGridView grid)
        {

            string payquery = @"
SELECT
    Rentals.RentalID,
    MediaItems.Title,
    MediaItems.Format,
    MediaItems.Price AS PricePerPiece,
    RentalHistory.Fee,
    RentalHistory.ChargeFee,
    RentalHistory.TotalFee,
    RentalHistory.RentalDate,
    RentalHistory.ReturnDate,
    RentalHistory.QuantityReturned,
    MediaItems.MaxRentalDays
FROM RentalHistory 
JOIN Rentals  ON RentalHistory.RentalID = Rentals.RentalID
JOIN MediaItems ON RentalHistory.MediaID = MediaItems.MediaID
WHERE RentalHistory.UserID = @userID
  AND RentalHistory.IsPaid = 0
  AND RentalHistory.IsReturned = 1;";

            DataTable mediaDt = new DataTable();
            ObjDBAccess.readDatathroughAdapter(payquery, mediaDt, userID);
            ObjDBAccess.closeConn();
            grid.DataSource = mediaDt;
            dataGridProperties(grid);
        }

        public void componentHide(
    Control feetxt, Label feelbl,
    Control chargefeetxt, Label chargefeelbl,
    Control totalfeetxt, Label totalfeelbl,
    Control paytxt, Label paylbl,
    Button paybtn)
        {
            feetxt.Visible = false;
            feelbl.Visible = false;
            chargefeetxt.Visible = false;
            chargefeelbl.Visible = false;
            totalfeetxt.Visible = false;
            totalfeelbl.Visible = false;
            paytxt.Visible = false;
            paylbl.Visible = false;
            paybtn.Visible = false;
        }

        public void componentShow(
     Control feetxt, Label feelbl,
     Control chargefeetxt, Label chargefeelbl,
     Control totalfeetxt, Label totalfeelbl,
     Control paytxt, Label paylbl,
     Button paybtn)
        {
            feetxt.Visible = true;
            feelbl.Visible = true;
            chargefeetxt.Visible = true;
            chargefeelbl.Visible = true;
            totalfeetxt.Visible = true;
            totalfeelbl.Visible = true;
            paytxt.Visible = true;
            paylbl.Visible = true;
            paybtn.Visible = true;
        }

        public void dataGridProperties(DataGridView grid)
        {
            grid.Columns["RentalID"].Visible = false;
            grid.Columns["Fee"].Visible = false;
            grid.Columns["ChargeFee"].Visible = false;
            grid.Columns["TotalFee"].Visible = false;

            grid.Columns["Title"].SortMode = DataGridViewColumnSortMode.NotSortable;
            grid.Columns["Format"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["PricePerPiece"].HeaderText = "Price";
            grid.Columns["PricePerPiece"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["RentalDate"].HeaderText = "Rental Date";
            grid.Columns["RentalDate"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["ReturnDate"].HeaderText = "Return Date";
            grid.Columns["ReturnDate"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["QuantityReturned"].HeaderText = "Quantity";
            grid.Columns["QuantityReturned"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["MaxRentalDays"].HeaderText = "Max Rent Days";
            grid.Columns["MaxRentalDays"].SortMode = DataGridViewColumnSortMode.NotSortable;

        }
    }
}
