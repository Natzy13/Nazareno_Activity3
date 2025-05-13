using BogsySystem.Forms.Services;
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
    public partial class UserReport : Form
    {
        UserReportServices services = new UserReportServices();

        public UserReport()
        {
            InitializeComponent();
        }

        private void UserReport_Load(object sender, EventArgs e)
        {
            services.userReportLoadFunction(dataGridUsers, dataGridUserRented, 
                activerentlbl, historylbl, dataGridUserHistory, backlbl);
        }

        private void dataGridUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            services.cellClickFunction(e, dataGridUsers, activerentlbl, dataGridUserRented, 
                historylbl, dataGridUserHistory, backlbl);
        }

        private void searchbtn_Click(object sender, EventArgs e)
        {
            services.searchButtonFunction(dataGridUsers, searchfilter, searchtxt);
        }

        private void dataGridUserRented_Click(object sender, EventArgs e)
        {
            dataGridUsers.ClearSelection();
        }
    }
}
