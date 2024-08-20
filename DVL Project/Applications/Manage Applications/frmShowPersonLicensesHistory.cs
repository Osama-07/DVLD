using DrivingBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVL_Project.Applications.Manage_Applications.Manage_Test_Types
{
    public partial class frmShowPersonLicensesHistory : Form
    {
        // Internaitonal.
        static DataTable dtInternationalLicenses;
        DataView dvInternationalLicenses;
        // Local.
        static DataTable dtLocalLicenses;
        DataView dvLocalLicenses;

        private int _PersonID;
        private string _NationalNo;

        public frmShowPersonLicensesHistory(string NationalNo)
        {
            InitializeComponent();

            this._NationalNo = NationalNo;
        }

        void _LoadInternationalLicenses()
        {
            // international Licenses.
            dtInternationalLicenses = clsInternationalLicenses.GetAllInternationalLicensesByPersonID(_PersonID);
            dvInternationalLicenses = dtInternationalLicenses.DefaultView;

            dgvInternationalLicenses.DataSource = dvInternationalLicenses;
            lblRecordsInternational.Text = "# Records : " + dvInternationalLicenses.Count.ToString();
        }

        void _LoadLocalLicenses()
        {
            // Local Licenses.
            dtLocalLicenses = clsLicenses.GetAllLicenses(_PersonID);
            dvLocalLicenses = dtLocalLicenses.DefaultView;

            dgvLocalLicenses.DataSource = dvLocalLicenses;
            lblRecordsLocal.Text = "# Records : " + dvLocalLicenses.Count.ToString();
        }

        void _Referesh()
        {
            _LoadInternationalLicenses();
            _LoadLocalLicenses();
        }

        private void ucFindPerson1_OnFindPerson(int obj)
        {
            _PersonID = obj;

            _Referesh();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowPersonLicensesHistory_Load(object sender, EventArgs e)
        {
            ucFindPerson1.LoadPersonInfo(_NationalNo);
            ucFindPerson1.Disable();
        }
    }
}
