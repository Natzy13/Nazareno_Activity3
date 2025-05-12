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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            dataGridRent = new DataGridView();
            rentbtn = new FontAwesome.Sharp.IconButton();
            quantitytxt = new NumericUpDown();
            quantitylbl = new Label();
            filterbtn = new ComboBox();
            searchbtn = new FontAwesome.Sharp.IconButton();
            searchtxt = new TextBox();
            dataGridCart = new DataGridView();
            clearCart = new FontAwesome.Sharp.IconButton();
            addCart = new FontAwesome.Sharp.IconButton();
            label1 = new Label();
            subtotaltxt = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridRent).BeginInit();
            ((System.ComponentModel.ISupportInitialize)quantitytxt).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridCart).BeginInit();
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
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridRent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridRent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(192, 192, 255);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridRent.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridRent.EnableHeadersVisualStyles = false;
            dataGridRent.Location = new Point(27, 57);
            dataGridRent.Name = "dataGridRent";
            dataGridRent.ReadOnly = true;
            dataGridRent.RowHeadersVisible = false;
            dataGridRent.ScrollBars = ScrollBars.Horizontal;
            dataGridRent.Size = new Size(349, 281);
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
            rentbtn.Location = new Point(394, 356);
            rentbtn.Name = "rentbtn";
            rentbtn.Size = new Size(191, 26);
            rentbtn.TabIndex = 17;
            rentbtn.Text = "Rent";
            rentbtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            rentbtn.UseVisualStyleBackColor = false;
            rentbtn.Click += rentbtn_Click;
            // 
            // quantitytxt
            // 
            quantitytxt.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            quantitytxt.Location = new Point(103, 356);
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
            quantitylbl.Location = new Point(27, 359);
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
            filterbtn.Location = new Point(27, 26);
            filterbtn.Name = "filterbtn";
            filterbtn.Size = new Size(135, 25);
            filterbtn.TabIndex = 25;
            filterbtn.Text = "Filter";
            filterbtn.SelectedIndexChanged += filterbtn_SelectedIndexChanged;
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
            searchbtn.Location = new Point(555, 26);
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
            searchtxt.Location = new Point(333, 26);
            searchtxt.Name = "searchtxt";
            searchtxt.PlaceholderText = "Search Title";
            searchtxt.Size = new Size(216, 26);
            searchtxt.TabIndex = 30;
            // 
            // dataGridCart
            // 
            dataGridCart.AllowUserToAddRows = false;
            dataGridCart.AllowUserToDeleteRows = false;
            dataGridCart.AllowUserToResizeColumns = false;
            dataGridCart.AllowUserToResizeRows = false;
            dataGridCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridCart.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridCart.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridCart.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(192, 192, 255);
            dataGridViewCellStyle4.SelectionForeColor = Color.Black;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dataGridCart.DefaultCellStyle = dataGridViewCellStyle4;
            dataGridCart.EnableHeadersVisualStyles = false;
            dataGridCart.Location = new Point(394, 58);
            dataGridCart.Name = "dataGridCart";
            dataGridCart.ReadOnly = true;
            dataGridCart.RowHeadersVisible = false;
            dataGridCart.ScrollBars = ScrollBars.Horizontal;
            dataGridCart.Size = new Size(191, 248);
            dataGridCart.TabIndex = 32;
            dataGridCart.CellClick += dataGridCart_CellClick;
            dataGridCart.CellDoubleClick += dataGridCart_CellDoubleClick;
            dataGridCart.Click += dataGridCart_Click;
            // 
            // clearCart
            // 
            clearCart.BackColor = SystemColors.ActiveCaptionText;
            clearCart.FlatAppearance.BorderSize = 0;
            clearCart.FlatStyle = FlatStyle.Flat;
            clearCart.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            clearCart.ForeColor = Color.White;
            clearCart.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
            clearCart.IconColor = Color.White;
            clearCart.IconFont = FontAwesome.Sharp.IconFont.Auto;
            clearCart.IconSize = 19;
            clearCart.ImageAlign = ContentAlignment.MiddleRight;
            clearCart.Location = new Point(286, 356);
            clearCart.Name = "clearCart";
            clearCart.Size = new Size(90, 26);
            clearCart.TabIndex = 33;
            clearCart.Text = "Clear";
            clearCart.TextImageRelation = TextImageRelation.ImageBeforeText;
            clearCart.UseVisualStyleBackColor = false;
            clearCart.Click += clearCart_Click;
            // 
            // addCart
            // 
            addCart.BackColor = Color.ForestGreen;
            addCart.FlatAppearance.BorderSize = 0;
            addCart.FlatStyle = FlatStyle.Flat;
            addCart.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            addCart.ForeColor = Color.White;
            addCart.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
            addCart.IconColor = Color.White;
            addCart.IconFont = FontAwesome.Sharp.IconFont.Auto;
            addCart.IconSize = 19;
            addCart.ImageAlign = ContentAlignment.MiddleRight;
            addCart.Location = new Point(190, 356);
            addCart.Name = "addCart";
            addCart.Size = new Size(90, 26);
            addCart.TabIndex = 34;
            addCart.Text = "Add";
            addCart.TextImageRelation = TextImageRelation.ImageBeforeText;
            addCart.UseVisualStyleBackColor = false;
            addCart.Click += addCart_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(394, 320);
            label1.Name = "label1";
            label1.Size = new Size(75, 19);
            label1.TabIndex = 35;
            label1.Text = "Subtotal:";
            // 
            // subtotaltxt
            // 
            subtotaltxt.AutoSize = true;
            subtotaltxt.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            subtotaltxt.Location = new Point(478, 320);
            subtotaltxt.Name = "subtotaltxt";
            subtotaltxt.Size = new Size(37, 20);
            subtotaltxt.TabIndex = 36;
            subtotaltxt.Text = "0.00";
            // 
            // UserRent
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(612, 401);
            Controls.Add(subtotaltxt);
            Controls.Add(label1);
            Controls.Add(addCart);
            Controls.Add(clearCart);
            Controls.Add(dataGridCart);
            Controls.Add(searchbtn);
            Controls.Add(searchtxt);
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
            ((System.ComponentModel.ISupportInitialize)dataGridCart).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridRent;
        private FontAwesome.Sharp.IconButton rentbtn;
        private NumericUpDown quantitytxt;
        private Label quantitylbl;
        private ComboBox filterbtn;
        private FontAwesome.Sharp.IconButton searchbtn;
        private TextBox searchtxt;
        private DataGridView dataGridCart;
        private FontAwesome.Sharp.IconButton clearCart;
        private FontAwesome.Sharp.IconButton addCart;
        private Label label1;
        private Label subtotaltxt;
    }
}