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

namespace DVL_Project.Drivers_Screens
{
    public partial class frmListDrivers : Form
    {
        static DataTable dtDrivers = clsDrivers.GetAllDriversWithDetailse();
        DataView dvDrivers = dtDrivers.DefaultView;

        public frmListDrivers()
        {
            InitializeComponent();
        }

        private void frmListDrivers_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = 0; // select (None).

            dtDrivers = clsDrivers.GetAllDriversWithDetailse();
            dvDrivers = dtDrivers.DefaultView;

            dgvListDrivers.DataSource = dvDrivers; // load drivers data after refresh.
            lblRecords.Text = "# Records : " + dvDrivers.Count; // store number of records and show it.
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.Text != "None")
            {
                tbSearch.Visible = true;
            }
            else
                tbSearch.Visible = false;
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if (cbFilter.Text == "None" || tbSearch.Text == null || tbSearch.Text == "")
            {
                dvDrivers.RowFilter = "1 = 1"; // filtring data from data view.
                dgvListDrivers.DataSource = dvDrivers; // load all drivers data from data table.
                lblRecords.Text = "# Records : " + dvDrivers.Count; // store number of records and show it.
                return;
            }

            if (cbFilter.Text == "DriverID")
            {
                if (int.TryParse(tbSearch.Text, out int DriverID))
                {
                    if (dvDrivers.Count > 0)
                    {
                        dvDrivers.RowFilter = "DriverID = " + DriverID.ToString(); // filtring data from data view.
                        dgvListDrivers.DataSource = dvDrivers; // load drivers data from data table after filtering.
                        lblRecords.Text = "# Records : " + dvDrivers.Count; // store number of records after filtering.
                        return;
                    }
                }
                else
                    tbSearch.Clear(); // if was input not number clear text box.
                
                return;
            }

            if (cbFilter.Text == "NationalNo")
            {
                if (dvDrivers.Count > 0)
                {
                    dvDrivers.RowFilter = "NationalNo like '" + tbSearch.Text + "%'"; // filtring data from data view.
                    dgvListDrivers.DataSource = dvDrivers; // load drivers data from data table after filtering.
                    lblRecords.Text = "# Records : " + dvDrivers.Count; // store number of records after filtering.
                    return;
                }
            }

        }

        private void showDetailseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonDetailse frm;
            
            frm = new frmShowPersonDetailse((string)dgvListDrivers.CurrentRow.Cells[1].Value);

            frm.ShowDialog();
        }

        private void sendPhoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("SMS Message will be here.", "Send SMS",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Email Message will be here.", "Send Email",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

    }
}
