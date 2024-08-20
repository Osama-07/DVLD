using DrivingBusinessLayer;
using DVL_Project.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVL_Project
{
    public partial class ucPersonalInfo : UserControl
    {
        private clsPepole _Person;

        private int _PersonID = -1;

        public int PersonID
        {
            get { return _PersonID; }
        }
        public clsPepole SelectedPersonInfo
        {
            get { return _Person; }
        }

        public ucPersonalInfo()
        {
            InitializeComponent();
        }

        public void Reset()
        {
            lblPersonID.Text = "????";
            lblNationalNo.Text = "????";
            lblFullName.Text = "????";
            lblDateOfBirth.Text = "????";
            lblEmail.Text = "????";
            lblPhone.Text = "????";
            lblAddress.Text = "????";
            lblGender.Text = "????";
            lblCountry.Text = "????";
            pbPersonalPicture.Image = Resources.No_Person;
            lblEditPersonInfo.Enabled = false;
        }

        public bool LoadPersonInfo(int PersonID)
        {
            _Person = clsPepole.FindPerson(PersonID);

            if (_Person == null)
            {
                Reset();

                return false;
            }
            else
                _FillPersonInfo();

            return true;
        }

        public bool LoadPersonInfo(string NationalNo)
        {
            _Person = clsPepole.FindPerson(NationalNo);

            if (_Person == null)
            {
                Reset();

                return false;
            }
            else
                _FillPersonInfo();

            return true;
        }

        private void _LoadPersonImage()
        {
            string ImagePath = _Person.PersonalPicture;

            if (ImagePath != "" && ImagePath != null)
                if (File.Exists(ImagePath))
                    pbPersonalPicture.ImageLocation = _Person.PersonalPicture;
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                pbPersonalPicture.Image = Resources.No_Person;


        }

        private void _FillPersonInfo()
        {
            if (_Person != null)
            {
                _PersonID = _Person.PersonID;

                lblPersonID.Text = _Person.PersonID.ToString();
                lblNationalNo.Text = _Person.NationalNo;
                lblFullName.Text = _Person.FullName();
                lblDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();
                lblEmail.Text = _Person.Email;
                lblPhone.Text = _Person.Phone;
                lblAddress.Text = _Person.Address;
                lblGender.Text = _Person.Gender;
                lblCountry.Text = _Person.CountryInfo.CountryName;
                lblEditPersonInfo.Enabled = true;

                _LoadPersonImage();
            }
        }

        private void lblEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson(_PersonID);

            frm.ShowDialog();

            // Refresh.
            LoadPersonInfo(_PersonID);
        }

    }
}
