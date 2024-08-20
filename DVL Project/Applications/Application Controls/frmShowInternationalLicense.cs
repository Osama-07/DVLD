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
    public partial class frmShowInternationalLicense : Form
    {
        public frmShowInternationalLicense(int InternationalID)
        {
            InitializeComponent();

            ctrInternationalLicenseInfo1.LoadInternationalLicenseInfo(InternationalID);

        }

        private void frmShowInternationalLicense_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
