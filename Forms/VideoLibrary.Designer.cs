namespace BogsySystem.Forms
{
    partial class VideoLibrary
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
            dataGridVid = new DataGridView();
            vidtitletxt = new TextBox();
            label1 = new Label();
            formatlbl = new Label();
            formatxt = new ComboBox();
            label2 = new Label();
            quantitytxt = new NumericUpDown();
            label3 = new Label();
            maxrenttxt = new ComboBox();
            editbtn = new FontAwesome.Sharp.IconButton();
            removebtn = new FontAwesome.Sharp.IconButton();
            addbtn = new FontAwesome.Sharp.IconButton();
            filterbtn = new ComboBox();
            searchbtn = new FontAwesome.Sharp.IconButton();
            searchtxt = new TextBox();
            searchfilter = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridVid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)quantitytxt).BeginInit();
            SuspendLayout();
            // 
            // dataGridVid
            // 
            dataGridVid.AllowUserToAddRows = false;
            dataGridVid.AllowUserToDeleteRows = false;
            dataGridVid.AllowUserToResizeColumns = false;
            dataGridVid.AllowUserToResizeRows = false;
            dataGridVid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridVid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridVid.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridVid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridVid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(192, 192, 255);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridVid.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridVid.EnableHeadersVisualStyles = false;
            dataGridVid.Location = new Point(28, 57);
            dataGridVid.Name = "dataGridVid";
            dataGridVid.ReadOnly = true;
            dataGridVid.RowHeadersVisible = false;
            dataGridVid.ScrollBars = ScrollBars.Horizontal;
            dataGridVid.Size = new Size(945, 561);
            dataGridVid.TabIndex = 1;
            dataGridVid.CellClick += dataGridVid_CellClick;
            dataGridVid.CellMouseDoubleClick += dataGridVid_CellMouseDoubleClick;
            dataGridVid.Click += dataGridVid_Click;
            // 
            // vidtitletxt
            // 
            vidtitletxt.Font = new Font("Century Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            vidtitletxt.Location = new Point(121, 648);
            vidtitletxt.Name = "vidtitletxt";
            vidtitletxt.Size = new Size(310, 31);
            vidtitletxt.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(27, 650);
            label1.Name = "label1";
            label1.Size = new Size(46, 23);
            label1.TabIndex = 3;
            label1.Text = "Title";
            // 
            // formatlbl
            // 
            formatlbl.AutoSize = true;
            formatlbl.Font = new Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            formatlbl.Location = new Point(27, 693);
            formatlbl.Name = "formatlbl";
            formatlbl.Size = new Size(74, 23);
            formatlbl.TabIndex = 5;
            formatlbl.Text = "Format";
            // 
            // formatxt
            // 
            formatxt.Font = new Font("Century Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            formatxt.FormattingEnabled = true;
            formatxt.Items.AddRange(new object[] { "VCD", "DVD" });
            formatxt.Location = new Point(121, 693);
            formatxt.Name = "formatxt";
            formatxt.Size = new Size(135, 30);
            formatxt.TabIndex = 6;
            formatxt.Text = "Select";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(471, 650);
            label2.Name = "label2";
            label2.Size = new Size(89, 23);
            label2.TabIndex = 7;
            label2.Text = "Quantity";
            // 
            // quantitytxt
            // 
            quantitytxt.Font = new Font("Century Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            quantitytxt.Location = new Point(625, 648);
            quantitytxt.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            quantitytxt.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            quantitytxt.Name = "quantitytxt";
            quantitytxt.Size = new Size(34, 31);
            quantitytxt.TabIndex = 8;
            quantitytxt.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(471, 693);
            label3.Name = "label3";
            label3.Size = new Size(100, 23);
            label3.TabIndex = 9;
            label3.Text = "Rent Days";
            // 
            // maxrenttxt
            // 
            maxrenttxt.Font = new Font("Century Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            maxrenttxt.FormattingEnabled = true;
            maxrenttxt.Items.AddRange(new object[] { "1", "2", "3" });
            maxrenttxt.Location = new Point(625, 693);
            maxrenttxt.Name = "maxrenttxt";
            maxrenttxt.Size = new Size(34, 30);
            maxrenttxt.TabIndex = 10;
            maxrenttxt.Text = "0";
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
            editbtn.IconSize = 19;
            editbtn.ImageAlign = ContentAlignment.MiddleRight;
            editbtn.Location = new Point(721, 693);
            editbtn.Name = "editbtn";
            editbtn.Size = new Size(120, 31);
            editbtn.TabIndex = 14;
            editbtn.Text = "Edit";
            editbtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            editbtn.UseVisualStyleBackColor = false;
            editbtn.Click += editbtn_Click;
            // 
            // removebtn
            // 
            removebtn.BackColor = Color.Firebrick;
            removebtn.FlatAppearance.BorderSize = 0;
            removebtn.FlatStyle = FlatStyle.Flat;
            removebtn.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            removebtn.ForeColor = Color.White;
            removebtn.IconChar = FontAwesome.Sharp.IconChar.Trash;
            removebtn.IconColor = Color.White;
            removebtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            removebtn.IconSize = 19;
            removebtn.ImageAlign = ContentAlignment.MiddleRight;
            removebtn.Location = new Point(852, 692);
            removebtn.Name = "removebtn";
            removebtn.Size = new Size(120, 31);
            removebtn.TabIndex = 15;
            removebtn.Text = "Remove";
            removebtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            removebtn.UseVisualStyleBackColor = false;
            removebtn.Click += removebtn_Click;
            // 
            // addbtn
            // 
            addbtn.BackColor = Color.ForestGreen;
            addbtn.FlatAppearance.BorderSize = 0;
            addbtn.FlatStyle = FlatStyle.Flat;
            addbtn.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            addbtn.ForeColor = Color.White;
            addbtn.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
            addbtn.IconColor = Color.White;
            addbtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            addbtn.IconSize = 19;
            addbtn.ImageAlign = ContentAlignment.MiddleRight;
            addbtn.Location = new Point(721, 648);
            addbtn.Name = "addbtn";
            addbtn.Size = new Size(251, 31);
            addbtn.TabIndex = 16;
            addbtn.Text = "Add";
            addbtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            addbtn.UseVisualStyleBackColor = false;
            addbtn.Click += addbtn_Click;
            // 
            // filterbtn
            // 
            filterbtn.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            filterbtn.FormattingEnabled = true;
            filterbtn.Items.AddRange(new object[] { "All", "VCD", "DVD", "Max Rent 1 day", "Max Rent 2 days", "Max Rent 3 days" });
            filterbtn.Location = new Point(30, 25);
            filterbtn.Name = "filterbtn";
            filterbtn.Size = new Size(110, 25);
            filterbtn.TabIndex = 24;
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
            searchbtn.Location = new Point(942, 25);
            searchbtn.Name = "searchbtn";
            searchbtn.Size = new Size(30, 26);
            searchbtn.TabIndex = 28;
            searchbtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            searchbtn.UseVisualStyleBackColor = false;
            searchbtn.Click += searchbtn_Click;
            // 
            // searchtxt
            // 
            searchtxt.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchtxt.Location = new Point(668, 25);
            searchtxt.Name = "searchtxt";
            searchtxt.PlaceholderText = "Type \"all\" to show all";
            searchtxt.Size = new Size(271, 26);
            searchtxt.TabIndex = 27;
            // 
            // searchfilter
            // 
            searchfilter.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchfilter.FormattingEnabled = true;
            searchfilter.Items.AddRange(new object[] { "ID", "Title" });
            searchfilter.Location = new Point(594, 25);
            searchfilter.Name = "searchfilter";
            searchfilter.Size = new Size(65, 25);
            searchfilter.TabIndex = 29;
            searchfilter.Text = "Filter";
            // 
            // VideoLibrary
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1001, 751);
            Controls.Add(searchfilter);
            Controls.Add(searchbtn);
            Controls.Add(searchtxt);
            Controls.Add(filterbtn);
            Controls.Add(addbtn);
            Controls.Add(removebtn);
            Controls.Add(editbtn);
            Controls.Add(maxrenttxt);
            Controls.Add(label3);
            Controls.Add(quantitytxt);
            Controls.Add(label2);
            Controls.Add(formatxt);
            Controls.Add(formatlbl);
            Controls.Add(label1);
            Controls.Add(vidtitletxt);
            Controls.Add(dataGridVid);
            FormBorderStyle = FormBorderStyle.None;
            Name = "VideoLibrary";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Video Library";
            Load += VideoLibrary_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridVid).EndInit();
            ((System.ComponentModel.ISupportInitialize)quantitytxt).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridVid;
        private TextBox vidtitletxt;
        private Label label1;
        private Label formatlbl;
        private ComboBox formatxt;
        private Label label2;
        private NumericUpDown quantitytxt;
        private Label label3;
        private ComboBox maxrenttxt;
        private FontAwesome.Sharp.IconButton editbtn;
        private FontAwesome.Sharp.IconButton removebtn;
        private FontAwesome.Sharp.IconButton addbtn;
        private ComboBox filterbtn;
        private FontAwesome.Sharp.IconButton searchbtn;
        private TextBox searchtxt;
        private ComboBox searchfilter;
    }
}