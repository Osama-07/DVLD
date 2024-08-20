namespace DVL_Project.Applications.Driving_Licenses_Services
{
    partial class frmRenewLicenses
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRenewLicenses));
            this.label1 = new System.Windows.Forms.Label();
            this.ctrFindLicense1 = new DVL_Project.ctrFindLicense();
            this.lblShowNewLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.lblShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.btnIssue = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbApplicationNewLicenseInfo = new System.Windows.Forms.GroupBox();
            this.tbNotes = new System.Windows.Forms.TextBox();
            this.lblTotlaFees = new System.Windows.Forms.Label();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.lblExpirationDate = new System.Windows.Forms.Label();
            this.lblOldLicenseID = new System.Windows.Forms.Label();
            this.lblRenewedLicenseID = new System.Windows.Forms.Label();
            this.lblLicenseFees = new System.Windows.Forms.Label();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.lblIssueDate = new System.Windows.Forms.Label();
            this.lblApplicationDate = new System.Windows.Forms.Label();
            this.lblR_L_ApplicationID = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gbApplicationNewLicenseInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Dubai", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(271, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Renew Licenses";
            // 
            // ctrFindLicense1
            // 
            this.ctrFindLicense1.BackColor = System.Drawing.Color.White;
            this.ctrFindLicense1.Location = new System.Drawing.Point(2, 57);
            this.ctrFindLicense1.Name = "ctrFindLicense1";
            this.ctrFindLicense1.Size = new System.Drawing.Size(760, 357);
            this.ctrFindLicense1.TabIndex = 1;
            this.ctrFindLicense1.OnFindLicense += new System.Action<int>(this.ctrFindLicense1_OnFindLicense);
            // 
            // lblShowNewLicenseInfo
            // 
            this.lblShowNewLicenseInfo.AutoSize = true;
            this.lblShowNewLicenseInfo.Enabled = false;
            this.lblShowNewLicenseInfo.Font = new System.Drawing.Font("Dubai", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowNewLicenseInfo.Location = new System.Drawing.Point(265, 660);
            this.lblShowNewLicenseInfo.Name = "lblShowNewLicenseInfo";
            this.lblShowNewLicenseInfo.Size = new System.Drawing.Size(109, 22);
            this.lblShowNewLicenseInfo.TabIndex = 13;
            this.lblShowNewLicenseInfo.TabStop = true;
            this.lblShowNewLicenseInfo.Text = "Show License Info";
            this.lblShowNewLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblShowLicenseInfo_LinkClicked);
            // 
            // lblShowLicenseHistory
            // 
            this.lblShowLicenseHistory.AutoSize = true;
            this.lblShowLicenseHistory.Enabled = false;
            this.lblShowLicenseHistory.Font = new System.Drawing.Font("Dubai", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowLicenseHistory.Location = new System.Drawing.Point(31, 663);
            this.lblShowLicenseHistory.Name = "lblShowLicenseHistory";
            this.lblShowLicenseHistory.Size = new System.Drawing.Size(128, 22);
            this.lblShowLicenseHistory.TabIndex = 12;
            this.lblShowLicenseHistory.TabStop = true;
            this.lblShowLicenseHistory.Text = "Show License History";
            this.lblShowLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblShowLicenseHistory_LinkClicked);
            // 
            // btnIssue
            // 
            this.btnIssue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnIssue.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnIssue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIssue.Enabled = false;
            this.btnIssue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIssue.Font = new System.Drawing.Font("Dubai", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssue.Image = global::DVL_Project.Properties.Resources.Driveing_Licenses_Services;
            this.btnIssue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIssue.Location = new System.Drawing.Point(604, 651);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(153, 35);
            this.btnIssue.TabIndex = 11;
            this.btnIssue.Text = "Issue New License";
            this.btnIssue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIssue.UseVisualStyleBackColor = true;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
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
            this.btnClose.Location = new System.Drawing.Point(500, 651);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(98, 35);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gbApplicationNewLicenseInfo
            // 
            this.gbApplicationNewLicenseInfo.Controls.Add(this.tbNotes);
            this.gbApplicationNewLicenseInfo.Controls.Add(this.lblTotlaFees);
            this.gbApplicationNewLicenseInfo.Controls.Add(this.lblCreatedBy);
            this.gbApplicationNewLicenseInfo.Controls.Add(this.lblExpirationDate);
            this.gbApplicationNewLicenseInfo.Controls.Add(this.lblOldLicenseID);
            this.gbApplicationNewLicenseInfo.Controls.Add(this.lblRenewedLicenseID);
            this.gbApplicationNewLicenseInfo.Controls.Add(this.lblLicenseFees);
            this.gbApplicationNewLicenseInfo.Controls.Add(this.lblApplicationFees);
            this.gbApplicationNewLicenseInfo.Controls.Add(this.lblIssueDate);
            this.gbApplicationNewLicenseInfo.Controls.Add(this.lblApplicationDate);
            this.gbApplicationNewLicenseInfo.Controls.Add(this.lblR_L_ApplicationID);
            this.gbApplicationNewLicenseInfo.Controls.Add(this.label12);
            this.gbApplicationNewLicenseInfo.Controls.Add(this.label11);
            this.gbApplicationNewLicenseInfo.Controls.Add(this.label10);
            this.gbApplicationNewLicenseInfo.Controls.Add(this.label9);
            this.gbApplicationNewLicenseInfo.Controls.Add(this.label8);
            this.gbApplicationNewLicenseInfo.Controls.Add(this.label7);
            this.gbApplicationNewLicenseInfo.Controls.Add(this.label6);
            this.gbApplicationNewLicenseInfo.Controls.Add(this.label5);
            this.gbApplicationNewLicenseInfo.Controls.Add(this.label4);
            this.gbApplicationNewLicenseInfo.Controls.Add(this.label3);
            this.gbApplicationNewLicenseInfo.Controls.Add(this.label2);
            this.gbApplicationNewLicenseInfo.Location = new System.Drawing.Point(8, 407);
            this.gbApplicationNewLicenseInfo.Name = "gbApplicationNewLicenseInfo";
            this.gbApplicationNewLicenseInfo.Size = new System.Drawing.Size(750, 238);
            this.gbApplicationNewLicenseInfo.TabIndex = 14;
            this.gbApplicationNewLicenseInfo.TabStop = false;
            this.gbApplicationNewLicenseInfo.Text = "Application New License Info";
            // 
            // tbNotes
            // 
            this.tbNotes.Location = new System.Drawing.Point(112, 186);
            this.tbNotes.Multiline = true;
            this.tbNotes.Name = "tbNotes";
            this.tbNotes.Size = new System.Drawing.Size(467, 46);
            this.tbNotes.TabIndex = 21;
            // 
            // lblTotlaFees
            // 
            this.lblTotlaFees.AutoSize = true;
            this.lblTotlaFees.Font = new System.Drawing.Font("Dubai", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotlaFees.Location = new System.Drawing.Point(537, 155);
            this.lblTotlaFees.Name = "lblTotlaFees";
            this.lblTotlaFees.Size = new System.Drawing.Size(42, 21);
            this.lblTotlaFees.TabIndex = 20;
            this.lblTotlaFees.Text = "[$$$$]";
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Font = new System.Drawing.Font("Dubai", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedBy.Location = new System.Drawing.Point(537, 125);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(42, 21);
            this.lblCreatedBy.TabIndex = 19;
            this.lblCreatedBy.Text = "[????]";
            // 
            // lblExpirationDate
            // 
            this.lblExpirationDate.AutoSize = true;
            this.lblExpirationDate.Font = new System.Drawing.Font("Dubai", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpirationDate.Location = new System.Drawing.Point(537, 95);
            this.lblExpirationDate.Name = "lblExpirationDate";
            this.lblExpirationDate.Size = new System.Drawing.Size(42, 21);
            this.lblExpirationDate.TabIndex = 18;
            this.lblExpirationDate.Text = "[????]";
            // 
            // lblOldLicenseID
            // 
            this.lblOldLicenseID.AutoSize = true;
            this.lblOldLicenseID.Font = new System.Drawing.Font("Dubai", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOldLicenseID.Location = new System.Drawing.Point(537, 64);
            this.lblOldLicenseID.Name = "lblOldLicenseID";
            this.lblOldLicenseID.Size = new System.Drawing.Size(42, 21);
            this.lblOldLicenseID.TabIndex = 17;
            this.lblOldLicenseID.Text = "[????]";
            // 
            // lblRenewedLicenseID
            // 
            this.lblRenewedLicenseID.AutoSize = true;
            this.lblRenewedLicenseID.Font = new System.Drawing.Font("Dubai", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRenewedLicenseID.Location = new System.Drawing.Point(537, 34);
            this.lblRenewedLicenseID.Name = "lblRenewedLicenseID";
            this.lblRenewedLicenseID.Size = new System.Drawing.Size(42, 21);
            this.lblRenewedLicenseID.TabIndex = 16;
            this.lblRenewedLicenseID.Text = "[????]";
            // 
            // lblLicenseFees
            // 
            this.lblLicenseFees.AutoSize = true;
            this.lblLicenseFees.Font = new System.Drawing.Font("Dubai", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseFees.Location = new System.Drawing.Point(170, 155);
            this.lblLicenseFees.Name = "lblLicenseFees";
            this.lblLicenseFees.Size = new System.Drawing.Size(42, 21);
            this.lblLicenseFees.TabIndex = 15;
            this.lblLicenseFees.Text = "[$$$$]";
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.AutoSize = true;
            this.lblApplicationFees.Font = new System.Drawing.Font("Dubai", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationFees.Location = new System.Drawing.Point(170, 125);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(42, 21);
            this.lblApplicationFees.TabIndex = 14;
            this.lblApplicationFees.Text = "[$$$$]";
            // 
            // lblIssueDate
            // 
            this.lblIssueDate.AutoSize = true;
            this.lblIssueDate.Font = new System.Drawing.Font("Dubai", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIssueDate.Location = new System.Drawing.Point(170, 95);
            this.lblIssueDate.Name = "lblIssueDate";
            this.lblIssueDate.Size = new System.Drawing.Size(42, 21);
            this.lblIssueDate.TabIndex = 13;
            this.lblIssueDate.Text = "[????]";
            // 
            // lblApplicationDate
            // 
            this.lblApplicationDate.AutoSize = true;
            this.lblApplicationDate.Font = new System.Drawing.Font("Dubai", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationDate.Location = new System.Drawing.Point(170, 64);
            this.lblApplicationDate.Name = "lblApplicationDate";
            this.lblApplicationDate.Size = new System.Drawing.Size(42, 21);
            this.lblApplicationDate.TabIndex = 12;
            this.lblApplicationDate.Text = "[????]";
            // 
            // lblR_L_ApplicationID
            // 
            this.lblR_L_ApplicationID.AutoSize = true;
            this.lblR_L_ApplicationID.Font = new System.Drawing.Font("Dubai", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblR_L_ApplicationID.Location = new System.Drawing.Point(170, 34);
            this.lblR_L_ApplicationID.Name = "lblR_L_ApplicationID";
            this.lblR_L_ApplicationID.Size = new System.Drawing.Size(42, 21);
            this.lblR_L_ApplicationID.TabIndex = 11;
            this.lblR_L_ApplicationID.Text = "[????]";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Dubai", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(405, 155);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 21);
            this.label12.TabIndex = 10;
            this.label12.Text = "Total Fees:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Dubai", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(405, 125);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 21);
            this.label11.TabIndex = 9;
            this.label11.Text = "Created By:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Dubai", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(405, 95);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 21);
            this.label10.TabIndex = 8;
            this.label10.Text = "Expiration Date:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Dubai", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(405, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 21);
            this.label9.TabIndex = 7;
            this.label9.Text = "Old License ID:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Dubai", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(405, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 21);
            this.label8.TabIndex = 6;
            this.label8.Text = "Renewed License ID:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Dubai", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(40, 185);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 21);
            this.label7.TabIndex = 5;
            this.label7.Text = "Notes:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Dubai", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(40, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 21);
            this.label6.TabIndex = 4;
            this.label6.Text = "License Fees:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Dubai", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(40, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 21);
            this.label5.TabIndex = 3;
            this.label5.Text = "Application Fees:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Dubai", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(40, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 21);
            this.label4.TabIndex = 2;
            this.label4.Text = "Issue Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Dubai", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(40, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 21);
            this.label3.TabIndex = 1;
            this.label3.Text = "Application Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Dubai", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "R.L.Application ID:";
            // 
            // frmRenewLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(762, 694);
            this.Controls.Add(this.gbApplicationNewLicenseInfo);
            this.Controls.Add(this.lblShowNewLicenseInfo);
            this.Controls.Add(this.lblShowLicenseHistory);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrFindLicense1);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRenewLicenses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Renew Licenses";
            this.Load += new System.EventHandler(this.frmRenewLicenses_Load);
            this.gbApplicationNewLicenseInfo.ResumeLayout(false);
            this.gbApplicationNewLicenseInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ctrFindLicense ctrFindLicense1;
        private System.Windows.Forms.LinkLabel lblShowNewLicenseInfo;
        private System.Windows.Forms.LinkLabel lblShowLicenseHistory;
        private System.Windows.Forms.Button btnIssue;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox gbApplicationNewLicenseInfo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNotes;
        private System.Windows.Forms.Label lblTotlaFees;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label lblExpirationDate;
        private System.Windows.Forms.Label lblOldLicenseID;
        private System.Windows.Forms.Label lblRenewedLicenseID;
        private System.Windows.Forms.Label lblLicenseFees;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.Label lblIssueDate;
        private System.Windows.Forms.Label lblApplicationDate;
        private System.Windows.Forms.Label lblR_L_ApplicationID;
    }
}