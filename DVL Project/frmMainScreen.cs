using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DrivingBusinessLayer;
using DVL_Project.Applications;
using DVL_Project.Applications.Application_Controls;
using DVL_Project.Applications.Detain_Licenses;
using DVL_Project.Applications.Driving_Licenses_Services;
using DVL_Project.Applications.Manage_Application_Types;
using DVL_Project.Applications.Manage_Test_Types;
using DVL_Project.Drivers_Screens;
using DVL_Project.Login;
using DVL_Project.Users_Screens;

namespace DVL_Project
{
    public partial class frmMainScreen : Form
    {
        private frmLogin _frmLogin;

        public frmMainScreen(frmLogin Login)
        {
            InitializeComponent();

            _frmLogin = Login;
        }

        private void DLVDSystem_Load(object sender, EventArgs e)
        {
            this.
            lblLogedUser.Text = "Loged User: " + clsGlobal.CurrentUser.Username;
        }

        private void pepolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPepole frm = new frmPepole();

            frm.ShowDialog();
        }

        private void logoutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            _frmLogin.Show();
            this.Close();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmShowUserDetailse frm = new frmShowUserDetailse(clsGlobal.CurrentUser.UserID);

            frm.ShowDialog();

        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListUsers UserForm = new frmListUsers();

            UserForm.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListDrivers frm = new frmListDrivers();

            frm.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDriverLicense frm = new frmAddUpdateLocalDriverLicense();

            frm.ShowDialog();
        }

        private void localDrivingLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalDrivingLicenseApplications frm = new frmLocalDrivingLicenseApplications();

            frm.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddInternationalLicenses frm = new frmAddInternationalLicenses();

            frm.ShowDialog();
        }

        private void lostDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplacementForLostOrDamagedLicense frm = new frmReplacementForLostOrDamagedLicense();

            frm.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewLicenses frm = new frmRenewLicenses();

            frm.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageTestTypes frm = new frmManageTestTypes();

            frm.ShowDialog();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageApplicationTypes frm = new frmManageApplicationTypes();

            frm.ShowDialog();
        }

        private void internationalDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInternationalLicenseApplications frm = new frmInternationalLicenseApplications();

            frm.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDerainLicense frm = new frmDerainLicense();

            frm.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseLicense frm = new frmReleaseLicense();

            frm.ShowDialog();
        }

        private void releaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseLicense frm = new frmReleaseLicense();

            frm.ShowDialog();
        }

        private void manageDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageDetaines frm = new frmManageDetaines();

            frm.ShowDialog();
        }

        private void ChangePasswordtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(clsGlobal.CurrentUser.UserID);

            frm.ShowDialog();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalDrivingLicenseApplications frm = new frmLocalDrivingLicenseApplications();

            frm.ShowDialog();
        }

        private void frmMainScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsGlobal.CurrentUser = null;
            _frmLogin.Show();
            this.Close();
        }
    }
}
