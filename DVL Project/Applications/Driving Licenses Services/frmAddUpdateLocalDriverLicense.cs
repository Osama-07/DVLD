using DrivingBusinessLayer;
using DVL_Project.Users_Screens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVL_Project.Applications
{
    public partial class frmAddUpdateLocalDriverLicense : Form
    {
        enum enMode { AddNew = 0, UpdateMode = 1};

        enMode _Mode;
        
        static DataTable LicenseClasses = clsLicenseClasses.GetAllLinceseClasses();
        DataView dvLicenseClasses = LicenseClasses.DefaultView;

        public int LocalDrivingLicenseApplicationsID = -1;
        private clsLocalDrivingLicenseApplications _LocalDrivingLicenseApplications;

        public frmAddUpdateLocalDriverLicense()
        {
            InitializeComponent();

            _Mode = enMode.AddNew;
        }

        public frmAddUpdateLocalDriverLicense(int LocalDrivingLicenseApplicationsiD)
        {
            InitializeComponent();

            LocalDrivingLicenseApplicationsID = LocalDrivingLicenseApplicationsiD;
            _Mode = enMode.UpdateMode;
        }
        
        void _Reset()
        {
            ucPersonalInfo1.Reset(); // if the User is not found person reset ucPersonalInfo1.
            lblApplicationID.Text = "[????]";
            lblPersonID.Text = "[????]";
            lblApplicationDate.Text = "[????]";
            lblApplicationType.Text = "[????]";
            cbLicenseClasses.Enabled = false;
            lblAppFees.Text = "[$$$$]";
            tpPersonalInfo.Show();
            tpApplicationInfo.Hide();
            btnBack.Visible = false;
            btnNext.Enabled = false;
            btnSave.Enabled = false;
        }

        void _FillLocalDrivingApplicationObject()
        {
            // we will add new local driving license application here.
            if (_Mode == enMode.AddNew)
            {
                _LocalDrivingLicenseApplications = new clsLocalDrivingLicenseApplications();
                _LocalDrivingLicenseApplications.ApplicantPersonID = ucPersonalInfo1.PersonID;
                _LocalDrivingLicenseApplications.ApplicationDate = DateTime.Now;
                _LocalDrivingLicenseApplications.ApplicationTypeID = clsApplicationTypes.Find(1).ApplicationTypeID;
                _LocalDrivingLicenseApplications.LastStatusDate = DateTime.Now;
                _LocalDrivingLicenseApplications.PaidFees = _LocalDrivingLicenseApplications.ApplicationTypeInfo.ApplicationFees;
                _LocalDrivingLicenseApplications.CreatedByUserID = clsGlobal.CurrentUser.UserID;
                _LocalDrivingLicenseApplications.LicenseClassID = clsLicenseClasses.Find(clsLicenseClasses.GetLicenseClassID(cbLicenseClasses.Text)).LicenseClassID;
            }
            else
            {
                _LocalDrivingLicenseApplications.LicenseClassID = clsLicenseClasses.Find(clsLicenseClasses.GetLicenseClassID(cbLicenseClasses.Text)).LicenseClassID;
                _LocalDrivingLicenseApplications.LastStatusDate = DateTime.Now;
                _LocalDrivingLicenseApplications.ApplicantPersonID = ucPersonalInfo1.PersonID;
                _LocalDrivingLicenseApplications.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            }
        }

        void _FillApplicationInfoByUpdateMode()
        {
            _LocalDrivingLicenseApplications = clsLocalDrivingLicenseApplications.FindLocalDrivignLicenseApplicationByID(LocalDrivingLicenseApplicationsID);

            ucPersonalInfo1.LoadPersonInfo(_LocalDrivingLicenseApplications.ApplicantPersonID);
            lblTitle.Text = "Update Local Driver License";
            lblApplicationID.Text = _LocalDrivingLicenseApplications.ApplicationID.ToString();
            lblPersonID.Text = Convert.ToInt32(_LocalDrivingLicenseApplications.PersonInfo.PersonID).ToString();
            lblApplicationDate.Text = _LocalDrivingLicenseApplications.ApplicationDate.ToLongDateString();
            cbLicenseClasses.SelectedIndex = clsLocalDrivingLicenseApplications.GetLicenseClassID(_LocalDrivingLicenseApplications.ApplicationID);
            lblApplicationType.Text = _LocalDrivingLicenseApplications.ApplicationTypeInfo.ApplicationTypeTitle;
            lblAppFees.Text = Convert.ToInt32(_LocalDrivingLicenseApplications.PaidFees).ToString();

            btnNext.Enabled = true;
            btnSave.Enabled = true;
            cbLicenseClasses.Enabled = true;
        }
        
        void _FillApplicationInfoByAddNewMode()
        {
            lblTitle.Text = "Add New Local Driving License";
            lblPersonID.Text = ucPersonalInfo1.PersonID.ToString();
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblApplicationType.Text = "New Local Driver License";
            lblAppFees.Text = Convert.ToInt16(clsApplicationTypes.Find(1).ApplicationFees) + " $";

            // Enable entering Application info.
            cbLicenseClasses.SelectedIndex = 0;
            cbLicenseClasses.Enabled = true;
            btnSave.Enabled = true;
        }

        bool _CheckBeforeSave()
        {
            // Get LicenseClassID by Class Name from combo Box.
            int LicenseClassID = clsLicenseClasses.GetLicenseClassID(cbLicenseClasses.Text);
            string NationalNo = _LocalDrivingLicenseApplications.PersonInfo.NationalNo;

            if (!clsLicenses.IsHasLicense(NationalNo, LicenseClassID))
            {
                if (!clsApplications.IsHasApplication(_LocalDrivingLicenseApplications.PersonInfo.PersonID, LicenseClassID))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        bool _Save()
        {
            return _LocalDrivingLicenseApplications.Save();
        }

        void _GetAllLicenseClasses()
        {
            foreach (DataRow row in dvLicenseClasses.Table.Rows)
            {
                cbLicenseClasses.Items.Add(row["ClassName"]);
            }

            cbLicenseClasses.SelectedIndex = 0; // select first item in combo box.
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelectPerson_Click(object sender, EventArgs e)
        {
            frmFindPerson frm = new frmFindPerson();

            frm.DataPersonBack += GetPersonalInfo;

            frm.ShowDialog();
        }

        private void GetPersonalInfo(object sender, int PersonID)
        {
            if (PersonID == -1)
            {
                _Reset();

                MessageBox.Show("Please select person for Complete all steps.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error); // show error if not select a person.
                
                btnNext.Enabled = false;
                return;
            }

            // Receive Data From frmFindPerson And Load in ucPersonalInfo.
            ucPersonalInfo1.LoadPersonInfo(PersonID);

            _FillApplicationInfoByAddNewMode();
            btnNext.Enabled = true;
        }

        private void frmNewLocalDriverLicense_Load(object sender, EventArgs e)
        {
            _GetAllLicenseClasses(); // Fill combo box by license classes.

            if (_Mode == enMode.UpdateMode)
                _FillApplicationInfoByUpdateMode();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _FillLocalDrivingApplicationObject();

            if (_CheckBeforeSave())
            {

                if (_Save())
                {
                    if (_Mode == enMode.AddNew)
                    {
                        // Add local
                        MessageBox.Show("Add Application Successfully.", "Succeded",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                        lblApplicationID.Text = _LocalDrivingLicenseApplications.ApplicationID.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Updated Application Successfully.", "Succeded",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                    MessageBox.Show("Add Application is Failed.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("You Have already application incompleate.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            btnBack.Visible = false;
            btnNext.Visible = true;

            tcAddLocalLicense.SelectTab(1); // select Application Info Tap Page.
            tpApplicationInfo.Show();
            tpPersonalInfo.Hide();

            btnNext.Visible = false;
            btnBack.Visible = true;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            btnNext.Visible = false; // hide btnNext.
            btnBack.Visible = true; // show btnBack

            tcAddLocalLicense.SelectTab(0); // select Personal Info Tap Page.
            tpPersonalInfo.Show();
            tpApplicationInfo.Hide();

            btnNext.Visible = true; // show btnNext.
            btnBack.Visible = false; // hide btnBack.
        }
    }
}
