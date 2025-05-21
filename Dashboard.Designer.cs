using FontAwesome.Sharp;

namespace BogsySystem
{
    partial class Dashboard
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuPanel = new Panel();
            userreportbtn = new IconButton();
            logoutbtn = new IconButton();
            reportbtn = new IconButton();
            usersbtn = new IconButton();
            vidlibbtn = new IconButton();
            menubtn = new IconButton();
            logoPanel = new Panel();
            pictureLogo = new PictureBox();
            panelTitle = new Panel();
            exitbtn = new Button();
            currentPaneltitle = new Label();
            iconCurrentPaneltitle = new IconPictureBox();
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
            menuPanel.Controls.Add(userreportbtn);
            menuPanel.Controls.Add(logoutbtn);
            menuPanel.Controls.Add(reportbtn);
            menuPanel.Controls.Add(usersbtn);
            menuPanel.Controls.Add(vidlibbtn);
            menuPanel.Controls.Add(menubtn);
            menuPanel.Controls.Add(logoPanel);
            menuPanel.Dock = DockStyle.Left;
            menuPanel.Location = new Point(0, 0);
            menuPanel.Name = "menuPanel";
            menuPanel.Size = new Size(188, 800);
            menuPanel.TabIndex = 0;
            // 
            // userreportbtn
            // 
            userreportbtn.Dock = DockStyle.Top;
            userreportbtn.FlatAppearance.BorderSize = 0;
            userreportbtn.FlatStyle = FlatStyle.Flat;
            userreportbtn.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            userreportbtn.ForeColor = Color.Gainsboro;
            userreportbtn.IconChar = IconChar.ChartSimple;
            userreportbtn.IconColor = Color.White;
            userreportbtn.IconFont = IconFont.Auto;
            userreportbtn.IconSize = 30;
            userreportbtn.ImageAlign = ContentAlignment.MiddleLeft;
            userreportbtn.Location = new Point(0, 275);
            userreportbtn.Name = "userreportbtn";
            userreportbtn.Padding = new Padding(3, 0, 0, 0);
            userreportbtn.Size = new Size(188, 42);
            userreportbtn.TabIndex = 6;
            userreportbtn.Text = "User Report";
            userreportbtn.TextAlign = ContentAlignment.MiddleLeft;
            userreportbtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            userreportbtn.UseVisualStyleBackColor = true;
            userreportbtn.Click += userreportbtn_Click;
            // 
            // logoutbtn
            // 
            logoutbtn.Dock = DockStyle.Bottom;
            logoutbtn.FlatAppearance.BorderSize = 0;
            logoutbtn.FlatStyle = FlatStyle.Flat;
            logoutbtn.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            logoutbtn.ForeColor = Color.Gainsboro;
            logoutbtn.IconChar = IconChar.RightToBracket;
            logoutbtn.IconColor = Color.White;
            logoutbtn.IconFont = IconFont.Auto;
            logoutbtn.IconSize = 30;
            logoutbtn.ImageAlign = ContentAlignment.MiddleLeft;
            logoutbtn.Location = new Point(0, 758);
            logoutbtn.Name = "logoutbtn";
            logoutbtn.Padding = new Padding(3, 0, 0, 0);
            logoutbtn.Size = new Size(188, 42);
            logoutbtn.TabIndex = 5;
            logoutbtn.Text = "Logout";
            logoutbtn.TextAlign = ContentAlignment.MiddleLeft;
            logoutbtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            logoutbtn.UseVisualStyleBackColor = true;
            logoutbtn.Click += logoutbtn_Click;
            // 
            // reportbtn
            // 
            reportbtn.Dock = DockStyle.Top;
            reportbtn.FlatAppearance.BorderSize = 0;
            reportbtn.FlatStyle = FlatStyle.Flat;
            reportbtn.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            reportbtn.ForeColor = Color.Gainsboro;
            reportbtn.IconChar = IconChar.ChartSimple;
            reportbtn.IconColor = Color.White;
            reportbtn.IconFont = IconFont.Auto;
            reportbtn.IconSize = 30;
            reportbtn.ImageAlign = ContentAlignment.MiddleLeft;
            reportbtn.Location = new Point(0, 233);
            reportbtn.Name = "reportbtn";
            reportbtn.Padding = new Padding(3, 0, 0, 0);
            reportbtn.Size = new Size(188, 42);
            reportbtn.TabIndex = 4;
            reportbtn.Text = "Video Report";
            reportbtn.TextAlign = ContentAlignment.MiddleLeft;
            reportbtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            reportbtn.UseVisualStyleBackColor = true;
            reportbtn.Click += reportbtn_Click;
            // 
            // usersbtn
            // 
            usersbtn.Dock = DockStyle.Top;
            usersbtn.FlatAppearance.BorderSize = 0;
            usersbtn.FlatStyle = FlatStyle.Flat;
            usersbtn.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            usersbtn.ForeColor = Color.Gainsboro;
            usersbtn.IconChar = IconChar.Users;
            usersbtn.IconColor = Color.White;
            usersbtn.IconFont = IconFont.Auto;
            usersbtn.IconSize = 30;
            usersbtn.ImageAlign = ContentAlignment.MiddleLeft;
            usersbtn.Location = new Point(0, 191);
            usersbtn.Name = "usersbtn";
            usersbtn.Padding = new Padding(3, 0, 0, 0);
            usersbtn.Size = new Size(188, 42);
            usersbtn.TabIndex = 3;
            usersbtn.Text = "Users";
            usersbtn.TextAlign = ContentAlignment.MiddleLeft;
            usersbtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            usersbtn.UseVisualStyleBackColor = true;
            usersbtn.Click += usersbtn_Click;
            // 
            // vidlibbtn
            // 
            vidlibbtn.Dock = DockStyle.Top;
            vidlibbtn.FlatAppearance.BorderSize = 0;
            vidlibbtn.FlatStyle = FlatStyle.Flat;
            vidlibbtn.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            vidlibbtn.ForeColor = Color.Gainsboro;
            vidlibbtn.IconChar = IconChar.Film;
            vidlibbtn.IconColor = Color.White;
            vidlibbtn.IconFont = IconFont.Auto;
            vidlibbtn.IconSize = 30;
            vidlibbtn.ImageAlign = ContentAlignment.MiddleLeft;
            vidlibbtn.Location = new Point(0, 149);
            vidlibbtn.Name = "vidlibbtn";
            vidlibbtn.Padding = new Padding(3, 0, 0, 0);
            vidlibbtn.Size = new Size(188, 42);
            vidlibbtn.TabIndex = 2;
            vidlibbtn.Text = "Video Library";
            vidlibbtn.TextAlign = ContentAlignment.MiddleLeft;
            vidlibbtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            vidlibbtn.UseVisualStyleBackColor = true;
            vidlibbtn.Click += vidlibbtn_Click;
            // 
            // menubtn
            // 
            menubtn.Dock = DockStyle.Top;
            menubtn.FlatAppearance.BorderSize = 0;
            menubtn.FlatStyle = FlatStyle.Flat;
            menubtn.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menubtn.ForeColor = Color.Gainsboro;
            menubtn.IconChar = IconChar.House;
            menubtn.IconColor = Color.White;
            menubtn.IconFont = IconFont.Auto;
            menubtn.IconSize = 30;
            menubtn.ImageAlign = ContentAlignment.MiddleLeft;
            menubtn.Location = new Point(0, 107);
            menubtn.Name = "menubtn";
            menubtn.Padding = new Padding(3, 0, 0, 0);
            menubtn.Size = new Size(188, 42);
            menubtn.TabIndex = 1;
            menubtn.Text = "Menu";
            menubtn.TextAlign = ContentAlignment.MiddleLeft;
            menubtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            menubtn.UseVisualStyleBackColor = true;
            menubtn.Click += menubtn_Click;
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
            panelTitle.TabIndex = 1;
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
            exitbtn.Click += button1_Click;
            // 
            // currentPaneltitle
            // 
            currentPaneltitle.AutoSize = true;
            currentPaneltitle.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            currentPaneltitle.ForeColor = Color.Gainsboro;
            currentPaneltitle.Location = new Point(51, 17);
            currentPaneltitle.Name = "currentPaneltitle";
            currentPaneltitle.Size = new Size(43, 17);
            currentPaneltitle.TabIndex = 1;
            currentPaneltitle.Text = "Menu";
            // 
            // iconCurrentPaneltitle
            // 
            iconCurrentPaneltitle.BackColor = Color.FromArgb(31, 30, 68);
            iconCurrentPaneltitle.ForeColor = Color.FromArgb(172, 126, 241);
            iconCurrentPaneltitle.IconChar = IconChar.House;
            iconCurrentPaneltitle.IconColor = Color.FromArgb(172, 126, 241);
            iconCurrentPaneltitle.IconFont = IconFont.Auto;
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
            panelDesktop.TabIndex = 2;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1189, 800);
            Controls.Add(panelDesktop);
            Controls.Add(panelTitle);
            Controls.Add(menuPanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Dashboard";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
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
        private Panel logoPanel;
        private FontAwesome.Sharp.IconButton menubtn;
        private FontAwesome.Sharp.IconButton usersbtn;
        private FontAwesome.Sharp.IconButton vidlibbtn;
        private FontAwesome.Sharp.IconButton reportbtn;
        private PictureBox pictureLogo;
        private Panel panelTitle;
        private IconPictureBox iconCurrentPaneltitle;
        private Label currentPaneltitle;
        private Panel panelDesktop;
        private Button exitbtn;
        private IconButton logoutbtn;
        private IconButton userreportbtn;
    }
}
