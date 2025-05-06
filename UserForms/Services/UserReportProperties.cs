using BogsySystem.Forms;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BogsySystem.UserForms
{
    public partial class UserReport : Form
    {
        void queryTotalRent()
        {
            string queryTotalRent = "SELECT COUNT(*) FROM RentalHistory WHERE UserID = '" + Login.ID + "' AND IsPaid = 1";
            SqlCommand totalRent = new SqlCommand(queryTotalRent);
            totalrenttxt.Text = Convert.ToInt32(ObjDBAccess.executeScalar(totalRent)).ToString();
        }

        void queryTotalQuantity()
        {
            string queryTotalQuantity = "SELECT SUM(Quantity) FROM RentalHistory WHERE UserID = '" + Login.ID + "' AND IsPaid = 1";
            SqlCommand totalQuantity = new SqlCommand(queryTotalQuantity);
            var result = ObjDBAccess.executeScalar(totalQuantity);
            totalqtytxt.Text = result != DBNull.Value ? Convert.ToInt32(result).ToString() : "0";
        }

        void queryTotalFee()
        {
            string queryTotalFee = "SELECT SUM(Fee) FROM RentalHistory WHERE UserID = '" + Login.ID + "' AND IsPaid = 1";
            SqlCommand totalFee = new SqlCommand(queryTotalFee);
            totalfeetxt.Text = string.Format("{0:N2}", ObjDBAccess.executeScalar(totalFee) ?? 0);
        }

        void queryTotalCharge()
        {
            string queryTotalCharge = "SELECT SUM(ChargeFee) FROM RentalHistory WHERE UserID = '" + Login.ID + "' AND IsPaid = 1";
            SqlCommand totalCharge = new SqlCommand(queryTotalCharge);
            totalchargetxt.Text = string.Format("{0:N2}", ObjDBAccess.executeScalar(totalCharge) ?? 0);
        }

        void queryTotalAmount()
        {
            string queryTotalAmount = "SELECT SUM(TotalFee) FROM RentalHistory WHERE UserID = '" + Login.ID + "' AND IsPaid = 1";
            SqlCommand totalAmount = new SqlCommand(queryTotalAmount);
            totalamttxt.Text = string.Format("{0:N2}", ObjDBAccess.executeScalar(totalAmount) ?? 0);
        }

        public void dataGridProperties()
        {
            dataGridHistory.Columns["Title"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridHistory.Columns["Format"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridHistory.Columns["RentalDate"].HeaderText = "Rent Date";
            dataGridHistory.Columns["RentalDate"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridHistory.Columns["ReturnDate"].HeaderText = "Return Date";
            dataGridHistory.Columns["ReturnDate"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridHistory.Columns["Quantity"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridHistory.Columns["Fee"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridHistory.Columns["ChargeFee"].HeaderText = "Charge Fee";
            dataGridHistory.Columns["ChargeFee"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridHistory.Columns["TotalFee"].HeaderText = "Total Amount Paid";
            dataGridHistory.Columns["TotalFee"].SortMode = DataGridViewColumnSortMode.NotSortable;
        }
    }
}
