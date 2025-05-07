using BogsySystem.Forms;
using BogsySystem.Forms.Properties;
using BogsySystem.UserForms.Services;
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
        UserReportServices services = new UserReportServices();
        private int loginID = int.Parse(LoginServices.ID);
        public UserReport()
        {
            InitializeComponent();
        }

        private void UserReport_Load(object sender, EventArgs e)
        {

            totalrenttxt.Text = services.queryTotalRent(loginID).ToString();
            totalqtytxt.Text = services.queryTotalQuantity(loginID).ToString();
            totalfeetxt.Text = services.queryTotalFee(loginID).ToString();
            totalchargetxt.Text = services.queryTotalCharge(loginID).ToString();
            totalamttxt.Text = services.queryTotalAmount(loginID).ToString();
      
            try
            {
                DataTable mediaDt = services.userHistory(loginID);

                if (mediaDt.Rows.Count > 0)
                {
                    dataGridHistory.DataSource = mediaDt;
                    services.dataGridProperties(dataGridHistory);
                }
                else MessageBox.Show("No History Found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }      
    }
}
