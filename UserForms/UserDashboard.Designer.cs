namespace BogsySystem.UserForms
{
    partial class UserDashboard
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
            menuPanel = new Panel();
            logoutbtn = new FontAwesome.Sharp.IconButton();
            reportbtn = new FontAwesome.Sharp.IconButton();
            accountbtn = new FontAwesome.Sharp.IconButton();
            paybtn = new FontAwesome.Sharp.IconButton();
            rentbtn = new FontAwesome.Sharp.IconButton();
            logoPanel = new Panel();
            pictureLogo = new PictureBox();
            panelTitle = new Panel();
            exitbtn = new Button();
            currentPaneltitle = new Label();
            iconCurrentPaneltitle = new FontAwesome.Sharp.IconPictureBox();
            panelDesktop = new Panel();
            menuPanel.SuspendLayout();
            logoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureLogo).BeginInit();
            panelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconCurrentPaneltitle).BeginInit();
            SuspendLayout();
            // 
            // menuPanel
            // 
            menuPanel.BackColor = Color.FromArgb(31, 30, 68);
            menuPanel.Controls.Add(logoutbtn);
            menuPanel.Controls.Add(reportbtn);
            menuPanel.Controls.Add(accountbtn);
            menuPanel.Controls.Add(paybtn);
            menuPanel.Controls.Add(rentbtn);
            menuPanel.Controls.Add(logoPanel);
            menuPanel.Dock = DockStyle.Left;
            menuPanel.Location = new Point(0, 0);
            menuPanel.Name = "menuPanel";
            menuPanel.Size = new Size(188, 800);
            menuPanel.TabIndex = 1;
            // 
            // logoutbtn
            // 
            logoutbtn.Dock = DockStyle.Bottom;
            logoutbtn.FlatAppearance.BorderSize = 0;
            logoutbtn.FlatStyle = FlatStyle.Flat;
            logoutbtn.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            logoutbtn.ForeColor = Color.Gainsboro;
            logoutbtn.IconChar = FontAwesome.Sharp.IconChar.RightToBracket;
            logoutbtn.IconColor = Color.White;
            logoutbtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            logoutbtn.IconSize = 30;
            logoutbtn.ImageAlign = ContentAlignment.MiddleLeft;
            logoutbtn.Location = new Point(0, 758);
            logoutbtn.Name = "logoutbtn";
            logoutbtn.Padding = new Padding(3, 0, 0, 0);
            logoutbtn.Size = new Size(188, 42);
            logoutbtn.TabIndex = 6;
            logoutbtn.Text = "Logout";
            logoutbtn.TextAlign = ContentAlignment.MiddleLeft;
            logoutbtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            logoutbtn.UseVisualStyleBackColor = true;
            logoutbtn.Click += iconButton1_Click;
            // 
            // reportbtn
            // 
            reportbtn.Dock = DockStyle.Top;
            reportbtn.FlatAppearance.BorderSize = 0;
            reportbtn.FlatStyle = FlatStyle.Flat;
            reportbtn.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            reportbtn.ForeColor = Color.Gainsboro;
            reportbtn.IconChar = FontAwesome.Sharp.IconChar.ChartSimple;
            reportbtn.IconColor = Color.White;
            reportbtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            reportbtn.IconSize = 30;
            reportbtn.ImageAlign = ContentAlignment.MiddleLeft;
            reportbtn.Location = new Point(0, 233);
            reportbtn.Name = "reportbtn";
            reportbtn.Padding = new Padding(3, 0, 0, 0);
            reportbtn.Size = new Size(188, 42);
            reportbtn.TabIndex = 5;
            reportbtn.Text = "Report";
            reportbtn.TextAlign = ContentAlignment.MiddleLeft;
            reportbtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            reportbtn.UseVisualStyleBackColor = true;
            reportbtn.Click += reportbtn_Click;
            // 
            // accountbtn
            // 
            accountbtn.Dock = DockStyle.Top;
            accountbtn.FlatAppearance.BorderSize = 0;
            accountbtn.FlatStyle = FlatStyle.Flat;
            accountbtn.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            accountbtn.ForeColor = Color.Gainsboro;
            accountbtn.IconChar = FontAwesome.Sharp.IconChar.User;
            accountbtn.IconColor = Color.White;
            accountbtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            accountbtn.IconSize = 30;
            accountbtn.ImageAlign = ContentAlignment.MiddleLeft;
            accountbtn.Location = new Point(0, 191);
            accountbtn.Name = "accountbtn";
            accountbtn.Padding = new Padding(3, 0, 0, 0);
            accountbtn.Size = new Size(188, 42);
            accountbtn.TabIndex = 4;
            accountbtn.Text = "Account";
            accountbtn.TextAlign = ContentAlignment.MiddleLeft;
            accountbtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            accountbtn.UseVisualStyleBackColor = true;
            accountbtn.Click += accountbtn_Click;
            // 
            // paybtn
            // 
            paybtn.Dock = DockStyle.Top;
            paybtn.FlatAppearance.BorderSize = 0;
            paybtn.FlatStyle = FlatStyle.Flat;
            paybtn.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            paybtn.ForeColor = Color.Gainsboro;
            paybtn.IconChar = FontAwesome.Sharp.IconChar.MoneyBillTransfer;
            paybtn.IconColor = Color.White;
            paybtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            paybtn.IconSize = 30;
            paybtn.ImageAlign = ContentAlignment.MiddleLeft;
            paybtn.Location = new Point(0, 149);
            paybtn.Name = "paybtn";
            paybtn.Padding = new Padding(3, 0, 0, 0);
            paybtn.Size = new Size(188, 42);
            paybtn.TabIndex = 3;
            paybtn.Text = "Return/Pay";
            paybtn.TextAlign = ContentAlignment.MiddleLeft;
            paybtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            paybtn.UseVisualStyleBackColor = true;
            paybtn.Click += paybtn_Click;
            // 
            // rentbtn
            // 
            rentbtn.Dock = DockStyle.Top;
            rentbtn.FlatAppearance.BorderSize = 0;
            rentbtn.FlatStyle = FlatStyle.Flat;
            rentbtn.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rentbtn.ForeColor = Color.Gainsboro;
            rentbtn.IconChar = FontAwesome.Sharp.IconChar.Film;
            rentbtn.IconColor = Color.White;
            rentbtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            rentbtn.IconSize = 30;
            rentbtn.ImageAlign = ContentAlignment.MiddleLeft;
            rentbtn.Location = new Point(0, 107);
            rentbtn.Name = "rentbtn";
            rentbtn.Padding = new Padding(3, 0, 0, 0);
            rentbtn.Size = new Size(188, 42);
            rentbtn.TabIndex = 1;
            rentbtn.Text = "Rent";
            rentbtn.TextAlign = ContentAlignment.MiddleLeft;
            rentbtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            rentbtn.UseVisualStyleBackColor = true;
            rentbtn.Click += rentbtn_Click;
            // 
            // logoPanel
            // 
            logoPanel.Controls.Add(pictureLogo);
            logoPanel.Dock = DockStyle.Top;
            logoPanel.Location = new Point(0, 0);
            logoPanel.Name = "logoPanel";
            logoPanel.Size = new Size(188, 107);
            logoPanel.TabIndex = 1;
            // 
            // pictureLogo
            // 
            pictureLogo.Dock = DockStyle.Fill;
            pictureLogo.Image = Properties.Resources.logo;
            pictureLogo.Location = new Point(0, 0);
            pictureLogo.Name = "pictureLogo";
            pictureLogo.Size = new Size(188, 107);
            pictureLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureLogo.TabIndex = 1;
            pictureLogo.TabStop = false;
            // 
            // panelTitle
            // 
            panelTitle.BackColor = Color.FromArgb(31, 30, 68);
            panelTitle.Controls.Add(exitbtn);
            panelTitle.Controls.Add(currentPaneltitle);
            panelTitle.Controls.Add(iconCurrentPaneltitle);
            panelTitle.Dock = DockStyle.Top;
            panelTitle.Location = new Point(188, 0);
            panelTitle.Name = "panelTitle";
            panelTitle.Size = new Size(1001, 49);
            panelTitle.TabIndex = 2;
            // 
            // exitbtn
            // 
            exitbtn.BackColor = Color.Transparent;
            exitbtn.FlatAppearance.BorderSize = 0;
            exitbtn.FlatStyle = FlatStyle.Flat;
            exitbtn.Font = new Font("Century Gothic", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            exitbtn.ForeColor = Color.Red;
            exitbtn.Location = new Point(979, 0);
            exitbtn.Name = "exitbtn";
            exitbtn.Size = new Size(22, 22);
            exitbtn.TabIndex = 0;
            exitbtn.Text = "X";
            exitbtn.UseVisualStyleBackColor = false;
            exitbtn.Click += exitbtn_Click;
            // 
            // currentPaneltitle
            // 
            currentPaneltitle.AutoSize = true;
            currentPaneltitle.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            currentPaneltitle.ForeColor = Color.Gainsboro;
            currentPaneltitle.Location = new Point(51, 17);
            currentPaneltitle.Name = "currentPaneltitle";
            currentPaneltitle.Size = new Size(37, 17);
            currentPaneltitle.TabIndex = 1;
            currentPaneltitle.Text = "Rent";
            // 
            // iconCurrentPaneltitle
            // 
            iconCurrentPaneltitle.BackColor = Color.FromArgb(31, 30, 68);
            iconCurrentPaneltitle.ForeColor = Color.FromArgb(172, 126, 241);
            iconCurrentPaneltitle.IconChar = FontAwesome.Sharp.IconChar.Film;
            iconCurrentPaneltitle.IconColor = Color.FromArgb(172, 126, 241);
            iconCurrentPaneltitle.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconCurrentPaneltitle.IconSize = 25;
            iconCurrentPaneltitle.Location = new Point(19, 12);
            iconCurrentPaneltitle.Name = "iconCurrentPaneltitle";
            iconCurrentPaneltitle.Size = new Size(25, 25);
            iconCurrentPaneltitle.TabIndex = 0;
            iconCurrentPaneltitle.TabStop = false;
            // 
            // panelDesktop
            // 
            panelDesktop.BackColor = Color.FromArgb(31, 30, 68);
            panelDesktop.Dock = DockStyle.Fill;
            panelDesktop.Location = new Point(188, 49);
            panelDesktop.Name = "panelDesktop";
            panelDesktop.Size = new Size(1001, 751);
            panelDesktop.TabIndex = 3;
            // 
            // UserDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1189, 800);
            Controls.Add(panelDesktop);
            Controls.Add(panelTitle);
            Controls.Add(menuPanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "UserDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UserDashboard";
            menuPanel.ResumeLayout(false);
            logoPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureLogo).EndInit();
            panelTitle.ResumeLayout(false);
            panelTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconCurrentPaneltitle).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel menuPanel;
        private FontAwesome.Sharp.IconButton accountbtn;
        private FontAwesome.Sharp.IconButton paybtn;
        private FontAwesome.Sharp.IconButton rentbtn;
        private Panel logoPanel;
        private PictureBox pictureLogo;
        private Panel panelTitle;
        private Button exitbtn;
        private Label currentPaneltitle;
        private FontAwesome.Sharp.IconPictureBox iconCurrentPaneltitle;
        private Panel panelDesktop;
        private FontAwesome.Sharp.IconButton reportbtn;
        private FontAwesome.Sharp.IconButton logoutbtn;
    }
}