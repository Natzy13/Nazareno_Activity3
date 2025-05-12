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
        private string TitleQuantities { get; set; }

        public void userReturnLoad(Button returnbtn, DataGridView grid)
        {
            LoginID = int.Parse(LoginServices.ID);
            componentHide(returnbtn); ;

            try
            {
                DataTable returnMedia = displayReturnQuery(LoginID);

                if (returnMedia.Rows.Count > 0)
                {
                    grid.DataSource = returnMedia;
                    dataGridProperties(grid);
                }
                else MessageBox.Show("No rented media found, so there are no media for return.", "Information", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable displayReturnQuery(int loginID)
        {
            DataTable displayReturnQuery = new DataTable();
            ObjDBAccess.readDatathroughAdapter(UserReturnStrings.displayReturnQuery(loginID), displayReturnQuery);
            ObjDBAccess.closeConn();
            return displayReturnQuery;
        }

        public void returnButtonFunction(DataGridView grid)
        {
            LoginID = int.Parse(LoginServices.ID);
            int rowsUserReturn = userReturnQuery(RentalID, QuantityRent);
            if (rowsUserReturn > 0)
            {
                MessageBox.Show($"Successfully returned:\n\n{TitleQuantities}", 
                    "Return Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                refreshDataGridQuery(LoginID, grid);
            }
            else MessageBox.Show("Error occurred while returning the media");
        }

        public int userReturnQuery(int rentalID, int quantityRent)
        {
            decimal overdueChargePerDay = 5;
            SqlCommand cmdReturn = new SqlCommand(UserReturnStrings.userReturnQuery);
            // Add parameters to the SqlCommand
            cmdReturn.Parameters.AddWithValue("@rentalID", rentalID);
            cmdReturn.Parameters.AddWithValue("@quantityRent", quantityRent);
            cmdReturn.Parameters.AddWithValue("@overdueChargePerDay", overdueChargePerDay);
            int userReturnQuery = ObjDBAccess.executeQuery(cmdReturn);
            ObjDBAccess.closeConn();
            return userReturnQuery;
        }

        public void cellClickFunction(DataGridViewCellEventArgs e, DataGridView grid, Button returnbtn)
        {
            try
            {
                // Check if the clicked event was on a valid row
                if (e.RowIndex >= 0)
                {
                    grid.CurrentRow.Selected = true;
                    componentShow(returnbtn);
                    DataGridViewRow row = grid.Rows[e.RowIndex];         
                    RentalID = Convert.ToInt32(row.Cells["RentalID"].Value);
                    MediaID = Convert.ToInt32(row.Cells["MediaID"].Value);
                    Title = row.Cells["Title"].Value.ToString();
                    QuantityRent = Convert.ToInt32(row.Cells["Quantity"].Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        public void cellClickFunction2(DataGridViewCellEventArgs e, DataGridView grid, Button returnbtn)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow clickedRow = grid.Rows[e.RowIndex];
                    RentalID = Convert.ToInt32(clickedRow.Cells["RentalID"].Value);
                    QuantityRent = Convert.ToInt32(clickedRow.Cells["TotalQuantity"].Value);
                    TitleQuantities = clickedRow.Cells["TitlesWithQuantities"].Value.ToString();

                    clickedRow.Selected = true;
                    componentShow(returnbtn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        public DataTable refreshDataGridQuery(int loginID, DataGridView grid)
        {
            DataTable refreshDataGridQuery = new DataTable();
            ObjDBAccess.readDatathroughAdapter(UserReturnStrings.displayReturnQuery(loginID), refreshDataGridQuery);
            ObjDBAccess.closeConn();
            grid.DataSource = refreshDataGridQuery;
            dataGridProperties(grid);
            return refreshDataGridQuery;
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

            grid.Columns["TitlesWithQuantities"].HeaderText = "Title/Quantity";
            grid.Columns["TitlesWithQuantities"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["RentalDate"].HeaderText = "Rent Date";
            grid.Columns["RentalDate"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["TotalQuantity"].HeaderText = "Quantity";
            grid.Columns["TotalQuantity"].SortMode = DataGridViewColumnSortMode.NotSortable;

        }

    }
}
