using DrivingBusinessLayer;
using DVL_Project.Glabal_Classes;
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

namespace DVL_Project.Applications.Manage_Tests.Controls
{
    public partial class ctrScheduledTest : UserControl
    {
        private clsTestTypes.enTestTypes _TestTypeID = clsTestTypes.enTestTypes.Vision;
        private int _TestID = -1;

        private int _TestAppointmentID = -1;
        private clsTestAppointments _TestAppointment;

        private int _LocalDrivingLicenseApplicationID = -1;
        private clsLocalDrivingLicenseApplications _LocalDrivingLicenseApplications;

        public clsTestTypes.enTestTypes TestTypeID
        {
            get
            {
                return _TestTypeID;
            }
            set
            {
                _TestTypeID = value;

                switch (_TestTypeID)
                {

                    case clsTestTypes.enTestTypes.Vision:
                        {
                            gbTestType.Text = "Vision Test";
                            pbTestType.Image = Resources.eye;
                            break;
                        }

                    case clsTestTypes.enTestTypes.Writing:
                        {
                            gbTestType.Text = "Written Test";
                            pbTestType.Image = Resources.Wrting;
                            break;
                        }
                    case clsTestTypes.enTestTypes.Street:
                        {
                            gbTestType.Text = "Street Test";
                            pbTestType.Image = Resources.Street;
                            break;

                        }
                }
            }
        }
        public int TestID
        {
            get
            {
                return _TestID;
            }
        }
        public int TestAppointmentID
        {
            get
            {
                return _TestAppointmentID;
            }
        }

        public void LoadInfo(int TestAppointmentID)
        {
            _TestAppointmentID = TestAppointmentID;

            _TestAppointment = clsTestAppointments.Find(TestAppointmentID);

            if (_TestAppointment == null)
            {
                MessageBox.Show("Error: No  Appointment ID = " + _TestAppointmentID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _TestAppointmentID = -1;
                return;
            }

            _TestID = _TestAppointment.TestID;

            _LocalDrivingLicenseApplicationID = _TestAppointment.LocalDrivingLicenseApplicationID;
            _LocalDrivingLicenseApplications = clsLocalDrivingLicenseApplications.FindLocalDrivignLicenseApplicationByID(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplications == null)
            {
                MessageBox.Show("Error: No Local Driving License Application with ID = " + _LocalDrivingLicenseApplicationID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblD_L_AppID.Text = _LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID.ToString();
            lblClassName.Text = _LocalDrivingLicenseApplications.LicenseClass.ClassName;
            lblName.Text = _LocalDrivingLicenseApplications.PersonInfo.FullName();


            //this will show the trials for this test before 
            lblTrial.Text = _LocalDrivingLicenseApplications.TotalTrialsPerTest((int)_TestTypeID).ToString();


            lblDate.Text = clsFormat.DateToShort(_TestAppointment.AppointmentDate);
            lblFees.Text = _TestAppointment.PaidFees.ToString();
            lblTestID.Text = (_TestAppointment.TestID == -1) ? "Not Taken Yet" : _TestAppointment.TestID.ToString();

        }

        public ctrScheduledTest()
        {
            InitializeComponent();
        }


    }
}
