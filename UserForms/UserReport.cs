using BogsySystem.Forms;
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

namespace BogsySystem.UserForms
{
    public partial class UserReport : Form
    {
        DBAccess ObjDBAccess = new DBAccess();
        public UserReport()
        {
            InitializeComponent();
        }

        private void UserReport_Load(object sender, EventArgs e)
        {
            queryTotalRent();
            queryTotalQuantity();
            queryTotalFee();
            queryTotalCharge();
            queryTotalAmount();
  
            try
            {
                String tablequery = @"SELECT 
    MI.Title,
    MI.Format,
    RH.RentalDate,
    RH.ReturnDate,
    R.Quantity,
    RH.Fee,
    RH.ChargeFee,
    RH.TotalFee
FROM RentalHistory RH
JOIN MediaItems MI ON RH.MediaID = MI.MediaID
JOIN Rentals R ON RH.RentalID = R.RentalID
WHERE RH.UserID = '"+Login.ID+"' AND RH.IsPaid = 1 ORDER BY RH.RentalDate DESC;";
                DataTable mediaDt = new DataTable();
                ObjDBAccess.readDatathroughAdapter(tablequery, mediaDt);
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

    }
}
