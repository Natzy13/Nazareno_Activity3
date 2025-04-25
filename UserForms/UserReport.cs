using BogsySystem.Forms;
using Microsoft.Data.SqlClient;
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
    public partial class UserReport : Form
    {
        DBAccess ObjDBAccess = new DBAccess();
        public UserReport()
        {
            InitializeComponent();
        }

        private void UserReport_Load(object sender, EventArgs e)
        {
            queryTotalRent();
            queryTotalQuantity();
            queryTotalFee();
            queryTotalCharge();
            queryTotalAmount();
  
            try
            {
                String tablequery = @"SELECT 
    MI.Title,
    MI.Format,
    RH.RentalDate,
    RH.ReturnDate,
    R.Quantity,
    RH.Fee,
    RH.ChargeFee,
    RH.TotalFee
FROM RentalHistory RH
JOIN MediaItems MI ON RH.MediaID = MI.MediaID
JOIN Rentals R ON RH.RentalID = R.RentalID
WHERE RH.UserID = '"+Login.ID+"' AND RH.IsPaid = 1 ORDER BY RH.RentalDate DESC;";
                DataTable mediaDt = new DataTable();
                ObjDBAccess.readDatathroughAdapter(tablequery, mediaDt);
                ObjDBAccess.closeConn();

                if (mediaDt.Rows.Count > 0)
                {
                    dataGridHistory.DataSource = mediaDt;
                    dataGridProperties();
                }
                else
                {
                    MessageBox.Show("No History Found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
