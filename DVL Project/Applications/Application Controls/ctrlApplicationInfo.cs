using DrivingBusinessLayer;
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
    public partial class ctrlApplicationInfo : UserControl
    {
        int _PersonID;

        public ctrlApplicationInfo()
        {
            InitializeComponent();

            /*_LocalDrivingLicense = clsLocalDrivingLicenseApplications.Find(LocalDrivingLicenseID);

            if (_LocalDrivingLicense == null)
            {
                MessageBox.Show("this Driving License ID is not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }*/

        }

        public void Reset()
        {
            lblApplicationID.Text = "[????]";
            lblStatus.Text = "[????]";
            lblFees.Text = "[????]";
            lblType.Text = "[????]";
            lblFullName.Text = "[????]";
            lblDate.Text = "[????]";
            lblStatusDate.Text = "[????]";
            lblCreatedBy.Text = "[????]";
            lblViewPersonInfo.Enabled = false;
        }

        public bool LoadApplicationInfo(int ApplicationID)
        {
            clsApplications Application = clsApplications.Find(ApplicationID);

            if (Application != null)
            {
                _PersonID = Application.PersonInfo.PersonID;

                lblApplicationID.Text = Application.ApplicationID.ToString();
                lblStatus.Text = Application.StatusText;
                lblFees.Text = Convert.ToInt16(Application.PaidFees).ToString();
                lblType.Text = Application.ApplicationTypeInfo.ApplicationTypeTitle;
                lblFullName.Text = Application.PersonInfo.FullName();
                lblDate.Text = Application.ApplicationDate.ToShortDateString();
                lblStatusDate.Text = Application.LastStatusDate.ToShortDateString();
                lblCreatedBy.Text = Application.CreatedByUser.Username;
                lblViewPersonInfo.Enabled = true;

                return true;
            }
            else
                return false;
        }

        private void lblViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonDetailse frm = new frmShowPersonDetailse(_PersonID);

            frm.ShowDialog();
        }
    }
}
