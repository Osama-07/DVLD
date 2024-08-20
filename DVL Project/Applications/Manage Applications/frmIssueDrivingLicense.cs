using DrivingBusinessLayer;
using DVL_Project.Users_Screens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVL_Project.Applications.Manage_Applications
{
    public partial class frmIssueDrivingLicense : Form
    {
        int _LocalDrivingLicenseApplicationID = -1;
        clsLocalDrivingLicenseApplications _LocalDrivingLicenseApplications;

        public frmIssueDrivingLicense(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();

            this._LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }

        bool _ChangeAppStatus()
        {

            if (clsTests.GetPassedTestCount(_LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID) == 3)
            {
                return (_LocalDrivingLicenseApplications.SetCompleated());
            }
            else
                return false;

        }

        clsDrivers _AddNewDriver()
        {
            clsDrivers Driver = clsDrivers.FindDriver(_LocalDrivingLicenseApplications.PersonInfo.NationalNo);

            if (Driver == null)
            {
                Driver = new clsDrivers();

                Driver.Person = _LocalDrivingLicenseApplications.PersonInfo;
                Driver.CreatedByUser = clsGlobal.CurrentUser;
                Driver.CreatedDate = DateTime.Now;

                if (Driver.Save())
                {
                    return Driver;
                }
                else
                    return null;
            }
            else
                return Driver;

        }

        bool _IssueDrivingLicense()
        {
            clsDrivers Driver = _AddNewDriver();

            if (Driver == null)
            {
                MessageBox.Show("Add Driver is Failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            clsLicenses License = new clsLicenses();

            License.Application = _LocalDrivingLicenseApplications;
            License.Driver = Driver;
            License.LicenseClass = _LocalDrivingLicenseApplications.LicenseClass;
            License.IssueDate = DateTime.Now;
            License.ExpirationDate = DateTime.Now.AddYears(_LocalDrivingLicenseApplications.LicenseClass.DefaultValidityLength);
            
            if (string.IsNullOrEmpty(tbNotes.Text))
            {
                License.Notes = "";
            }
            else
                License.Notes = tbNotes.Text;

            License.PaidFees = _LocalDrivingLicenseApplications.LicenseClass.ClassFees;
            License.IsActive = true;
            License.IssueReason = 1; // 1 = (First Time).
            License.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (License.Save())
            {
                return true;
            }
            else
                return false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {

            if (_IssueDrivingLicense())
            {
                if (_ChangeAppStatus())
                {
                    btnIssue.Enabled = false;
                    MessageBox.Show("Issue License Successfully.", "Succeeded", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }

            }
            else
                MessageBox.Show("Issue License is Failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void frmIssueDrivingLicense_Load(object sender, EventArgs e)
        {
            if (clsTests.GetPassedTestCount(_LocalDrivingLicenseApplicationID) != 3)
            {
                MessageBox.Show("this Person Is not compleated all test.", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Close();
                return;
            }
            
            this._LocalDrivingLicenseApplications = clsLocalDrivingLicenseApplications.FindLocalDrivignLicenseApplicationByID(_LocalDrivingLicenseApplicationID);

            ctrDrivingLicenseApplicationInfo1.LoadDrivigLicenseApplicationInfo(_LocalDrivingLicenseApplicationID);
        }
    }
}
