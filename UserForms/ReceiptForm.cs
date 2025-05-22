using BogsySystem.UserForms.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace BogsySystem.UserForms
{
  
    public partial class ReceiptForm : Form
    {
        ReceiptFormServices services = new ReceiptFormServices();
        public static Bitmap memoryImage;

        public ReceiptForm()
        {
            InitializeComponent();
        }

        private void ReceiptForm_Load(object sender, EventArgs e)
        {
            services.receiptFormLoad(dataGridReceipt, namelbl, cashlbl, changelbl, datelbl);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void printbtn_Click(object sender, EventArgs e)
        {
            services.PrintForm(printpanel, new Size(768, 384));
        }
    }
}
