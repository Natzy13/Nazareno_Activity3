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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BogsySystem.UserForms
{
    public partial class UserReturn : Form
    {
        UserReturnServices services = new UserReturnServices();

        public UserReturn()
        {
            InitializeComponent();
        }

        private void UserReturn_Load(object sender, EventArgs e)
        {
           services.userReturnLoad(returnbtn, dataGridReturn);
        }

        private void returnbtn_Click(object sender, EventArgs e)
        {
            services.returnButtonFunction(dataGridReturn);
        }
        private void dataGridReturn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            services.cellClickFunction(e, dataGridReturn, returnbtn);
        }

        private void dataGridReturn_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridReturn.ClearSelection();
            services.componentHide(returnbtn);
        }

        private void dataGridReturn_Click(object sender, EventArgs e)
        {
            dataGridReturn.ClearSelection();
            services.componentHide(returnbtn);
        }
    }
}
