namespace BogsySystem.Forms
{
    partial class Login
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
            labeltop = new Label();
            unamelbl = new Label();
            passlbl = new Label();
            unamelogintxt = new TextBox();
            passlogintxt = new TextBox();
            loginbtn = new Button();
            label1 = new Label();
            exitbtn = new Button();
            hidepassbtn = new FontAwesome.Sharp.IconButton();
            showpassbtn = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)loginlogo).BeginInit();
            SuspendLayout();
            // 
            // loginlogo
            // 
            loginlogo.Image = Properties.Resources.logo;
            loginlogo.Location = new Point(72, 41);
            loginlogo.Name = "loginlogo";
            loginlogo.Size = new Size(198, 99);
            loginlogo.SizeMode = PictureBoxSizeMode.Zoom;
            loginlogo.TabIndex = 1;
            loginlogo.TabStop = false;
            // 
            // labeltop
            // 
            labeltop.AutoSize = true;
            labeltop.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labeltop.ForeColor = Color.Gainsboro;
            labeltop.Location = new Point(146, 9);
            labeltop.Name = "labeltop";
            labeltop.Size = new Size(51, 19);
            labeltop.TabIndex = 11;
            labeltop.Text = "Login";
            // 
            // unamelbl
            // 
            unamelbl.AutoSize = true;
            unamelbl.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            unamelbl.ForeColor = Color.Gainsboro;
            unamelbl.Location = new Point(43, 172);
            unamelbl.Name = "unamelbl";
            unamelbl.Size = new Size(82, 18);
            unamelbl.TabIndex = 12;
            unamelbl.Text = "Username";
            // 
            // passlbl
            // 
            passlbl.AutoSize = true;
            passlbl.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            passlbl.ForeColor = Color.Gainsboro;
            passlbl.Location = new Point(43, 241);
            passlbl.Name = "passlbl";
            passlbl.Size = new Size(75, 18);
            passlbl.TabIndex = 13;
            passlbl.Text = "Password";
            // 
            // unamelogintxt
            // 
            unamelogintxt.BackColor = Color.White;
            unamelogintxt.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            unamelogintxt.Location = new Point(43, 196);
            unamelogintxt.Name = "unamelogintxt";
            unamelogintxt.Size = new Size(265, 27);
            unamelogintxt.TabIndex = 14;
            // 
            // passlogintxt
            // 
            passlogintxt.BackColor = Color.White;
            passlogintxt.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            passlogintxt.Location = new Point(43, 262);
            passlogintxt.Name = "passlogintxt";
            passlogintxt.PasswordChar = '*';
            passlogintxt.Size = new Size(265, 27);
            passlogintxt.TabIndex = 15;
            // 
            // loginbtn
            // 
            loginbtn.BackColor = Color.Black;
            loginbtn.FlatAppearance.BorderSize = 0;
            loginbtn.FlatStyle = FlatStyle.Flat;
            loginbtn.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            loginbtn.ForeColor = Color.White;
            loginbtn.Location = new Point(134, 308);
            loginbtn.Name = "loginbtn";
            loginbtn.Size = new Size(75, 30);
            loginbtn.TabIndex = 16;
            loginbtn.Text = "Login";
            loginbtn.UseVisualStyleBackColor = false;
            loginbtn.Click += loginbtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 9F, FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Gainsboro;
            label1.Location = new Point(56, 344);
            label1.Name = "label1";
            label1.Size = new Size(231, 16);
            label1.TabIndex = 17;
            label1.Text = "Don't have an account? Register here";
            label1.Click += label1_Click;
            // 
            // exitbtn
            // 
            exitbtn.BackColor = Color.Transparent;
            exitbtn.FlatAppearance.BorderSize = 0;
            exitbtn.FlatStyle = FlatStyle.Flat;
            exitbtn.Font = new Font("Century Gothic", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            exitbtn.ForeColor = Color.Red;
            exitbtn.Location = new Point(319, 2);
            exitbtn.Name = "exitbtn";
            exitbtn.Size = new Size(22, 22);
            exitbtn.TabIndex = 18;
            exitbtn.Text = "X";
            exitbtn.UseVisualStyleBackColor = false;
            exitbtn.Click += exitbtn_Click;
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
            hidepassbtn.Location = new Point(268, 262);
            hidepassbtn.Name = "hidepassbtn";
            hidepassbtn.Size = new Size(40, 27);
            hidepassbtn.TabIndex = 19;
            hidepassbtn.UseVisualStyleBackColor = false;
            hidepassbtn.Click += hidepassbtn_Click;
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
            showpassbtn.Location = new Point(268, 262);
            showpassbtn.Name = "showpassbtn";
            showpassbtn.Size = new Size(40, 27);
            showpassbtn.TabIndex = 20;
            showpassbtn.UseVisualStyleBackColor = false;
            showpassbtn.Click += showpassbtn_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(31, 30, 68);
            ClientSize = new Size(343, 378);
            Controls.Add(showpassbtn);
            Controls.Add(hidepassbtn);
            Controls.Add(exitbtn);
            Controls.Add(label1);
            Controls.Add(loginbtn);
            Controls.Add(passlogintxt);
            Controls.Add(unamelogintxt);
            Controls.Add(passlbl);
            Controls.Add(unamelbl);
            Controls.Add(labeltop);
            Controls.Add(loginlogo);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)loginlogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox loginlogo;
        private Label labeltop;
        private Label unamelbl;
        private Label passlbl;
        private TextBox unamelogintxt;
        private TextBox passlogintxt;
        private Button loginbtn;
        private Label label1;
        private Button exitbtn;
        private FontAwesome.Sharp.IconButton hidepassbtn;
        private FontAwesome.Sharp.IconButton showpassbtn;
    }
}