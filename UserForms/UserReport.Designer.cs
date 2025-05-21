namespace BogsySystem.UserForms
{
    partial class UserReport
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
            rentsummarylbl = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            dataGridHistory = new DataGridView();
            totalrenttxt = new Label();
            totalqtytxt = new Label();
            totalfeetxt = new Label();
            totalchargetxt = new Label();
            label5 = new Label();
            totalamttxt = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridHistory).BeginInit();
            SuspendLayout();
            // 
            // rentsummarylbl
            // 
            rentsummarylbl.AutoSize = true;
            rentsummarylbl.Font = new Font("Century Gothic", 24F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            rentsummarylbl.Location = new Point(27, 20);
            rentsummarylbl.Name = "rentsummarylbl";
            rentsummarylbl.Size = new Size(269, 39);
            rentsummarylbl.TabIndex = 11;
            rentsummarylbl.Text = "Rental Summary";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 20.25F);
            label1.Location = new Point(65, 90);
            label1.Name = "label1";
            label1.Size = new Size(273, 33);
            label1.TabIndex = 12;
            label1.Text = "Total Rentals Made:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 20.25F);
            label2.Location = new Point(27, 144);
            label2.Name = "label2";
            label2.Size = new Size(311, 33);
            label2.TabIndex = 13;
            label2.Text = "Total Quantity Rented:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 20.25F);
            label3.Location = new Point(573, 90);
            label3.Name = "label3";
            label3.Size = new Size(217, 33);
            label3.TabIndex = 14;
            label3.Text = "Total Fees Paid:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 20.25F);
            label4.Location = new Point(527, 144);
            label4.Name = "label4";
            label4.Size = new Size(263, 33);
            label4.TabIndex = 15;
            label4.Text = "Total Overcharges:";
            // 
            // dataGridHistory
            // 
            dataGridHistory.AllowUserToAddRows = false;
            dataGridHistory.AllowUserToDeleteRows = false;
            dataGridHistory.AllowUserToResizeColumns = false;
            dataGridHistory.AllowUserToResizeRows = false;
            dataGridHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridHistory.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dataGridHistory.BackgroundColor = SystemColors.ActiveBorder;
            dataGridHistory.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.White;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridHistory.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridHistory.EnableHeadersVisualStyles = false;
            dataGridHistory.Location = new Point(28, 260);
            dataGridHistory.Name = "dataGridHistory";
            dataGridHistory.ReadOnly = true;
            dataGridHistory.RowHeadersVisible = false;
            dataGridHistory.ScrollBars = ScrollBars.Vertical;
            dataGridHistory.Size = new Size(945, 468);
            dataGridHistory.TabIndex = 16;
            // 
            // totalrenttxt
            // 
            totalrenttxt.AutoSize = true;
            totalrenttxt.Font = new Font("Century Gothic", 20.25F);
            totalrenttxt.Location = new Point(367, 90);
            totalrenttxt.Name = "totalrenttxt";
            totalrenttxt.Size = new Size(30, 33);
            totalrenttxt.TabIndex = 17;
            totalrenttxt.Text = "0";
            // 
            // totalqtytxt
            // 
            totalqtytxt.AutoSize = true;
            totalqtytxt.Font = new Font("Century Gothic", 20.25F);
            totalqtytxt.Location = new Point(367, 144);
            totalqtytxt.Name = "totalqtytxt";
            totalqtytxt.Size = new Size(30, 33);
            totalqtytxt.TabIndex = 18;
            totalqtytxt.Text = "0";
            // 
            // totalfeetxt
            // 
            totalfeetxt.AutoSize = true;
            totalfeetxt.Font = new Font("Century Gothic", 20.25F);
            totalfeetxt.Location = new Point(827, 90);
            totalfeetxt.Name = "totalfeetxt";
            totalfeetxt.Size = new Size(30, 33);
            totalfeetxt.TabIndex = 19;
            totalfeetxt.Text = "0";
            // 
            // totalchargetxt
            // 
            totalchargetxt.AutoSize = true;
            totalchargetxt.Font = new Font("Century Gothic", 20.25F);
            totalchargetxt.Location = new Point(827, 144);
            totalchargetxt.Name = "totalchargetxt";
            totalchargetxt.Size = new Size(30, 33);
            totalchargetxt.TabIndex = 20;
            totalchargetxt.Text = "0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 20.25F);
            label5.Location = new Point(285, 206);
            label5.Name = "label5";
            label5.Size = new Size(263, 33);
            label5.TabIndex = 21;
            label5.Text = "Total Amount Paid:";
            // 
            // totalamttxt
            // 
            totalamttxt.AutoSize = true;
            totalamttxt.Font = new Font("Century Gothic", 20.25F);
            totalamttxt.Location = new Point(569, 206);
            totalamttxt.Name = "totalamttxt";
            totalamttxt.Size = new Size(30, 33);
            totalamttxt.TabIndex = 22;
            totalamttxt.Text = "0";
            // 
            // UserReport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1001, 751);
            Controls.Add(totalamttxt);
            Controls.Add(label5);
            Controls.Add(totalchargetxt);
            Controls.Add(totalfeetxt);
            Controls.Add(totalqtytxt);
            Controls.Add(totalrenttxt);
            Controls.Add(dataGridHistory);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(rentsummarylbl);
            FormBorderStyle = FormBorderStyle.None;
            Name = "UserReport";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Report";
            Load += UserReport_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridHistory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label rentsummarylbl;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private DataGridView dataGridHistory;
        private Label totalrenttxt;
        private Label totalqtytxt;
        private Label totalfeetxt;
        private Label totalchargetxt;
        private Label label5;
        private Label totalamttxt;
    }
}