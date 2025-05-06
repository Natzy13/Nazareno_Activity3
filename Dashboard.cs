
using BogsySystem.Forms;
using FontAwesome.Sharp;
using Microsoft.Data.SqlClient;

namespace BogsySystem
{
    public partial class Dashboard : Form
    {
        private IconButton currentBtn; // Variable for the current button pressed
        private Panel leftBorderBtn;   // Variable for the vertical lign
        private Form currentChildForm;

        public static Color color1 = Color.FromArgb(172, 126, 241);
        public static Color color2 = Color.FromArgb(249, 118, 176);
        public static Color color3 = Color.FromArgb(253, 138, 114);
        public static Color color4 = Color.FromArgb(95, 77, 221);


        public Dashboard()
        {
            InitializeComponent();


            leftBorderBtn = new Panel(); //This is the vertical lign in the button when pressed
            leftBorderBtn.Size = new Size(5, 42); // This is the size of the vertical lign
            menuPanel.Controls.Add(leftBorderBtn);

            MessageBox.Show($"Welcome {Login.name}");
            ActivateButton(menubtn, color1);//Activate the menu button in startup
            OpenChildForm(new DashboardMain()); //Activate the dashboard main windows

        }

        //Method
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton(); //Reset the previous button

                currentBtn = (IconButton)senderBtn; // Current button declared as the constructor variable

                //Button properties when pressed
                currentBtn.BackColor = Color.FromArgb(37, 36, 81); // Background color
                currentBtn.ForeColor = color; //Text color
                currentBtn.TextAlign = ContentAlignment.MiddleCenter; //Text alignment
                currentBtn.IconColor = color; //Icon color
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage; // Text before the image show
                currentBtn.ImageAlign = ContentAlignment.MiddleCenter; //Text alignment

                //Vertical lign properties when pressed
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y); // This will use the current position of the button y axis            
                leftBorderBtn.BringToFront();

                //Icon current panel title properties
                iconCurrentPaneltitle.IconChar = currentBtn.IconChar; //Icon in panel title will be the same as the current icon
                iconCurrentPaneltitle.IconColor = color; //Icon in panel title will be the same color

            }

        }

        //This method is when the reset the button properties
        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.White;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;

            }
        }

        private void OpenChildForm(Form childForm) //This method is only applicable in windows form
        {
            if (currentChildForm != null) //Condition for closing the previous panel
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm; //Make the current form the childform
            childForm.TopLevel = false; //Makes the form behave like a control, not a top-level window
            childForm.FormBorderStyle = FormBorderStyle.None; //Hides the title bar/borders to make it fit inside another panel.
            childForm.Dock = DockStyle.Fill; //Makes the form stretch to fill the entire container (panelDesktop).
            panelDesktop.Controls.Add(childForm); //Add the childform in the panelDekstop
            panelDesktop.Tag = childForm;
            childForm.Show(); //Display the form in the panel
            currentPaneltitle.Text = childForm.Text; //The title will be the same as the panel
        }


        private void menubtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, color1);
            OpenChildForm(new DashboardMain());
        }

        private void vidlibbtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, color2);
            OpenChildForm(new VideoLibrary());
        }


        private void usersbtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, color3);
            OpenChildForm(new Users());
        }

        private void reportbtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, color4);
            OpenChildForm(new Report());
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logoutbtn_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you want to logout ?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                this.Close();

                Login login = new Login();
                login.Show();
            }
        }

        
    }
}
