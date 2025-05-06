namespace BogsySystem.Forms
{
    partial class SignUp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            loginlogo = new PictureBox();
            fnamelbl = new Label();
            unamelbl = new Label();
            passlbl = new Label();
            emaillbl = new Label();
            genderlbl = new Label();
            fnameregtxt = new TextBox();
            unameregtxt = new TextBox();
            passregtxt = new TextBox();
            emailregtxt = new TextBox();
            labeltop = new Label();
            genderregtxt = new ComboBox();
            regbtn = new FontAwesome.Sharp.IconButton();
            label1 = new Label();
            exitbtn = new Button();
            showpassbtn = new FontAwesome.Sharp.IconButton();
            hidepassbtn = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)loginlogo).BeginInit();
            SuspendLayout();
            // 
            // loginlogo
            // 
            loginlogo.Image = BogsySystem.Properties.Resources.logo;
            loginlogo.Location = new Point(126, 41);
            loginlogo.Name = "loginlogo";
            loginlogo.Size = new Size(198, 99);
            loginlogo.SizeMode = PictureBoxSizeMode.Zoom;
            loginlogo.TabIndex = 0;
            loginlogo.TabStop = false;
            // 
            // fnamelbl
            // 
            fnamelbl.AutoSize = true;
            fnamelbl.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            fnamelbl.ForeColor = Color.Gainsboro;
            fnamelbl.Location = new Point(33, 173);
            fnamelbl.Name = "fnamelbl";
            fnamelbl.Size = new Size(96, 19);
            fnamelbl.TabIndex = 1;
            fnamelbl.Text = "Full Name :";
            // 
            // unamelbl
            // 
            unamelbl.AutoSize = true;
            unamelbl.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            unamelbl.ForeColor = Color.Gainsboro;
            unamelbl.Location = new Point(34, 216);
            unamelbl.Name = "unamelbl";
            unamelbl.Size = new Size(95, 19);
            unamelbl.TabIndex = 2;
            unamelbl.Text = "Username :";
            // 
            // passlbl
            // 
            passlbl.AutoSize = true;
            passlbl.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            passlbl.ForeColor = Color.Gainsboro;
            passlbl.Location = new Point(41, 259);
            passlbl.Name = "passlbl";
            passlbl.Size = new Size(88, 19);
            passlbl.TabIndex = 3;
            passlbl.Text = "Password :";
            // 
            // emaillbl
            // 
            emaillbl.AutoSize = true;
            emaillbl.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            emaillbl.ForeColor = Color.Gainsboro;
            emaillbl.Location = new Point(69, 302);
            emaillbl.Name = "emaillbl";
            emaillbl.Size = new Size(60, 19);
            emaillbl.TabIndex = 4;
            emaillbl.Text = "Email :";
            // 
            // genderlbl
            // 
            genderlbl.AutoSize = true;
            genderlbl.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            genderlbl.ForeColor = Color.Gainsboro;
            genderlbl.Location = new Point(53, 345);
            genderlbl.Name = "genderlbl";
            genderlbl.Size = new Size(76, 19);
            genderlbl.TabIndex = 5;
            genderlbl.Text = "Gender :";
            // 
            // fnameregtxt
            // 
            fnameregtxt.BackColor = Color.White;
            fnameregtxt.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            fnameregtxt.Location = new Point(148, 169);
            fnameregtxt.Name = "fnameregtxt";
            fnameregtxt.Size = new Size(265, 27);
            fnameregtxt.TabIndex = 6;
            // 
            // unameregtxt
            // 
            unameregtxt.BackColor = Color.White;
            unameregtxt.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            unameregtxt.Location = new Point(148, 212);
            unameregtxt.Name = "unameregtxt";
            unameregtxt.Size = new Size(265, 27);
            unameregtxt.TabIndex = 7;
            // 
            // passregtxt
            // 
            passregtxt.BackColor = Color.White;
            passregtxt.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            passregtxt.Location = new Point(148, 255);
            passregtxt.Name = "passregtxt";
            passregtxt.PasswordChar = '*';
            passregtxt.Size = new Size(265, 27);
            passregtxt.TabIndex = 8;
            // 
            // emailregtxt
            // 
            emailregtxt.BackColor = Color.White;
            emailregtxt.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            emailregtxt.Location = new Point(148, 298);
            emailregtxt.Name = "emailregtxt";
            emailregtxt.Size = new Size(265, 27);
            emailregtxt.TabIndex = 9;
            // 
            // labeltop
            // 
            labeltop.AutoSize = true;
            labeltop.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labeltop.ForeColor = Color.Gainsboro;
            labeltop.Location = new Point(159, 10);
            labeltop.Name = "labeltop";
            labeltop.Size = new Size(131, 19);
            labeltop.TabIndex = 10;
            labeltop.Text = "Create Account";
            // 
            // genderregtxt
            // 
            genderregtxt.BackColor = Color.White;
            genderregtxt.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            genderregtxt.FormattingEnabled = true;
            genderregtxt.Items.AddRange(new object[] { "Male ", "Female", "Others" });
            genderregtxt.Location = new Point(148, 341);
            genderregtxt.Name = "genderregtxt";
            genderregtxt.Size = new Size(265, 29);
            genderregtxt.TabIndex = 11;
            genderregtxt.Text = "Select Gender";
            // 
            // regbtn
            // 
            regbtn.BackColor = Color.Black;
            regbtn.FlatAppearance.BorderSize = 0;
            regbtn.FlatStyle = FlatStyle.Flat;
            regbtn.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            regbtn.ForeColor = Color.FromArgb(224, 224, 224);
            regbtn.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            regbtn.IconColor = Color.Snow;
            regbtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            regbtn.IconSize = 20;
            regbtn.Location = new Point(323, 386);
            regbtn.Name = "regbtn";
            regbtn.Size = new Size(90, 29);
            regbtn.TabIndex = 12;
            regbtn.Text = "Create";
            regbtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            regbtn.UseVisualStyleBackColor = false;
            regbtn.Click += regbtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 9F, FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Gainsboro;
            label1.Location = new Point(69, 399);
            label1.Name = "label1";
            label1.Size = new Size(229, 16);
            label1.TabIndex = 13;
            label1.Text = "Already have an account? Login here";
            label1.Click += label1_Click;
            // 
            // exitbtn
            // 
            exitbtn.BackColor = Color.Transparent;
            exitbtn.FlatAppearance.BorderSize = 0;
            exitbtn.FlatStyle = FlatStyle.Flat;
            exitbtn.Font = new Font("Century Gothic", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            exitbtn.ForeColor = Color.Red;
            exitbtn.Location = new Point(426, 1);
            exitbtn.Name = "exitbtn";
            exitbtn.Size = new Size(22, 22);
            exitbtn.TabIndex = 14;
            exitbtn.Text = "X";
            exitbtn.UseVisualStyleBackColor = false;
            exitbtn.Click += exitbtn_Click;
            // 
            // showpassbtn
            // 
            showpassbtn.BackColor = Color.White;
            showpassbtn.FlatAppearance.BorderSize = 0;
            showpassbtn.FlatStyle = FlatStyle.Popup;
            showpassbtn.ForeColor = Color.Black;
            showpassbtn.IconChar = FontAwesome.Sharp.IconChar.Eye;
            showpassbtn.IconColor = Color.FromArgb(31, 30, 68);
            showpassbtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            showpassbtn.IconSize = 35;
            showpassbtn.Location = new Point(373, 255);
            showpassbtn.Name = "showpassbtn";
            showpassbtn.Size = new Size(40, 27);
            showpassbtn.TabIndex = 15;
            showpassbtn.UseVisualStyleBackColor = false;
            showpassbtn.Click += showpassbtn_Click;
            // 
            // hidepassbtn
            // 
            hidepassbtn.BackColor = Color.White;
            hidepassbtn.FlatAppearance.BorderSize = 0;
            hidepassbtn.FlatStyle = FlatStyle.Popup;
            hidepassbtn.ForeColor = Color.Black;
            hidepassbtn.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            hidepassbtn.IconColor = Color.FromArgb(31, 30, 68);
            hidepassbtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            hidepassbtn.IconSize = 35;
            hidepassbtn.Location = new Point(373, 255);
            hidepassbtn.Name = "hidepassbtn";
            hidepassbtn.Size = new Size(40, 27);
            hidepassbtn.TabIndex = 16;
            hidepassbtn.UseVisualStyleBackColor = false;
            hidepassbtn.Click += hidepassbtn_Click;
            // 
            // SignUp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(31, 30, 68);
            ClientSize = new Size(450, 434);
            Controls.Add(showpassbtn);
            Controls.Add(genderregtxt);
            Controls.Add(emailregtxt);
            Controls.Add(unameregtxt);
            Controls.Add(fnameregtxt);
            Controls.Add(exitbtn);
            Controls.Add(label1);
            Controls.Add(regbtn);
            Controls.Add(labeltop);
            Controls.Add(genderlbl);
            Controls.Add(emaillbl);
            Controls.Add(passlbl);
            Controls.Add(unamelbl);
            Controls.Add(fnamelbl);
            Controls.Add(loginlogo);
            Controls.Add(hidepassbtn);
            Controls.Add(passregtxt);
            ForeColor = Color.FromArgb(255, 128, 128);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SignUp";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SignUp";
            ((System.ComponentModel.ISupportInitialize)loginlogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox loginlogo;
        private Label fnamelbl;
        private Label unamelbl;
        private Label passlbl;
        private Label emaillbl;
        private Label genderlbl;
        private TextBox fnameregtxt;
        private TextBox unameregtxt;
        private TextBox passregtxt;
        private TextBox emailregtxt;
        private Label labeltop;
        private ComboBox genderregtxt;
        private FontAwesome.Sharp.IconButton regbtn;
        private Label label1;
        private Button exitbtn;
        private FontAwesome.Sharp.IconButton showpassbtn;
        private FontAwesome.Sharp.IconButton hidepassbtn;
    }
}