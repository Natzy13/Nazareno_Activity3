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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dataGridReport = new DataGridView();
            searchbtn = new FontAwesome.Sharp.IconButton();
            searchtxt = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridReport).BeginInit();
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
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.White;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridReport.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridReport.EnableHeadersVisualStyles = false;
            dataGridReport.Location = new Point(28, 57);
            dataGridReport.Name = "dataGridReport";
            dataGridReport.ReadOnly = true;
            dataGridReport.RowHeadersVisible = false;
            dataGridReport.ScrollBars = ScrollBars.Vertical;
            dataGridReport.Size = new Size(945, 669);
            dataGridReport.TabIndex = 2;
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
            searchbtn.TabIndex = 33;
            searchbtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            searchbtn.UseVisualStyleBackColor = false;
            searchbtn.Click += searchbtn_Click;
            // 
            // searchtxt
            // 
            searchtxt.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchtxt.Location = new Point(668, 25);
            searchtxt.Name = "searchtxt";
            searchtxt.PlaceholderText = "Enter title or type all";
            searchtxt.Size = new Size(271, 26);
            searchtxt.TabIndex = 32;
            // 
            // Report
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1001, 751);
            Controls.Add(searchbtn);
            Controls.Add(searchtxt);
            Controls.Add(dataGridReport);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Report";
            Text = "Video Report";
            Load += Report_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridReport).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridReport;
        private FontAwesome.Sharp.IconButton searchbtn;
        private TextBox searchtxt;
    }
}