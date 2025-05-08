namespace BogsySystem.UserForms
{
    partial class UserAccount
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
            namelbl = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            fnametxt = new TextBox();
            usernametxt = new TextBox();
            passtxt = new TextBox();
            emailtxt = new TextBox();
            label6 = new Label();
            label7 = new Label();
            gendertxt = new ComboBox();
            editbtn = new FontAwesome.Sharp.IconButton();
            deactbtn = new FontAwesome.Sharp.IconButton();
            idtxt = new Label();
            showpassbtn = new FontAwesome.Sharp.IconButton();
            hidepassbtn = new FontAwesome.Sharp.IconButton();
            SuspendLayout();
            // 
            // namelbl
            // 
            namelbl.AutoSize = true;
            namelbl.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            namelbl.Location = new Point(33, 24);
            namelbl.Name = "namelbl";
            namelbl.Size = new Size(105, 21);
            namelbl.TabIndex = 0;
            namelbl.Text = "Account ID:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(32, 110);
            label1.Name = "label1";
            label1.Size = new Size(90, 21);
            label1.TabIndex = 1;
            label1.Text = "Full Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(33, 243);
            label2.Name = "label2";
            label2.Size = new Size(92, 21);
            label2.TabIndex = 2;
            label2.Text = "Username:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(320, 243);
            label3.Name = "label3";
            label3.Size = new Size(86, 21);
            label3.TabIndex = 3;
            label3.Text = "Password:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(33, 315);
            label4.Name = "label4";
            label4.Size = new Size(55, 21);
            label4.TabIndex = 4;
            label4.Text = "Email:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(320, 110);
            label5.Name = "label5";
            label5.Size = new Size(74, 21);
            label5.TabIndex = 5;
            label5.Text = "Gender:";
            // 
            // fnametxt
            // 
            fnametxt.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            fnametxt.Location = new Point(32, 132);
            fnametxt.Name = "fnametxt";
            fnametxt.Size = new Size(252, 26);
            fnametxt.TabIndex = 6;
            // 
            // usernametxt
            // 
            usernametxt.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            usernametxt.Location = new Point(33, 267);
            usernametxt.Name = "usernametxt";
            usernametxt.Size = new Size(252, 26);
            usernametxt.TabIndex = 7;
            // 
            // passtxt
            // 
            passtxt.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            passtxt.Location = new Point(320, 267);
            passtxt.Name = "passtxt";
            passtxt.PasswordChar = '*';
            passtxt.Size = new Size(252, 26);
            passtxt.TabIndex = 8;
            // 
            // emailtxt
            // 
            emailtxt.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            emailtxt.Location = new Point(33, 339);
            emailtxt.Name = "emailtxt";
            emailtxt.Size = new Size(252, 26);
            emailtxt.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Century Gothic", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label6.Location = new Point(33, 74);
            label6.Name = "label6";
            label6.Size = new Size(155, 23);
            label6.TabIndex = 10;
            label6.Text = "Personal Details";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Century Gothic", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label7.Location = new Point(33, 207);
            label7.Name = "label7";
            label7.Size = new Size(155, 23);
            label7.TabIndex = 11;
            label7.Text = "Account Details";
            // 
            // gendertxt
            // 
            gendertxt.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gendertxt.FormattingEnabled = true;
            gendertxt.Items.AddRange(new object[] { "Male", "Female ", "Other" });
            gendertxt.Location = new Point(320, 132);
            gendertxt.Name = "gendertxt";
            gendertxt.Size = new Size(252, 28);
            gendertxt.TabIndex = 12;
            // 
            // editbtn
            // 
            editbtn.BackColor = Color.Black;
            editbtn.FlatAppearance.BorderSize = 0;
            editbtn.FlatStyle = FlatStyle.Flat;
            editbtn.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            editbtn.ForeColor = Color.White;
            editbtn.IconChar = FontAwesome.Sharp.IconChar.Pen;
            editbtn.IconColor = Color.White;
            editbtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            editbtn.IconSize = 19;
            editbtn.ImageAlign = ContentAlignment.MiddleRight;
            editbtn.Location = new Point(320, 339);
            editbtn.Name = "editbtn";
            editbtn.Size = new Size(252, 26);
            editbtn.TabIndex = 13;
            editbtn.Text = "Edit";
            editbtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            editbtn.UseVisualStyleBackColor = false;
            editbtn.Click += editbtn_Click;
            // 
            // deactbtn
            // 
            deactbtn.BackColor = Color.Red;
            deactbtn.FlatAppearance.BorderSize = 0;
            deactbtn.FlatStyle = FlatStyle.Flat;
            deactbtn.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            deactbtn.ForeColor = Color.Black;
            deactbtn.IconChar = FontAwesome.Sharp.IconChar.Lock;
            deactbtn.IconColor = Color.Black;
            deactbtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            deactbtn.IconSize = 20;
            deactbtn.ImageAlign = ContentAlignment.MiddleRight;
            deactbtn.Location = new Point(463, 19);
            deactbtn.Name = "deactbtn";
            deactbtn.Size = new Size(109, 26);
            deactbtn.TabIndex = 14;
            deactbtn.Text = "Deactivate";
            deactbtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            deactbtn.UseVisualStyleBackColor = false;
            deactbtn.Click += deactbtn_Click;
            // 
            // idtxt
            // 
            idtxt.AutoSize = true;
            idtxt.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            idtxt.Location = new Point(144, 24);
            idtxt.Name = "idtxt";
            idtxt.Size = new Size(19, 21);
            idtxt.TabIndex = 15;
            idtxt.Text = "0";
            // 
            // showpassbtn
            // 
            showpassbtn.BackColor = Color.White;
            showpassbtn.FlatAppearance.BorderSize = 0;
            showpassbtn.FlatStyle = FlatStyle.Popup;
            showpassbtn.ForeColor = Color.Black;
            showpassbtn.IconChar = FontAwesome.Sharp.IconChar.Eye;
            showpassbtn.IconColor = Color.FromArgb(31, 30, 68);
            showpassbtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            showpassbtn.IconSize = 35;
            showpassbtn.Location = new Point(532, 267);
            showpassbtn.Name = "showpassbtn";
            showpassbtn.Size = new Size(40, 26);
            showpassbtn.TabIndex = 21;
            showpassbtn.UseVisualStyleBackColor = false;
            showpassbtn.Click += showpassbtn_Click;
            // 
            // hidepassbtn
            // 
            hidepassbtn.BackColor = Color.White;
            hidepassbtn.FlatAppearance.BorderSize = 0;
            hidepassbtn.FlatStyle = FlatStyle.Popup;
            hidepassbtn.ForeColor = Color.Black;
            hidepassbtn.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            hidepassbtn.IconColor = Color.FromArgb(31, 30, 68);
            hidepassbtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            hidepassbtn.IconSize = 35;
            hidepassbtn.Location = new Point(532, 267);
            hidepassbtn.Name = "hidepassbtn";
            hidepassbtn.Size = new Size(40, 26);
            hidepassbtn.TabIndex = 22;
            hidepassbtn.UseVisualStyleBackColor = false;
            hidepassbtn.Click += hidepassbtn_Click;
            // 
            // UserAccount
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(612, 401);
            Controls.Add(idtxt);
            Controls.Add(deactbtn);
            Controls.Add(editbtn);
            Controls.Add(gendertxt);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(emailtxt);
            Controls.Add(usernametxt);
            Controls.Add(fnametxt);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(namelbl);
            Controls.Add(showpassbtn);
            Controls.Add(hidepassbtn);
            Controls.Add(passtxt);
            FormBorderStyle = FormBorderStyle.None;
            Name = "UserAccount";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Account Information";
            Load += UserAccount_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label namelbl;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox fnametxt;
        private TextBox usernametxt;
        private TextBox passtxt;
        private TextBox emailtxt;
        private Label label6;
        private Label label7;
        private ComboBox gendertxt;
        private FontAwesome.Sharp.IconButton editbtn;
        private FontAwesome.Sharp.IconButton deactbtn;
        private Label idtxt;
        private FontAwesome.Sharp.IconButton showpassbtn;
        private FontAwesome.Sharp.IconButton hidepassbtn;
    }
}