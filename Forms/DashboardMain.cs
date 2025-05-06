using BogsySystem.Forms.Properties;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BogsySystem.Forms
{
    public partial class DashboardMain : Form
    {
        DashboardServices services = new DashboardServices();
        public DashboardMain()
        {
            InitializeComponent();
        }

        private void DashboardMain_Load(object sender, EventArgs e)
        {
            totalmediatxt.Text = services.queryTotalMedia().ToString();
            totalrentalstxt.Text = services.queryTotalRentals().ToString();           
            totalregisteredtxt.Text = services.queryTotalRegistered().ToString();          
            activerentalstxt.Text = services.queryActiveRentals().ToString();           
            totalrevtxt.Text = services.queryTotalRevenue().ToString();          
            overduerenttxt.Text = services.queryOverdueRent().ToString();

            try
            {
                DataTable mediaDt = services.GetRentalHistory();

                if (mediaDt.Rows.Count > 0)
                {
                    dataGridHistory.DataSource = mediaDt;
                    dataGridProperties();
                }
                else
                {
                    MessageBox.Show("No History Found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void dataGridProperties()
        {
            dataGridHistory.Columns["RentalID"].Visible = false;

            dataGridHistory.Columns["Name"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridHistory.Columns["Title"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridHistory.Columns["Format"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridHistory.Columns["RentalDate"].HeaderText = "Rent Date";
            dataGridHistory.Columns["RentalDate"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridHistory.Columns["ReturnDate"].HeaderText = "Return Date";
            dataGridHistory.Columns["ReturnDate"].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

    }
    }
