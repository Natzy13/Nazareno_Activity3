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

    public partial class Report : Form
    {
        DBAccess ObjDBAccess = new DBAccess();
        private int selectedUserID;
        public Report()
        {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            try
            {
                string queryReport = @"SELECT Title, AvailableCopies,(TotalCopies - AvailableCopies) AS RentedCopies FROM MediaItems ORDER BY Title ASC;";
                DataTable mediaDt1 = new DataTable();
                ObjDBAccess.readDatathroughAdapter(queryReport, mediaDt1);

                if (mediaDt1.Rows.Count > 0)
                {
                    dataGridReport.DataSource = mediaDt1;
                    dataGridProperties1();
                }
                else
                {
                    MessageBox.Show("No media found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                String queryUsers = "SELECT ID, Name, Username FROM Users WHERE IsAdmin = 0";
                DataTable mediaDt2 = new DataTable();
                ObjDBAccess.readDatathroughAdapter(queryUsers, mediaDt2);

                if (mediaDt2.Rows.Count > 0)
                {
                    dataGridUsers.DataSource = mediaDt2;
                    dataGridProperties2();
                }
                else
                {
                    MessageBox.Show("No active users found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            activerentlbl.Visible = false;
            dataGridUserRented.Visible = false;
        }

        
    }
}
