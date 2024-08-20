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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVL_Project.Applications.Manage_Test_Types
{
    public partial class frmTakeTask : Form
    {
        private int _TestID = -1;
        private clsTests _Test;
        private int _TestAppointmentID = -1;
        private clsTestTypes.enTestTypes _TestTypeID = clsTestTypes.enTestTypes.Vision;

        public frmTakeTask(int AppointmentID, clsTestTypes.enTestTypes TestTypeID)
        {
            InitializeComponent();

            this._TestAppointmentID = AppointmentID;
            this._TestTypeID = TestTypeID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTakeTask_Load(object sender, EventArgs e)
        {
            ctrScheduledTest1.TestTypeID = _TestTypeID;

            ctrScheduledTest1.LoadInfo(_TestAppointmentID);

            if (ctrScheduledTest1.TestAppointmentID == -1)
                btnSave.Enabled = false;
            else
                btnSave.Enabled = true;


            _TestID = ctrScheduledTest1.TestID;

            if (_TestID == -1)
            {
                _Test = new clsTests();
            }
            else
            {
                _Test = clsTests.Find(_TestID);

                if (_Test.TestResult)
                    rbPass.Checked = true;
                else
                    rbFail.Checked = true;

                tbNotes.Text = _Test.Notes;

                gbResult.Enabled = false;
                tbNotes.Enabled = false;
                btnSave.Enabled = false;
            }
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save? After that you cannot change the Pass/Fail results after you save?.",
                        "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            _Test.TestAppointmentID = _TestAppointmentID;
            _Test.TestAppointment = clsTestAppointments.Find(_TestAppointmentID);
            _Test.TestResult = rbPass.Checked;
            _Test.Notes = tbNotes.Text.Trim();
            _Test.CreatedByUser = clsGlobal.CurrentUser;

            if (_Test.Save()) // Save of Take Test.
            {
                _Test.TestAppointment.IsLocked = true;

                if (_Test.TestAppointment.Save()) // Save after change (IsLocked).
                {
                    gbResult.Enabled = false;
                    btnSave.Enabled = false;

                    MessageBox.Show("Test Compleated.", "Succeeded", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }

            }
            else
                MessageBox.Show("Test is InCompleate.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
        }


    }
}
