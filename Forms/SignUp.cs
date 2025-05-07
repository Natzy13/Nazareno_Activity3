using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BogsySystem.Forms.Properties;
using Microsoft.Data.SqlClient;

namespace BogsySystem.Forms
{
    public partial class SignUp : Form
    {
        SignUpServices services = new SignUpServices();

        public SignUp()
        {
            InitializeComponent();
        }

        private void regbtn_Click(object sender, EventArgs e)
        {
            services.registerButtonFunction(fnameregtxt,unameregtxt, passregtxt, emailregtxt, genderregtxt, this);
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            services.labelLogin(this);
        }

        private void showpassbtn_Click(object sender, EventArgs e)
        {
            services.showPass(passregtxt, hidepassbtn);
        }

        private void hidepassbtn_Click(object sender, EventArgs e)
        {
            services.hidePass(passregtxt, showpassbtn);
        }
       
    }
}
