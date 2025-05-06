using BogsySystem.Forms;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BogsySystem.UserForms
{
    public partial class UserPayProperties : Form
    {
        DBAccess ObjDBAccess = new DBAccess();
        private int rentalID;
        public UserPayProperties()
        {
            InitializeComponent();
        }

        private void UserPay_Load(object sender, EventArgs e)
        {
            componentHide();
            int userID = Convert.ToInt32(Login.ID);
            try
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

                if (mediaDt.Rows.Count > 0)
                {
                    dataGridPay.DataSource = mediaDt;
                    dataGridProperties();
                }
                else
                {
                    MessageBox.Show("No returned media found, so there are no pending payments", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void paybtn_Click(object sender, EventArgs e)
        {                         
            decimal totalFee = Convert.ToDecimal(totalfeetxt.Text);

            if (string.IsNullOrWhiteSpace(paytxt.Text))
            {
                MessageBox.Show("Please enter an amount to pay.");
            }
            else
            {
                decimal pay;
                if (decimal.TryParse(paytxt.Text, out pay))
                {
                    if (pay == 0 || pay < totalFee)
                    {
                        MessageBox.Show("The amount paid is not enough.");
                    }
                    else
                    {
                        decimal change = pay - totalFee;

                        int userID = int.Parse(Login.ID);
                        SqlCommand payRental = new SqlCommand("UPDATE RentalHistory SET IsPaid = 1 WHERE RentalID = @rentalID AND UserID = @userID;");
                        payRental.Parameters.AddWithValue("@rentalID", rentalID);
                        payRental.Parameters.AddWithValue("@userID", userID);
                        int row = ObjDBAccess.executeQuery(payRental);
                        ObjDBAccess.closeConn();

                        if (row > 0)
                        {
                            MessageBox.Show($"Payment successful!\nChange: {change:F2}");
                            paytxt.Text = "";
                            dataGridPay.ClearSelection();
                            componentHide();
                            refreshDataGrid();
                        }
                        else MessageBox.Show("There was an error with the rental.");
                        
                    }
                }
                else  MessageBox.Show("Please enter a valid number.");
                
            }
        }      
    }
}
