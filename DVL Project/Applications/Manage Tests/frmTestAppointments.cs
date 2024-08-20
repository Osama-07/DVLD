using DrivingBusinessLayer;
using DVL_Project.Properties;
using DVL_Project.Users_Screens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVL_Project.Applications.Manage_Test_Types
{
    public partial class frmTestAppointments : Form
    {
        static DataTable dtAppointments;
        DataView dvAppointments;

        private int _LocalDrivingLicenseApplicationID;
        private clsTestTypes.enTestTypes _TestType = clsTestTypes.enTestTypes.Vision;

        public frmTestAppointments(int D_L_AppID, clsTestTypes.enTestTypes testType)
        {
            InitializeComponent();

            _LocalDrivingLicenseApplicationID = D_L_AppID;
            _TestType = testType;
        }

        void _RefereshAppointmentsInfo()
        {
            if (clsTests.GetPassedTestCount(this._LocalDrivingLicenseApplicationID) != (int)_TestType)
            {
                dtAppointments = clsTestAppointments.GetAllTestAppointmentsByD_L_AppID(this._LocalDrivingLicenseApplicationID, (int)_TestType);
                dvAppointments = dtAppointments.DefaultView;
            }
            else
            {
                dtAppointments = clsTestAppointments.GetAllTestAppointmentsByD_L_AppID(this._LocalDrivingLicenseApplicationID, (int)_TestType);
                dvAppointments = dtAppointments.DefaultView;
            }

            dgvAppointments.DataSource = dvAppointments;
            lblRecords.Text = "# Records : " + dvAppointments.Count.ToString();
        }

        void _LoadTestTypeImageAndTitle()
        {
            switch (clsGlobal.TestType)
            {
                case clsGlobal.enTestType.VisionTest:
                    {
                        pbTestType.Image = Resources.eye;
                        lblTitle.Text = "Vision Test Appointments";
                    }
                    break;

                case clsGlobal.enTestType.WritingTest:
                    {
                        pbTestType.Image = Resources.Wrting;
                        lblTitle.Text = "Writing Test Appointments";
                    }
                    break;

                case clsGlobal.enTestType.StreetTest:
                    {
                        pbTestType.Image = Resources.Street;
                        lblTitle.Text = "Street Test Appointments";
                    }
                    break;

            }
        }

        private void frmTestAppointments_Load(object sender, EventArgs e)
        {
            _LoadTestTypeImageAndTitle();

            dtAppointments = clsTestAppointments.GetAllTestAppointmentsByD_L_AppID(_LocalDrivingLicenseApplicationID, (int)_TestType);
            dvAppointments = dtAppointments.DefaultView;
            
            dgvAppointments.DataSource = dvAppointments;
            lblRecords.Text = "# Records : " + dvAppointments.Count.ToString();
            
            ctrDrivingLicenseApplicationInfo1.LoadDrivigLicenseApplicationInfo(_LocalDrivingLicenseApplicationID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            bool IsFound = clsLocalDrivingLicenseApplications.DoesPassedTestType(this._LocalDrivingLicenseApplicationID, (int)_TestType);

            if (!IsFound)
            {
                if (!clsLocalDrivingLicenseApplications.IsThereAnActiveScheduledTest(this._LocalDrivingLicenseApplicationID, (int)_TestType))
                {

                    frmSechduleTests frm = new frmSechduleTests(this._LocalDrivingLicenseApplicationID, _TestType);

                    frm.ShowDialog();

                    _RefereshAppointmentsInfo();

                }
                else
                    MessageBox.Show("He already Has an active test, go to test.", "Stop",
                                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
                MessageBox.Show("this Person is already Passed in this test, go to next test.", "Stop",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void editTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int AppointmentID = (int)dgvAppointments.CurrentRow.Cells[0].Value;

            frmSechduleTests frm = new frmSechduleTests(this._LocalDrivingLicenseApplicationID, _TestType, AppointmentID);

            frm.ShowDialog();

            _RefereshAppointmentsInfo();
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int AppointmentID = (int)dgvAppointments.CurrentRow.Cells[0].Value;

            frmTakeTask frm = new frmTakeTask(AppointmentID, _TestType);

            frm.ShowDialog();

            _RefereshAppointmentsInfo();
        }
    }
}
