namespace BogsySystem.UserForms
{
    partial class UserReturn
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
            dataGridReturn = new DataGridView();
            returnbtn = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)dataGridReturn).BeginInit();
            SuspendLayout();
            // 
            // dataGridReturn
            // 
            dataGridReturn.AllowUserToAddRows = false;
            dataGridReturn.AllowUserToDeleteRows = false;
            dataGridReturn.AllowUserToResizeColumns = false;
            dataGridReturn.AllowUserToResizeRows = false;
            dataGridReturn.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridReturn.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridReturn.BackgroundColor = SystemColors.ActiveBorder;
            dataGridReturn.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridReturn.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridReturn.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(192, 192, 255);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridReturn.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridReturn.EnableHeadersVisualStyles = false;
            dataGridReturn.Location = new Point(27, 26);
            dataGridReturn.Name = "dataGridReturn";
            dataGridReturn.ReadOnly = true;
            dataGridReturn.RowHeadersVisible = false;
            dataGridReturn.ScrollBars = ScrollBars.Horizontal;
            dataGridReturn.Size = new Size(558, 312);
            dataGridReturn.TabIndex = 3;
            dataGridReturn.CellClick += dataGridReturn_CellClick;
            dataGridReturn.CellDoubleClick += dataGridReturn_CellDoubleClick;
            dataGridReturn.Click += dataGridReturn_Click;
            // 
            // returnbtn
            // 
            returnbtn.BackColor = Color.ForestGreen;
            returnbtn.FlatAppearance.BorderSize = 0;
            returnbtn.FlatStyle = FlatStyle.Flat;
            returnbtn.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            returnbtn.ForeColor = Color.White;
            returnbtn.IconChar = FontAwesome.Sharp.IconChar.RightToBracket;
            returnbtn.IconColor = Color.White;
            returnbtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            returnbtn.IconSize = 19;
            returnbtn.ImageAlign = ContentAlignment.MiddleRight;
            returnbtn.Location = new Point(475, 356);
            returnbtn.Name = "returnbtn";
            returnbtn.Size = new Size(110, 26);
            returnbtn.TabIndex = 20;
            returnbtn.Text = "Return";
            returnbtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            returnbtn.UseVisualStyleBackColor = false;
            returnbtn.Click += returnbtn_Click;
            // 
            // UserReturn
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(612, 401);
            Controls.Add(returnbtn);
            Controls.Add(dataGridReturn);
            FormBorderStyle = FormBorderStyle.None;
            Name = "UserReturn";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Return CD/DVD";
            Load += UserReturn_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridReturn).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridReturn;
        private FontAwesome.Sharp.IconButton returnbtn;
    }
}