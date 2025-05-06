using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BogsySystem.UserForms
{
    public partial class UserRent : Form
    {
        private void dataGridRent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Check if the clicked event was on a valid row
                if (e.RowIndex >= 0)
                {
                    // Select the current row
                    dataGridRent.CurrentRow.Selected = true;
                    componentShow();

                    // Retrieve the selected data into a variable
                    mediaID = Convert.ToInt32(dataGridRent.Rows[e.RowIndex].Cells["MediaID"].Value);
                    title = dataGridRent.Rows[e.RowIndex].Cells["Title"].Value?.ToString();
                    availableCopies = Convert.ToInt32(dataGridRent.Rows[e.RowIndex].Cells["AvailableCopies"].Value);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void dataGridRent_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridRent.ClearSelection();
            componentHide();
        }

        private void dataGridRent_Click(object sender, EventArgs e)
        {
            dataGridRent.ClearSelection();
            componentHide();
        }

        private void dataGridProperties()
        {
            dataGridRent.Columns["MediaID"].Visible = false;

            dataGridRent.Columns["Title"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridRent.Columns["Format"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridRent.Columns["AvailableCopies"].HeaderText = "Available";
            dataGridRent.Columns["AvailableCopies"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridRent.Columns["Price"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridRent.Columns["MaxRentalDays"].HeaderText = "Max Rent Days";
            dataGridRent.Columns["MaxRentalDays"].SortMode = DataGridViewColumnSortMode.NotSortable;

        }

        private void componentHide()
        {
            quantitylbl.Visible = false;
            quantitytxt.Visible = false;
            rentbtn.Visible = false;
        }
        private void componentShow()
        {
            quantitylbl.Visible = true;
            quantitytxt.Visible = true;
            rentbtn.Visible = true;
        }

        private void refreshDataGrid()
        {
            String tableQuery = "SELECT MediaID, Title, Format, AvailableCopies, Price, MaxRentalDays FROM MediaItems WHERE AvailableCopies > 0";
            DataTable mediaDt = new DataTable();
            ObjDBAccess.readDatathroughAdapter(tableQuery, mediaDt);
            ObjDBAccess.closeConn();
            dataGridRent.DataSource = mediaDt;
        }
    }
}
