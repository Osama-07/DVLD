namespace DVL_Project
{
    partial class frmShowPersonDetailse
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
            this.ucPersonalInfo1 = new DVL_Project.ucPersonalInfo();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ucPersonalInfo1
            // 
            this.ucPersonalInfo1.Location = new System.Drawing.Point(3, 59);
            this.ucPersonalInfo1.Name = "ucPersonalInfo1";
            this.ucPersonalInfo1.Size = new System.Drawing.Size(740, 253);
            this.ucPersonalInfo1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Dubai", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(244, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 45);
            this.label1.TabIndex = 1;
            this.label1.Text = "Person Detailse";
            // 
            // frmShowPersonDetailse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(742, 315);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ucPersonalInfo1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmShowPersonDetailse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmShowPersonDetailse";
            this.Load += new System.EventHandler(this.frmShowPersonDetailse_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ucPersonalInfo ucPersonalInfo1;
        private System.Windows.Forms.Label label1;
    }
}