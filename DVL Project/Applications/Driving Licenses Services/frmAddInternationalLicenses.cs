using DrivingBusinessLayer;
using DVL_Project.Applications.Application_Controls;
using DVL_Project.Applications.Manage_Applications.Manage_Test_Types;
using DVL_Project.Users_Screens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVL_Project.Applications.Driving_Licenses_Services
{
    public partial class frmAddInternationalLicenses : Form
    {
        private string _NationalNo;
        private clsInternationalLicenses I_L_License;

        public frmAddInternationalLicenses()
        {
            InitializeComponent();
        }

        void _FillInternationalLicenseInfoObject(clsLicenses License)
        {
            I_L_License = new clsInternationalLicenses();
            I_L_License.ApplicantPersonID = License.Driver.Person.PersonID;
            I_L_License.ApplicationDate = DateTime.Now;
            I_L_License.ApplicationTypeID = clsApplicationTypes.Find(6).ApplicationTypeID;
            I_L_License.ApplicationStatus = (clsApplications.enApplicationStatus)3; // 3 = Comleated all Tests for local License.
            I_L_License.LastStatusDate = DateTime.Now;
            I_L_License.PaidFees = clsApplicationTypes.Find(6).ApplicationFees;
            I_L_License.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            I_L_License.LocalLicenseInfo = clsLicenses.Find(License.LicenseID);
            I_L_License.DriverInfo = clsDrivers.FindDriver(License.Driver.Person.NationalNo);
            I_L_License.IssueDate = DateTime.Now;
            I_L_License.ExpirationDate = DateTime.Now.AddYears(1); // Expiration After 1 Year.
            I_L_License.IsActive = true;
        }

        bool _IssueInternationalLicense()
        {
            if (I_L_License.Save())
            {
                return true;
            }
            else
                return false;

        }

        private void frmAddInternationalLicenses_Load(object sender, EventArgs e)
        {


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrFindLicense1_OnFindLicense(int obj)
        {
            int LicenseID = obj;

            clsLicenses License = clsLicenses.Find(LicenseID);

            if (License == null)
            {
                MessageBox.Show("international License is Not Found.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            _NationalNo = License.Driver.Person.NationalNo;

            if (License.LicenseClass.LicenseClassID == 3)
            {
                if (!clsInternationalLicenses.IsHasLicense(License.Driver.DriverID))
                {
                    _FillInternationalLicenseInfoObject(License);

                    lblApplicationDate.Text = I_L_License.ApplicationDate.ToShortDateString();
                    lblIssueDate.Text = I_L_License.IssueDate.ToShortDateString();
                    lblFees.Text = I_L_License.PaidFees.ToString();
                    lblLocalLicenseID.Text = I_L_License.LocalLicenseInfo.LicenseID.ToString();
                    lblExpirationDate.Text = I_L_License.ExpirationDate.ToShortDateString();
                    lblCreatedBy.Text = I_L_License.CreatedByUser.Username;

                    lblShowLicensesHistory.Enabled = true;
                    btnIssue.Enabled = true;

                    return;
                }
                else
                {
                    MessageBox.Show("He Already has international License.", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    
                    lblShowLicensesHistory.Enabled = true;
                }

            }
            else
            {
                lblShowLicensesHistory.Enabled = true;
                btnIssue.Enabled = false;

                MessageBox.Show("Enter License from license (class 3 - Ordinary License).", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

            }


        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You sure do you want Issue International License Successfully ?", "Check",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                if (_IssueInternationalLicense())
                {
                    lblShowNewLicense.Enabled = true;
                    btnIssue.Enabled = false;

                    lblI_L_ApplicationID.Text = I_L_License.ApplicationID.ToString();
                    lblI_L_LicenseID.Text = I_L_License.InternationalLicenseID.ToString();

                    MessageBox.Show("Issue International License Successfully, New International ID = "
                        + I_L_License.InternationalLicenseID, "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void lblShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicensesHistory frm = new frmShowPersonLicensesHistory(_NationalNo);

            frm.ShowDialog();
        }

        private void lblShowNewLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowInternationalLicense frm = new frmShowInternationalLicense(I_L_License.InternationalLicenseID);

            frm.ShowDialog();
        }
    }
}
