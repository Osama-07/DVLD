using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVL_Project.Applications.Application_Controls
{
    public partial class frmFindLicense : Form
    {
        public delegate void LicenseIDDataBack(object sender, int LicenseID);

        public event LicenseIDDataBack DataLicenseBack;

        int _LicenseID = -1;

        public frmFindLicense()
        {
            InitializeComponent();
        }

        private void btnClose2_Click(object sender, EventArgs e)
        {
            DataLicenseBack?.Invoke(this, _LicenseID);

            this.Close();
        }

        private void ctrFindLicense1_OnFindLicense(int obj)
        {
            int LicenseID = obj;

            _LicenseID = LicenseID;
        }
    }
}
