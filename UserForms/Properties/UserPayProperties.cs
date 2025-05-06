using BogsySystem.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BogsySystem.UserForms
{
    public partial class UserPayProperties : Form
    {
        private void dataGridPay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Check if the clicked event was on a valid row
                if (e.RowIndex >= 0)
                {
                    // Select the current row
                    dataGridPay.CurrentRow.Selected = true;
                    componentShow();

                    // Retrieve the selected data into a variable
                    rentalID = Convert.ToInt32(dataGridPay.Rows[e.RowIndex].Cells["RentalID"].Value);

                    //Display to the textbox the selected cell
                    feetxt.Text = dataGridPay.Rows[e.RowIndex].Cells["Fee"].Value.ToString();
                    chargefeetxt.Text = dataGridPay.Rows[e.RowIndex].Cells["ChargeFee"].Value.ToString();
                    totalfeetxt.Text = dataGridPay.Rows[e.RowIndex].Cells["TotalFee"].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void dataGridPay_Click(object sender, EventArgs e)
        {
            dataGridPay.ClearSelection();
            componentHide();
        }

        private void dataGridPay_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridPay.ClearSelection();
            componentHide();
        }

        private void dataGridProperties()
        {
            dataGridPay.Columns["RentalID"].Visible = false;
            dataGridPay.Columns["Fee"].Visible = false;
            dataGridPay.Columns["ChargeFee"].Visible = false;
            dataGridPay.Columns["TotalFee"].Visible = false;

            dataGridPay.Columns["Title"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridPay.Columns["Format"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridPay.Columns["PricePerPiece"].HeaderText = "Price";
            dataGridPay.Columns["PricePerPiece"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridPay.Columns["RentalDate"].HeaderText = "Rental Date";
            dataGridPay.Columns["RentalDate"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridPay.Columns["ReturnDate"].HeaderText = "Return Date";
            dataGridPay.Columns["ReturnDate"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridPay.Columns["QuantityReturned"].HeaderText = "Quantity";
            dataGridPay.Columns["QuantityReturned"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridPay.Columns["MaxRentalDays"].HeaderText = "Max Rent Days";
            dataGridPay.Columns["MaxRentalDays"].SortMode = DataGridViewColumnSortMode.NotSortable;

        }

        private void componentHide()
        {
            feetxt.Visible = false;
            feelbl.Visible = false;
            chargefeetxt.Visible = false;
            chargefeelbl.Visible = false;
            totalfeetxt.Visible = false;
            totalfeelbl.Visible = false;
            chargefeelbl.Visible = false;
            paytxt.Visible = false;
            paylbl.Visible = false;
            paybtn.Visible = false;
        }
        private void componentShow()
        {
            feetxt.Visible = true;
            feelbl.Visible = true;
            chargefeetxt.Visible = true;
            chargefeelbl.Visible = true;
            totalfeetxt.Visible = true;
            totalfeelbl.Visible = true;
            chargefeelbl.Visible = true;
            paytxt.Visible = true;
            paylbl.Visible = true;
            paybtn.Visible = true;
        }

        private void refreshDataGrid()
        {
            int userID = int.Parse(Login.ID);
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
            dataGridPay.DataSource = mediaDt;

        }
    }
}
