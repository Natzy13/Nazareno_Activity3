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
       
        public Report()
        {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            services.reportLoadFunction(dataGridReport, dataGridUsers, dataGridUserRented, activerentlbl);
        }

        private void dataGridUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            services.userGridFunction(e,dataGridUsers,activerentlbl,dataGridUserRented);
        }

        private void dataGridUsers_Click(object sender, EventArgs e)
        {
            dataGridUsers.ClearSelection();
        }

        public void UserActiveRent()
        {
           services.UserActiveRent(activerentlbl,dataGridUserRented);
        }

        private void searchbtn_Click(object sender, EventArgs e)
        {
            services.searchButtonFunction(dataGridUsers, searchfilter, searchtxt);
        }
    }

}

