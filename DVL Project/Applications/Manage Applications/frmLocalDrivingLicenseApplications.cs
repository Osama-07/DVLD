using DrivingBusinessLayer;
using DVL_Project.Applications.Application_Controls;
using DVL_Project.Applications.Manage_Applications;
using DVL_Project.Applications.Manage_Applications.Manage_Test_Types;
using DVL_Project.Applications.Manage_Test_Types;
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

namespace DVL_Project.Applications.Manage_Application_Types
{
    public partial class frmLocalDrivingLicenseApplications : Form
    {
        static DataTable dtApplications = clsLocalDrivingLicenseApplications.GetAllLocalDrivingLicenseApplications();
        DataView dvApplications = dtApplications.DefaultView;

        public frmLocalDrivingLicenseApplications()
        {
            InitializeComponent();
        }

        void _LoadAllInfo()
        {
            dgvApplications.Rows.Clear();

            for (int i = 0; i < dvApplications.Count; i++)
            {
                dgvApplications.Rows.Add(dvApplications[i]["LocalDrivingLicenseApplicationID"].ToString(), dvApplications[i]["ClassName"].ToString(),
                    dvApplications[i]["NationalNo"].ToString(), dvApplications[i]["FullName"].ToString(), dvApplications[i]["ApplicationDate"].ToString(),
                    dvApplications[i]["PassedTestCount"].ToString(), dvApplications[i]["Status"].ToString());
            }

        }

        void _RefereshList()
        {
            dtApplications = clsLocalDrivingLicenseApplications.GetAllLocalDrivingLicenseApplications();
            dvApplications = dtApplications.DefaultView;
            _LoadAllInfo();
            lblRecords.Text = "# Records: " + dvApplications.Count.ToString();
            cbFiltersBy.SelectedIndex = 0; // 0 = (None) Mode.
        }

        void _SearchBy()
        {
            string query = "";

            if (cbFiltersBy.Text == "None" || tbSearch.Text == null || tbSearch.Text == "")
            {
                query = "1 = 1";

                dvApplications.RowFilter = query;
                _LoadAllInfo();
                return;
            }

            if (cbFiltersBy.Text == "L.D.L AppID")
            {
                if (int.TryParse(tbSearch.Text, out int ApplicationID))
                {
                    query = "LocalDrivingLicenseApplicationID = " + ApplicationID.ToString();

                    dvApplications.RowFilter = query;
                    _LoadAllInfo();
                    return;
                }
                else
                {
                    tbSearch.Clear();
                    return;
                }
            }

            if (cbFiltersBy.Text == "NationalNo")
            {
                query = "NationalNo Like '" + tbSearch.Text + "%'";

                dvApplications.RowFilter = query;
                _LoadAllInfo();
                return;
            }

            if (cbFiltersBy.Text == "Full Name")
            {
                query = "FullName Like '" + tbSearch.Text + "%'";

                dvApplications.RowFilter = query;
                _LoadAllInfo();
                return;
            }

            if (cbFiltersBy.Text == "Status")
            {
                query = "Status Like '" + tbSearch.Text + "%'";

                dvApplications.RowFilter = query;
                _LoadAllInfo();
                return;
            }

        }

        void _ManageShowAppMenue(string Status, byte PassedTestCount)
        {
            if (Status.ToLower() == "Canceled".ToLower())
            {
                editApplicationToolStripMenuItem.Enabled = false;
                deleteApplicationToolStripMenuItem.Enabled = false;
                cancelApplicationToolStripMenuItem.Enabled = false;
                sechduleTestsToolStripMenuItem.Enabled = false;
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                showLicenseToolStripMenuItem.Enabled = false;
                return;
            }

            if (Status.ToLower() == "Completed".ToLower())
            {
                editApplicationToolStripMenuItem.Enabled = false;
                deleteApplicationToolStripMenuItem.Enabled = false;
                cancelApplicationToolStripMenuItem.Enabled = false;

                sechduleTestsToolStripMenuItem.Enabled = false;
                sechduleVisionTestToolStripMenuItem.Enabled = false;
                sechduleWritenTestToolStripMenuItem.Enabled = false;
                scheduleStreetTestToolStripMenuItem.Enabled = false;

                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                showLicenseToolStripMenuItem.Enabled = true;

                return;

            }

            if (PassedTestCount == 0)
            {
                if (Status.ToLower() == "new")
                { 
                    editApplicationToolStripMenuItem.Enabled = true;
                    deleteApplicationToolStripMenuItem.Enabled = true;
                    cancelApplicationToolStripMenuItem.Enabled = true;

                    sechduleTestsToolStripMenuItem.Enabled = true;
                    sechduleVisionTestToolStripMenuItem.Enabled = true;
                    sechduleWritenTestToolStripMenuItem.Enabled = false;
                    scheduleStreetTestToolStripMenuItem.Enabled = false;

                    issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                    showLicenseToolStripMenuItem.Enabled = false;

                    return;
                }
            }

            if (PassedTestCount == 1)
            {
                if (Status.ToLower() == "new")
                {
                    editApplicationToolStripMenuItem.Enabled = true;
                    deleteApplicationToolStripMenuItem.Enabled = true;
                    cancelApplicationToolStripMenuItem.Enabled = true;

                    sechduleTestsToolStripMenuItem.Enabled = true;

                    sechduleVisionTestToolStripMenuItem.Enabled = false;
                    sechduleWritenTestToolStripMenuItem.Enabled = true;
                    scheduleStreetTestToolStripMenuItem.Enabled = false;

                    issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                    showLicenseToolStripMenuItem.Enabled = false;

                    return;
                }
            }

            if (PassedTestCount == 2)
            {
                if (Status.ToLower() == "new")
                {
                    editApplicationToolStripMenuItem.Enabled = true;
                    deleteApplicationToolStripMenuItem.Enabled = true;
                    cancelApplicationToolStripMenuItem.Enabled = true;

                    sechduleTestsToolStripMenuItem.Enabled = true;

                    sechduleVisionTestToolStripMenuItem.Enabled = false;
                    sechduleWritenTestToolStripMenuItem.Enabled = false;
                    scheduleStreetTestToolStripMenuItem.Enabled = true;

                    issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                    showLicenseToolStripMenuItem.Enabled = false;

                    return;
                }
            }

            if (PassedTestCount == 3)
            {
                if (Status.ToLower() == "new")
                {
                    editApplicationToolStripMenuItem.Enabled = false;
                    deleteApplicationToolStripMenuItem.Enabled = false;
                    cancelApplicationToolStripMenuItem.Enabled = false;

                    sechduleTestsToolStripMenuItem.Enabled = false;

                    sechduleVisionTestToolStripMenuItem.Enabled = false;
                    sechduleWritenTestToolStripMenuItem.Enabled = false;
                    scheduleStreetTestToolStripMenuItem.Enabled = false;

                    issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = true;
                    showLicenseToolStripMenuItem.Enabled = false;

                    return;
                }
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbFiltersBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFiltersBy.Text == "None")
            {
                tbSearch.Visible = false;// Hide tbSearch.
                _SearchBy(); // refresh dgvApplications.
            }
            else
                tbSearch.Visible = true; // show tbSearch.

            tbSearch.Clear();
        }

        private void frmLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            cbFiltersBy.SelectedIndex = 0; // select None mode.
            lblRecords.Text = "# Records: " + dvApplications.Count.ToString();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            _SearchBy();
            lblRecords.Text = "# Records: " + dvApplications.Count.ToString();
        }

        private void showDetailseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseID = Convert.ToInt32((string)dgvApplications.CurrentRow.Cells[0].Value);

            frmDrivingLicenseApplicationInfo frm = new frmDrivingLicenseApplicationInfo(LocalDrivingLicenseID);

            frm.ShowDialog();
        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure do you want cancel this Application?", "Check",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                if (clsLocalDrivingLicenseApplications.Delete(Convert.ToInt32((string)dgvApplications.CurrentRow.Cells[0].Value)))
                {

                    MessageBox.Show("Deleted Successfully", "Succeded", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    _RefereshList();
                }
                else
                    MessageBox.Show("you can't Delete this Application", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

            }
        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure do you want cancel this Application?","Check",
                MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                clsLocalDrivingLicenseApplications L_D_App =
                    clsLocalDrivingLicenseApplications.FindLocalDrivignLicenseApplicationByID(Convert.ToInt32((string)dgvApplications.CurrentRow.Cells[0].Value));

                if (L_D_App.Cancel())
                {
                    MessageBox.Show("Updated Successfully", "Succeded", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    _RefereshList();
                }
                else
                    MessageBox.Show("you Can't Updated this App.", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }


        }

        private void cmsManageApp_Opened(object sender, EventArgs e)
        {
            string Status = (string)dgvApplications.CurrentRow.Cells[6].Value;
            byte PassedTestCount = Convert.ToByte((string)dgvApplications.CurrentRow.Cells[5].Value);

            _ManageShowAppMenue(Status, PassedTestCount);
        }

        private void sechduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            frmTestAppointments frm = new frmTestAppointments(Convert.ToInt32((string)dgvApplications.CurrentRow.Cells[0].Value), clsTestTypes.enTestTypes.Vision);

            frm.ShowDialog();

            _RefereshList();
        }

        private void sechduleWritenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.TestType = clsGlobal.enTestType.WritingTest;

            frmTestAppointments frm = new frmTestAppointments(Convert.ToInt32((string)dgvApplications.CurrentRow.Cells[0].Value), clsTestTypes.enTestTypes.Writing);

            frm.ShowDialog();

            _RefereshList();
        }

        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.TestType = clsGlobal.enTestType.StreetTest;

            frmTestAppointments frm = new frmTestAppointments(Convert.ToInt32((string)dgvApplications.CurrentRow.Cells[0].Value), clsTestTypes.enTestTypes.Street);

            frm.ShowDialog();

            _RefereshList();
        }

        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIssueDrivingLicense frm = new frmIssueDrivingLicense(Convert.ToInt32((string)dgvApplications.CurrentRow.Cells[0].Value));

            frm.ShowDialog();

            _RefereshList();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string NationalNo = (string)dgvApplications.CurrentRow.Cells[2].Value;
            string ClassName = (string)dgvApplications.CurrentRow.Cells[1].Value;

            frmShowDriverLicenseInfo frm = new frmShowDriverLicenseInfo(NationalNo, ClassName);

            frm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string NationalNo = (string)dgvApplications.CurrentRow.Cells["NationalNo"].Value;

            frmShowPersonLicensesHistory frm = new frmShowPersonLicensesHistory(NationalNo);

            frm.ShowDialog();
        }

        private void btnAddApplication_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDriverLicense frm = new frmAddUpdateLocalDriverLicense();

            frm.ShowDialog();

            _RefereshList();
        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (!clsLocalDrivingLicenseApplications.CantEditApplication(Convert.ToInt32(dgvApplications.CurrentRow.Cells[0].Value)))
            {
                frmAddUpdateLocalDriverLicense frm = new frmAddUpdateLocalDriverLicense(Convert.ToInt32(dgvApplications.CurrentRow.Cells[0].Value));

                frm.ShowDialog();

                _RefereshList();
            }
            else
                MessageBox.Show("You can't edit this application because he started tests.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
