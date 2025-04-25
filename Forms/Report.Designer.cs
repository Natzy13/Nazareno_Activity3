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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            dataGridReport = new DataGridView();
            dataGridUsers = new DataGridView();
            dataGridUserRented = new DataGridView();
            rentsummarylbl = new Label();
            activerentlbl = new Label();
            backlbl = new Label();
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
            dataGridReport.Location = new Point(27, 26);
            dataGridReport.Name = "dataGridReport";
            dataGridReport.ReadOnly = true;
            dataGridReport.RowHeadersVisible = false;
            dataGridReport.ScrollBars = ScrollBars.Vertical;
            dataGridReport.Size = new Size(558, 191);
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
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(192, 192, 255);
            dataGridViewCellStyle4.SelectionForeColor = Color.Black;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dataGridUsers.DefaultCellStyle = dataGridViewCellStyle4;
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
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.ActiveCaptionText;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dataGridUserRented.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridUserRented.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = Color.White;
            dataGridViewCellStyle6.SelectionForeColor = Color.Black;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dataGridUserRented.DefaultCellStyle = dataGridViewCellStyle6;
            dataGridUserRented.EnableHeadersVisualStyles = false;
            dataGridUserRented.Location = new Point(310, 254);
            dataGridUserRented.Name = "dataGridUserRented";
            dataGridUserRented.ReadOnly = true;
            dataGridUserRented.RowHeadersVisible = false;
            dataGridUserRented.ScrollBars = ScrollBars.Vertical;
            dataGridUserRented.Size = new Size(275, 125);
            dataGridUserRented.TabIndex = 4;
            // 
            // rentsummarylbl
            // 
            rentsummarylbl.AutoSize = true;
            rentsummarylbl.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            rentsummarylbl.Location = new Point(27, 233);
            rentsummarylbl.Name = "rentsummarylbl";
            rentsummarylbl.Size = new Size(99, 18);
            rentsummarylbl.TabIndex = 12;
            rentsummarylbl.Text = "Active Users";
            // 
            // activerentlbl
            // 
            activerentlbl.AutoSize = true;
            activerentlbl.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            activerentlbl.Location = new Point(310, 233);
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
            // Report
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(612, 401);
            Controls.Add(activerentlbl);
            Controls.Add(rentsummarylbl);
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
        private Label rentsummarylbl;
        private Label activerentlbl;
        private Label backlbl;
    }
}