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
            services.dashboardMainFunction(totalmediatxt, totalrentalstxt, totalregisteredtxt, 
                activerentalstxt, totalrevtxt, overduerenttxt, dataGridHistory);
        }     
    }
    }
