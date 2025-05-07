using BogsySystem.Forms.Strings;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BogsySystem.Forms.Properties
{
    public class DashboardServices 
    {
        private DBAccess ObjDBAccess = new DBAccess();

        public void dashboardMainFunction(Label totalmediatxt, Label totalrentalstxt,
            Label totalregisteredtxt, Label activerentalstxt, Label totalrevtxt,
            Label overduerenttxt, DataGridView grid)
        {
            totalmediatxt.Text = queryTotalMedia().ToString();
            totalrentalstxt.Text = queryTotalRentals().ToString();
            totalregisteredtxt.Text = queryTotalRegistered().ToString();
            activerentalstxt.Text = queryActiveRentals().ToString();
            totalrevtxt.Text = queryTotalRevenue().ToString();
            overduerenttxt.Text = queryOverdueRent().ToString();

            try
            {
                DataTable rentalHistory = GetRentalHistory();

                if (rentalHistory.Rows.Count > 0)
                {
                    grid.DataSource = rentalHistory;
                    dataGridProperties(grid);
                }
                else MessageBox.Show("No History Found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public int queryTotalMedia()
        {
            SqlCommand totalMedia = new SqlCommand(DashboardMainStrings.queryTotalMedia);
            int TotalMedia = Convert.ToInt32(ObjDBAccess.executeScalar(totalMedia));
            return TotalMedia;
        }

        public int queryTotalRentals()
        {
            SqlCommand totalRentals = new SqlCommand(DashboardMainStrings.queryTotalRentals);
            int TotalRentals = Convert.ToInt32(ObjDBAccess.executeScalar(totalRentals));
            return TotalRentals;
        }

        public int queryTotalRegistered()
        {
            SqlCommand totalRegistered = new SqlCommand(DashboardMainStrings.queryTotalRegistered);
            int TotalRegistered = Convert.ToInt32(ObjDBAccess.executeScalar(totalRegistered));
            return TotalRegistered;
        }

        public int queryActiveRentals()
        {          
            SqlCommand activeRentals = new SqlCommand(DashboardMainStrings.queryActiveRentals);
            int ActiveRentals = Convert.ToInt32(ObjDBAccess.executeScalar(activeRentals));
            return ActiveRentals;
        }

        public decimal queryTotalRevenue()
        {            
            SqlCommand totalRevenue = new SqlCommand(DashboardMainStrings.queryTotalRevenue);
            object result = ObjDBAccess.executeScalar(totalRevenue);
            decimal TotalRevenue = result != DBNull.Value ? Convert.ToDecimal(result) : 0m;
            return TotalRevenue;
        }

        public int queryOverdueRent()
        {
           
            SqlCommand overdueRent = new SqlCommand(DashboardMainStrings.queryOverdueRent);
            int OverdueRent = Convert.ToInt32(ObjDBAccess.executeScalar(overdueRent));
            return OverdueRent;
        }

        public DataTable GetRentalHistory()
        {
            DataTable rentalHistory = new DataTable();

            try
            {
                ObjDBAccess.readDatathroughAdapter(DashboardMainStrings.historyQuery, rentalHistory);
                ObjDBAccess.closeConn();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve rental history.", ex);
            }

            return rentalHistory;
        }

        public void dataGridProperties(DataGridView grid)
        {
            grid.Columns["RentalID"].Visible = false;

            grid.Columns["Name"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["Title"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["Format"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["RentalDate"].HeaderText = "Rent Date";
            grid.Columns["RentalDate"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["ReturnDate"].HeaderText = "Return Date";
            grid.Columns["ReturnDate"].SortMode = DataGridViewColumnSortMode.NotSortable;
        }
    }
}
