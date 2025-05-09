using BogsySystem.Forms;
using BogsySystem.Forms.Properties;
using BogsySystem.UserForms.Services;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BogsySystem.UserForms
{
    public partial class UserPayProperties : Form
    {
        UserPayServices services = new UserPayServices();
       
        public UserPayProperties()
        {
            InitializeComponent();
        }

        private void UserPay_Load(object sender, EventArgs e)
        {
            services.userPayLoad(feetxt, feelbl, chargefeetxt, chargefeelbl, totalfeetxt, totalfeelbl, 
                paytxt, paylbl, paybtn, dataGridPay);
        }
        
        private void paybtn_Click(object sender, EventArgs e)
        {                         
          services.payButtonFunction(feetxt, feelbl, chargefeetxt, chargefeelbl, totalfeetxt, totalfeelbl,
                paytxt, paylbl, paybtn, dataGridPay);
        }

        private void dataGridPay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            services.cellClickFunction(e, dataGridPay, feetxt, feelbl, chargefeetxt, chargefeelbl, totalfeetxt, 
                totalfeelbl,paytxt, paylbl, paybtn);
        }

        private void dataGridPay_Click(object sender, EventArgs e)
        {
            dataGridPay.ClearSelection();
            services.componentHide(feetxt, feelbl, chargefeetxt, chargefeelbl, totalfeetxt, totalfeelbl, paytxt, 
                paylbl, paybtn);
        }

        private void dataGridPay_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridPay.ClearSelection();
            services.componentHide(feetxt, feelbl, chargefeetxt, chargefeelbl, totalfeetxt, totalfeelbl, paytxt, 
                paylbl, paybtn);
        }      
    }
}
