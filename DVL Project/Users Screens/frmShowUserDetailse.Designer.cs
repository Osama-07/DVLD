namespace DVL_Project.Users_Screens
{
    partial class frmShowUserDetailse
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
            this.label1 = new System.Windows.Forms.Label();
            this.ucUserInfo1 = new DVL_Project.ucUserInfo();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Dubai", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(262, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "User Detailse";
            // 
            // ucUserInfo1
            // 
            this.ucUserInfo1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucUserInfo1.Location = new System.Drawing.Point(0, 68);
            this.ucUserInfo1.Name = "ucUserInfo1";
            this.ucUserInfo1.Size = new System.Drawing.Size(748, 310);
            this.ucUserInfo1.TabIndex = 1;
            // 
            // ShowUserDetailse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(748, 378);
            this.Controls.Add(this.ucUserInfo1);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "ShowUserDetailse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShowUserDetailse";
            this.Load += new System.EventHandler(this.ShowUserDetailse_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ucUserInfo ucUserInfo1;
    }
}