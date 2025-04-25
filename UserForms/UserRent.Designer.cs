namespace BogsySystem.UserForms
{
    partial class UserRent
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            dataGridRent = new DataGridView();
            rentbtn = new FontAwesome.Sharp.IconButton();
            quantitytxt = new NumericUpDown();
            quantitylbl = new Label();
            filterbtn = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridRent).BeginInit();
            ((System.ComponentModel.ISupportInitialize)quantitytxt).BeginInit();
            SuspendLayout();
            // 
            // dataGridRent
            // 
            dataGridRent.AllowUserToAddRows = false;
            dataGridRent.AllowUserToDeleteRows = false;
            dataGridRent.AllowUserToResizeColumns = false;
            dataGridRent.AllowUserToResizeRows = false;
            dataGridRent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridRent.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridRent.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridRent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridRent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(192, 192, 255);
            dataGridViewCellStyle4.SelectionForeColor = Color.Black;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dataGridRent.DefaultCellStyle = dataGridViewCellStyle4;
            dataGridRent.EnableHeadersVisualStyles = false;
            dataGridRent.Location = new Point(27, 57);
            dataGridRent.Name = "dataGridRent";
            dataGridRent.ReadOnly = true;
            dataGridRent.RowHeadersVisible = false;
            dataGridRent.ScrollBars = ScrollBars.Horizontal;
            dataGridRent.Size = new Size(558, 281);
            dataGridRent.TabIndex = 2;
            dataGridRent.CellClick += dataGridRent_CellClick;
            dataGridRent.CellMouseDoubleClick += dataGridRent_CellMouseDoubleClick;
            dataGridRent.Click += dataGridRent_Click;
            // 
            // rentbtn
            // 
            rentbtn.BackColor = Color.ForestGreen;
            rentbtn.FlatAppearance.BorderSize = 0;
            rentbtn.FlatStyle = FlatStyle.Flat;
            rentbtn.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rentbtn.ForeColor = Color.White;
            rentbtn.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
            rentbtn.IconColor = Color.White;
            rentbtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            rentbtn.IconSize = 19;
            rentbtn.ImageAlign = ContentAlignment.MiddleRight;
            rentbtn.Location = new Point(475, 356);
            rentbtn.Name = "rentbtn";
            rentbtn.Size = new Size(110, 26);
            rentbtn.TabIndex = 17;
            rentbtn.Text = "Rent";
            rentbtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            rentbtn.UseVisualStyleBackColor = false;
            rentbtn.Click += rentbtn_Click;
            // 
            // quantitytxt
            // 
            quantitytxt.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            quantitytxt.Location = new Point(410, 356);
            quantitytxt.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            quantitytxt.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            quantitytxt.Name = "quantitytxt";
            quantitytxt.Size = new Size(34, 26);
            quantitytxt.TabIndex = 18;
            quantitytxt.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // quantitylbl
            // 
            quantitylbl.AutoSize = true;
            quantitylbl.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            quantitylbl.Location = new Point(333, 360);
            quantitylbl.Name = "quantitylbl";
            quantitylbl.Size = new Size(70, 18);
            quantitylbl.TabIndex = 19;
            quantitylbl.Text = "Quantity";
            // 
            // filterbtn
            // 
            filterbtn.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            filterbtn.FormattingEnabled = true;
            filterbtn.Items.AddRange(new object[] { "All", "VCD", "DVD", "Max Rent 1 day", "Max Rent 2 days", "Max Rent 3 days" });
            filterbtn.Location = new Point(449, 26);
            filterbtn.Name = "filterbtn";
            filterbtn.Size = new Size(135, 25);
            filterbtn.TabIndex = 25;
            filterbtn.Text = "Filter";
            filterbtn.SelectedIndexChanged += filterbtn_SelectedIndexChanged;
            // 
            // UserRent
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(612, 401);
            Controls.Add(filterbtn);
            Controls.Add(quantitylbl);
            Controls.Add(quantitytxt);
            Controls.Add(rentbtn);
            Controls.Add(dataGridRent);
            FormBorderStyle = FormBorderStyle.None;
            Name = "UserRent";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Rent CD/DVD";
            Load += UserRent_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridRent).EndInit();
            ((System.ComponentModel.ISupportInitialize)quantitytxt).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridRent;
        private FontAwesome.Sharp.IconButton rentbtn;
        private NumericUpDown quantitytxt;
        private Label quantitylbl;
        private ComboBox filterbtn;
    }
}