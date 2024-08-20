using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVL_Project.Applications
{
    public partial class frmDrivingLicenseApplicationInfo : Form
    {
        int _L_D_AppID;

        public frmDrivingLicenseApplicationInfo(int L_D_appID)
        {
            InitializeComponent();

            _L_D_AppID = L_D_appID;

        }

        private void frmDrivingLicenseApplicationInfo_Load(object sender, EventArgs e)
        {
            ctrDrivingLicenseApplicationInfo1.LoadDrivigLicenseApplicationInfo(_L_D_AppID);
        }

        private void btnClose2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
