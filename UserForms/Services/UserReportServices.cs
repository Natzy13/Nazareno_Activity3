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
    public class UserReportServices
    {
        DBAccess ObjDBAccess = new DBAccess();

 
        public int queryTotalRent(int loginID)
        {
            string queryTotalRent = $"SELECT COUNT(*) FROM RentalHistory WHERE UserID = '{loginID}' AND IsPaid = 1";
            SqlCommand totalRent = new SqlCommand(queryTotalRent);
            int TotalRent = Convert.ToInt32(ObjDBAccess.executeScalar(totalRent));
            return TotalRent;
        }

        public int queryTotalQuantity(int loginID)
        {
            string queryTotalQuantity = $"SELECT SUM(Quantity) FROM RentalHistory WHERE UserID = '{loginID}' AND IsPaid = 1";
            SqlCommand totalQuantity = new SqlCommand(queryTotalQuantity);
            int TotalQuantity = Convert.ToInt32(ObjDBAccess.executeScalar(totalQuantity));
            return TotalQuantity;
        }

        public decimal queryTotalFee(int loginID)
        {
            string queryTotalFee = $"SELECT SUM(Fee) FROM RentalHistory WHERE UserID = '{loginID}' AND IsPaid = 1";
            SqlCommand totalFee = new SqlCommand(queryTotalFee);
            object result = ObjDBAccess.executeScalar(totalFee);
            decimal TotalFee = result != DBNull.Value ? Convert.ToDecimal(result) : 0m;        
            return TotalFee;         
        }

        public decimal queryTotalCharge(int loginID) 
        {
            string queryTotalCharge = $"SELECT SUM(ChargeFee) FROM RentalHistory WHERE UserID = '{loginID}' AND IsPaid = 1";
            SqlCommand totalCharge = new SqlCommand(queryTotalCharge);
            object result = ObjDBAccess.executeScalar(totalCharge);
            decimal TotalCharge = result != DBNull.Value ? Convert.ToDecimal(result) : 0m;
            return TotalCharge;
        }

        public decimal queryTotalAmount(int loginID) 
        {
            string queryTotalAmount = $"SELECT SUM(TotalFee) FROM RentalHistory WHERE UserID = '{loginID}' AND IsPaid = 1";
            SqlCommand totalAmount = new SqlCommand(queryTotalAmount);
            object result = ObjDBAccess.executeScalar(totalAmount);
            decimal TotalAmount = result != DBNull.Value ? Convert.ToDecimal(result) : 0m;
            return TotalAmount;
        }

        public DataTable userHistory(int loginID)
        {
            String tablequery = $@"SELECT 
    MI.Title,
    RH.RentalDate,
    RH.ReturnDate,
    R.Quantity,
    RH.Fee,
    RH.ChargeFee,
    RH.TotalFee,
    RH.Cash,
    RH.PaidDate    
FROM RentalHistory RH
JOIN MediaItems MI ON RH.MediaID = MI.MediaID
JOIN Rentals R ON RH.RentalID = R.RentalID
WHERE RH.UserID = '{loginID}' AND RH.IsPaid = 1 ORDER BY RH.RentalDate DESC;";
            DataTable mediaDt = new DataTable();
            ObjDBAccess.readDatathroughAdapter(tablequery, mediaDt);
            ObjDBAccess.closeConn();
            return mediaDt;
        }

        public void dataGridProperties(DataGridView grid)
        {
            grid.Columns["Title"].SortMode = DataGridViewColumnSortMode.NotSortable;         

            grid.Columns["RentalDate"].HeaderText = "Rent Date";
            grid.Columns["RentalDate"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["ReturnDate"].HeaderText = "Return Date";
            grid.Columns["ReturnDate"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["Quantity"].HeaderText = "Qty";
            grid.Columns["Quantity"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["Fee"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["ChargeFee"].HeaderText = "Charge Fee";
            grid.Columns["ChargeFee"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["TotalFee"].HeaderText = "Total";
            grid.Columns["TotalFee"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["PaidDate"].HeaderText = "Date";
            grid.Columns["PaidDate"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["Cash"].SortMode = DataGridViewColumnSortMode.NotSortable;
        }
    }
}
