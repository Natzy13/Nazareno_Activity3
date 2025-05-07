using BogsySystem.Forms.Properties;
using BogsySystem.UserForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace BogsySystem.Forms
{
    public partial class Login : Form
    {      
        LoginServices services = new LoginServices();
        public Login()
        {
            InitializeComponent();
        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            services.LoginButtonFunction(unamelogintxt, passlogintxt, this);
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            services.labelSignup(this);
        }

       private void showpassbtn_Click(object sender, EventArgs e)
        {
            services.showPass(passlogintxt, hidepassbtn);
        }

        private void hidepassbtn_Click(object sender, EventArgs e)
        {
          services.hidePass(passlogintxt, showpassbtn);
        }
    }
}
