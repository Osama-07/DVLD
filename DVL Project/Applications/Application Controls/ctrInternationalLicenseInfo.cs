using DrivingBusinessLayer;
using DVL_Project.Properties;
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
    public partial class ctrInternationalLicenseInfo : UserControl
    {
        public ctrInternationalLicenseInfo()
        {
            InitializeComponent();
        }

        public void Reset()
        {
            lblName.Text = "[????]";
            lblInt_LicenseID.Text = "[????]";
            lblLicenseID.Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblGender.Text = "[????]";
            lblIssueDate.Text = "[????]";
            lblApplicationID.Text = "[????]";
            lblIsActive.Text = "[????]";
            lblDateOfBirth.Text = "[????]";
            lblDriverID.Text = "[????]";
            lblExpirationDate.Text = "[????]";
            pbPersonalImage.Image = Resources.No_Person;
        }

        public bool LoadInternationalLicenseInfo(int InternationalLicenseID)
        {
            clsInternationalLicenses Int_License = clsInternationalLicenses.Find(InternationalLicenseID);

            if (Int_License != null)
            {
                lblName.Text = Int_License.DriverInfo.Person.FullName();
                lblInt_LicenseID.Text = Int_License.InternationalLicenseID.ToString();
                lblLicenseID.Text = Int_License.LocalLicenseInfo.LicenseID.ToString();
                lblNationalNo.Text = Int_License.DriverInfo.Person.NationalNo;
                lblGender.Text = Int_License.DriverInfo.Person.Gender;
                lblIssueDate.Text = Int_License.IssueDate.ToShortDateString();
                lblApplicationID.Text = Int_License.ApplicationID.ToString();

                if (Int_License.IsActive == false)
                {
                    lblIsActive.Text = "No";
                }
                else
                    lblIsActive.Text = "Yes";

                lblDateOfBirth.Text = Int_License.DriverInfo.Person.DateOfBirth.ToShortDateString();
                lblDriverID.Text = Int_License.DriverInfo.DriverID.ToString();
                lblExpirationDate.Text = Int_License.ExpirationDate.ToShortDateString();
                pbPersonalImage.ImageLocation = Int_License.DriverInfo.Person.PersonalPicture;

                return true;
            }
            else
                Reset();

            return false;
        }

    }
}
