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
using System.Windows.Controls;
using System.Windows.Forms;

namespace BogsySystem.UserForms
{
    public partial class UserRent : Form
    {
        
        UserRentServices services = new UserRentServices();
        
        private int AvailableCopies { get; set; }

        public UserRent()
        {
            InitializeComponent();
        }

        private void UserRent_Load(object sender, EventArgs e)
        {
            services.userRentLoad(quantitylbl, quantitytxt, rentbtn, dataGridRent, 
                dataGridCart, services.cartTable);
        
        }

        private void addCart_Click(object sender, EventArgs e)
        {
            services.addCartButtonFunction(dataGridRent, quantitylbl, quantitytxt, services.cartTable, subtotaltxt, dataGridCart, rentbtn);
        }

        private void clearCart_Click(object sender, EventArgs e)
        {
            services.clearCartButtonFunction(dataGridCart, subtotaltxt, quantitylbl, quantitytxt, rentbtn);
        }

        private void rentbtn_Click(object sender, EventArgs e)
        {
            services.rentButtonFunction(quantitytxt, dataGridRent, dataGridCart, subtotaltxt);
        }

        private void filterbtn_SelectedIndexChanged(object sender, EventArgs e)
        {
            services.filterComboboxFunction(filterbtn, dataGridRent);
        }

        private void dataGridRent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            services.cellClickFunction(e, dataGridRent, dataGridCart, quantitylbl, quantitytxt);
        }

        private void dataGridCart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            services.cartCellClickFunction(e, dataGridCart,dataGridRent, quantitytxt, quantitylbl);
        }

        private void dataGridRent_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridRent.ClearSelection();
        }

        private void dataGridRent_Click(object sender, EventArgs e)
        {
            dataGridRent.ClearSelection();
        }

        private void searchbtn_Click(object sender, EventArgs e)
        {
            services.searchButtonFunction(dataGridRent, searchtxt);
        }
 
        private void dataGridCart_Click(object sender, EventArgs e)
        {
            dataGridCart.ClearSelection();
            services.componentHide(quantitylbl, quantitytxt, rentbtn, dataGridCart);
        }

        private void dataGridCart_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridCart.ClearSelection();
            services.componentHide(quantitylbl, quantitytxt, rentbtn, dataGridCart);
        }
    }
}
