using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BogsySystem.Forms
{
    public partial class SignUp : Form
    {
        private void showpassbtn_Click(object sender, EventArgs e)
        {
            if (passregtxt.PasswordChar == '*')
            {
                hidepassbtn.BringToFront();
                passregtxt.PasswordChar = '\0';
            }
        }

        private void hidepassbtn_Click(object sender, EventArgs e)
        {
            if (passregtxt.PasswordChar == '\0')
            {
                showpassbtn.BringToFront();
                passregtxt.PasswordChar = '*';
            }
        }

        void clearDataFields()
        {
            fnameregtxt.Clear();
            unameregtxt.Clear();
            passregtxt.Clear();
            emailregtxt.Clear();
            genderregtxt.Text = "Select Gender";
        }
    }
}
