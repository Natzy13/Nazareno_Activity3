namespace BogsySystem.UserForms
{
    partial class UserPayProperties
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
            dataGridPay = new DataGridView();
            paybtn = new FontAwesome.Sharp.IconButton();
            chargefeelbl = new Label();
            feelbl = new Label();
            totalfeelbl = new Label();
            paylbl = new Label();
            feetxt = new TextBox();
            chargefeetxt = new TextBox();
            paytxt = new TextBox();
            totalfeetxt = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridPay).BeginInit();
            SuspendLayout();
            // 
            // dataGridPay
            // 
            dataGridPay.AllowUserToAddRows = false;
            dataGridPay.AllowUserToDeleteRows = false;
            dataGridPay.AllowUserToResizeColumns = false;
            dataGridPay.AllowUserToResizeRows = false;
            dataGridPay.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridPay.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridPay.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridPay.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridPay.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(192, 192, 255);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridPay.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridPay.EnableHeadersVisualStyles = false;
            dataGridPay.Location = new Point(28, 26);
            dataGridPay.Name = "dataGridPay";
            dataGridPay.ReadOnly = true;
            dataGridPay.RowHeadersVisible = false;
            dataGridPay.ScrollBars = ScrollBars.Vertical;
            dataGridPay.Size = new Size(945, 600);
            dataGridPay.TabIndex = 3;
            dataGridPay.CellClick += dataGridPay_CellClick;
            dataGridPay.CellDoubleClick += dataGridPay_CellDoubleClick;
            dataGridPay.Click += dataGridPay_Click;
            // 
            // paybtn
            // 
            paybtn.BackColor = Color.ForestGreen;
            paybtn.FlatAppearance.BorderSize = 0;
            paybtn.FlatStyle = FlatStyle.Flat;
            paybtn.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            paybtn.ForeColor = Color.White;
            paybtn.IconChar = FontAwesome.Sharp.IconChar.MoneyBill;
            paybtn.IconColor = Color.White;
            paybtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            paybtn.IconSize = 19;
            paybtn.ImageAlign = ContentAlignment.MiddleRight;
            paybtn.Location = new Point(722, 694);
            paybtn.Name = "paybtn";
            paybtn.Size = new Size(251, 31);
            paybtn.TabIndex = 21;
            paybtn.Text = "Pay";
            paybtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            paybtn.UseVisualStyleBackColor = false;
            paybtn.Click += paybtn_Click;
            // 
            // chargefeelbl
            // 
            chargefeelbl.AutoSize = true;
            chargefeelbl.Font = new Font("Century Gothic", 14.25F, FontStyle.Bold);
            chargefeelbl.Location = new Point(27, 697);
            chargefeelbl.Name = "chargefeelbl";
            chargefeelbl.Size = new Size(139, 23);
            chargefeelbl.TabIndex = 23;
            chargefeelbl.Text = "Overdue Fee :";
            // 
            // feelbl
            // 
            feelbl.AutoSize = true;
            feelbl.Font = new Font("Century Gothic", 14.25F, FontStyle.Bold);
            feelbl.Location = new Point(70, 652);
            feelbl.Name = "feelbl";
            feelbl.Size = new Size(96, 23);
            feelbl.TabIndex = 24;
            feelbl.Text = "Subtotal :";
            // 
            // totalfeelbl
            // 
            totalfeelbl.AutoSize = true;
            totalfeelbl.Font = new Font("Century Gothic", 14.25F, FontStyle.Bold);
            totalfeelbl.Location = new Point(366, 650);
            totalfeelbl.Name = "totalfeelbl";
            totalfeelbl.Size = new Size(146, 23);
            totalfeelbl.TabIndex = 25;
            totalfeelbl.Text = "Final Rent Fee :";
            // 
            // paylbl
            // 
            paylbl.AutoSize = true;
            paylbl.Font = new Font("Century Gothic", 14.25F, FontStyle.Bold);
            paylbl.Location = new Point(457, 694);
            paylbl.Name = "paylbl";
            paylbl.Size = new Size(55, 23);
            paylbl.TabIndex = 26;
            paylbl.Text = "Pay :";
            // 
            // feetxt
            // 
            feetxt.Font = new Font("Century Gothic", 14.25F);
            feetxt.Location = new Point(188, 648);
            feetxt.Name = "feetxt";
            feetxt.ReadOnly = true;
            feetxt.Size = new Size(150, 31);
            feetxt.TabIndex = 27;
            // 
            // chargefeetxt
            // 
            chargefeetxt.Font = new Font("Century Gothic", 14.25F);
            chargefeetxt.Location = new Point(188, 694);
            chargefeetxt.Name = "chargefeetxt";
            chargefeetxt.ReadOnly = true;
            chargefeetxt.Size = new Size(150, 31);
            chargefeetxt.TabIndex = 28;
            // 
            // paytxt
            // 
            paytxt.Font = new Font("Century Gothic", 14.25F);
            paytxt.Location = new Point(535, 693);
            paytxt.Name = "paytxt";
            paytxt.Size = new Size(150, 31);
            paytxt.TabIndex = 29;
            // 
            // totalfeetxt
            // 
            totalfeetxt.Font = new Font("Century Gothic", 14.25F);
            totalfeetxt.Location = new Point(535, 650);
            totalfeetxt.Name = "totalfeetxt";
            totalfeetxt.ReadOnly = true;
            totalfeetxt.Size = new Size(150, 31);
            totalfeetxt.TabIndex = 30;
            // 
            // UserPayProperties
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1001, 751);
            Controls.Add(totalfeetxt);
            Controls.Add(paytxt);
            Controls.Add(chargefeetxt);
            Controls.Add(feetxt);
            Controls.Add(paylbl);
            Controls.Add(totalfeelbl);
            Controls.Add(feelbl);
            Controls.Add(chargefeelbl);
            Controls.Add(paybtn);
            Controls.Add(dataGridPay);
            FormBorderStyle = FormBorderStyle.None;
            Name = "UserPayProperties";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Payment";
            Load += UserPay_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridPay).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridPay;
        private FontAwesome.Sharp.IconButton paybtn;
        private Label chargefeelbl;
        private Label feelbl;
        private Label totalfeelbl;
        private Label paylbl;
        private TextBox feetxt;
        private TextBox chargefeetxt;
        private TextBox paytxt;
        private TextBox totalfeetxt;
    }
}