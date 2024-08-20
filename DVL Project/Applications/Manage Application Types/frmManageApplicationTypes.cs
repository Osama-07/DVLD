using DrivingBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVL_Project.Applications.Manage_Application_Types
{
    public partial class frmManageApplicationTypes : Form
    {
        public frmManageApplicationTypes()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            dgvApplicationTypes.Rows.Clear();

            DataTable dtApplications = clsApplicationTypes.GetAllApplicationTypes();
            DataView dvApplications = dtApplications.DefaultView;

            for (int i = 0; i < dvApplications.Count; i++)
            {
                dgvApplicationTypes.Rows.Add(dvApplications[i][0], dvApplications[i][1], dvApplications[i][2]);
            }
        }

        private void editTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ApplicationTypeID = Convert.ToInt32(dgvApplicationTypes.CurrentRow.Cells[0].Value); // 0 = Application ID.
            
            frmUpdateApplicationTypes frm = new frmUpdateApplicationTypes(ApplicationTypeID);

            frm.ShowDialog();

            frmManageApplicationTypes_Load(null, null);
        }
    }
}
