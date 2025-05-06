using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BogsySystem.Forms
{
    public partial class VideoLibrary : Form
    {
        private void dataGridVid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            editbtn.Visible = true;
            try
            {
                // Check if the clicked event was on a valid row
                if (e.RowIndex >= 0)
                {
                    // Select the current row
                    dataGridVid.CurrentRow.Selected = true;
                    addbtn.Visible = false;
                    // Retrieve and display data from the selected row
                    mediaID = Convert.ToInt32(dataGridVid.Rows[e.RowIndex].Cells["MediaID"].Value);
                    vidtitletxt.Text = dataGridVid.Rows[e.RowIndex].Cells["Title"].Value.ToString();
                    formatxt.Text = dataGridVid.Rows[e.RowIndex].Cells["Format"].Value.ToString();
                    currentAvailablecopies = Convert.ToInt32(dataGridVid.Rows[e.RowIndex].Cells["AvailableCopies"].Value); //Current available copies
                    quantitytxt.Value = Convert.ToInt32(dataGridVid.Rows[e.RowIndex].Cells["TotalCopies"].Value);
                    currentTotalcopies = Convert.ToInt32(dataGridVid.Rows[e.RowIndex].Cells["TotalCopies"].Value); //Current total copies
                    maxrenttxt.Text = Convert.ToInt32(dataGridVid.Rows[e.RowIndex].Cells["MaxRentalDays"].Value).ToString();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void dataGridVid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridVid.ClearSelection();  // Deselect the row            
            clearDataFields();
            addbtn.Visible = true;
            editbtn.Visible = false;
        }

        private void refreshDataGrid() //Method to refresh data grid
        {
            string tableQuery = "SELECT * FROM MediaItems WHERE IsAvailable = 1";
            DataTable mediaDt = new DataTable();
            ObjDBAccess.readDatathroughAdapter(tableQuery, mediaDt);
            dataGridVid.DataSource = mediaDt;
            dataGridProperties();
        }

        void clearDataFields()
        {
            vidtitletxt.Clear();
            formatxt.Text = "Select";
            maxrenttxt.Text = "0";
            quantitytxt.Value = 1;
        }

        void dataGridProperties()
        {
            dataGridVid.Columns["MediaID"].HeaderText = "ID";
            dataGridVid.Columns["MediaID"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridVid.Columns["Title"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridVid.Columns["Format"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridVid.Columns["AvailableCopies"].HeaderText = "Available";
            dataGridVid.Columns["AvailableCopies"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridVid.Columns["TotalCopies"].HeaderText = "Total Quantity";
            dataGridVid.Columns["TotalCopies"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridVid.Columns["Price"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridVid.Columns["MaxRentalDays"].HeaderText = "Max Rent Days";
            dataGridVid.Columns["MaxRentalDays"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridVid.Columns["IsAvailable"].Visible = false;
        }

        private void dataGridVid_Click(object sender, EventArgs e)
        {
            dataGridVid.ClearSelection();
            clearDataFields();
            addbtn.Visible = true;
            editbtn.Visible = false;
        }
    }
}
