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
        DBAccess ObjDBAccess = new DBAccess();
        public DashboardMain()
        {
            InitializeComponent();
        }

        private void DashboardMain_Load(object sender, EventArgs e)
        {
            string queryTotalMedia = "SELECT COUNT(*) FROM MediaItems WHERE IsAvailable = 1";
            SqlCommand totalMedia = new SqlCommand(queryTotalMedia);
            totalmediatxt.Text = Convert.ToInt32(ObjDBAccess.executeScalar(totalMedia)).ToString();

            string queryTotalRentals = "SELECT COUNT(*) FROM Rentals";
            SqlCommand totalRentals = new SqlCommand(queryTotalMedia);
            totalrentalstxt.Text = Convert.ToInt32(ObjDBAccess.executeScalar(totalRentals)).ToString();

            string queryTotalUsers = "SELECT COUNT(*) FROM Users WHERE IsAdmin = 0";
            SqlCommand totalUsers = new SqlCommand(queryTotalUsers);
            totalregisteredtxt.Text = Convert.ToInt32(ObjDBAccess.executeScalar(totalUsers)).ToString();

            string queryActiveRentals = "SELECT COUNT(*) FROM RentalHistory WHERE IsReturned = 0";
            SqlCommand activeRentals = new SqlCommand(queryActiveRentals);
            activerentalstxt.Text = Convert.ToInt32(ObjDBAccess.executeScalar(activeRentals)).ToString();

            string queryTotalRevenue = "SELECT SUM(TotalFee) FROM RentalHistory WHERE IsPaid = 1";
            SqlCommand totalRevenue = new SqlCommand(queryTotalRevenue);
            totalrevtxt.Text = string.Format("{0:N2}", ObjDBAccess.executeScalar(totalRevenue) ?? 0);

            string queryOverdueRent = "SELECT COUNT(*)\r\nFROM Rentals\r\nINNER JOIN MediaItems ON Rentals.MediaID = MediaItems.MediaID\r\nWHERE DATEDIFF(DAY, Rentals.RentalDate, GETDATE()) > MediaItems.MaxRentalDays;";
            SqlCommand overdueRent = new SqlCommand(queryOverdueRent);
            overduerenttxt.Text = Convert.ToInt32(ObjDBAccess.executeScalar(overdueRent)).ToString();

            try
            {
                string historyQuery = @"
SELECT 
    RH.RentalID,
    U.Name,
    M.Title,
    M.Format,
    RH.RentalDate,
    RH.ReturnDate 
FROM RentalHistory RH
JOIN MediaItems M ON RH.MediaID = M.MediaID
JOIN Users U ON RH.UserID = U.ID
WHERE RH.IsPaid = 1
ORDER BY RH.ReturnDate DESC";
                DataTable mediaDt = new DataTable();
                ObjDBAccess.readDatathroughAdapter(historyQuery, mediaDt);
                ObjDBAccess.closeConn();

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

