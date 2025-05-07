using BogsySystem.Forms;
using BogsySystem.Forms.Properties;
using BogsySystem.UserForms.Services;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BogsySystem.UserForms
{
    public partial class UserReturn : Form
    {
        UserReturnServices services = new UserReturnServices();
        private int mediaID, rentalID,quantityRent;
        private int loginID = int.Parse(LoginServices.ID);
        private string title;
        public UserReturn()
        {
            InitializeComponent();
        }

        private void UserReturn_Load(object sender, EventArgs e)
        {
            services.componentHide(returnbtn); ;

            try
            {
                DataTable mediaDt = services.displayReturn(loginID);

                if (mediaDt.Rows.Count > 0)
                {
                    dataGridReturn.DataSource = mediaDt;
                    services.dataGridProperties(dataGridReturn);
                }
                else MessageBox.Show("No rented media found, so there are no media for return.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void returnbtn_Click(object sender, EventArgs e)
        {
            int rows = services.userReturn(rentalID,quantityRent);
            if (rows > 0)
            {
                MessageBox.Show($"Successfully returned {quantityRent} copies of " + title); ;
                services.refreshDataGrid(loginID, dataGridReturn);
            }
            else
            {
                MessageBox.Show("Error occurred while returning the media");
            }
        }
        private void dataGridReturn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Check if the clicked event was on a valid row
                if (e.RowIndex >= 0)
                {
                    // Select the current row
                    dataGridReturn.CurrentRow.Selected = true;
                    services.componentShow(returnbtn);

                    // Retrieve the selected data into a variable
                    rentalID = Convert.ToInt32(dataGridReturn.Rows[e.RowIndex].Cells["RentalID"].Value);
                    mediaID = Convert.ToInt32(dataGridReturn.Rows[e.RowIndex].Cells["MediaID"].Value);
                    title = dataGridReturn.Rows[e.RowIndex].Cells["Title"].Value?.ToString();
                    quantityRent = Convert.ToInt32(dataGridReturn.Rows[e.RowIndex].Cells["Quantity"].Value); //Assign to variable
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void dataGridReturn_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridReturn.ClearSelection();
            services.componentHide(returnbtn);
        }

        private void dataGridReturn_Click(object sender, EventArgs e)
        {
            dataGridReturn.ClearSelection();
            services.componentHide(returnbtn);
        }
    }
}
