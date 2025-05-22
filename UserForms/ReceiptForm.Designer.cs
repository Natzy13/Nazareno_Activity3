namespace BogsySystem.UserForms
{
    partial class ReceiptForm
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            rentsummarylbl = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            dataGridReceipt = new DataGridView();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            namelbl = new Label();
            datelbl = new Label();
            button1 = new Button();
            cashlbl = new Label();
            changelbl = new Label();
            label9 = new Label();
            label10 = new Label();
            printbtn = new Button();
            printpanel = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridReceipt).BeginInit();
            printpanel.SuspendLayout();
            SuspendLayout();
            // 
            // rentsummarylbl
            // 
            rentsummarylbl.AutoSize = true;
            rentsummarylbl.Font = new Font("Century Gothic", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rentsummarylbl.Location = new Point(252, 7);
            rentsummarylbl.Name = "rentsummarylbl";
            rentsummarylbl.Size = new Size(169, 25);
            rentsummarylbl.TabIndex = 12;
            rentsummarylbl.Text = "Invoice Receipt";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(23, 60);
            label1.Name = "label1";
            label1.Size = new Size(103, 19);
            label1.TabIndex = 13;
            label1.Text = "Store Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(23, 92);
            label2.Name = "label2";
            label2.Size = new Size(62, 19);
            label2.TabIndex = 14;
            label2.Text = "Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(410, 60);
            label3.Name = "label3";
            label3.Size = new Size(49, 19);
            label3.TabIndex = 15;
            label3.Text = "Date:";
            // 
            // dataGridReceipt
            // 
            dataGridReceipt.AllowUserToAddRows = false;
            dataGridReceipt.AllowUserToDeleteRows = false;
            dataGridReceipt.AllowUserToResizeColumns = false;
            dataGridReceipt.AllowUserToResizeRows = false;
            dataGridReceipt.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridReceipt.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dataGridReceipt.BackgroundColor = SystemColors.ActiveBorder;
            dataGridReceipt.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.ActiveCaptionText;
            dataGridViewCellStyle4.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.White;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dataGridReceipt.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridReceipt.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = Color.White;
            dataGridViewCellStyle5.SelectionForeColor = Color.Black;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dataGridReceipt.DefaultCellStyle = dataGridViewCellStyle5;
            dataGridReceipt.EnableHeadersVisualStyles = false;
            dataGridReceipt.Location = new Point(14, 125);
            dataGridReceipt.Name = "dataGridReceipt";
            dataGridReceipt.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Control;
            dataGridViewCellStyle6.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dataGridReceipt.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dataGridReceipt.RowHeadersVisible = false;
            dataGridReceipt.ScrollBars = ScrollBars.Vertical;
            dataGridReceipt.Size = new Size(645, 131);
            dataGridReceipt.TabIndex = 17;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(144, 60);
            label4.Name = "label4";
            label4.Size = new Size(147, 21);
            label4.TabIndex = 18;
            label4.Text = "Bogsy Video Store";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(410, 91);
            label5.Name = "label5";
            label5.Size = new Size(68, 19);
            label5.TabIndex = 19;
            label5.Text = "Branch:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(504, 91);
            label6.Name = "label6";
            label6.Size = new Size(143, 21);
            label6.TabIndex = 20;
            label6.Text = "Buhangin Branch";
            // 
            // namelbl
            // 
            namelbl.AutoSize = true;
            namelbl.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            namelbl.Location = new Point(144, 90);
            namelbl.Name = "namelbl";
            namelbl.Size = new Size(58, 21);
            namelbl.TabIndex = 21;
            namelbl.Text = "Name";
            // 
            // datelbl
            // 
            datelbl.AutoSize = true;
            datelbl.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            datelbl.Location = new Point(507, 62);
            datelbl.Name = "datelbl";
            datelbl.Size = new Size(38, 17);
            datelbl.TabIndex = 22;
            datelbl.Text = "Date";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaptionText;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(600, 344);
            button1.Name = "button1";
            button1.Size = new Size(75, 25);
            button1.TabIndex = 23;
            button1.Text = "Close";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // cashlbl
            // 
            cashlbl.AutoSize = true;
            cashlbl.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cashlbl.Location = new Point(504, 270);
            cashlbl.Name = "cashlbl";
            cashlbl.Size = new Size(41, 21);
            cashlbl.TabIndex = 27;
            cashlbl.Text = "0.00";
            // 
            // changelbl
            // 
            changelbl.AutoSize = true;
            changelbl.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            changelbl.Location = new Point(504, 293);
            changelbl.Name = "changelbl";
            changelbl.Size = new Size(41, 21);
            changelbl.TabIndex = 26;
            changelbl.Text = "0.00";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(410, 293);
            label9.Name = "label9";
            label9.Size = new Size(77, 19);
            label9.TabIndex = 25;
            label9.Text = "Change:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(410, 270);
            label10.Name = "label10";
            label10.Size = new Size(52, 19);
            label10.TabIndex = 24;
            label10.Text = "Cash:";
            // 
            // printbtn
            // 
            printbtn.BackColor = SystemColors.ActiveCaptionText;
            printbtn.FlatAppearance.BorderSize = 0;
            printbtn.FlatStyle = FlatStyle.Flat;
            printbtn.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            printbtn.ForeColor = Color.White;
            printbtn.Location = new Point(508, 344);
            printbtn.Name = "printbtn";
            printbtn.Size = new Size(75, 25);
            printbtn.TabIndex = 28;
            printbtn.Text = "Print";
            printbtn.UseVisualStyleBackColor = false;
            printbtn.Click += printbtn_Click;
            // 
            // printpanel
            // 
            printpanel.BackColor = Color.White;
            printpanel.Controls.Add(cashlbl);
            printpanel.Controls.Add(changelbl);
            printpanel.Controls.Add(label9);
            printpanel.Controls.Add(label10);
            printpanel.Controls.Add(datelbl);
            printpanel.Controls.Add(namelbl);
            printpanel.Controls.Add(label6);
            printpanel.Controls.Add(label5);
            printpanel.Controls.Add(label4);
            printpanel.Controls.Add(dataGridReceipt);
            printpanel.Controls.Add(label3);
            printpanel.Controls.Add(label2);
            printpanel.Controls.Add(label1);
            printpanel.Controls.Add(rentsummarylbl);
            printpanel.Location = new Point(16, 13);
            printpanel.Name = "printpanel";
            printpanel.Size = new Size(674, 322);
            printpanel.TabIndex = 29;
            // 
            // ReceiptForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(705, 381);
            Controls.Add(printpanel);
            Controls.Add(printbtn);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ReceiptForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ReceiptForm";
            Load += ReceiptForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridReceipt).EndInit();
            printpanel.ResumeLayout(false);
            printpanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label rentsummarylbl;
        private Label label1;
        private Label label2;
        private Label label3;
        private DataGridView dataGridReceipt;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label namelbl;
        private Label datelbl;
        private Button button1;
        private Label cashlbl;
        private Label changelbl;
        private Label label9;
        private Label label10;
        private Button printbtn;
        private Panel printpanel;
    }
}