using DrivingBusinessLayer;
using DVL_Project.Properties;
using DVL_Project.Users_Screens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVL_Project.Applications.Manage_Test_Types
{
    public partial class frmSechduleTests : Form
    {

        private int _LocalDrivingLicenseApplicationID;
        private clsTestTypes.enTestTypes _TestTypeID = clsTestTypes.enTestTypes.Vision;
        private int _AppointmentID;

        public frmSechduleTests(int LocalDrivingLicenseApplicationID, clsTestTypes.enTestTypes TestTypeID, int AppointmentID = -1)
        {
            InitializeComponent();

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestTypeID = TestTypeID;
            _AppointmentID = AppointmentID;
        }

        private void frmSechduleTests_Load(object sender, EventArgs e)
        {
            ctrScheduleTest1.TestTypeID = _TestTypeID;
            ctrScheduleTest1.LoadInfo(_LocalDrivingLicenseApplicationID, _AppointmentID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
