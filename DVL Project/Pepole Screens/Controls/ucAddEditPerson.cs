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

namespace DVL_Project
{
    public partial class ucAddEditPerson : UserControl
    {
        enum enMode { AddNew=1, UpdateMode =2}

        enMode _Mode;

        clsPepole Person;

        public ucAddEditPerson(int PersonID)
        {
            InitializeComponent();

            if (PersonID == -1)
            {
                Person = new clsPepole();
                _Mode = enMode.AddNew;
            }
            else
            {
                Person = clsPepole.FindPerson(PersonID);
                _Mode = enMode.UpdateMode;
            }
        }

        bool _AddNewPerson()
        {
            return Person.Save();
        }

        bool _UpdatePerson()
        {
            return Person.Save();
        }

        bool IsNationalNoExist()
        {
            return (clsPepole.IsPersonExist(tbNationalNo.Text));
        }

        void ValidatingInput(TextBox textBox)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                errorProvider1.SetError(textBox, "should be have a value");
            }
            else
                errorProvider1.SetError(textBox, "");
        }

        public bool Save()
        {

            switch(_Mode)
            {
                case enMode.AddNew:

                    if (_AddNewPerson())
                    {
                        return true;
                    }
                    else
                        return false;

                case enMode.UpdateMode:

                    if (_UpdatePerson())
                    {
                        return true;
                    }
                    else
                        return false;

            }

            return false;
        }

        private void TextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidatingInput((TextBox)sender);
        }

        private void dtDateOfBirth_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lbllinkSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image files (*.PNG;*.JPG;)|*.PNG;*.JPG";
            openFileDialog1.InitialDirectory = @"G:\";
            openFileDialog1.FilterIndex = 0;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbPersonalPicture.ImageLocation = openFileDialog1.FileName;
                lblRemove.Visible = true;
            }
        }

        private void lblRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonalPicture.Image = Resources.No_Person;
            lblRemove.Visible = false;
        }

        private void tbNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (clsPepole.IsPersonExist(tbNationalNo.Text))
            {
                errorProvider1.SetError(tbNationalNo, "this NationalNo is Exist.");
            }
            else
                errorProvider1.SetError(tbNationalNo, "");
        }

        private void ucAddEditPerson_Load(object sender, EventArgs e)
        {
            DataTable dtCountries = clsCountries.GetAllCountries();

            foreach(DataRow row in dtCountries.Rows)
            {

                cbCountry.Items.Add(row["CountryName"]);

            }
        }
    }
}
