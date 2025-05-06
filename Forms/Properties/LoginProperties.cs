using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BogsySystem.Forms
{
    public partial class Login : Form
    {

        private void hidepassbtn_Click(object sender, EventArgs e)
        {
            if (passlogintxt.PasswordChar == '\0')
            {
                showpassbtn.BringToFront();
                passlogintxt.PasswordChar = '*';
            }
        }

        private void showpassbtn_Click(object sender, EventArgs e)
        {
            if (passlogintxt.PasswordChar == '*')
            {
                hidepassbtn.BringToFront();
                passlogintxt.PasswordChar = '\0';
            }
        }
    }
}
