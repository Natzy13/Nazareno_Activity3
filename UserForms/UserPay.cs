using BogsySystem.Forms;
using BogsySystem.UserForms.Services;
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
        UserPayServices services = new UserPayServices();
        private int rentalID;
        public UserPayProperties()
        {
            InitializeComponent();
        }

        private void UserPay_Load(object sender, EventArgs e)
        {
            services.componentHide(feetxt,feelbl,chargefeetxt,chargefeelbl,totalfeetxt,totalfeelbl,paytxt,paylbl,paybtn);
            int userID = Convert.ToInt32(Login.ID);
            try
            {
                DataTable mediaDt = services.displayPay(userID);

                if (mediaDt.Rows.Count > 0)
                {
                    dataGridPay.DataSource = mediaDt;
                    services.dataGridProperties(dataGridPay);
                }
                else  MessageBox.Show("No returned media found, so there are no pending payments", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void paybtn_Click(object sender, EventArgs e)
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

                        int userID = int.Parse(Login.ID);
                        int row = services.userPay(rentalID, userID, pay, change);

                        if (row > 0)
                        {
                            MessageBox.Show($"Payment successful!\nChange: {change:F2}");
                            paytxt.Text = "";
                            dataGridPay.ClearSelection();
                            services.componentHide(feetxt, feelbl, chargefeetxt, chargefeelbl, totalfeetxt, totalfeelbl, paytxt, paylbl, paybtn);
                            services.refreshDataGrid(userID, dataGridPay);
                        }
                        else MessageBox.Show("There was an error with the rental.");                     
                    }
                }
                else  MessageBox.Show("Please enter a valid number.");                
            }
        }

        private void dataGridPay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Check if the clicked event was on a valid row
                if (e.RowIndex >= 0)
                {
                    // Select the current row
                    dataGridPay.CurrentRow.Selected = true;
                    services.componentShow(feetxt, feelbl, chargefeetxt, chargefeelbl, totalfeetxt, totalfeelbl, paytxt, paylbl, paybtn);

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
            services.componentHide(feetxt, feelbl, chargefeetxt, chargefeelbl, totalfeetxt, totalfeelbl, paytxt, paylbl, paybtn);
        }

        private void dataGridPay_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridPay.ClearSelection();
            services.componentHide(feetxt, feelbl, chargefeetxt, chargefeelbl, totalfeetxt, totalfeelbl, paytxt, paylbl, paybtn);
        }      
    }
}
