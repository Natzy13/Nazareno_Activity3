using BogsySystem.Forms.Properties;
using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace BogsySystem.Forms
{
    public partial class Users : Form
    {
        UsersServices services = new UsersServices();
        public Users()
        {
            InitializeComponent();
        }

        private void Users_Load(object sender, EventArgs e) //vidLoadFunction
        {
            services.userLoadFunction(filter, activatebtn, editbtn, nametxt, emailtxt, gendertxt, namelbl, emaillbl,
                genderlbl, dataGridUsers);

        }

        private void deactbtn_Click(object sender, EventArgs e)
        {
            services.ActivateButtonFunction(dataGridUsers);
        }

        private void editbtn_Click(object sender, EventArgs e)
        {
            services.EditButtonFunction(nametxt, emailtxt, gendertxt, namelbl, emaillbl, genderlbl, activatebtn, 
                editbtn, dataGridUsers);
        }

        private void filter_SelectedIndexChanged(object sender, EventArgs e)
        {
           services.filterComboboxFunction(filter, dataGridUsers);
        }

        private void dataGridUsers_CellClick(object sender, DataGridViewCellEventArgs e) //cellClickFunction
        {
            services.cellClickFunction(e,dataGridUsers,activatebtn,editbtn, nametxt, emailtxt,gendertxt,namelbl, 
               emaillbl, genderlbl);
        }

        private void dataGridUsers_Click(object sender, EventArgs e)
        {
            dataGridUsers.CurrentRow.Selected = false;
            services.componentHide(activatebtn, editbtn, nametxt, emailtxt, gendertxt, namelbl, emaillbl, genderlbl);
        }

        private void dataGridUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridUsers.CurrentRow.Selected = false;
            services.componentHide(activatebtn, editbtn, nametxt, emailtxt, gendertxt, namelbl, emaillbl, genderlbl);
        }

        private void searchbtn_Click(object sender, EventArgs e)
        {
            services.searchButtonFunction(dataGridUsers,searchfilter, searchtxt);
        }
    }
}
