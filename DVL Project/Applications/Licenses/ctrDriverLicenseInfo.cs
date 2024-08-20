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
    public partial class ctrDriverLicenseInfo : UserControl
    {

        int _LicenseID = -1;
        clsLicenses _License;

        public clsLicenses SelectedLicense
        {
            get
            {
                return _License;
            }
        }
        public int LicenseID
        {
            get
            {
                return _LicenseID;
            }
        }

        string _IssueReasonText(byte IssueReason)
        {
            switch(IssueReason)
            {
                case 1:

                    return "(First Time)";

                case 2:

                    return "(Renew)";

                case 3:

                    return "(Replacement for Lost)";

                case 4:

                    return "(Replacement for Damaged)";

                default:

                    return "(First Time)";

            }

        }

        public ctrDriverLicenseInfo()
        {
            InitializeComponent();
        }

        public void Reset()
        {
            lblClass.Text = "[????]";
            lblName.Text = "[????]";
            lblLicenseID.Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblGender.Text = "[????]";
            lblIssueDate.Text = "[????]";
            lblIssueReason.Text = "[????]";
            lblNotes.Text = "[????]";
            lblIsActive.Text = "[????]";
            lblDateOfBirth.Text = "[????]";
            lblDriverID.Text = "[????]";
            lblExpirationDate.Text = "[????]";
            pbPersonalImage.Image = Resources.No_Person;
        }

        public void LoadDriverLicenseInfo(int LicenseID)
        {
            _LicenseID = LicenseID;
            _License = clsLicenses.Find(_LicenseID);

            if (_License == null)
            {
                Reset();
                MessageBox.Show("this License with ID " + LicenseID + " is not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            lblClass.Text = _License.LicenseClass.ClassName;
            lblName.Text = _License.Driver.Person.FullName();
            lblLicenseID.Text = _LicenseID.ToString();
            lblNationalNo.Text = _License.Driver.Person.NationalNo;
            lblGender.Text = _License.Driver.Person.Gender;
            lblIssueDate.Text = _License.IssueDate.ToShortDateString();

            lblIssueReason.Text = _IssueReasonText(_License.IssueReason);
            lblNotes.Text = _License.Notes == "" ? "No Notes" : _License.Notes;
            lblIsActive.Text = _License.IsActive ? "Yes" : "No";
            lblDateOfBirth.Text = _License.Driver.Person.DateOfBirth.ToShortDateString();
            lblDriverID.Text = _License.Driver.DriverID.ToString();
            lblExpirationDate.Text = _License.ExpirationDate.ToShortDateString();

            if (_License.Driver.Person.PersonalPicture != "")
            {
                pbPersonalImage.ImageLocation = _License.Driver.Person.PersonalPicture;
            }
            else
                pbPersonalImage.Image = Resources.No_Person;

        }

        public void LoadDriverLicenseInfo(string NationalNo, string ClassName)
        {

            _License = clsLicenses.FindLicenseByNationalNoAndClassName(NationalNo, ClassName);
            
            if (_License == null)
            {
                Reset();
                MessageBox.Show("this License with NationalNo " + NationalNo + " is not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            _LicenseID = _License.LicenseID;


            lblClass.Text = _License.LicenseClass.ClassName;
            lblName.Text = _License.Driver.Person.FullName();
            lblLicenseID.Text = _License.LicenseID.ToString();
            lblNationalNo.Text = _License.Driver.Person.NationalNo;
            lblGender.Text = _License.Driver.Person.Gender;
            lblIssueDate.Text = _License.IssueDate.ToShortDateString();

            lblIssueReason.Text = _IssueReasonText(_License.IssueReason);
            lblNotes.Text = _License.Notes == "" ? "No Notes" : _License.Notes;
            lblIsActive.Text = _License.IsActive ? "Yes" : "No";
            lblDateOfBirth.Text = _License.Driver.Person.DateOfBirth.ToShortDateString();
            lblDriverID.Text = _License.Driver.DriverID.ToString();
            lblExpirationDate.Text = _License.ExpirationDate.ToShortDateString();

            if (_License.Driver.Person.PersonalPicture != "")
            {
                pbPersonalImage.ImageLocation = _License.Driver.Person.PersonalPicture;
            }
            else
                pbPersonalImage.Image = Resources.No_Person;

        }

    }
}
