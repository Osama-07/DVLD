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
    public partial class frmReplacementForLostOrDamagedLicense : Form
    {
        clsLicenses _NewLicense = new clsLicenses();
        clsLicenses _OldLicense;
        clsApplicationTypes _ApplicationType;

        public frmReplacementForLostOrDamagedLicense()
        {
            InitializeComponent();
        }

        void _Referesh()
        {
            lblShowNewLicenseInfo.Enabled = false;
            lblShowLicenseHistory.Enabled = false;
            btnIssueReplacement.Enabled = false;
            ctrDriverLicenseInfo1.Reset();
            lblL_R_ApplicationID.Text = "[????]";
            lblApplicationDate.Text = "[????]";
            lblApplicationFees.Text = "[????]";
            lblReplacementLicenseID.Text = "[????]";
            lblOldLicenseID.Text = "[????]";
            lblCreatedBy.Text = "[????]";
            
            // this to call founction rbDamage Change.
            rbDamaged.Checked = false; 
            rbDamaged.Checked = true;

        }

        bool _SaveNewApplication(ref clsLicenses newLicense)
        {
            clsApplications Application = new clsApplications();

            Application.ApplicantPersonID = _OldLicense.Application.PersonInfo.PersonID;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationTypeID = _ApplicationType.ApplicationTypeID;
            Application.LastStatusDate = DateTime.Now;
            Application.ApplicationStatus = _OldLicense.Application.ApplicationStatus;
            Application.PaidFees = _ApplicationType.ApplicationFees;
            Application.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (Application.Save())
            {
                newLicense.Application = Application;
                return true;
            }
            else
            {
                MessageBox.Show("add application is failed.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
        }

        bool _SaveNewLicense()
        {
            if (_SaveNewApplication(ref _NewLicense)) // add new application and store in new License.
            {
                _NewLicense.Driver = _OldLicense.Driver;
                _NewLicense.LicenseClass = _OldLicense.LicenseClass;
                _NewLicense.IssueDate = _OldLicense.IssueDate;
                _NewLicense.ExpirationDate = _OldLicense.ExpirationDate;
                _NewLicense.Notes = _OldLicense.Notes;
                _NewLicense.PaidFees = _OldLicense.PaidFees;
                
                _OldLicense.IsActive = false; // UnActive of Old License.
                _NewLicense.IsActive = true; // Avtivate New License.

                _NewLicense.IssueReason = Convert.ToByte(_ApplicationType.ApplicationTypeID);
                _NewLicense.CreatedByUserID = clsGlobal.CurrentUser.UserID;


                _OldLicense.Save(); // because change IsActive = false.
                return _NewLicense.Save();
            }
            else
            {
                return false; 
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(tbSearch.Text, out int LicenseID))
            {
                tbSearch.Clear();
            }
        }

        private void rbDamaged_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDamaged.Checked)
            {
                lblTitle.Text = "Replacement For Damaged";
                _ApplicationType = clsApplicationTypes.Find(4); // 4 = Replacement for Damaged.
                lblApplicationFees.Text = _ApplicationType.ApplicationFees.ToString();
            }
        }

        private void rbLost_CheckedChanged(object sender, EventArgs e)
        {
            if (rbLost.Checked)
            {
                lblTitle.Text = "Replacement For Lost";
                _ApplicationType = clsApplicationTypes.Find(3); // 3 = Replacement for Lost.
                lblApplicationFees.Text = _ApplicationType.ApplicationFees.ToString();
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _Referesh();

            if (int.TryParse(tbSearch.Text, out int LicenseID))
            {
                _OldLicense = clsLicenses.Find(LicenseID);

                if (_OldLicense != null)
                {
                    // if is not detained continue process
                    if (!clsDetainedLicenses.IsDetained(_OldLicense.LicenseID))
                    {
                        // Show Licnese Info and new Application.

                        ctrDriverLicenseInfo1.LoadDriverLicenseInfo(_OldLicense.LicenseID);
                        lblApplicationDate.Text = DateTime.Now.ToLongDateString();
                        lblOldLicenseID.Text = _OldLicense.LicenseID.ToString();
                        lblCreatedBy.Text = _OldLicense.Application.CreatedByUser.Username;

                        // Enable btnIssueReplacement.
                        btnIssueReplacement.Enabled = true;
                        // Enable Link Label History.
                        lblShowLicenseHistory.Enabled = true;
                    }
                    else
                        MessageBox.Show("License With ID " + tbSearch.Text + " is Detained", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("License With ID " + tbSearch.Text + " is Not Found", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void frmReplacementForLostOrDamagedLicense_Load(object sender, EventArgs e)
        {
            rbDamaged.Checked = true;
            tbSearch.Focus();
        }

        private void lblShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string NationalNo = _OldLicense.Application.PersonInfo.NationalNo;

            frmShowPersonLicensesHistory frm = new frmShowPersonLicensesHistory(NationalNo);

            frm.ShowDialog();
        }

        private void btnIssueReplacement_Click(object sender, EventArgs e)
        {
            if (_SaveNewLicense())
            {
                lblL_R_ApplicationID.Text = _NewLicense.Application.ApplicationID.ToString();
                lblReplacementLicenseID.Text = _NewLicense.LicenseID.ToString();
                ctrDriverLicenseInfo1.LoadDriverLicenseInfo(_NewLicense.LicenseID);

                btnIssueReplacement.Enabled = false;
                lblShowNewLicenseInfo.Enabled = true;

                MessageBox.Show("Add new License Successfully, New LicenseID = " + _NewLicense.LicenseID, "Succeeded",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void lblShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowDriverLicenseInfo frm = new frmShowDriverLicenseInfo(_NewLicense.LicenseID);

            frm.ShowDialog();
        }


    }
}
