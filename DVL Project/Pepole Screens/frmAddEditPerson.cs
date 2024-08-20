using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using DrivingBusinessLayer;
using DVL_Project.Properties;
using System.IO;
using DVL_Project.Glabal_Classes;
using DVL_Project.Users_Screens;

namespace DVL_Project
{
    public partial class frmAddEditPerson : Form
    {
        public delegate void PersonIDBackEventHandler(object sender, int PersonID);

        public event PersonIDBackEventHandler DataPersonBack;

        enum enMode { AddNew = 1, UpdateMode = 2 }

        enMode _Mode;

        clsPepole _Person;

        public frmAddEditPerson()
        {
            InitializeComponent();

            _Person = new clsPepole();
            _Mode = enMode.AddNew;
        }

        public frmAddEditPerson(int PersonID)
        {
            InitializeComponent();

            _Person = clsPepole.FindPerson(PersonID);
            _Mode = enMode.UpdateMode;
        }

        private void _ResetDefualtValues()
        {
            //this will initialize the reset the defaule values
            _FillCountriesInComboBox();

            if (_Mode == enMode.AddNew)
            {
                lblTilte.Text = "Add New Person";
                _Person = new clsPepole();
            }
            else
            {
                lblTilte.Text = "Update Person";
            }

            //set default image for the person.
            pbPersonalPicture.Image = Resources.No_Person;

            //hide/show the remove linke incase there is no image for the person.
            lblRemove.Visible = (pbPersonalPicture.ImageLocation != null);

            //we set the max date to 18 years from today, and set the default value the same.
            dtDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtDateOfBirth.Value = dtDateOfBirth.MaxDate;

            //should not allow adding age more than 100 years
            dtDateOfBirth.MinDate = DateTime.Now.AddYears(-100);

            //this will set default country to jordan.
            cbCountry.SelectedIndex = cbCountry.FindString("Yemen");

            tbFirstName.Text = "";
            tbSecondName.Text = "";
            tbThirdName.Text = "";
            tbLastName.Text = "";
            tbNationalNo.Text = "";
            cbGender.SelectedIndex = cbGender.FindString("Male");
            tbPhone.Text = "";
            tbEmail.Text = "";
            tbAddress.Text = "";
        }

        void _FillCountriesInComboBox()
        {
            // Fill cbCountry.
            DataTable dtCountries = clsCountries.GetAllCountries();

            foreach (DataRow row in dtCountries.Rows)
            {

                cbCountry.Items.Add(row["CountryName"]);

            }
        }

        bool _IsNationalNoExist()
        {
            return (clsPepole.IsPersonExist(tbNationalNo.Text));
        }

        bool _HandlePersonImage()
        {
            if (_Person.PersonalPicture != pbPersonalPicture.ImageLocation)
            {
                if (_Person.PersonalPicture != "")
                {
                    //first we delete the old image from the folder in case there is any.
                    try
                    {
                        File.Delete(_Person.PersonalPicture);
                    }
                    catch(IOException iox)
                    {
                        // we could not delete image the fail.
                        // log it later.
                        MessageBox.Show(iox.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

                if (pbPersonalPicture.ImageLocation != null)
                {
                    string sourcefile = pbPersonalPicture.ImageLocation;

                    if (clsGlobal.util.CopyImageToProjectImagesFolder(ref sourcefile))
                    {
                        pbPersonalPicture.ImageLocation = sourcefile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                }

            }

            return true;
        }

        void _FillPerson()
        {
            _Person.NationalNo = tbNationalNo.Text.Trim();
            _Person.FirstName = tbFirstName.Text.Trim();
            _Person.SecondName = tbSecondName.Text.Trim();
            _Person.ThirdName = tbThirdName.Text.Trim();
            _Person.LastName = tbLastName.Text.Trim();
            _Person.Email = tbEmail.Text.Trim();
            _Person.Phone = tbPhone.Text.Trim();
            _Person.DateOfBirth = dtDateOfBirth.Value;
            _Person.CountryID = clsCountries.GetCountryID(cbCountry.Text);
            _Person.Address = tbAddress.Text.Trim();
            _Person.Gender = cbGender.Text;

            if (pbPersonalPicture.ImageLocation != null)
            {
                _Person.PersonalPicture = pbPersonalPicture.ImageLocation;
            }
            else
                _Person.PersonalPicture = "";

        }

        void _FillBoxes()
        {
            lblPersonID.Text = _Person.PersonID.ToString();
            tbNationalNo.Text = _Person.NationalNo.Trim();
            tbFirstName.Text = _Person.FirstName.Trim();
            tbSecondName.Text = _Person.SecondName.Trim();
            tbThirdName.Text = _Person.ThirdName.Trim();
            tbLastName.Text = _Person.LastName.Trim();
            tbEmail.Text = _Person.Email.Trim();
            tbPhone.Text = _Person.Phone.Trim();
            dtDateOfBirth.Value = _Person.DateOfBirth;
            cbCountry.SelectedIndex = _Person.CountryID - 1; // number of country - 1 because cbCountry start from 0.
            tbAddress.Text = _Person.Address.Trim();

            if (_Person.Gender == "Male")
            {
                cbGender.SelectedIndex = 0;// select (Male). 
            }
            else
                cbGender.SelectedIndex = 1;// select (Female).


            if (_Person.PersonalPicture != "" && _Person.PersonalPicture != null)
            {
                pbPersonalPicture.ImageLocation = _Person.PersonalPicture;
                lblRemove.Visible = true;
            }
            else
                pbPersonalPicture.Image = Resources.No_Person;


        }

        bool _ValidatingInput(TextBox textBox)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                errorProvider1.SetError(textBox, "should be have a value");
                return false;
            }
            else
                errorProvider1.SetError(textBox, "");

            return true;
        }

        bool _CheckBeforeSave()
        {
            // Check tbNationalNo.
            if (!_ValidatingInput(tbNationalNo) || _IsNationalNoExist())
            {
                if (tbNationalNo.Text != _Person.NationalNo)
                {
                    return false;// if this is wrong return false.
                }

            }

            // Check tbFirstName.
            if (!_ValidatingInput(tbFirstName))
            {
                return false;// if this is wrong return false.
            }

            // Check tbSecondName.
            if (!_ValidatingInput(tbSecondName))
            {
                return false;// if this is wrong return false.
            }

            // Check tbThirdName.
            if (!_ValidatingInput(tbThirdName))
            {
                return false;// if this is wrong return false.
            }

            // Check tbLastName.
            if (!_ValidatingInput(tbLastName))
            {
                return false;// if this is wrong return false.
            }

            // Check tbEmail.
            if (!_ValidatingInput(tbEmail) || !clsValidation.ValidateEmail(tbEmail.Text))
            {
                return false;// if this is wrong return false.
            }
            else
            {
                if (!clsValidation.ValidateEmail(tbEmail.Text))
                    return false;
            }

            // Check tbPhone.
            if (!_ValidatingInput(tbPhone))
            {
                return false;// if this is wrong return false.
            }

            // Check tbAddress.
            if (!_ValidatingInput(tbAddress))
            {
                return false;// if this is wrong return false.
            }

            // Check dtDateOfBirth.
            if (!_CheckDate(dtDateOfBirth))
            {
                return false; // if the input date less than 18 years return false.
            }



            return true;
        }

        public bool Save()
        {
            return _Person.Save();
        }

        private bool _CheckDate(DateTimePicker date)
        {
            if (date.Value.AddYears(18) > DateTime.Now)
            {
                errorProvider1.SetError(date, "Date Must be 18 Years Or Older.");
                return false;// if the input date less than 18 return false.
            }
            else
                errorProvider1.SetError(date, "");

            return true;
        }

        private void TextBox_Validating(object sender, CancelEventArgs e)
        {
            _ValidatingInput((TextBox)sender);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (!_HandlePersonImage())
                return;

            if (_CheckBeforeSave())// if Mode is Add New compailer will come here.
            {
                _FillPerson();// store all information in Person object.

                if (Save())// if Save is (true) store Person information in database.
                {
                    DataPersonBack?.Invoke(this, _Person.PersonID);

                    MessageBox.Show("Added Successfully.", "Succeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else
                MessageBox.Show("Added is failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

        private void frmAddNewPerson_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if (_Mode == enMode.UpdateMode)
                _FillBoxes();
        }

        private void lbllinkSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
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
            pbPersonalPicture.ImageLocation = null;
            pbPersonalPicture.Image = Resources.No_Person;
            lblRemove.Visible = false;
        }

        private void tbEmail_Validating(object sender, CancelEventArgs e)
        {
            if (_ValidatingInput(tbEmail))
            {
                if (!tbEmail.Text.EndsWith("@gmail.com") && !tbEmail.Text.EndsWith("@hotmail.com") || !clsValidation.ValidateEmail(tbEmail.Text))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(tbEmail, "the Email should be have End a value like (@gmail.com) Or (@hotmail.com)");
                    return;
                }
                else
                    errorProvider1.SetError(tbEmail, "");

                e.Cancel = false;
            }
        }

        private void dtDateOfBirth_Validating(object sender, CancelEventArgs e)
        {
            _CheckDate(dtDateOfBirth);
        }


    }
}
