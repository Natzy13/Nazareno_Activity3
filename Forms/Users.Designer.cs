﻿namespace BogsySystem.Forms
{
    partial class Users
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dataGridUsers = new DataGridView();
            activatebtn = new FontAwesome.Sharp.IconButton();
            namelbl = new Label();
            nametxt = new TextBox();
            emaillbl = new Label();
            emailtxt = new TextBox();
            gendertxt = new ComboBox();
            genderlbl = new Label();
            editbtn = new FontAwesome.Sharp.IconButton();
            filter = new ComboBox();
            searchtxt = new TextBox();
            searchbtn = new FontAwesome.Sharp.IconButton();
            searchfilter = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridUsers).BeginInit();
            SuspendLayout();
            // 
            // dataGridUsers
            // 
            dataGridUsers.AllowUserToAddRows = false;
            dataGridUsers.AllowUserToDeleteRows = false;
            dataGridUsers.AllowUserToResizeColumns = false;
            dataGridUsers.AllowUserToResizeRows = false;
            dataGridUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(192, 192, 255);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridUsers.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridUsers.EnableHeadersVisualStyles = false;
            dataGridUsers.Location = new Point(28, 57);
            dataGridUsers.Name = "dataGridUsers";
            dataGridUsers.ReadOnly = true;
            dataGridUsers.RowHeadersVisible = false;
            dataGridUsers.ScrollBars = ScrollBars.Vertical;
            dataGridUsers.Size = new Size(945, 561);
            dataGridUsers.TabIndex = 0;
            dataGridUsers.CellClick += dataGridUsers_CellClick;
            dataGridUsers.CellDoubleClick += dataGridUsers_CellDoubleClick;
            dataGridUsers.Click += dataGridUsers_Click;
            // 
            // activatebtn
            // 
            activatebtn.BackColor = Color.Green;
            activatebtn.FlatAppearance.BorderSize = 0;
            activatebtn.FlatStyle = FlatStyle.Flat;
            activatebtn.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            activatebtn.ForeColor = Color.White;
            activatebtn.IconChar = FontAwesome.Sharp.IconChar.Unlock;
            activatebtn.IconColor = Color.White;
            activatebtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            activatebtn.IconSize = 20;
            activatebtn.ImageAlign = ContentAlignment.MiddleRight;
            activatebtn.Location = new Point(736, 650);
            activatebtn.Name = "activatebtn";
            activatebtn.Size = new Size(237, 31);
            activatebtn.TabIndex = 15;
            activatebtn.Text = "Activate";
            activatebtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            activatebtn.UseVisualStyleBackColor = false;
            activatebtn.Click += deactbtn_Click;
            // 
            // namelbl
            // 
            namelbl.AutoSize = true;
            namelbl.Font = new Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            namelbl.Location = new Point(27, 650);
            namelbl.Name = "namelbl";
            namelbl.Size = new Size(67, 23);
            namelbl.TabIndex = 17;
            namelbl.Text = "Name";
            // 
            // nametxt
            // 
            nametxt.Font = new Font("Century Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nametxt.Location = new Point(111, 648);
            nametxt.Name = "nametxt";
            nametxt.Size = new Size(351, 31);
            nametxt.TabIndex = 16;
            // 
            // emaillbl
            // 
            emaillbl.AutoSize = true;
            emaillbl.Font = new Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            emaillbl.Location = new Point(27, 693);
            emaillbl.Name = "emaillbl";
            emaillbl.Size = new Size(61, 23);
            emaillbl.TabIndex = 19;
            emaillbl.Text = "Email";
            // 
            // emailtxt
            // 
            emailtxt.Font = new Font("Century Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            emailtxt.Location = new Point(111, 691);
            emailtxt.Name = "emailtxt";
            emailtxt.Size = new Size(351, 31);
            emailtxt.TabIndex = 18;
            // 
            // gendertxt
            // 
            gendertxt.Font = new Font("Century Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gendertxt.FormattingEnabled = true;
            gendertxt.Items.AddRange(new object[] { "Male", "Female", "Others" });
            gendertxt.Location = new Point(493, 692);
            gendertxt.Name = "gendertxt";
            gendertxt.Size = new Size(166, 30);
            gendertxt.TabIndex = 21;
            gendertxt.Text = "Select Gender";
            // 
            // genderlbl
            // 
            genderlbl.AutoSize = true;
            genderlbl.Font = new Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            genderlbl.Location = new Point(493, 650);
            genderlbl.Name = "genderlbl";
            genderlbl.Size = new Size(80, 23);
            genderlbl.TabIndex = 20;
            genderlbl.Text = "Gender";
            // 
            // editbtn
            // 
            editbtn.BackColor = Color.Black;
            editbtn.FlatAppearance.BorderSize = 0;
            editbtn.FlatStyle = FlatStyle.Flat;
            editbtn.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            editbtn.ForeColor = Color.White;
            editbtn.IconChar = FontAwesome.Sharp.IconChar.Pen;
            editbtn.IconColor = Color.White;
            editbtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            editbtn.IconSize = 20;
            editbtn.ImageAlign = ContentAlignment.MiddleRight;
            editbtn.Location = new Point(736, 693);
            editbtn.Name = "editbtn";
            editbtn.Size = new Size(237, 31);
            editbtn.TabIndex = 22;
            editbtn.Text = "Edit";
            editbtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            editbtn.UseVisualStyleBackColor = false;
            editbtn.Click += editbtn_Click;
            // 
            // filter
            // 
            filter.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            filter.FormattingEnabled = true;
            filter.Items.AddRange(new object[] { "All", "Activated", "Deactivated", "Male", "Female" });
            filter.Location = new Point(30, 26);
            filter.Name = "filter";
            filter.Size = new Size(110, 25);
            filter.TabIndex = 23;
            filter.Text = "Filter";
            filter.SelectedIndexChanged += filter_SelectedIndexChanged;
            // 
            // searchtxt
            // 
            searchtxt.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchtxt.Location = new Point(668, 25);
            searchtxt.Name = "searchtxt";
            searchtxt.Size = new Size(271, 26);
            searchtxt.TabIndex = 24;
            // 
            // searchbtn
            // 
            searchbtn.BackColor = Color.Black;
            searchbtn.FlatAppearance.BorderSize = 0;
            searchbtn.FlatStyle = FlatStyle.Flat;
            searchbtn.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            searchbtn.ForeColor = Color.White;
            searchbtn.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlassPlus;
            searchbtn.IconColor = Color.White;
            searchbtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            searchbtn.IconSize = 19;
            searchbtn.Location = new Point(943, 25);
            searchbtn.Name = "searchbtn";
            searchbtn.Size = new Size(30, 26);
            searchbtn.TabIndex = 25;
            searchbtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            searchbtn.UseVisualStyleBackColor = false;
            searchbtn.Click += searchbtn_Click;
            // 
            // searchfilter
            // 
            searchfilter.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchfilter.FormattingEnabled = true;
            searchfilter.Items.AddRange(new object[] { "ID", "Name" });
            searchfilter.Location = new Point(594, 25);
            searchfilter.Name = "searchfilter";
            searchfilter.Size = new Size(65, 25);
            searchfilter.TabIndex = 26;
            searchfilter.Text = "Filter";
            // 
            // Users
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1001, 751);
            Controls.Add(searchfilter);
            Controls.Add(searchbtn);
            Controls.Add(searchtxt);
            Controls.Add(filter);
            Controls.Add(editbtn);
            Controls.Add(gendertxt);
            Controls.Add(genderlbl);
            Controls.Add(emaillbl);
            Controls.Add(emailtxt);
            Controls.Add(namelbl);
            Controls.Add(nametxt);
            Controls.Add(activatebtn);
            Controls.Add(dataGridUsers);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Users";
            Text = "Users";
            Load += Users_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridUsers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridUsers;
        private FontAwesome.Sharp.IconButton activatebtn;
        private Label namelbl;
        private TextBox nametxt;
        private Label emaillbl;
        private TextBox emailtxt;
        private ComboBox gendertxt;
        private Label genderlbl;
        private FontAwesome.Sharp.IconButton editbtn;
        private ComboBox filter;
        private TextBox searchtxt;
        private FontAwesome.Sharp.IconButton searchbtn;
        private ComboBox searchfilter;
    }
}