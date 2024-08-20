namespace DVL_Project.Applications.Detain_Licenses
{
    partial class frmDerainLicense
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDerainLicense));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDetain = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblShowLicensesHistory = new System.Windows.Forms.LinkLabel();
            this.gbDetaineInfo = new System.Windows.Forms.GroupBox();
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
            this.ctrFindLicense1 = new DVL_Project.ctrFindLicense();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbDetaineInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(321, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(117, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Dubai", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(276, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 49);
            this.label1.TabIndex = 3;
            this.label1.Text = "Detain License";
            // 
            // btnDetain
            // 
            this.btnDetain.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDetain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDetain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDetain.Enabled = false;
            this.btnDetain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetain.Font = new System.Drawing.Font("Dubai", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetain.Image = ((System.Drawing.Image)(resources.GetObject("btnDetain.Image")));
            this.btnDetain.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetain.Location = new System.Drawing.Point(606, 651);
            this.btnDetain.Name = "btnDetain";
            this.btnDetain.Size = new System.Drawing.Size(153, 32);
            this.btnDetain.TabIndex = 12;
            this.btnDetain.Text = "Detain";
            this.btnDetain.UseVisualStyleBackColor = true;
            this.btnDetain.Click += new System.EventHandler(this.btnDetain_Click);
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
            this.btnClose.Location = new System.Drawing.Point(502, 650);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(98, 33);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblShowLicensesHistory
            // 
            this.lblShowLicensesHistory.AutoSize = true;
            this.lblShowLicensesHistory.Enabled = false;
            this.lblShowLicensesHistory.Font = new System.Drawing.Font("Dubai", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowLicensesHistory.Location = new System.Drawing.Point(28, 659);
            this.lblShowLicensesHistory.Name = "lblShowLicensesHistory";
            this.lblShowLicensesHistory.Size = new System.Drawing.Size(134, 22);
            this.lblShowLicensesHistory.TabIndex = 9;
            this.lblShowLicensesHistory.TabStop = true;
            this.lblShowLicensesHistory.Text = "Show Licenses History";
            this.lblShowLicensesHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblShowLicensesHistory_LinkClicked);
            // 
            // gbDetaineInfo
            // 
            this.gbDetaineInfo.Controls.Add(this.tbDetaineFees);
            this.gbDetaineInfo.Controls.Add(this.lblDetaineByUser);
            this.gbDetaineInfo.Controls.Add(this.lblLicenseID);
            this.gbDetaineInfo.Controls.Add(this.lblDetaineDate);
            this.gbDetaineInfo.Controls.Add(this.lblDetaineID);
            this.gbDetaineInfo.Controls.Add(this.label6);
            this.gbDetaineInfo.Controls.Add(this.label5);
            this.gbDetaineInfo.Controls.Add(this.label4);
            this.gbDetaineInfo.Controls.Add(this.label3);
            this.gbDetaineInfo.Controls.Add(this.label2);
            this.gbDetaineInfo.Enabled = false;
            this.gbDetaineInfo.Location = new System.Drawing.Point(9, 484);
            this.gbDetaineInfo.Name = "gbDetaineInfo";
            this.gbDetaineInfo.Size = new System.Drawing.Size(750, 145);
            this.gbDetaineInfo.TabIndex = 13;
            this.gbDetaineInfo.TabStop = false;
            this.gbDetaineInfo.Text = "Detain License Info";
            // 
            // tbDetaineFees
            // 
            this.tbDetaineFees.Font = new System.Drawing.Font("Dubai", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDetaineFees.Location = new System.Drawing.Point(143, 95);
            this.tbDetaineFees.Name = "tbDetaineFees";
            this.tbDetaineFees.Size = new System.Drawing.Size(98, 26);
            this.tbDetaineFees.TabIndex = 10;
            this.tbDetaineFees.TextChanged += new System.EventHandler(this.tbDetaineFees_TextChanged);
            this.tbDetaineFees.Validating += new System.ComponentModel.CancelEventHandler(this.tbDetaineFees_Validating);
            // 
            // lblDetaineByUser
            // 
            this.lblDetaineByUser.AutoSize = true;
            this.lblDetaineByUser.Font = new System.Drawing.Font("Dubai", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetaineByUser.Location = new System.Drawing.Point(518, 76);
            this.lblDetaineByUser.Name = "lblDetaineByUser";
            this.lblDetaineByUser.Size = new System.Drawing.Size(42, 21);
            this.lblDetaineByUser.TabIndex = 9;
            this.lblDetaineByUser.Text = "[????]";
            // 
            // lblLicenseID
            // 
            this.lblLicenseID.AutoSize = true;
            this.lblLicenseID.Font = new System.Drawing.Font("Dubai", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseID.Location = new System.Drawing.Point(518, 35);
            this.lblLicenseID.Name = "lblLicenseID";
            this.lblLicenseID.Size = new System.Drawing.Size(42, 21);
            this.lblLicenseID.TabIndex = 8;
            this.lblLicenseID.Text = "[????]";
            // 
            // lblDetaineDate
            // 
            this.lblDetaineDate.AutoSize = true;
            this.lblDetaineDate.Font = new System.Drawing.Font("Dubai", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetaineDate.Location = new System.Drawing.Point(139, 65);
            this.lblDetaineDate.Name = "lblDetaineDate";
            this.lblDetaineDate.Size = new System.Drawing.Size(42, 21);
            this.lblDetaineDate.TabIndex = 6;
            this.lblDetaineDate.Text = "[????]";
            // 
            // lblDetaineID
            // 
            this.lblDetaineID.AutoSize = true;
            this.lblDetaineID.Font = new System.Drawing.Font("Dubai", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetaineID.Location = new System.Drawing.Point(139, 35);
            this.lblDetaineID.Name = "lblDetaineID";
            this.lblDetaineID.Size = new System.Drawing.Size(42, 21);
            this.lblDetaineID.TabIndex = 5;
            this.lblDetaineID.Text = "[????]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Dubai", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(402, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 21);
            this.label6.TabIndex = 4;
            this.label6.Text = "Detained By User:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Dubai", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(404, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 21);
            this.label5.TabIndex = 3;
            this.label5.Text = "License ID:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Dubai", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(35, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 21);
            this.label4.TabIndex = 2;
            this.label4.Text = "Detaine Fees:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Dubai", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(35, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 21);
            this.label3.TabIndex = 1;
            this.label3.Text = "Detaine Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Dubai", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Detaine ID:";
            // 
            // ctrFindLicense1
            // 
            this.ctrFindLicense1.BackColor = System.Drawing.Color.White;
            this.ctrFindLicense1.Location = new System.Drawing.Point(3, 132);
            this.ctrFindLicense1.Name = "ctrFindLicense1";
            this.ctrFindLicense1.Size = new System.Drawing.Size(760, 357);
            this.ctrFindLicense1.TabIndex = 0;
            this.ctrFindLicense1.OnFindLicense += new System.Action<int>(this.ctrFindLicense1_OnFindLicense);
            this.ctrFindLicense1.OnResetInfo += new System.Action<int>(this.ctrFindLicense1_OnResetInfo);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkRate = 20;
            this.errorProvider1.ContainerControl = this;
            // 
            // frmDerainLicense
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(762, 690);
            this.Controls.Add(this.gbDetaineInfo);
            this.Controls.Add(this.btnDetain);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblShowLicensesHistory);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrFindLicense1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDerainLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Derain License";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gbDetaineInfo.ResumeLayout(false);
            this.gbDetaineInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrFindLicense ctrFindLicense1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDetain;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.LinkLabel lblShowLicensesHistory;
        private System.Windows.Forms.GroupBox gbDetaineInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDetaineByUser;
        private System.Windows.Forms.Label lblLicenseID;
        private System.Windows.Forms.Label lblDetaineDate;
        private System.Windows.Forms.Label lblDetaineID;
        private System.Windows.Forms.TextBox tbDetaineFees;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}