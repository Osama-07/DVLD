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
    public partial class frmChangePassword : Form
    {

        clsUsers _User;


        public frmChangePassword(int UserID)
        {
            InitializeComponent();

            _User = clsUsers.FindUserByUserID(UserID);
        }

        bool _TextBoxIsEmpty(TextBox textBox)
        {
            // check null or empty.
            if (string.IsNullOrEmpty(textBox.Text))
            {
                errorProvider1.SetError(textBox, "should be have a value.");
                return false;
            }
            else
                errorProvider1.SetError(textBox, "");

            if (textBox.TextLength < 8)
            {
                errorProvider1.SetError(textBox, "should be have 8 length or more.");
                return false;
            }
            else
                errorProvider1.SetError(textBox, "");


            return true;
        }

        bool _CheckInputsBeforeSave()
        {

            // check null or empty.
            if (!_TextBoxIsEmpty(tbOldPassword) || !_TextBoxIsEmpty(tbNewPassword) || !_TextBoxIsEmpty(tbRenterNewPassword))
                return false;

            // check if tbOldPassword is same current Password.
            if (clsUtil.ComputeHash(tbOldPassword.Text) != _User.Password)
            {
                errorProvider1.SetError(tbOldPassword, "enter old password.");
                return false;
            }
            else
                errorProvider1.SetError(tbOldPassword, "");

            // check if rental new password same new password.
            if (tbRenterNewPassword.Text != tbNewPassword.Text)
            {
                errorProvider1.SetError(tbRenterNewPassword, "this not same new password.");
                return false;
            }
            else
                errorProvider1.SetError(tbRenterNewPassword, "");


            return true;
        }

        private void PasswordValidating(object sender, CancelEventArgs e)
        {
            if (!_TextBoxIsEmpty((TextBox)sender))
                return;


            if (tbRenterNewPassword.Text != tbNewPassword.Text)
            {
                errorProvider1.SetError(tbRenterNewPassword, "this not same new password.");
                return;
            }
            else
                errorProvider1.SetError(tbRenterNewPassword, "");

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Found Error, check your enter info.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (_CheckInputsBeforeSave())
            {
                string HashPassword = clsUtil.ComputeHash(tbNewPassword.Text);
                _User.Password = HashPassword;

                if (_User.Save())
                {
                    clsUtil.SaveLoginRegister("", ""); // clear login registry while change password.

                    MessageBox.Show("Updated Password successfully", "Succeded", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("sure than inputs currctly", "error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
        }

        private void tbOldPassword_Validating(object sender, CancelEventArgs e)
        {

            if (!_TextBoxIsEmpty(tbOldPassword)) // if text box is empty will return.
                return;


            if (clsUtil.ComputeHash(tbOldPassword.Text) != _User.Password)
            {
                errorProvider1.SetError(tbOldPassword, "enter old password.");
                return;
            }
            else
                errorProvider1.SetError(tbOldPassword, "");

        }

        private void btnShowNewPassword_Click(object sender, EventArgs e)
        {
            if (tbNewPassword.UseSystemPasswordChar == false)
                tbNewPassword.UseSystemPasswordChar = true;
            else
                tbNewPassword.UseSystemPasswordChar = false;

            tbNewPassword.Focus();
        }

        private void btnShowOldPassword_Click(object sender, EventArgs e)
        {
            if (tbOldPassword.UseSystemPasswordChar == false)
                tbOldPassword.UseSystemPasswordChar = true;
            else
                tbOldPassword.UseSystemPasswordChar = false;

            tbOldPassword.Focus();
        }

        private void btnShowRenterPassword_Click(object sender, EventArgs e)
        {
            if (tbRenterNewPassword.UseSystemPasswordChar == false)
                tbRenterNewPassword.UseSystemPasswordChar = true;
            else
                tbRenterNewPassword.UseSystemPasswordChar = false;

            tbRenterNewPassword.Focus();
        }
    }
}
