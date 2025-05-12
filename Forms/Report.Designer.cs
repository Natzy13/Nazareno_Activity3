namespace BogsySystem.Forms
{
    partial class Report
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
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            dataGridReport = new DataGridView();
            dataGridUsers = new DataGridView();
            dataGridUserRented = new DataGridView();
            activerentlbl = new Label();
            backlbl = new Label();
            searchfilter = new ComboBox();
            searchbtn = new FontAwesome.Sharp.IconButton();
            searchtxt = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridReport).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridUsers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridUserRented).BeginInit();
            SuspendLayout();
            // 
            // dataGridReport
            // 
            dataGridReport.AllowUserToAddRows = false;
            dataGridReport.AllowUserToDeleteRows = false;
            dataGridReport.AllowUserToResizeColumns = false;
            dataGridReport.AllowUserToResizeRows = false;
            dataGridReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridReport.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridReport.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = SystemColors.ActiveCaptionText;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle7.ForeColor = Color.White;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dataGridReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.White;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle8.ForeColor = Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = Color.White;
            dataGridViewCellStyle8.SelectionForeColor = Color.Black;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            dataGridReport.DefaultCellStyle = dataGridViewCellStyle8;
            dataGridReport.EnableHeadersVisualStyles = false;
            dataGridReport.Location = new Point(27, 26);
            dataGridReport.Name = "dataGridReport";
            dataGridReport.ReadOnly = true;
            dataGridReport.RowHeadersVisible = false;
            dataGridReport.ScrollBars = ScrollBars.Vertical;
            dataGridReport.Size = new Size(558, 179);
            dataGridReport.TabIndex = 2;
            // 
            // dataGridUsers
            // 
            dataGridUsers.AllowUserToAddRows = false;
            dataGridUsers.AllowUserToDeleteRows = false;
            dataGridUsers.AllowUserToResizeColumns = false;
            dataGridUsers.AllowUserToResizeRows = false;
            dataGridUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridUsers.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridUsers.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = SystemColors.ActiveCaptionText;
            dataGridViewCellStyle9.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle9.ForeColor = Color.White;
            dataGridViewCellStyle9.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
            dataGridUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dataGridUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = Color.White;
            dataGridViewCellStyle10.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle10.ForeColor = Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = Color.FromArgb(192, 192, 255);
            dataGridViewCellStyle10.SelectionForeColor = Color.Black;
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.True;
            dataGridUsers.DefaultCellStyle = dataGridViewCellStyle10;
            dataGridUsers.EnableHeadersVisualStyles = false;
            dataGridUsers.Location = new Point(27, 254);
            dataGridUsers.Name = "dataGridUsers";
            dataGridUsers.ReadOnly = true;
            dataGridUsers.RowHeadersVisible = false;
            dataGridUsers.ScrollBars = ScrollBars.Vertical;
            dataGridUsers.Size = new Size(275, 125);
            dataGridUsers.TabIndex = 3;
            dataGridUsers.CellClick += dataGridUsers_CellClick;
            dataGridUsers.Click += dataGridUsers_Click;
            // 
            // dataGridUserRented
            // 
            dataGridUserRented.AllowUserToAddRows = false;
            dataGridUserRented.AllowUserToDeleteRows = false;
            dataGridUserRented.AllowUserToResizeColumns = false;
            dataGridUserRented.AllowUserToResizeRows = false;
            dataGridUserRented.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridUserRented.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridUserRented.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = SystemColors.ActiveCaptionText;
            dataGridViewCellStyle11.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle11.ForeColor = Color.White;
            dataGridViewCellStyle11.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = DataGridViewTriState.True;
            dataGridUserRented.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            dataGridUserRented.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = Color.White;
            dataGridViewCellStyle12.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle12.ForeColor = Color.Black;
            dataGridViewCellStyle12.SelectionBackColor = Color.White;
            dataGridViewCellStyle12.SelectionForeColor = Color.Black;
            dataGridViewCellStyle12.WrapMode = DataGridViewTriState.True;
            dataGridUserRented.DefaultCellStyle = dataGridViewCellStyle12;
            dataGridUserRented.EnableHeadersVisualStyles = false;
            dataGridUserRented.Location = new Point(310, 243);
            dataGridUserRented.Name = "dataGridUserRented";
            dataGridUserRented.ReadOnly = true;
            dataGridUserRented.RowHeadersVisible = false;
            dataGridUserRented.ScrollBars = ScrollBars.Vertical;
            dataGridUserRented.Size = new Size(275, 136);
            dataGridUserRented.TabIndex = 4;
            // 
            // activerentlbl
            // 
            activerentlbl.AutoSize = true;
            activerentlbl.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            activerentlbl.Location = new Point(310, 222);
            activerentlbl.Name = "activerentlbl";
            activerentlbl.Size = new Size(201, 18);
            activerentlbl.TabIndex = 13;
            activerentlbl.Text = "User Active Rented Media";
            // 
            // backlbl
            // 
            backlbl.AutoSize = true;
            backlbl.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            backlbl.Location = new Point(354, 304);
            backlbl.Name = "backlbl";
            backlbl.Size = new Size(190, 21);
            backlbl.TabIndex = 22;
            backlbl.Text = "Select a user to display ";
            // 
            // searchfilter
            // 
            searchfilter.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchfilter.FormattingEnabled = true;
            searchfilter.Items.AddRange(new object[] { "ID", "Name" });
            searchfilter.Location = new Point(27, 222);
            searchfilter.Name = "searchfilter";
            searchfilter.Size = new Size(65, 25);
            searchfilter.TabIndex = 32;
            searchfilter.Text = "Filter";
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
            searchbtn.Location = new Point(271, 222);
            searchbtn.Name = "searchbtn";
            searchbtn.Size = new Size(30, 26);
            searchbtn.TabIndex = 31;
            searchbtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            searchbtn.UseVisualStyleBackColor = false;
            searchbtn.Click += searchbtn_Click;
            // 
            // searchtxt
            // 
            searchtxt.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchtxt.Location = new Point(98, 222);
            searchtxt.Name = "searchtxt";
            searchtxt.PlaceholderText = "Type \"all\" to show all";
            searchtxt.Size = new Size(167, 26);
            searchtxt.TabIndex = 30;
            // 
            // Report
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(612, 401);
            Controls.Add(searchfilter);
            Controls.Add(searchbtn);
            Controls.Add(searchtxt);
            Controls.Add(activerentlbl);
            Controls.Add(dataGridUserRented);
            Controls.Add(dataGridUsers);
            Controls.Add(dataGridReport);
            Controls.Add(backlbl);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Report";
            Text = "Report";
            Load += Report_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridReport).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridUsers).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridUserRented).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridReport;
        private DataGridView dataGridUsers;
        private DataGridView dataGridUserRented;
        private Label activerentlbl;
        private Label backlbl;
        private ComboBox searchfilter;
        private FontAwesome.Sharp.IconButton searchbtn;
        private TextBox searchtxt;
    }
}