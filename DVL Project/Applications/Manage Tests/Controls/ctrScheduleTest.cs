using DrivingBusinessLayer;
using DVL_Project.Properties;
using DVL_Project.Users_Screens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVL_Project.Applications.Manage_Test_Types.Manage_Test_Types
{
    public partial class ctrScheduleTest : UserControl
    {
        public enum enMode { AddNew = 1, Update = 2 }
        enMode _Mode;

        public enum enCreationMode { FirstTimeTestSchedule = 1, RetakeTestSchedule = 2}
        enCreationMode _CreationMode = enCreationMode.FirstTimeTestSchedule;     

        private clsTestTypes.enTestTypes _TestTypeID = clsTestTypes.enTestTypes.Vision;
        public clsTestTypes.enTestTypes TestTypeID
        {
            get
            {
                return _TestTypeID;
            }
            set
            {
                _TestTypeID = value;

                switch(_TestTypeID)
                {
                    case clsTestTypes.enTestTypes.Vision:
                        {
                            gbTestType.Text = "Vision Test";
                            pbTestType.Image = Resources.eye;
                        }
                        break;
                    case clsTestTypes.enTestTypes.Writing:
                        {
                            gbTestType.Text = "Writing Test";
                            pbTestType.Image = Resources.Wrting;
                        }
                        break;
                    case clsTestTypes.enTestTypes.Street:
                        {
                            gbTestType.Text = "Street Test";
                            pbTestType.Image = Resources.Street;
                        }
                        break;
                    default:
                        {
                            gbTestType.Text = "Vision Test";
                            pbTestType.Image = Resources.eye;
                        }
                        break;
                }

            }

        }

        private clsLocalDrivingLicenseApplications _LocalDrivingLicenseApplications;
        private int _LocalDrivingLicenseApplicationID = -1;

        private clsTestAppointments _TestAppointment;
        private int _TestAppointmentID = - 1;

        public ctrScheduleTest()
        {
            InitializeComponent();
        }


        /*bool _AddRetakeApplication()
        {
            clsApplications _RetakeApplication = new clsApplications();

            _RetakeApplication.ApplicantPersonID = _TestAppointment.LocalDrivingLicenseApplication.ApplicantPersonID;
            _RetakeApplication.ApplicationDate = DateTime.Now;
            _RetakeApplication.LastStatusDate = DateTime.Now;
            _RetakeApplication.ApplicationStatus = (clsApplications.enApplicationStatus)3;
            _RetakeApplication.PaidFees = _RetakeApplication.ApplicationTypeInfo.ApplicationFees;
            _RetakeApplication.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (_RetakeApplication.Save())
            {
                _TestAppointment.RetakeTestApplicationID = _RetakeApplication.ApplicationID;
                lblRetakeAppID.Text = _RetakeApplication.ApplicationID.ToString();
                return true;
            }
            else
                return false;
        }

        bool _AddNewAppointment()
        {
            _TestAppointment = new clsTestAppointments();

            _TestAppointment.TestTypeID = (int)_TestTypeID;
            _TestAppointment.LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplicationID;
            _TestAppointment.AppointmentDate = dtpSechduleDate.Value;
            _TestAppointment.PaidFees = clsTestTypes.Find(_TestTypeID).TestTypeFees;
            _TestAppointment.CreatedByUser = clsGlobal.CurrentUser;
            _TestAppointment.IsLocked = false;

            return _TestAppointment.Save();
        }

        bool _UpdateAppointment()
        {
            _TestAppointment.AppointmentDate = dtpSechduleDate.Value; // just the date you can edit.

            return _TestAppointment.Save();
        }

        bool _Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:

                    if (_AddNewAppointment())
                    {

                        _Mode = enMode.Update;

                        return true;
                    }
                    else
                        return false;

                case enMode.Update:

                    if (_UpdateAppointment())
                    {
                        return true;
                    }
                    else
                        return false;
            }

            return false;
        }*/

        private bool _HandleAvtiveTestAppointmentConstraint()
        {
            if (clsLocalDrivingLicenseApplications.IsThereAnActiveScheduledTest(_LocalDrivingLicenseApplicationID, (int)_TestTypeID))
            {
                btnSave.Enabled = false;
                dtpSechduleDate.Enabled = false;
                return false;
            }

            return true;
        }

        private bool _HandleLockedTestAppointmentConstraint()
        {
            if (_TestAppointment.IsLocked)
            {
                MessageBox.Show("person already set for the test, appointment Locked.", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                dtpSechduleDate.Enabled = false;
                btnSave.Enabled = false;
                return false;
            }

            return true;
        }

        private bool _HandlePreviousTestConstraint()
        {
            switch (TestTypeID)
            {
                case clsTestTypes.enTestTypes.Vision:
                    {
                        return true;
                    }
                case clsTestTypes.enTestTypes.Writing:
                    {
                        if (!_LocalDrivingLicenseApplications.DoesPassedTestType((int)clsTestTypes.enTestTypes.Vision))
                        {
                            MessageBox.Show("Person is not passed in Vision test.", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            dtpSechduleDate.Enabled = false;
                            btnSave.Enabled = false;
                            return false;
                        }
                        else
                            return true;
                    }
                case clsTestTypes.enTestTypes.Street:
                    {
                        if (!_LocalDrivingLicenseApplications.DoesPassedTestType((int)clsTestTypes.enTestTypes.Vision))
                        {
                            MessageBox.Show("Person is not passed in Writing test.", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            dtpSechduleDate.Enabled = false;
                            btnSave.Enabled = false;
                            return false;
                        }
                        else
                            return true;
                    }                
            }

            return false;
        }

        private bool _HandleRetakeTestApplication()
        {
            if (_Mode == enMode.AddNew && _CreationMode == enCreationMode.RetakeTestSchedule)
            {
                clsApplications _RetakeApplication = new clsApplications();

                _RetakeApplication.ApplicantPersonID = _LocalDrivingLicenseApplications.ApplicantPersonID;
                _RetakeApplication.ApplicationTypeID = clsApplicationTypes.Find(8).ApplicationTypeID;
                _RetakeApplication.ApplicationDate = DateTime.Now;
                _RetakeApplication.LastStatusDate = DateTime.Now;
                _RetakeApplication.ApplicationStatus = (clsApplications.enApplicationStatus)3;
                _RetakeApplication.PaidFees = _RetakeApplication.ApplicationTypeInfo.ApplicationFees;
                _RetakeApplication.CreatedByUserID = clsGlobal.CurrentUser.UserID;

                if (!_RetakeApplication.Save())
                {
                    _TestAppointment.RetakeTestApplicationID = -1;
                    MessageBox.Show("Filed to create application.", "Filed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                _TestAppointment.RetakeTestApplicationID = _RetakeApplication.ApplicationID;
                lblRetakeAppID.Text = _RetakeApplication.ApplicationID.ToString();
            }

            return true;
        }

        private bool _LoadTestAppointmentData()
        {
            _TestAppointment = clsTestAppointments.Find(_TestAppointmentID);

            if (_TestAppointment == null)
            {
                MessageBox.Show("Error: No Local Driving License Info with ID " + _LocalDrivingLicenseApplicationID, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return false;
            }

            lblFees.Text = _TestAppointment.PaidFees.ToString();

            if (DateTime.Compare(DateTime.Now, _TestAppointment.AppointmentDate) < 0)
                dtpSechduleDate.MinDate = DateTime.Now;
            else
                dtpSechduleDate.MinDate = _TestAppointment.AppointmentDate;

            dtpSechduleDate.Value = _TestAppointment.AppointmentDate;

            if (_TestAppointment.RetakeTestApplicationID == -1)
            {
                lblRetakeAppID.Text = "N/A";
                lblAppFees.Text = "0";
            }
            else
            {
                lblRetakeAppID.Text = _TestAppointment.RetakeTestApplicationID.ToString();
                lblAppFees.Text = _TestAppointment.RetakeTestApplication.PaidFees.ToString();
                gbRetakeAppInfo.Enabled = true;
            }

            return true;
        }

        public void LoadInfo(int LocalDrivingLicenseApplicationID, int AppointmentID = -1)
        {
            if (AppointmentID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestAppointmentID = AppointmentID;
            _LocalDrivingLicenseApplications = clsLocalDrivingLicenseApplications.FindLocalDrivignLicenseApplicationByID(_LocalDrivingLicenseApplicationID);


            if (_LocalDrivingLicenseApplications == null)
            {
                MessageBox.Show("Error: No Local Driving License Info with ID " + _LocalDrivingLicenseApplicationID, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }


            if (clsTestAppointments.IsFaild(_LocalDrivingLicenseApplicationID, (int)_TestTypeID))
                _CreationMode = enCreationMode.RetakeTestSchedule;
            else
                _CreationMode = enCreationMode.FirstTimeTestSchedule;


            if (_CreationMode == enCreationMode.RetakeTestSchedule)
            {
                lblAppFees.Text = clsApplicationTypes.Find(8).ApplicationFees.ToString(); // application fees for retake test.
                gbRetakeAppInfo.Enabled = true;
                lblRetakeAppID.Text = "[????]";
            }
            else
            {
                lblAppFees.Text = "0";
                gbRetakeAppInfo.Enabled = false;
                lblTotalFees.Text = "0";
                lblRetakeAppID.Text = "N/A";
            }


            lblD_L_AppID.Text = _LocalDrivingLicenseApplicationID.ToString();
            lblClassName.Text = _LocalDrivingLicenseApplications.LicenseClass.ClassName;
            lblName.Text = _LocalDrivingLicenseApplications.PersonInfo.FullName();
            lblTrial.Text = _LocalDrivingLicenseApplications.TotalTrialsPerTest((int)_TestTypeID).ToString();


            if (_Mode == enMode.AddNew)
            {
                _TestAppointment = new clsTestAppointments();

                lblFees.Text = clsTestTypes.Find(_TestTypeID).TestTypeFees.ToString();
                dtpSechduleDate.MinDate = DateTime.Now;
                lblRetakeAppID.Text = "N/A";

            }
            else
            {
                if (!_LoadTestAppointmentData())
                {
                    return;
                }
            }

            lblTotalFees.Text = ((Convert.ToSingle(lblAppFees.Text)) + Convert.ToSingle(lblFees.Text)).ToString();

            if (_Mode == enMode.AddNew)
                if (!_HandleAvtiveTestAppointmentConstraint())
                    return;

            if (!_HandleLockedTestAppointmentConstraint())
                return;

            if (!_HandlePreviousTestConstraint())
                return;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                _TestAppointment.AppointmentDate = dtpSechduleDate.Value;

                if (_TestAppointment.Save())
                {
                    MessageBox.Show("Update Appointment successfully.", "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Update Appointment is Filed.", "Filed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (!_HandleRetakeTestApplication())
                return;

            _TestAppointment.TestTypeID = (int)_TestTypeID;
            _TestAppointment.LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplicationID;
            _TestAppointment.PaidFees = Convert.ToDecimal(lblFees.Text);
            _TestAppointment.CreatedByUser = clsGlobal.CurrentUser;

            if (_TestAppointment.Save())
            {
                _Mode = enMode.Update;
                MessageBox.Show("Add Appointment successfully.", "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Filed Add Appointment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
