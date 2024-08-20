namespace DVL_Project.Applications.Application_Controls
{
    partial class ctrDrivingLicenseApplicationInfo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblPassedTestCount = new System.Windows.Forms.Label();
            this.lblClassName = new System.Windows.Forms.Label();
            this.lblDrivingLicenseApplicationID = new System.Windows.Forms.Label();
            this.lblShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ctrlApplicationInfo2 = new DVL_Project.Applications.Application_Controls.ctrlApplicationInfo();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.lblPassedTestCount);
            this.groupBox2.Controls.Add(this.lblClassName);
            this.groupBox2.Controls.Add(this.lblDrivingLicenseApplicationID);
            this.groupBox2.Controls.Add(this.lblShowLicenseInfo);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(730, 125);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Driving License Application Info";
            // 
            // lblPassedTestCount
            // 
            this.lblPassedTestCount.AutoSize = true;
            this.lblPassedTestCount.Font = new System.Drawing.Font("Dubai", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassedTestCount.ForeColor = System.Drawing.Color.Red;
            this.lblPassedTestCount.Location = new System.Drawing.Point(442, 76);
            this.lblPassedTestCount.Name = "lblPassedTestCount";
            this.lblPassedTestCount.Size = new System.Drawing.Size(44, 22);
            this.lblPassedTestCount.TabIndex = 10;
            this.lblPassedTestCount.Text = "[????]";
            // 
            // lblClassName
            // 
            this.lblClassName.AutoSize = true;
            this.lblClassName.Font = new System.Drawing.Font("Dubai", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClassName.ForeColor = System.Drawing.Color.Red;
            this.lblClassName.Location = new System.Drawing.Point(442, 32);
            this.lblClassName.Name = "lblClassName";
            this.lblClassName.Size = new System.Drawing.Size(44, 22);
            this.lblClassName.TabIndex = 9;
            this.lblClassName.Text = "[????]";
            // 
            // lblDrivingLicenseApplicationID
            // 
            this.lblDrivingLicenseApplicationID.AutoSize = true;
            this.lblDrivingLicenseApplicationID.Font = new System.Drawing.Font("Dubai", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDrivingLicenseApplicationID.ForeColor = System.Drawing.Color.Red;
            this.lblDrivingLicenseApplicationID.Location = new System.Drawing.Point(116, 32);
            this.lblDrivingLicenseApplicationID.Name = "lblDrivingLicenseApplicationID";
            this.lblDrivingLicenseApplicationID.Size = new System.Drawing.Size(44, 22);
            this.lblDrivingLicenseApplicationID.TabIndex = 8;
            this.lblDrivingLicenseApplicationID.Text = "[????]";
            // 
            // lblShowLicenseInfo
            // 
            this.lblShowLicenseInfo.AutoSize = true;
            this.lblShowLicenseInfo.Font = new System.Drawing.Font("Dubai", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowLicenseInfo.Location = new System.Drawing.Point(95, 85);
            this.lblShowLicenseInfo.Name = "lblShowLicenseInfo";
            this.lblShowLicenseInfo.Size = new System.Drawing.Size(109, 22);
            this.lblShowLicenseInfo.TabIndex = 7;
            this.lblShowLicenseInfo.TabStop = true;
            this.lblShowLicenseInfo.Text = "Show License Info";
            this.lblShowLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblShowLicenseInfo_LinkClicked);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Dubai", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(333, 76);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 22);
            this.label11.TabIndex = 3;
            this.label11.Text = "Passed Tests :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Dubai", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(297, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(124, 22);
            this.label10.TabIndex = 2;
            this.label10.Text = "Applied For License :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Dubai", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(22, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 22);
            this.label9.TabIndex = 1;
            this.label9.Text = "D.L.AppID :";
            // 
            // ctrlApplicationInfo2
            // 
            this.ctrlApplicationInfo2.BackColor = System.Drawing.Color.White;
            this.ctrlApplicationInfo2.Location = new System.Drawing.Point(3, 134);
            this.ctrlApplicationInfo2.Name = "ctrlApplicationInfo2";
            this.ctrlApplicationInfo2.Size = new System.Drawing.Size(734, 221);
            this.ctrlApplicationInfo2.TabIndex = 3;
            // 
            // ctrDrivingLicenseApplicationInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ctrlApplicationInfo2);
            this.Controls.Add(this.groupBox2);
            this.Name = "ctrDrivingLicenseApplicationInfo";
            this.Size = new System.Drawing.Size(738, 357);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblPassedTestCount;
        private System.Windows.Forms.Label lblClassName;
        private System.Windows.Forms.Label lblDrivingLicenseApplicationID;
        private System.Windows.Forms.LinkLabel lblShowLicenseInfo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private ctrlApplicationInfo ctrlApplicationInfo2;
    }
}
