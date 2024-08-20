using DrivingBusinessLayer;
using DVL_Project.Glabal_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVL_Project.Users_Screens
{
    public partial class frmAddEditUser : Form
    {
        enum enMode { AddNew = 1, UpdateMode = 2};

        enMode _Mode;

        clsUsers _User;

        public frmAddEditUser()
        {
            InitializeComponent();

            _Mode = enMode.AddNew;
        }

        public frmAddEditUser(int userID)
        {
            InitializeComponent();

            _User = clsUsers.FindUserByUserID(userID);
            _Mode = enMode.UpdateMode;
        }

        private void _ResetDefaultValues()
        {
            if (_Mode == enMode.UpdateMode)
            {
                // load Data of user.
                lblTitle.Text = "Edit User With ID (" + _User.UserID + ")"; // Change Title.
                this.Text = "Update User";
                ucPersonalInfo1.LoadPersonInfo(_User.PersonID);
                btnSelectPerson.Visible = false;
                lblUserID.Text = _User.UserID.ToString();
                tbUsername.Text = _User.Username;
                chbIsActive.Checked = _User.IsActive;
                tbPassword.Enabled = false;
                tbPasswordAgain.Enabled = false;

                return;
            }
            else
            {
                // disable entering user info.
                lblTitle.Text = "Add New User"; // Change Title.
                this.Text = "Add New User";
                _User = new clsUsers();
                tbUsername.Enabled = false;
                tbPassword.Enabled = false;
                tbPasswordAgain.Enabled = false;
                chbIsActive.Enabled = false;
                btnSave.Enabled = false;
            }


            lblUserID.Text = "[????]";
            tbUsername.Text = "";
            tbPassword.Text = "";
            tbPasswordAgain.Text = "";
            chbIsActive.Checked = false;
        }

        bool _Save()
        {
            return _User.Save();
        }

        bool _CheckIsEmpty(TextBox textbox)
        {
            return (string.IsNullOrEmpty(textbox.Text));
        }

        bool _CheckBeforeSaveInUpdateMode()
        {
            if (clsUsers.IsUserExistByUsername(tbUsername.Text) && tbUsername.Text != _User.Username)
            {
                errorProvider1.SetError(tbUsername, "this Username is already exist");
                return false; // if the username is already exist in Update Mode return false.
            }
            else
                errorProvider1.SetError(tbUsername, "");

            return true;
        }

        bool _CheckBeforeSave()
        {
            if (!(_User.PersonID > 0))
                return false;
            
            // if _Mode == AddNew Mode.
            if (clsUsers.IsUserExistByUsername(tbUsername.Text))
            {
                errorProvider1.SetError(tbUsername, "this Username is already exist");
                return false; // if the username is already exist in Add New Mode return false.
            }
            else
                errorProvider1.SetError(tbUsername, "");
            


            if (tbPassword.Text.Length < 8)
            {
                errorProvider1.SetError(tbPassword, "Password should be have 8 or more caracters");
                return false; // if the password has less 8 caracters return false.
            }
            else
                errorProvider1.SetError(tbPassword, "");

            if (tbPasswordAgain.Text != tbPassword.Text)
            {
                errorProvider1.SetError(tbPasswordAgain, "enter same of password");
                return false; // if again password is not same the password return false.
            }
            else
                errorProvider1.SetError(tbPasswordAgain, "");


            if (_CheckIsEmpty(tbUsername) || _CheckIsEmpty(tbPassword) || _CheckIsEmpty(tbPasswordAgain))
                return false; // if the information is incomplete return false.

            return true;
        }

        void _FillUserInfo()
        {
            // Fill User object To add Or Update.
            _User.Username = tbUsername.Text;
            _User.IsActive = chbIsActive.Checked;

            if (_Mode == enMode.AddNew)
            {
                _User.Password = clsUtil.ComputeHash(tbPassword.Text); // in update mode you can't change password, go to change password form.
            }
        }

        private void frmAddEditUser_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelectPerson_Click(object sender, EventArgs e)
        {
            frmFindPerson frm = new frmFindPerson();

            frm.DataPersonBack += LoadPersonInfo;

            frm.ShowDialog();
        }

        private void LoadPersonInfo(object sender, int PersonID)
        {
            _User.PersonID = PersonID;

            if (_User.PersonID > 0)
            {
                if (!clsUsers.IsUserExistByPersonID(PersonID)) // check if this person is already have userID.
                {
                    // Receive Data From frmFindPerson And Load in ucPersonalInfo.
                    ucPersonalInfo1.LoadPersonInfo(PersonID);

                    // Enable entering user info.
                    tbUsername.Enabled = true;
                    tbPassword.Enabled = true;
                    tbPasswordAgain.Enabled = true;
                    chbIsActive.Enabled = true;
                    btnSave.Enabled = true;
                }
                else
                {
                    MessageBox.Show("this Person is already have UserID.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);  // show error if not select a person.

                    ucPersonalInfo1.Reset(); // if the User is exist reset ucPersonalInfo1.
                }

            }
            else
            {
                MessageBox.Show("Please select person to Complete adding user information.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error); // show error if not select a person.

                ucPersonalInfo1.Reset(); // if the User is not found reset ucPersonalInfo1.
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.AddNew)
            {
                if (_CheckBeforeSave()) // for check about information of input.
                {
                    _FillUserInfo();
                    if (_Save())
                    {
                        MessageBox.Show("Added User Successfully.", "Succeded",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
                    }
                    else
                        MessageBox.Show("Added User is failed.", "Failed",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Make sure you enter the information correctly", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (_CheckBeforeSaveInUpdateMode())
                {
                    _FillUserInfo();
                    if (_Save())
                    {

                        MessageBox.Show("Updated User Successfully.", "Succeded",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Updated User is failed.", "Failed",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

    }
}
