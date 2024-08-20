namespace DVL_Project
{
    partial class frmPepole
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
            System.Windows.Forms.Button btnAddPerson;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPepole));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvPepolesInfo = new System.Windows.Forms.DataGridView();
            this.cmsCommandMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDetailseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addNewPersonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.sendPhoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendEmailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblRecordes = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFiltersBy = new System.Windows.Forms.ComboBox();
            this.tbFilterBy = new System.Windows.Forms.TextBox();
            this.smallImages = new System.Windows.Forms.ImageList(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            btnAddPerson = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPepolesInfo)).BeginInit();
            this.cmsCommandMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddPerson
            // 
            btnAddPerson.BackColor = System.Drawing.Color.Transparent;
            btnAddPerson.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            btnAddPerson.Cursor = System.Windows.Forms.Cursors.Hand;
            btnAddPerson.FlatAppearance.BorderSize = 0;
            btnAddPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAddPerson.Image = ((System.Drawing.Image)(resources.GetObject("btnAddPerson.Image")));
            btnAddPerson.Location = new System.Drawing.Point(1072, 174);
            btnAddPerson.Name = "btnAddPerson";
            btnAddPerson.Size = new System.Drawing.Size(32, 36);
            btnAddPerson.TabIndex = 9;
            btnAddPerson.UseVisualStyleBackColor = false;
            btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Dubai", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(445, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Manage Pepole";
            // 
            // dgvPepolesInfo
            // 
            this.dgvPepolesInfo.AllowDrop = true;
            this.dgvPepolesInfo.AllowUserToAddRows = false;
            this.dgvPepolesInfo.AllowUserToDeleteRows = false;
            this.dgvPepolesInfo.AllowUserToOrderColumns = true;
            this.dgvPepolesInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvPepolesInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPepolesInfo.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Dubai", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPepolesInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPepolesInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPepolesInfo.ContextMenuStrip = this.cmsCommandMenu;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Dubai", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPepolesInfo.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPepolesInfo.GridColor = System.Drawing.SystemColors.Control;
            this.dgvPepolesInfo.Location = new System.Drawing.Point(4, 211);
            this.dgvPepolesInfo.Name = "dgvPepolesInfo";
            this.dgvPepolesInfo.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Dubai", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPepolesInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPepolesInfo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvPepolesInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvPepolesInfo.Size = new System.Drawing.Size(1102, 332);
            this.dgvPepolesInfo.TabIndex = 2;
            // 
            // cmsCommandMenu
            // 
            this.cmsCommandMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailseToolStripMenuItem,
            this.toolStripSeparator1,
            this.addNewPersonToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripSeparator2,
            this.sendPhoneToolStripMenuItem,
            this.sendEmailToolStripMenuItem});
            this.cmsCommandMenu.Name = "cmsCommandMenu";
            this.cmsCommandMenu.Size = new System.Drawing.Size(163, 148);
            // 
            // showDetailseToolStripMenuItem
            // 
            this.showDetailseToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showDetailseToolStripMenuItem.Image")));
            this.showDetailseToolStripMenuItem.Name = "showDetailseToolStripMenuItem";
            this.showDetailseToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.showDetailseToolStripMenuItem.Text = "Show Detailse";
            this.showDetailseToolStripMenuItem.Click += new System.EventHandler(this.showDetailseToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(159, 6);
            // 
            // addNewPersonToolStripMenuItem
            // 
            this.addNewPersonToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addNewPersonToolStripMenuItem.Image")));
            this.addNewPersonToolStripMenuItem.Name = "addNewPersonToolStripMenuItem";
            this.addNewPersonToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.addNewPersonToolStripMenuItem.Text = "Add New Person";
            this.addNewPersonToolStripMenuItem.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editToolStripMenuItem.Image")));
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteToolStripMenuItem.Image")));
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(159, 6);
            // 
            // sendPhoneToolStripMenuItem
            // 
            this.sendPhoneToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("sendPhoneToolStripMenuItem.Image")));
            this.sendPhoneToolStripMenuItem.Name = "sendPhoneToolStripMenuItem";
            this.sendPhoneToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.sendPhoneToolStripMenuItem.Text = "Phone Call";
            this.sendPhoneToolStripMenuItem.Click += new System.EventHandler(this.sendPhoneToolStripMenuItem_Click);
            // 
            // sendEmailToolStripMenuItem
            // 
            this.sendEmailToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("sendEmailToolStripMenuItem.Image")));
            this.sendEmailToolStripMenuItem.Name = "sendEmailToolStripMenuItem";
            this.sendEmailToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.sendEmailToolStripMenuItem.Text = "Send Email";
            this.sendEmailToolStripMenuItem.Click += new System.EventHandler(this.sendEmailToolStripMenuItem_Click);
            // 
            // lblRecordes
            // 
            this.lblRecordes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRecordes.AutoSize = true;
            this.lblRecordes.Font = new System.Drawing.Font("Dubai", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordes.Location = new System.Drawing.Point(4, 553);
            this.lblRecordes.Name = "lblRecordes";
            this.lblRecordes.Size = new System.Drawing.Size(81, 25);
            this.lblRecordes.TabIndex = 5;
            this.lblRecordes.Text = "#Records : ";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Dubai", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Find By : ";
            // 
            // cbFiltersBy
            // 
            this.cbFiltersBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFiltersBy.Font = new System.Drawing.Font("Dubai", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFiltersBy.FormattingEnabled = true;
            this.cbFiltersBy.Items.AddRange(new object[] {
            "None",
            "PersonID",
            "NationalNo",
            "Email",
            "Phone",
            "FirstName",
            "SecondName",
            "ThirdName",
            "LastName",
            "Gender",
            "Nationality"});
            this.cbFiltersBy.Location = new System.Drawing.Point(86, 182);
            this.cbFiltersBy.Name = "cbFiltersBy";
            this.cbFiltersBy.Size = new System.Drawing.Size(128, 26);
            this.cbFiltersBy.TabIndex = 7;
            this.cbFiltersBy.SelectedIndexChanged += new System.EventHandler(this.cbFiltersBy_SelectedIndexChanged);
            // 
            // tbFilterBy
            // 
            this.tbFilterBy.Font = new System.Drawing.Font("Dubai", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFilterBy.Location = new System.Drawing.Point(231, 182);
            this.tbFilterBy.Name = "tbFilterBy";
            this.tbFilterBy.Size = new System.Drawing.Size(198, 26);
            this.tbFilterBy.TabIndex = 8;
            this.tbFilterBy.Visible = false;
            this.tbFilterBy.TextChanged += new System.EventHandler(this.tbFiltersBy_TextChanged);
            // 
            // smallImages
            // 
            this.smallImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("smallImages.ImageStream")));
            this.smallImages.TransparentColor = System.Drawing.Color.Transparent;
            this.smallImages.Images.SetKeyName(0, "Add Person.png");
            this.smallImages.Images.SetKeyName(1, "account_settings.png");
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("Dubai", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1002, 549);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(102, 29);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(451, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(131, 108);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // frmPepole
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1108, 582);
            this.Controls.Add(btnAddPerson);
            this.Controls.Add(this.tbFilterBy);
            this.Controls.Add(this.cbFiltersBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblRecordes);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvPepolesInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPepole";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Pepole";
            this.Load += new System.EventHandler(this.frmPepole_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPepolesInfo)).EndInit();
            this.cmsCommandMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvPepolesInfo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblRecordes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbFiltersBy;
        private System.Windows.Forms.TextBox tbFilterBy;
        private System.Windows.Forms.ImageList smallImages;
        private System.Windows.Forms.ContextMenuStrip cmsCommandMenu;
        private System.Windows.Forms.ToolStripMenuItem showDetailseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem addNewPersonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem sendPhoneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendEmailToolStripMenuItem;
    }
}