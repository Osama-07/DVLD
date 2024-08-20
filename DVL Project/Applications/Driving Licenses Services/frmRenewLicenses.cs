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
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVL_Project.Applications.Driving_Licenses_Services
{
    public partial class frmRenewLicenses : Form
    {
        clsLicenses _OldLicense;
        clsLicenses _NewLicense = new clsLicenses();
        clsApplications _Application = new clsApplications();
        clsApplicationTypes AppType = clsApplicationTypes.Find(2);

        public frmRenewLicenses()
        {
            InitializeComponent();
        }

        void _FillApplicationInfoObject()
        {
            _Application.ApplicantPersonID = _OldLicense.Application.PersonInfo.PersonID;
            _Application.ApplicationDate = DateTime.Now;
            _Application.ApplicationTypeID = AppType.ApplicationTypeID;
            _Application.ApplicationStatus = _OldLicense.Application.ApplicationStatus;
            _Application.LastStatusDate = DateTime.Now;
            _Application.PaidFees = AppType.ApplicationFees;
            _Application.CreatedByUserID = clsGlobal.CurrentUser.UserID;
        }

        void _FillLicenseInfoObject()
        {
            //_NewLicense.Application; (store notes after click issue button.).
            _NewLicense.Driver = _OldLicense.Driver;
            _NewLicense.LicenseClass = clsLicenseClasses.Find(_OldLicense.LicenseClass.LicenseClassID);
            _NewLicense.IssueDate = DateTime.Now;
            _NewLicense.ExpirationDate = DateTime.Now.AddYears(_NewLicense.LicenseClass.DefaultValidityLength);
            //_NewLicense.Notes; (store notes after click issue button.).
            _NewLicense.PaidFees = _NewLicense.LicenseClass.ClassFees;
            _NewLicense.IsActive = false; // change After Issued.
            _NewLicense.IssueReason = 2; // 2 = Renew. (For Detailse look Class Licenses).
            _NewLicense.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            _FillApplicationInfoObject();
        }

        bool _IssueRenewLicense()
        {
            _OldLicense.IsActive = false; // stop Old License.

            if (_OldLicense.Save())
            {
                if (_Application.Save())
                {
                    _NewLicense.Application = _Application;
                    _NewLicense.Notes = tbNotes.Text;
                    _NewLicense.IsActive = true;

                    return _NewLicense.Save();
                }
                else
                    return false;
            }
            else
                return false;


        }

        private void ctrFindLicense1_OnFindLicense(int obj)
        {
            int LicenseID = obj;

            _OldLicense = clsLicenses.Find(LicenseID);

            if (_OldLicense != null)
            {
                DateTime ActiveDate = DateTime.Now.AddMonths(2);

                if (_OldLicense.ExpirationDate <= ActiveDate)
                {
                    _FillLicenseInfoObject();

                    lblApplicationDate.Text = _Application.ApplicationDate.ToLongDateString();
                    lblIssueDate.Text = _NewLicense.IssueDate.ToLongDateString();
                    lblApplicationFees.Text = Convert.ToInt32(_Application.ApplicationTypeInfo.ApplicationFees).ToString();
                    lblLicenseFees.Text = Convert.ToInt32(_NewLicense.PaidFees).ToString();
                    lblOldLicenseID.Text = _OldLicense.LicenseID.ToString();
                    lblExpirationDate.Text = _NewLicense.ExpirationDate.ToLongDateString();
                    lblCreatedBy.Text = clsGlobal.CurrentUser.Username;
                    lblTotlaFees.Text = (_NewLicense.PaidFees + _Application.PaidFees).ToString();

                    
                    btnIssue.Enabled = true;
                    lblShowLicenseHistory.Enabled = true;
                    lblShowNewLicenseInfo.Enabled = false;
                    gbApplicationNewLicenseInfo.Enabled = true;
                }
                else
                {
                    btnIssue.Enabled = false;
                    lblShowNewLicenseInfo.Enabled = true;
                    lblShowLicenseHistory.Enabled = true;
                    gbApplicationNewLicenseInfo.Enabled = false;

                    MessageBox.Show("You can't Renew this license because it is not Finished.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                btnIssue.Enabled = false;
                lblShowLicenseHistory.Enabled = false;
                lblShowNewLicenseInfo.Enabled = false;
                ctrFindLicense1.Reset();
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicensesHistory frm = new frmShowPersonLicensesHistory(_OldLicense.Driver.Person.NationalNo);

            frm.ShowDialog();
        }

        private void frmRenewLicenses_Load(object sender, EventArgs e)
        {
            lblApplicationFees.Text = Convert.ToInt32(AppType.ApplicationFees).ToString();
        }

        private void lblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_NewLicense.LicenseID != -1)
            {
                // Show New License.
                frmShowDriverLicenseInfo frm = new frmShowDriverLicenseInfo(_NewLicense.LicenseID);

                frm.ShowDialog();
            }
            else
            {
                // Show Old License.
                frmShowDriverLicenseInfo frm = new frmShowDriverLicenseInfo(_OldLicense.LicenseID);

                frm.ShowDialog();
            }
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (_IssueRenewLicense())
            {
                MessageBox.Show("Issue Renew License Successfully.", "Succeeded",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                btnIssue.Enabled = false;
                lblShowNewLicenseInfo.Enabled = true;
                lblR_L_ApplicationID.Text = _NewLicense.Application.ApplicationID.ToString();
                lblRenewedLicenseID.Text = _NewLicense.LicenseID.ToString();
            }

        }
    }
}
