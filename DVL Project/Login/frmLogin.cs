using DrivingBusinessLayer;
using DVL_Project.Glabal_Classes;
using DVL_Project.Users_Screens;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DVL_Project.Login
{
    public partial class frmLogin : Form
    {

        public frmLogin()
        {
            InitializeComponent();
        }

        private bool _CheckLoginInfo()
        {
            string HashPassword = clsUtil.ComputeHash(tbPassword.Text);

            clsGlobal.CurrentUser = clsUsers.FindUserByUsernameAndPassword(tbUsername.Text.ToLower(), HashPassword.ToLower());

            if (clsGlobal.CurrentUser != null)
            {
                if (clsGlobal.CurrentUser.IsActive)
                {
                    return true;
                }
                else
                    MessageBox.Show("Your not have a permisstion to login, tell your manage to login", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
                MessageBox.Show("Username Or Password is Wrong, try agine.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            return false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbUsername_Enter(object sender, EventArgs e)
        {
            if (tbUsername.Text == "Username")
            {
                tbUsername.Text = "";
                tbUsername.ForeColor = Color.Black;
            }
        }

        private void tbUsername_Leave(object sender, EventArgs e)
        {
            if (tbUsername.Text == "")
            {
                tbUsername.Text = "Username";
                tbUsername.ForeColor = Color.Gray;
            }
        }

        private void tbPassword_Enter(object sender, EventArgs e)
        {
            if (tbPassword.Text == "Password")
            {
                tbPassword.Text = "";
                tbPassword.ForeColor = Color.Black;
                tbPassword.UseSystemPasswordChar = true;
            }
        }

        private void tbPassword_Leave(object sender, EventArgs e)
        {
            if (tbPassword.Text == "")
            {
                tbPassword.Text = "Password";
                tbPassword.ForeColor = Color.Gray;
                tbPassword.UseSystemPasswordChar = false;
            }
        }

        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            if (tbPassword.UseSystemPasswordChar == false)
            {
                tbPassword.UseSystemPasswordChar = true;
                tbPassword.Focus();
            }
            else
            {
                tbPassword.UseSystemPasswordChar = false;
                tbPassword.Focus();
            }
        }

        private void tbUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbUsername.Text))
            {

                epLogin.SetError(tbUsername, "this box Should be has a value");

            }
            else
                epLogin.SetError(tbUsername, "");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (_CheckLoginInfo())
            {
                if (chkRememberMe.Checked)
                {
                    //clsUtil.SaveLoginRegister(tbUsername.Text, tbPassword.Text);
                    clsGlobal.util.RememberMe(tbUsername.Text, tbPassword.Text); // save login info in txt File.
                    chkRememberMe.Checked = true;
                }
                else
                {
                    clsUtil.SaveLoginRegister("", "");
                    chkRememberMe.Checked = false;
                    tbUsername.Text = "";
                    tbPassword.Text = "";
                    tbUsername_Leave(null, null);
                    tbPassword_Leave(null, null);
                }


                frmMainScreen frmMain = new frmMainScreen(this);
                this.Hide();
                frmMain.ShowDialog();
            }
            else
                lblWrongMessage.Visible = true;
        }

        private void tbUsername_TextChanged(object sender, EventArgs e)
        {
            chkRememberMe.Checked = false;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            // Old way.
            //if (clsUtil.LoadLoginInfo(ref tbUsername, ref tbPassword)) // Load Login Info From File.
            //    chkRememberMe.Checked = true;

            //New way.
            //string Username = "", Password = "";
            //if (clsGlobal.util.LoadLoginInfo(ref Username, ref Password)) // Load Login Info From File.
            //{
            //    //write information in Text boxes and change fore color from 'gray' to 'black'.
            //   tbUsername.ForeColor = Color.Black;
            //    tbUsername.Text = Username;

            //    tbPassword.ForeColor = Color.Black;
            //    tbPassword.Text = Password;
            //    tbPassword.UseSystemPasswordChar = true;

            //    chkRememberMe.Checked = true;
            //}

            tbUsername_Leave(null, null);
            tbPassword_Leave(null, null);
            tbUsername.Focus();
        }

    }
}
