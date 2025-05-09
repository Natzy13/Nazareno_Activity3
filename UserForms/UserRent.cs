using BogsySystem.Forms;
using BogsySystem.Forms.Properties;
using BogsySystem.UserForms.Services;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BogsySystem.UserForms
{
    public partial class UserRent : Form
    {
        DBAccess ObjDBAccess = new DBAccess();
        UserRentServices services = new UserRentServices();
      
        public UserRent()
        {
            InitializeComponent();
        }

        private void UserRent_Load(object sender, EventArgs e)
        {
            services.userRentLoad(quantitylbl, quantitytxt, rentbtn, dataGridRent);
        }

        private void rentbtn_Click(object sender, EventArgs e)
        {
           services.rentButtonFunction(quantitytxt,dataGridRent);
        }

        private void filterbtn_SelectedIndexChanged(object sender, EventArgs e)
        {
            services.filterComboboxFunction(filterbtn, dataGridRent);
        }

        private void dataGridRent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           services.cellClickFunction(e, dataGridRent,quantitylbl,quantitytxt,rentbtn);
        }

        private void dataGridRent_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridRent.ClearSelection();
            services.componentHide(quantitylbl, quantitytxt, rentbtn);
        }

        private void dataGridRent_Click(object sender, EventArgs e)
        {
            dataGridRent.ClearSelection();
            services.componentHide(quantitylbl, quantitytxt, rentbtn);
        }

        private void searchbtn_Click(object sender, EventArgs e)
        {
            services.searchButtonFunction(dataGridRent,searchtxt);
        }
    }
}
