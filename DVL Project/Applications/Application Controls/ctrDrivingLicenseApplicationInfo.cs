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
    public partial class ctrDrivingLicenseApplicationInfo : UserControl
    {
        string _NationalNo;
        string _ClassName;

        public ctrDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        public void Reset()
        {
            lblDrivingLicenseApplicationID.Text = "[????]";
            lblClassName.Text = "[????]";
            lblPassedTestCount.Text = "[????]";
            lblShowLicenseInfo.Enabled = false;
            ctrlApplicationInfo2.Reset();
        }

        public bool LoadDrivigLicenseApplicationInfo(int LocalDrivingLicenseApplicationID)
        {
            clsLocalDrivingLicenseApplications L_D_App;
            
            L_D_App = clsLocalDrivingLicenseApplications.FindLocalDrivignLicenseApplicationByID(LocalDrivingLicenseApplicationID);

            if (L_D_App != null)
            {
                lblDrivingLicenseApplicationID.Text = L_D_App.LocalDrivingLicenseApplicationID.ToString();
                lblClassName.Text = L_D_App.LicenseClass.ClassName;
                lblPassedTestCount.Text = clsTests.GetPassedTestCount(LocalDrivingLicenseApplicationID).ToString() + "/3";

                string NationalNo = L_D_App.PersonInfo.NationalNo;


                _NationalNo = NationalNo; // this step for show license info.
                _ClassName = L_D_App.LicenseClass.ClassName; // this step for show license info.


                if (L_D_App.ApplicationStatus == clsApplications.enApplicationStatus.Compleated)
                {
                    lblShowLicenseInfo.Enabled = true;
                }
                else
                    lblShowLicenseInfo.Enabled = false;

                ctrlApplicationInfo2.LoadApplicationInfo(L_D_App.ApplicationID);

                return true;
            }
            else
                return false;
        }

        private void lblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowDriverLicenseInfo frm = new frmShowDriverLicenseInfo(_NationalNo, _ClassName);

            frm.ShowDialog();
        }
    }
}
