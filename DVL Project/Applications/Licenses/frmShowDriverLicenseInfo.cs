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
    public partial class frmShowDriverLicenseInfo : Form
    {
        private int _LicenseID = -1;

        public frmShowDriverLicenseInfo(int LicenseID)
        {
            InitializeComponent();

            _LicenseID = LicenseID;
        }

        public frmShowDriverLicenseInfo(string NationalNo, string ClassName)
        {
            InitializeComponent();

            ctrDriverLicenseInfo1.LoadDriverLicenseInfo(NationalNo, ClassName);
        }

        private void frmDriverLicenseInfo_Load(object sender, EventArgs e)
        {
            if (_LicenseID > 0)
            {
                ctrDriverLicenseInfo1.LoadDriverLicenseInfo(_LicenseID);
            }
        }

        private void btnClose2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
