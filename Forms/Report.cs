using BogsySystem.Forms.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace BogsySystem.Forms
{

    public partial class Report : Form
    {
        ReportServices services = new ReportServices();
        private int selectedUserID;
        public Report()
        {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable mediaDt1 = services.GetMediaReport();

                if (mediaDt1.Rows.Count > 0)
                {
                    dataGridReport.DataSource = mediaDt1;
                    services.DataGridProperties1(dataGridReport);
                }
                else MessageBox.Show("No media found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                DataTable mediaDt2 = services.GetUsers();

                if (mediaDt2.Rows.Count > 0)
                {
                    dataGridUsers.DataSource = mediaDt2;
                    services.DataGridProperties2(dataGridUsers);
                }
                else MessageBox.Show("No active users found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            activerentlbl.Visible = false;
            dataGridUserRented.Visible = false;
        }

        private void dataGridUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Check if the clicked event was on a valid row
                if (e.RowIndex >= 0)
                {
                    // Select the current row
                    dataGridUsers.CurrentRow.Selected = true;

                    // Retrieve the selected data into a variable
                    selectedUserID = Convert.ToInt32(dataGridUsers.Rows[e.RowIndex].Cells["ID"].Value);
                    UserActiveRent();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void dataGridUsers_Click(object sender, EventArgs e)
        {
            dataGridUsers.ClearSelection();
        }

        public void UserActiveRent()
        {
            activerentlbl.Visible = true;
            dataGridUserRented.Visible = true;

            DataTable mediaDt3 = services.GetUsersActiveRentals(selectedUserID);

            if (mediaDt3.Rows.Count > 0)
            {
                dataGridUserRented.DataSource = mediaDt3;
                services.DataGridProperties3(dataGridUserRented);
            }
            else
            {
                activerentlbl.Visible = false;
                dataGridUserRented.Visible = false;
                dataGridUsers.ClearSelection();
                MessageBox.Show("User have no active rent", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void searchbtn_Click(object sender, EventArgs e)
        {
            services.searchFunction(dataGridUsers, searchfilter, searchtxt);
        }
    }

}

