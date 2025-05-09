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
    public class UserReturnServices
    {
        private DBAccess ObjDBAccess = new DBAccess();

        private int MediaID {  get; set; }
        private int RentalID { get; set; }
        private int QuantityRent { get; set; }
        private int LoginID { get; set; }
        private string Title { get; set; }

        public DataTable displayReturn (int loginID)
        {           
            DataTable mediaDt = new DataTable();
            ObjDBAccess.readDatathroughAdapter(UserReturnStrings.displayReturnQuery(loginID), mediaDt);
            ObjDBAccess.closeConn();
            return mediaDt;
        }

        public void userReturnLoad(Button returnbtn, DataGridView grid)
        {
            LoginID = int.Parse(LoginServices.ID);
            componentHide(returnbtn); ;

            try
            {
                DataTable returnMedia = displayReturn(LoginID);

                if (returnMedia.Rows.Count > 0)
                {
                    grid.DataSource = returnMedia;
                    dataGridProperties(grid);
                }
                else MessageBox.Show("No rented media found, so there are no media for return.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void returnButtonFunction(DataGridView grid)
        {
            LoginID = int.Parse(LoginServices.ID);
            int rows = userReturnQuery(RentalID, QuantityRent);
            if (rows > 0)
            {
                MessageBox.Show($"Successfully returned {QuantityRent} copies of " + Title); ;
                refreshDataGrid(LoginID, grid);
            }
            else
            {
                MessageBox.Show("Error occurred while returning the media");
            }
        }

        public int userReturnQuery(int rentalID, int quantityRent) 
        {
            decimal overdueChargePerDay = 5;

            SqlCommand cmdReturn = new SqlCommand(UserReturnStrings.userReturnQuery);

            // Add parameters to the SqlCommand
            cmdReturn.Parameters.AddWithValue("@rentalID", rentalID);
            cmdReturn.Parameters.AddWithValue("@quantityRent", quantityRent);
            cmdReturn.Parameters.AddWithValue("@overdueChargePerDay", overdueChargePerDay);

            int rows = ObjDBAccess.executeQuery(cmdReturn);
            ObjDBAccess.closeConn();

            return rows;
        }

        public void cellClickFunction(DataGridViewCellEventArgs e, DataGridView grid, Button returnbtn)
        {
            try
            {
                // Check if the clicked event was on a valid row
                if (e.RowIndex >= 0)
                {
                    // Select the current row
                    grid.CurrentRow.Selected = true;
                    componentShow(returnbtn);

                    DataGridViewRow row = grid.Rows[e.RowIndex];
         
                    // Retrieve the selected data into a variable
                    RentalID = Convert.ToInt32(row.Cells["RentalID"].Value);
                    MediaID = Convert.ToInt32(row.Cells["MediaID"].Value);
                    Title = row.Cells["Title"].Value.ToString();
                    QuantityRent = Convert.ToInt32(row.Cells["Quantity"].Value); //Assign to variable
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        public DataTable refreshDataGrid(int loginID, DataGridView grid)
        {        
            DataTable mediaDt = new DataTable();
            ObjDBAccess.readDatathroughAdapter(UserReturnStrings.displayReturnQuery(loginID), mediaDt);           
            ObjDBAccess.closeConn();
            grid.DataSource = mediaDt;
            dataGridProperties(grid);
            return mediaDt;
        }

        public void componentHide(Button returnbtn)
        {
            returnbtn.Visible = false;
        }

        public void componentShow(Button returnbtn)
        {
            returnbtn.Visible = true;
        }

        public void dataGridProperties(DataGridView grid)
        {
            grid.Columns["RentalID"].Visible = false;
            grid.Columns["MediaID"].Visible = false;

            grid.Columns["Title"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["Format"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["Price"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["RentalDate"].HeaderText = "Rent Date";
            grid.Columns["RentalDate"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["Quantity"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["MaxRentalDays"].HeaderText = "Max Rent Days";
            grid.Columns["MaxRentalDays"].SortMode = DataGridViewColumnSortMode.NotSortable;
        }
    }
}
