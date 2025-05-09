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
        private int loginID { get; set; }
        

        public void userReportLoad(Label totalrenttxt, Label totalqtytxt, Label totalfeetxt, Label totalchargetxt,
            Label totalamttxt, DataGridView grid) 
        {
            loginID = int.Parse(LoginServices.ID);

            totalrenttxt.Text = queryTotalRent(loginID).ToString();
            totalqtytxt.Text = queryTotalQuantity(loginID).ToString();
            totalfeetxt.Text = queryTotalFee(loginID).ToString();
            totalchargetxt.Text = queryTotalCharge(loginID).ToString();
            totalamttxt.Text = queryTotalAmount(loginID).ToString();

            try
            {
                DataTable mediaDt = userHistory(loginID);

                if (mediaDt.Rows.Count > 0)
                {
                    grid.DataSource = mediaDt;
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
            int TotalRent = Convert.ToInt32(ObjDBAccess.executeScalar(totalRent));
            return TotalRent;
        }

        public int queryTotalQuantity(int loginID)
        {          
            SqlCommand totalQuantity = new SqlCommand(UserReportStrings.queryTotalQuantity(loginID));
            object result = ObjDBAccess.executeScalar(totalQuantity);
            int TotalQuantity = result != DBNull.Value ? Convert.ToInt32(result) : 0;
            return TotalQuantity;
        }

        public decimal queryTotalFee(int loginID)
        {          
            SqlCommand totalFee = new SqlCommand(UserReportStrings.queryTotalFee(loginID));
            object result = ObjDBAccess.executeScalar(totalFee);
            decimal TotalFee = result != DBNull.Value ? Convert.ToDecimal(result) : 0m;        
            return TotalFee;         
        }

        public decimal queryTotalCharge(int loginID) 
        {           
            SqlCommand totalCharge = new SqlCommand(UserReportStrings.queryTotalCharge(loginID));
            object result = ObjDBAccess.executeScalar(totalCharge);
            decimal TotalCharge = result != DBNull.Value ? Convert.ToDecimal(result) : 0m;
            return TotalCharge;
        }

        public decimal queryTotalAmount(int loginID) 
        {           
            SqlCommand totalAmount = new SqlCommand(UserReportStrings.queryTotalAmount(loginID));
            object result = ObjDBAccess.executeScalar(totalAmount);
            decimal TotalAmount = result != DBNull.Value ? Convert.ToDecimal(result) : 0m;
            return TotalAmount;
        }

        public DataTable userHistory(int loginID)
        {          
            DataTable mediaDt = new DataTable();
            ObjDBAccess.readDatathroughAdapter(UserReportStrings.queryUserHistory(loginID), mediaDt);
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
