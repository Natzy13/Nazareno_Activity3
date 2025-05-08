using BogsySystem.Forms;
using BogsySystem.Forms.Properties;
using BogsySystem.UserForms.Services;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BogsySystem.UserForms
{
    public partial class UserAccount : Form
    {
        
        UserAccountServices services = new UserAccountServices();
  
        public UserAccount()
        {
            InitializeComponent();
        }

        private void UserAccount_Load(object sender, EventArgs e)
        {
            services.userAccountLoad(idtxt,fnametxt,usernametxt,passtxt,emailtxt,gendertxt);
        }

        private void editbtn_Click(object sender, EventArgs e)
        {
            services.editButtonFunction(fnametxt,usernametxt,passtxt,emailtxt,gendertxt, this.ParentForm);
        }

        private void deactbtn_Click(object sender, EventArgs e)
        {
            services.deactButtonFunction(this.ParentForm);
        }

        private void showpassbtn_Click(object sender, EventArgs e)
        {
            services.showPass(passtxt, hidepassbtn);
        }

        private void hidepassbtn_Click(object sender, EventArgs e)
        {
            services.hidePass(passtxt, showpassbtn);
        }
    }
}
