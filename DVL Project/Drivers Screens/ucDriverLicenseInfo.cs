using DrivingBusinessLayer;
using DVL_Project.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVL_Project.Application
{
    public partial class ucDriverLicenseInfo : UserControl
    {

        public ucDriverLicenseInfo()
        {
            InitializeComponent();
        }

        public void Reset()
        {
            lblLicenseClass.Text = "[????]";
            lblFullName.Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblLicenseID.Text = "[????]";
            lblGender.Text = "[????]";
            lblIssueDate.Text = "[????]";
            lblIssueReason.Text = "[????]";
            lblNotes.Text = "[????]";
            lblIsActive.Text = "[????]";
            lblDriverID.Text = "[????]";
            lblDateOfBirth.Text = "[????]";
            lblExprationDate.Text = "[????]";
            pbPersonalPicture.Image = Resources.No_Person;
        }

        public bool LoadLicenseInfo(int LicenseID)
        {
            if (clsApplications.Is)

        }

    }
}
