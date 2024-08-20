namespace DVL_Project.Applications.Detain_Licenses
{
    partial class frmReleaseLicense
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReleaseLicense));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ctrFindLicense1 = new DVL_Project.ctrFindLicense();
            this.gbReleaseInfo = new System.Windows.Forms.GroupBox();
            this.lblApplicationID = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblReleaseDate = new System.Windows.Forms.Label();
            this.lblReleasedByUser = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.tbDetaineFees = new System.Windows.Forms.TextBox();
            this.lblDetaineByUser = new System.Windows.Forms.Label();
            this.lblLicenseID = new System.Windows.Forms.Label();
            this.lblDetaineDate = new System.Windows.Forms.Label();
            this.lblDetaineID = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRelease = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblShowLicensesHistory = new System.Windows.Forms.LinkLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbReleaseInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Dubai", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(279, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 49);
            this.label1.TabIndex = 5;
            this.label1.Text = "Release License";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(320, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(117, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // ctrFindLicense1
            // 
            this.ctrFindLicense1.BackColor = System.Drawing.Color.White;
            this.ctrFindLicense1.Location = new System.Drawing.Point(1, 118);
            this.ctrFindLicense1.Name = "ctrFindLicense1";
            this.ctrFindLicense1.Size = new System.Drawing.Size(760, 357);
            this.ctrFindLicense1.TabIndex = 7;
            this.ctrFindLicense1.OnFindLicense += new System.Action<int>(this.ctrFindLicense1_OnFindLicense);
            this.ctrFindLicense1.OnResetInfo += new System.Action<int>(this.ctrFindLicense1_OnResetInfo);
            // 
            // gbReleaseInfo
            // 
            this.gbReleaseInfo.Controls.Add(this.lblApplicationID);
            this.gbReleaseInfo.Controls.Add(this.label8);
            this.gbReleaseInfo.Controls.Add(this.lblReleaseDate);
            this.gbReleaseInfo.Controls.Add(this.lblReleasedByUser);
            this.gbReleaseInfo.Controls.Add(this.label9);
            this.gbReleaseInfo.Controls.Add(this.label);
            this.gbReleaseInfo.Controls.Add(this.tbDetaineFees);
            this.gbReleaseInfo.Controls.Add(this.lblDetaineByUser);
            this.gbReleaseInfo.Controls.Add(this.lblLicenseID);
            this.gbReleaseInfo.Controls.Add(this.lblDetaineDate);
            this.gbReleaseInfo.Controls.Add(this.lblDetaineID);
            this.gbReleaseInfo.Controls.Add(this.label6);
            this.gbReleaseInfo.Controls.Add(this.label5);
            this.gbReleaseInfo.Controls.Add(this.label4);
            this.gbReleaseInfo.Controls.Add(this.label3);
            this.gbReleaseInfo.Controls.Add(this.label2);
            this.gbReleaseInfo.Enabled = false;
            this.gbReleaseInfo.Location = new System.Drawing.Point(7, 470);
            this.gbReleaseInfo.Name = "gbReleaseInfo";
            this.gbReleaseInfo.Size = new System.Drawing.Size(750, 175);
            this.gbReleaseInfo.TabIndex = 14;
            this.gbReleaseInfo.TabStop = false;
            this.gbReleaseInfo.Text = "Release License Info";
            // 
            // lblApplicationID
            // 
            this.lblApplicationID.AutoSize = true;
            this.lblApplicationID.Font = new System.Drawing.Font("Dubai", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationID.Location = new System.Drawing.Point(521, 27);
            this.lblApplicationID.Name = "lblApplicationID";
            this.lblApplicationID.Size = new System.Drawing.Size(42, 21);
            this.lblApplicationID.TabIndex = 17;
            this.lblApplicationID.Text = "[????]";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Dubai", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(405, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 21);
            this.label8.TabIndex = 16;
            this.label8.Text = "Release_App ID:";
            // 
            // lblReleaseDate
            // 
            this.lblReleaseDate.AutoSize = true;
            this.lblReleaseDate.Font = new System.Drawing.Font("Dubai", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReleaseDate.Location = new System.Drawing.Point(521, 89);
            this.lblReleaseDate.Name = "lblReleaseDate";
            this.lblReleaseDate.Size = new System.Drawing.Size(42, 21);
            this.lblReleaseDate.TabIndex = 15;
            this.lblReleaseDate.Text = "[????]";
            // 
            // lblReleasedByUser
            // 
            this.lblReleasedByUser.AutoSize = true;
            this.lblReleasedByUser.Font = new System.Drawing.Font("Dubai", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReleasedByUser.Location = new System.Drawing.Point(521, 119);
            this.lblReleasedByUser.Name = "lblReleasedByUser";
            this.lblReleasedByUser.Size = new System.Drawing.Size(42, 21);
            this.lblReleasedByUser.TabIndex = 14;
            this.lblReleasedByUser.Text = "[????]";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Dubai", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(405, 119);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 21);
            this.label9.TabIndex = 13;
            this.label9.Text = "Released By User:";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Dubai", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(405, 89);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(78, 21);
            this.label.TabIndex = 11;
            this.label.Text = "Release Date:";
            // 
            // tbDetaineFees
            // 
            this.tbDetaineFees.Font = new System.Drawing.Font("Dubai", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDetaineFees.Location = new System.Drawing.Point(143, 129);
            this.tbDetaineFees.Name = "tbDetaineFees";
            this.tbDetaineFees.Size = new System.Drawing.Size(98, 26);
            this.tbDetaineFees.TabIndex = 10;
            this.tbDetaineFees.TextChanged += new System.EventHandler(this.tbDetaineFees_TextChanged);
            // 
            // lblDetaineByUser
            // 
            this.lblDetaineByUser.AutoSize = true;
            this.lblDetaineByUser.Font = new System.Drawing.Font("Dubai", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetaineByUser.Location = new System.Drawing.Point(150, 89);
            this.lblDetaineByUser.Name = "lblDetaineByUser";
            this.lblDetaineByUser.Size = new System.Drawing.Size(42, 21);
            this.lblDetaineByUser.TabIndex = 9;
            this.lblDetaineByUser.Text = "[????]";
            // 
            // lblLicenseID
            // 
            this.lblLicenseID.AutoSize = true;
            this.lblLicenseID.Font = new System.Drawing.Font("Dubai", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseID.Location = new System.Drawing.Point(521, 57);
            this.lblLicenseID.Name = "lblLicenseID";
            this.lblLicenseID.Size = new System.Drawing.Size(42, 21);
            this.lblLicenseID.TabIndex = 8;
            this.lblLicenseID.Text = "[????]";
            // 
            // lblDetaineDate
            // 
            this.lblDetaineDate.AutoSize = true;
            this.lblDetaineDate.Font = new System.Drawing.Font("Dubai", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetaineDate.Location = new System.Drawing.Point(150, 57);
            this.lblDetaineDate.Name = "lblDetaineDate";
            this.lblDetaineDate.Size = new System.Drawing.Size(42, 21);
            this.lblDetaineDate.TabIndex = 6;
            this.lblDetaineDate.Text = "[????]";
            // 
            // lblDetaineID
            // 
            this.lblDetaineID.AutoSize = true;
            this.lblDetaineID.Font = new System.Drawing.Font("Dubai", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetaineID.Location = new System.Drawing.Point(150, 27);
            this.lblDetaineID.Name = "lblDetaineID";
            this.lblDetaineID.Size = new System.Drawing.Size(42, 21);
            this.lblDetaineID.TabIndex = 5;
            this.lblDetaineID.Text = "[????]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Dubai", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(34, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 21);
            this.label6.TabIndex = 4;
            this.label6.Text = "Detained By User:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Dubai", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(405, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 21);
            this.label5.TabIndex = 3;
            this.label5.Text = "License ID:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Dubai", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(35, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 21);
            this.label4.TabIndex = 2;
            this.label4.Text = "Detaine Fees:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Dubai", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(35, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 21);
            this.label3.TabIndex = 1;
            this.label3.Text = "Detaine Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Dubai", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Detaine ID:";
            // 
            // btnRelease
            // 
            this.btnRelease.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRelease.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRelease.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRelease.Enabled = false;
            this.btnRelease.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRelease.Font = new System.Drawing.Font("Dubai", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRelease.Image = ((System.Drawing.Image)(resources.GetObject("btnRelease.Image")));
            this.btnRelease.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRelease.Location = new System.Drawing.Point(604, 661);
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Size = new System.Drawing.Size(153, 32);
            this.btnRelease.TabIndex = 17;
            this.btnRelease.Text = "Release";
            this.btnRelease.UseVisualStyleBackColor = true;
            this.btnRelease.Click += new System.EventHandler(this.btnRelease_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Dubai", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(500, 660);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(98, 33);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblShowLicensesHistory
            // 
            this.lblShowLicensesHistory.AutoSize = true;
            this.lblShowLicensesHistory.Enabled = false;
            this.lblShowLicensesHistory.Font = new System.Drawing.Font("Dubai", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowLicensesHistory.Location = new System.Drawing.Point(27, 669);
            this.lblShowLicensesHistory.Name = "lblShowLicensesHistory";
            this.lblShowLicensesHistory.Size = new System.Drawing.Size(134, 22);
            this.lblShowLicensesHistory.TabIndex = 15;
            this.lblShowLicensesHistory.TabStop = true;
            this.lblShowLicensesHistory.Text = "Show Licenses History";
            this.lblShowLicensesHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblShowLicensesHistory_LinkClicked);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkRate = 20;
            this.errorProvider1.ContainerControl = this;
            // 
            // frmReleaseLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(761, 698);
            this.Controls.Add(this.btnRelease);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblShowLicensesHistory);
            this.Controls.Add(this.gbReleaseInfo);
            this.Controls.Add(this.ctrFindLicense1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReleaseLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Release License";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gbReleaseInfo.ResumeLayout(false);
            this.gbReleaseInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private ctrFindLicense ctrFindLicense1;
        private System.Windows.Forms.GroupBox gbReleaseInfo;
        private System.Windows.Forms.TextBox tbDetaineFees;
        private System.Windows.Forms.Label lblDetaineByUser;
        private System.Windows.Forms.Label lblLicenseID;
        private System.Windows.Forms.Label lblDetaineDate;
        private System.Windows.Forms.Label lblDetaineID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblReleasedByUser;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button btnRelease;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.LinkLabel lblShowLicensesHistory;
        private System.Windows.Forms.Label lblReleaseDate;
        private System.Windows.Forms.Label lblApplicationID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}