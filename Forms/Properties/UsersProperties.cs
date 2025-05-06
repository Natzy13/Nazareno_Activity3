using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BogsySystem.Forms
{
    public partial class Users : Form
    {
        private void dataGridUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Check if the clicked event was on a valid row
                if (e.RowIndex >= 0)
                {
                    // Select the current row
                    dataGridUsers.CurrentRow.Selected = true;
                    componentShow();

                    // Retrieve the selected data into a variable
                    selectedUserID = Convert.ToInt32(dataGridUsers.Rows[e.RowIndex].Cells["ID"].Value);
                    nametxt.Text = dataGridUsers.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                    emailtxt.Text = dataGridUsers.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                    gendertxt.Text = dataGridUsers.Rows[e.RowIndex].Cells["Gender"].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void dataGridUsers_Click(object sender, EventArgs e)
        {
            dataGridUsers.CurrentRow.Selected = false;
            componentHide();
        }

        private void dataGridUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridUsers.CurrentRow.Selected = false;
            componentHide();
        }

        void dataGridProperties()
        {
            dataGridUsers.Columns["ID"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridUsers.Columns["Name"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridUsers.Columns["Username"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridUsers.Columns["Email"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridUsers.Columns["Gender"].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        void refreshDataGrid()
        {

            string tablequery = "SELECT ID, Name, Username, Email, Gender FROM Users WHERE IsAdmin = 0";
            DataTable usersDt = new DataTable();
            ObjDBAccess.readDatathroughAdapter(tablequery, usersDt);
            dataGridUsers.DataSource = usersDt;
        }

        void componentHide()
        {
            activatebtn.Visible = false;
            editbtn.Visible = false;
            nametxt.Visible = false;
            emailtxt.Visible = false;
            gendertxt.Visible = false;
            namelbl.Visible = false;
            emaillbl.Visible = false;
            genderlbl.Visible = false;
        }

        void componentShow()
        {
            activatebtn.Visible = true;
            editbtn.Visible = true;
            nametxt.Visible = true;
            emailtxt.Visible = true;
            gendertxt.Visible = true;
            namelbl.Visible = true;
            emaillbl.Visible = true;
            genderlbl.Visible = true;
        }
    }
}
