using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BogsySystem.UserForms
{
    public partial class UserAccount : Form
    {
        private void showpassbtn_Click(object sender, EventArgs e)
        {
            if (passtxt.PasswordChar == '*')
            {
                hidepassbtn.BringToFront();
                passtxt.PasswordChar = '\0';
            }
        }

        private void hidepassbtn_Click(object sender, EventArgs e)
        {
            if (passtxt.PasswordChar == '\0')
            {
                showpassbtn.BringToFront();
                passtxt.PasswordChar = '*';
            }
        }
    }
}
