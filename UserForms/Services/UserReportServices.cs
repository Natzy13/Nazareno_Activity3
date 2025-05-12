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

namespace BogsySystem.UserForms.Services
{
    public class UserReportServices
    {
        DBAccess ObjDBAccess = new DBAccess();
        private int LoginID { get; set; }
        
        public void userReportLoad(Label totalrenttxt, Label totalqtytxt, Label totalfeetxt, Label totalchargetxt,
            Label totalamttxt, DataGridView grid) 
        {
            LoginID = int.Parse(LoginServices.ID);

            totalrenttxt.Text = queryTotalRent(LoginID).ToString();
            totalqtytxt.Text = queryTotalQuantity(LoginID).ToString();
            totalfeetxt.Text = queryTotalFee(LoginID).ToString();
            totalchargetxt.Text = queryTotalCharge(LoginID).ToString();
            totalamttxt.Text = queryTotalAmount(LoginID).ToString();

            try
            {
                DataTable userMediaHistory = userHistory(LoginID);

                if (userMediaHistory.Rows.Count > 0)
                {
                    grid.DataSource = userMediaHistory;
                    dataGridProperties(grid);
                }
                else MessageBox.Show("No History Found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public int queryTotalRent(int loginID)
        {        
            SqlCommand totalRent = new SqlCommand(UserReportStrings.queryTotalRent(loginID));
            int queryTotalRent = Convert.ToInt32(ObjDBAccess.executeScalar(totalRent));
            return queryTotalRent;
        }

        public int queryTotalQuantity(int loginID)
        {          
            SqlCommand totalQuantity = new SqlCommand(UserReportStrings.queryTotalQuantity(loginID));
            object result = ObjDBAccess.executeScalar(totalQuantity);
            int queryTotalQuantity = result != DBNull.Value ? Convert.ToInt32(result) : 0;
            return queryTotalQuantity;
        }

        public decimal queryTotalFee(int loginID)
        {          
            SqlCommand totalFee = new SqlCommand(UserReportStrings.queryTotalFee(loginID));
            object result = ObjDBAccess.executeScalar(totalFee);
            decimal queryTotalFee = result != DBNull.Value ? Convert.ToDecimal(result) : 0m;        
            return queryTotalFee;         
        }

        public decimal queryTotalCharge(int loginID) 
        {           
            SqlCommand totalCharge = new SqlCommand(UserReportStrings.queryTotalCharge(loginID));
            object result = ObjDBAccess.executeScalar(totalCharge);
            decimal queryTotalCharge = result != DBNull.Value ? Convert.ToDecimal(result) : 0m;
            return queryTotalCharge;
        }

        public decimal queryTotalAmount(int loginID) 
        {           
            SqlCommand totalAmount = new SqlCommand(UserReportStrings.queryTotalAmount(loginID));
            object result = ObjDBAccess.executeScalar(totalAmount);
            decimal queryTotalAmount = result != DBNull.Value ? Convert.ToDecimal(result) : 0m;
            return queryTotalAmount;
        }

        public DataTable userHistory(int loginID)
        {          
            DataTable userHistory = new DataTable();
            ObjDBAccess.readDatathroughAdapter(UserReportStrings.queryUserHistory(loginID), userHistory);
            ObjDBAccess.closeConn();
            return userHistory;
        }

        public void dataGridProperties(DataGridView grid)
        {
            grid.Columns["RentalID"].Visible = false;
            grid.Columns["TitlesWithQuantities"].HeaderText = "Title";
            grid.Columns["TitlesWithQuantities"].SortMode = DataGridViewColumnSortMode.NotSortable;         

            grid.Columns["RentalDate"].HeaderText = "Rent Date";
            grid.Columns["RentalDate"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["ReturnDate"].HeaderText = "Return Date";
            grid.Columns["ReturnDate"].SortMode = DataGridViewColumnSortMode.NotSortable;        

            grid.Columns["Fees"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["ChargeFees"].HeaderText = "Charge Fee";
            grid.Columns["ChargeFees"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["TotalFee"].HeaderText = "Total";
            grid.Columns["TotalFee"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["PaidDate"].HeaderText = "Paid";
            grid.Columns["PaidDate"].SortMode = DataGridViewColumnSortMode.NotSortable;
          
        }
    }
}
