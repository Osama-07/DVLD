namespace DVL_Project.Users_Screens
{
    partial class frmChangePassword
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChangePassword));
            this.tbRenterNewPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbNewPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tbOldPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnShowOldPassword = new System.Windows.Forms.Button();
            this.btnShowNewPassword = new System.Windows.Forms.Button();
            this.btnShowRenterPassword = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbRenterNewPassword
            // 
            this.tbRenterNewPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbRenterNewPassword.Font = new System.Drawing.Font("Dubai", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRenterNewPassword.Location = new System.Drawing.Point(136, 101);
            this.tbRenterNewPassword.Name = "tbRenterNewPassword";
            this.tbRenterNewPassword.Size = new System.Drawing.Size(176, 26);
            this.tbRenterNewPassword.TabIndex = 2;
            this.tbRenterNewPassword.UseSystemPasswordChar = true;
            this.tbRenterNewPassword.Validating += new System.ComponentModel.CancelEventHandler(this.PasswordValidating);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Dubai", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(24, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 22);
            this.label5.TabIndex = 10;
            this.label5.Text = " Renter Password";
            // 
            // tbNewPassword
            // 
            this.tbNewPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbNewPassword.Font = new System.Drawing.Font("Dubai", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNewPassword.Location = new System.Drawing.Point(136, 64);
            this.tbNewPassword.Name = "tbNewPassword";
            this.tbNewPassword.Size = new System.Drawing.Size(176, 26);
            this.tbNewPassword.TabIndex = 1;
            this.tbNewPassword.UseSystemPasswordChar = true;
            this.tbNewPassword.Validating += new System.ComponentModel.CancelEventHandler(this.PasswordValidating);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Dubai", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(40, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 22);
            this.label4.TabIndex = 8;
            this.label4.Text = "New Password";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("Dubai", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(288, 173);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(101, 29);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("Dubai", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(184, 173);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(98, 29);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tbOldPassword
            // 
            this.tbOldPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbOldPassword.Font = new System.Drawing.Font("Dubai", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOldPassword.Location = new System.Drawing.Point(136, 27);
            this.tbOldPassword.Name = "tbOldPassword";
            this.tbOldPassword.Size = new System.Drawing.Size(176, 26);
            this.tbOldPassword.TabIndex = 0;
            this.tbOldPassword.UseSystemPasswordChar = true;
            this.tbOldPassword.Validating += new System.ComponentModel.CancelEventHandler(this.tbOldPassword_Validating);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Dubai", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 22);
            this.label1.TabIndex = 14;
            this.label1.Text = "Old Password";
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkRate = 20;
            this.errorProvider1.ContainerControl = this;
            // 
            // btnShowOldPassword
            // 
            this.btnShowOldPassword.BackColor = System.Drawing.Color.White;
            this.btnShowOldPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowOldPassword.FlatAppearance.BorderSize = 0;
            this.btnShowOldPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowOldPassword.Image = ((System.Drawing.Image)(resources.GetObject("btnShowOldPassword.Image")));
            this.btnShowOldPassword.Location = new System.Drawing.Point(282, 28);
            this.btnShowOldPassword.Name = "btnShowOldPassword";
            this.btnShowOldPassword.Size = new System.Drawing.Size(29, 23);
            this.btnShowOldPassword.TabIndex = 15;
            this.btnShowOldPassword.UseVisualStyleBackColor = false;
            this.btnShowOldPassword.Click += new System.EventHandler(this.btnShowOldPassword_Click);
            // 
            // btnShowNewPassword
            // 
            this.btnShowNewPassword.BackColor = System.Drawing.Color.White;
            this.btnShowNewPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowNewPassword.FlatAppearance.BorderSize = 0;
            this.btnShowNewPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowNewPassword.Image = ((System.Drawing.Image)(resources.GetObject("btnShowNewPassword.Image")));
            this.btnShowNewPassword.Location = new System.Drawing.Point(282, 65);
            this.btnShowNewPassword.Name = "btnShowNewPassword";
            this.btnShowNewPassword.Size = new System.Drawing.Size(29, 23);
            this.btnShowNewPassword.TabIndex = 16;
            this.btnShowNewPassword.UseVisualStyleBackColor = false;
            this.btnShowNewPassword.Click += new System.EventHandler(this.btnShowNewPassword_Click);
            // 
            // btnShowRenterPassword
            // 
            this.btnShowRenterPassword.BackColor = System.Drawing.Color.White;
            this.btnShowRenterPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowRenterPassword.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnShowRenterPassword.FlatAppearance.BorderSize = 0;
            this.btnShowRenterPassword.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnShowRenterPassword.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnShowRenterPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowRenterPassword.Image = ((System.Drawing.Image)(resources.GetObject("btnShowRenterPassword.Image")));
            this.btnShowRenterPassword.Location = new System.Drawing.Point(282, 102);
            this.btnShowRenterPassword.Name = "btnShowRenterPassword";
            this.btnShowRenterPassword.Size = new System.Drawing.Size(29, 23);
            this.btnShowRenterPassword.TabIndex = 17;
            this.btnShowRenterPassword.UseVisualStyleBackColor = false;
            this.btnShowRenterPassword.Click += new System.EventHandler(this.btnShowRenterPassword_Click);
            // 
            // frmChangePassword
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 210);
            this.Controls.Add(this.btnShowRenterPassword);
            this.Controls.Add(this.btnShowNewPassword);
            this.Controls.Add(this.btnShowOldPassword);
            this.Controls.Add(this.tbOldPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tbRenterNewPassword);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbNewPassword);
            this.Controls.Add(this.label4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmChangePassword";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbRenterNewPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbNewPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox tbOldPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnShowOldPassword;
        private System.Windows.Forms.Button btnShowRenterPassword;
        private System.Windows.Forms.Button btnShowNewPassword;
    }
}