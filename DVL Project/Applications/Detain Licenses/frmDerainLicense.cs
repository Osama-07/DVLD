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
    public partial class frmDerainLicense : Form
    {
        clsDetainedLicenses _DetaineLicense = new clsDetainedLicenses();

        public frmDerainLicense()
        {
            InitializeComponent();
        }

        void _Reset()
        {
            lblDetaineDate.Text = "[????]";
            lblLicenseID.Text = "[????]";
            lblDetaineByUser.Text = "[????]";
            tbDetaineFees.Clear();
            errorProvider1.SetError(tbDetaineFees, "");

            gbDetaineInfo.Enabled = false;
            btnDetain.Enabled = false;
            lblShowLicensesHistory.Enabled = false;
        }

        void _FillDetaineInfo()
        {
            lblDetaineDate.Text = _DetaineLicense.DetainDate.ToLongDateString();
            lblLicenseID.Text = _DetaineLicense.License.LicenseID.ToString();
            lblDetaineByUser.Text = _DetaineLicense.CreatedByUser.Username;
        }

        bool _Save()
        {
            _DetaineLicense.DetainDate = DateTime.Now;
            _DetaineLicense.FineFees = Convert.ToDecimal(tbDetaineFees.Text);
            _DetaineLicense.CreatedByUser = clsGlobal.CurrentUser;
            _DetaineLicense.IsReleased = false;

            if (_DetaineLicense.Save())
            {
                return true;
            }

            return false;
        }

        private void ctrFindLicense1_OnFindLicense(int obj)
        {
            int LicenseID = obj;

            _DetaineLicense.License = clsLicenses.Find(LicenseID);

            if (_DetaineLicense.License != null)
            {
                // if License Not Detained Continue Process.
                if (!clsDetainedLicenses.IsDetained(_DetaineLicense.License.LicenseID))
                {

                    _DetaineLicense.DetainDate = DateTime.Now;
                    // DetaineLicense.FineFees = User Enter How match Fees.
                    _DetaineLicense.CreatedByUser = clsGlobal.CurrentUser;
                    _DetaineLicense.IsReleased = false;

                    gbDetaineInfo.Enabled = true;
                    _FillDetaineInfo();

                    tbDetaineFees.Focus();
                    lblShowLicensesHistory.Enabled = true;

                }
                else
                {
                    gbDetaineInfo.Enabled = false;
                    tbDetaineFees.Enabled = false;
                    btnDetain.Enabled = false;
                    lblShowLicensesHistory.Enabled = true;
                    MessageBox.Show("this License Already Detained.", "Warning",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else
                _Reset();

        }

        private void ctrFindLicense1_OnResetInfo(int obj)
        {
            // if On Click Reset Or Search about Licnese is Not Found.
            _Reset();
        }

        private void lblShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string NationalNo = _DetaineLicense.License.Driver.Person.NationalNo;

            frmShowPersonLicensesHistory frm = new frmShowPersonLicensesHistory(NationalNo);

            frm.ShowDialog();
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

            if (!string.IsNullOrEmpty(tbDetaineFees.Text))
            {
                btnDetain.Enabled = true;
            }
            else
                btnDetain.Enabled = false;

        }

        private void tbDetaineFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbDetaineFees.Text))
            {
                errorProvider1.SetError(tbDetaineFees, "Enter Fine Fees");
                btnDetain.Enabled = false;
            }
            else
            {
                errorProvider1.SetError(tbDetaineFees, "");
                btnDetain.Enabled = true;
            }
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
                return;

            if (MessageBox.Show("Are you sure do you want detaine this License ?", "Check",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (_Save())
                {
                    MessageBox.Show("Detained License Successfully.", "Succeeded",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    lblDetaineID.Text = _DetaineLicense.DetainID.ToString();
                    tbDetaineFees.Enabled = false;
                    btnDetain.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Detained License is Failed.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }


    }
}
