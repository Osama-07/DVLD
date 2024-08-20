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

namespace DVL_Project.Applications.Detain_Licenses
{
    public partial class frmManageDetaines : Form
    {
        static DataTable dtDetainedLicenses = clsDetainedLicenses.GetAllDetainedLicensesWithDetailse();
        DataView dvDetainedLicenses = dtDetainedLicenses.DefaultView;

        public frmManageDetaines()
        {
            InitializeComponent();
        }

        void _ShowDetainedInfo()
        {
            dgvDetainedLicenses.Rows.Clear();

            for (int i = 0; i < dvDetainedLicenses.Count; i++)
            {

                dgvDetainedLicenses.Rows.Add(dvDetainedLicenses[i]["DetainID"], dvDetainedLicenses[i]["LicenseID"],
                                             dvDetainedLicenses[i]["NationalNo"], dvDetainedLicenses[i]["FullName"],
                                             dvDetainedLicenses[i]["Username"], dvDetainedLicenses[i]["IsReleased"]);
            }
        }

        void _Referesh()
        {
            dtDetainedLicenses = clsDetainedLicenses.GetAllDetainedLicensesWithDetailse();
            dvDetainedLicenses = dtDetainedLicenses.DefaultView;

            dgvDetainedLicenses.Rows.Clear();

            if (cbFiltersBy.SelectedIndex == 0) // 0 = (None).
            {
                _ShowDetainedInfo();
            }
            else
                cbFiltersBy.SelectedIndex = 0; // because if already selected 0 he dont shows info.

            lblRecords.Text = "# Records : " + dvDetainedLicenses.Count.ToString();
        }

        void _Search()
        {
            string query = "";

            if (cbFiltersBy.Text == "None" || tbSearch.Text == "" || tbSearch.Text == null)
            {
                query = "1 = 1";

                dvDetainedLicenses.RowFilter = query;
                _ShowDetainedInfo();              
                return;
            }

            if (cbFiltersBy.Text == "DetaineID")
            {
                if (int.TryParse(tbSearch.Text, out int DetainID))
                {
                    query = "DetainID = " + tbSearch.Text;
                    dvDetainedLicenses.RowFilter = query;
                    _ShowDetainedInfo();
                    return;
                }
                else
                    tbSearch.Clear();

                return;
            }

            if (cbFiltersBy.Text == "LicenseID")
            {
                if (int.TryParse(tbSearch.Text, out int DetainID))
                {
                    query = "LicenseID = " + tbSearch.Text;
                    dvDetainedLicenses.RowFilter = query;
                    _ShowDetainedInfo();
                    return;
                }
                else
                    tbSearch.Clear();

                return;
            }

            if (cbFiltersBy.Text == "NationalNo")
            {
                query = "NationalNo Like '" + tbSearch.Text + "%'";
                dvDetainedLicenses.RowFilter = query;
                _ShowDetainedInfo();
                return;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDetaineLicense_Click(object sender, EventArgs e)
        {
            frmDerainLicense frm = new frmDerainLicense();

            frm.ShowDialog();

            _Referesh();
        }

        private void releaseLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvDetainedLicenses.CurrentRow.Cells[1].Value;

            frmReleaseLicense frm = new frmReleaseLicense(LicenseID);

            frm.ShowDialog();

            _Referesh();
        }

        private void frmManageDetaines_Load(object sender, EventArgs e)
        {
            _Referesh();
        }

        private void cbFiltersBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFiltersBy.Text != null && cbFiltersBy.Text != "None")
            {
                tbSearch.Visible = true;
                tbSearch.Focus();
            }
            else
            {
                _Search();
                tbSearch.Visible = false;
                tbSearch.Clear();
            }

            lblRecords.Text = "# Records : " + dvDetainedLicenses.Count.ToString();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            _Search();
            lblRecords.Text = "# Records : " + dvDetainedLicenses.Count.ToString();
        }

        private void cmsManageDetaines_Opening(object sender, CancelEventArgs e)
        {
            string IsReleased = (string)dgvDetainedLicenses.CurrentRow.Cells[5].Value; // Is Released Column in dgvDetainedLicenses.

            if (IsReleased == "Yes")
            {
                releaseLicenseToolStripMenuItem.Enabled = false;
            }
            else
                releaseLicenseToolStripMenuItem.Enabled = true;

        }
    }
}
