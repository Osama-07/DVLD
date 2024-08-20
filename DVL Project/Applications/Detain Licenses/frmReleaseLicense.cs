using DrivingBusinessLayer;
using DVL_Project.Applications.Manage_Applications.Manage_Test_Types;
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

namespace DVL_Project.Applications.Detain_Licenses
{
    public partial class frmReleaseLicense : Form
    {
        clsDetainedLicenses _ReleaseLicense;
        clsApplications _Application = new clsApplications();

        public frmReleaseLicense()
        {
            InitializeComponent();

        }

        public frmReleaseLicense(int LicenseID)
        {
            InitializeComponent();

            if (LicenseID > 0)
            {
                ctrFindLicense1.LoadLicenseInfo(LicenseID);
            }
        }

        void _ShowIsReleased()
        {
            // if licnese is Released.
            lblDetaineID.Text = _ReleaseLicense.DetainID.ToString();
            lblDetaineDate.Text = _ReleaseLicense.DetainDate.ToLongDateString();
            lblDetaineByUser.Text = _ReleaseLicense.CreatedByUser.Username;
            tbDetaineFees.Text = Convert.ToInt32(_ReleaseLicense.FineFees).ToString();
            lblLicenseID.Text = _ReleaseLicense.License.LicenseID.ToString();
            lblApplicationID.Text = _ReleaseLicense.ReleaseApplication.ApplicationID.ToString();
            lblReleaseDate.Text = _ReleaseLicense.ReleaseDate.ToLongDateString();
            lblReleasedByUser.Text = _ReleaseLicense.ReleasedByUser.Username;

            gbReleaseInfo.Enabled = true;
            tbDetaineFees.Enabled = false;
            lblShowLicensesHistory.Enabled = true;
            btnRelease.Enabled = false;

        }

        void _ShowIsNotReleased()
        {
            _Reset();

            lblDetaineID.Text = _ReleaseLicense.DetainID.ToString();
            lblDetaineDate.Text = _ReleaseLicense.DetainDate.ToLongDateString();
            lblDetaineByUser.Text = _ReleaseLicense.CreatedByUser.Username;
            tbDetaineFees.Text = Convert.ToInt32(_ReleaseLicense.FineFees).ToString();
            lblLicenseID.Text = _ReleaseLicense.License.LicenseID.ToString();
            lblReleaseDate.Text = DateTime.Now.ToLongDateString();
            lblReleasedByUser.Text = clsGlobal.CurrentUser.Username;

            _FillApplicationInfo();

            gbReleaseInfo.Enabled = true;
            tbDetaineFees.Enabled = true;
            lblShowLicensesHistory.Enabled = true;
        }

        void _Reset()
        {
            lblDetaineID.Text = "[????]";
            lblDetaineDate.Text = "[????]";
            lblLicenseID.Text = "[????]";
            lblDetaineByUser.Text = "[????]";
            lblReleaseDate.Text = "[????]";
            lblApplicationID.Text = "[????]";
            lblReleasedByUser.Text = "[????]";
            tbDetaineFees.Clear();
            //errorProvider1.SetError(tbDetaineFees, "");

            gbReleaseInfo.Enabled = false;
            btnRelease.Enabled = false;
            lblShowLicensesHistory.Enabled = false;
        }

        void _FillApplicationInfo()
        {
            _Application.ApplicantPersonID = _ReleaseLicense.License.Application.PersonInfo.PersonID;
            _Application.ApplicationDate = DateTime.Now;
            _Application.ApplicationTypeID = 5; // 5 = Release Detained License.
            _Application.LastStatusDate = DateTime.Now;
            _Application.ApplicationStatus = (clsApplications.enApplicationStatus)3; // 3 = Compleated.
            _Application.PaidFees = _Application.ApplicationTypeInfo.ApplicationFees;
            _Application.CreatedByUserID = clsGlobal.CurrentUser.UserID;
        }

        bool _Save()
        {
            if (_Application.Save())
            {
                _ReleaseLicense.IsReleased = true;
                _ReleaseLicense.ReleaseDate = DateTime.Now;
                _ReleaseLicense.ReleasedByUser = clsGlobal.CurrentUser;
                _ReleaseLicense.ReleaseApplication = _Application;

                if (_ReleaseLicense.Save())
                {
                    return true;
                }
                else
                    return false;

            }
            else
                return false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbDetaineFees_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(tbDetaineFees.Text, out int Fees))
            {
                tbDetaineFees.Clear();
            }

            if (!string.IsNullOrEmpty(tbDetaineFees.Text) && _ReleaseLicense.FineFees == Convert.ToInt32(tbDetaineFees.Text))
            {
                btnRelease.Enabled = true;
            }
            else
                btnRelease.Enabled = false;
        }

        private void ctrFindLicense1_OnFindLicense(int obj)
        {
            int LicenseID = obj;

            _ReleaseLicense = clsDetainedLicenses.GetLicenseDetained(LicenseID);

            if (_ReleaseLicense != null)
            {
                if (!_ReleaseLicense.IsReleased)
                {
                    _ShowIsNotReleased();

                }
                else
                {
                    _ShowIsReleased();
                    MessageBox.Show("this License is already Released.", "Stop",
                                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

            }
            else
            {
                MessageBox.Show("this License is not detained.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                gbReleaseInfo.Enabled = false;
                lblShowLicensesHistory.Enabled = true;
                btnRelease.Enabled = false;
                _Reset();
            }


        }

        private void lblShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string NationalNo = _ReleaseLicense.License.Driver.Person.NationalNo;

            frmShowPersonLicensesHistory frm = new frmShowPersonLicensesHistory(NationalNo);

            frm.ShowDialog();
        }

        private void ctrFindLicense1_OnResetInfo(int obj)
        {
            _Reset();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are u sure do you want Released this License?", "Check", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                
                if (_Save())
                {
                    MessageBox.Show("Released License Successfully.", "Succeeded",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                    lblApplicationID.Text = _ReleaseLicense.ReleaseApplication.ApplicationID.ToString();

                    tbDetaineFees.Enabled = false;
                    btnRelease.Enabled = false;
                }
                else
                    MessageBox.Show("Released License is Failed.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
