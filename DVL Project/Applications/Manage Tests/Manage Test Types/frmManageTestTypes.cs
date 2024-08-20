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

namespace DVL_Project.Applications.Manage_Test_Types
{
    public partial class frmManageTestTypes : Form
    {
        static DataTable dtTests = clsTestTypes.GetAllTestTypes();
        DataView dvTests = dtTests.DefaultView;

        public frmManageTestTypes()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmManageTestTypes_Load(object sender, EventArgs e)
        {
            dgvTestTypes.Rows.Clear();


            for (int i = 0; i < dvTests.Count; i++)
            {
                dgvTestTypes.Rows.Add(dvTests[i][0], dvTests[i][1], dvTests[i][2], dvTests[i][3]);
            }
        }

        private void editTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateTestType frm = new frmUpdateTestType((clsTestTypes.enTestTypes)dgvTestTypes.CurrentRow.Cells[0].Value);// 0 = Test Type ID.

            frm.ShowDialog();

            frmManageTestTypes_Load(null, null);
        }
    }
}
