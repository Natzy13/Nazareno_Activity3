using BogsySystem.Forms;
using BogsySystem.Forms.Properties;
using BogsySystem.UserForms.Strings;
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
        private int rentalID { get; set; }

        public void userPayLoad(TextBox feetxt, Label feelbl, TextBox chargefeetxt, Label chargefeelbl, TextBox totalfeetxt,
            Label totalfeelbl, TextBox paytxt, Label paylbl, Button paybtn, DataGridView grid)
        {
            componentHide(feetxt, feelbl, chargefeetxt, chargefeelbl, totalfeetxt, totalfeelbl, paytxt, paylbl, paybtn);
            int userID = Convert.ToInt32(LoginServices.ID);
            try
            {
                DataTable payMedia = displayPayQuery(userID);

                if (payMedia.Rows.Count > 0)
                {
                    grid.DataSource = payMedia;
                    dataGridProperties(grid);
                }
                else MessageBox.Show("No returned media found, so there are no pending payments", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable displayPayQuery(int userID)
        {
            DataTable displayPayQuery = new DataTable();
            ObjDBAccess.readDatathroughAdapter(UserPayStrings.payQuery, displayPayQuery, userID);
            ObjDBAccess.closeConn();

            return displayPayQuery;
        }

        public void payButtonFunction(TextBox feetxt, Label feelbl, TextBox chargefeetxt, Label chargefeelbl, TextBox totalfeetxt,
            Label totalfeelbl, TextBox paytxt, Label paylbl, Button paybtn, DataGridView grid)
        {
            decimal totalFee = Convert.ToDecimal(totalfeetxt.Text);

            if (string.IsNullOrWhiteSpace(paytxt.Text)) MessageBox.Show("Please enter an amount to pay.");
            else
            {
                decimal pay;
                if (decimal.TryParse(paytxt.Text, out pay))
                {
                    if (pay == 0 || pay < totalFee) MessageBox.Show("The amount paid is not enough.");

                    else
                    {
                        decimal change = pay - totalFee;

                        int userID = int.Parse(LoginServices.ID);
                        int rowUserPay = userPayQuery(rentalID, userID, pay, change);

                        if (rowUserPay > 0)
                        {
                            MessageBox.Show($"Payment successful!\nChange: {change:F2}");
                            paytxt.Text = "";
                            grid.ClearSelection();
                            componentHide(feetxt, feelbl, chargefeetxt, chargefeelbl, totalfeetxt, totalfeelbl, paytxt, 
                                paylbl, paybtn);
                            refreshDataGridQuery(userID, grid);
                        }
                        else MessageBox.Show("There was an error with the rental.");
                    }
                }
                else MessageBox.Show("Please enter a valid number.");
            }
        }

        public int userPayQuery(int rentalID, int userID,decimal pay,decimal changeAmount) 
        {
            SqlCommand payRental = new SqlCommand(UserPayStrings.payRentalQuery);
            payRental.Parameters.AddWithValue("@paidDate", DateTime.Now);
            payRental.Parameters.AddWithValue("@cash", pay);
            payRental.Parameters.AddWithValue("@change", changeAmount);
            payRental.Parameters.AddWithValue("@rentalID", rentalID);
            payRental.Parameters.AddWithValue("@userID", userID);
            int userPayQuery = ObjDBAccess.executeQuery(payRental);
            ObjDBAccess.closeConn();
            return userPayQuery;
        }

        public void cellClickFunction(DataGridViewCellEventArgs e, DataGridView grid, TextBox feetxt, Label feelbl, 
            TextBox chargefeetxt, Label chargefeelbl, TextBox totalfeetxt,Label totalfeelbl, TextBox paytxt, 
            Label paylbl, Button paybtn)
        {
            try
            {
                // Check if the clicked event was on a valid row
                if (e.RowIndex >= 0)
                {
                    // Select the current row
                    grid.CurrentRow.Selected = true;
                    componentShow(feetxt, feelbl, chargefeetxt, chargefeelbl, totalfeetxt, totalfeelbl, paytxt, paylbl, paybtn);
               
                    DataGridViewRow row = grid.Rows[e.RowIndex];
                    // Retrieve the selected data into a variable
                    rentalID = Convert.ToInt32(row.Cells["RentalID"].Value);

                    //Display to the textbox the selected cell
                    feetxt.Text = row.Cells["Fee"].Value.ToString();
                    chargefeetxt.Text = row.Cells["ChargeFee"].Value.ToString();
                    totalfeetxt.Text = row.Cells["TotalFee"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        public void refreshDataGridQuery(int userID, DataGridView grid)
        {
            DataTable refreshDataGrid = new DataTable();
            ObjDBAccess.readDatathroughAdapter(UserPayStrings.payQuery, refreshDataGrid, userID);
            ObjDBAccess.closeConn();
            grid.DataSource = refreshDataGrid;
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
