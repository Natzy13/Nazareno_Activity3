using BogsySystem.Forms;
using BogsySystem.Forms.Properties;
using BogsySystem.UserForms.Strings;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BogsySystem.UserForms.Services
{
    public class UserPayServices
    {
        private DBAccess ObjDBAccess = new DBAccess();
        private int RentalDetailID { get; set; }
        private string Title { get; set; }
        private int QuantityRent { get; set; }

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
                    dataGridProperties2(grid);
                }
                else MessageBox.Show("No rented media, so there are no payments or media to be returned.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        public DataTable displayPayQuery(int userID)
        {
            DataTable displayPayQuery2 = new DataTable();
            ObjDBAccess.readDatathroughAdapter(UserPayStrings.payQuery, displayPayQuery2, userID);
            ObjDBAccess.closeConn();

            return displayPayQuery2;
        }
        public void payButtonFunction(TextBox feetxt, Label feelbl, TextBox chargefeetxt, Label chargefeelbl, TextBox totalfeetxt,
           Label totalfeelbl, TextBox paytxt, Label paylbl, Button paybtn, DataGridView grid)
        {
            decimal fee = Convert.ToDecimal(feetxt.Text);
            decimal overdueFee = Convert.ToDecimal(chargefeetxt.Text);
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
                        int rowUserPay = userPayQuery(RentalDetailID, QuantityRent, fee, pay, change,
                            overdueFee, totalFee);

                        if (rowUserPay > 0)
                        {
                            MessageBox.Show($"Payment successful for: {Title} (x{QuantityRent})\nChange: {change:F2}");
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

        public int userPayQuery(int rentalDetailID, int quantityRent, decimal fee,decimal pay, decimal changeAmount, 
            decimal chargeFee, decimal totalFee)
        {
            SqlCommand payRental = new SqlCommand(UserPayStrings.userReturnAndPayQuery);
            payRental.Parameters.AddWithValue("@rentalDetailID", rentalDetailID);
            payRental.Parameters.AddWithValue("@quantityRent", quantityRent); 
            payRental.Parameters.AddWithValue("@fee", fee);
            payRental.Parameters.AddWithValue("@chargeFee", chargeFee);
            payRental.Parameters.AddWithValue("@totalFee", totalFee);
            payRental.Parameters.AddWithValue("@paidDate", DateTime.Now);
            payRental.Parameters.AddWithValue("@cash", pay);
            payRental.Parameters.AddWithValue("@change", changeAmount);
            int userPayQuery = ObjDBAccess.executeQuery(payRental);
            ObjDBAccess.closeConn();
            return userPayQuery;
        }

        public void cellClickFunction(DataGridViewCellEventArgs e, DataGridView grid, TextBox feetxt, Label feelbl,
           TextBox chargefeetxt, Label chargefeelbl, TextBox totalfeetxt, Label totalfeelbl, TextBox paytxt,
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
                    RentalDetailID = Convert.ToInt32(row.Cells["RentalDetailID"].Value);
                    Title = row.Cells["Title"].Value.ToString();

                    //Subtotal
                    decimal fee = Convert.ToDecimal(row.Cells["Fee"].Value);
                    QuantityRent = Convert.ToInt32(row.Cells["Quantity"].Value);
                    decimal subtotal = fee * QuantityRent;
                    
                    //Overdue Charge
                    DateTime rentalDate = Convert.ToDateTime(row.Cells["RentalDate"].Value);
                    int maxRentalDays = Convert.ToInt32(row.Cells["MaxRentalDays"].Value);
                    decimal overdueChargePerDay = 5.00m;
                    int overdueDays = (DateTime.Now - rentalDate).Days - maxRentalDays;
                    overdueDays = Math.Max(0, overdueDays);
                    decimal overdueFee = overdueDays * overdueChargePerDay * QuantityRent;

                    //TotalFee
                    decimal totalFee = subtotal + overdueFee;

                    //Display to the textbox the selected cell
                    feetxt.Text = subtotal.ToString();
                    chargefeetxt.Text = overdueFee.ToString();
                    totalfeetxt.Text = totalFee.ToString();
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
            dataGridProperties2(grid);
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

        public void dataGridProperties2(DataGridView grid)
        {
            grid.Columns["RentalDetailID"].Visible = false;
            grid.Columns["Fee"].Visible = false;
            grid.Columns["ChargeFee"].Visible = false;
            grid.Columns["TotalFee"].Visible = false;
                 
            grid.Columns["Title"].SortMode = DataGridViewColumnSortMode.NotSortable;
            grid.Columns["Quantity"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["RentalDate"].HeaderText = "Rent Date";
            grid.Columns["RentalDate"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["MaxRentalDays"].HeaderText = "Max Rent Days";
            grid.Columns["MaxRentalDays"].SortMode = DataGridViewColumnSortMode.NotSortable;
        }
    }
}