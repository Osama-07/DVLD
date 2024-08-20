using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DrivingBusinessLayer;

namespace DVL_Project
{
    public partial class frmPepole : Form
    {
        static DataTable PepoleInfo = clsPepole.GetAllPersonsWithDetailse();
        DataView dvPepole = PepoleInfo.DefaultView;

        public frmPepole()
        {
            InitializeComponent();
        }

        void _SearchBy()
        {

            if (tbFilterBy.Text == null || tbFilterBy.Text == "" || cbFiltersBy.Text == "None")
            {
                dvPepole.RowFilter = "";
                dgvPepolesInfo.DataSource = dvPepole;
                lblRecordes.Text = "# Records : " + dvPepole.Count;
                return;
            }// text box is empty will be return.


            if (cbFiltersBy.Text == "PersonID" && tbFilterBy.Text != "")
            {
                if (int.TryParse(tbFilterBy.Text, out int ID))
                {
                    dvPepole.RowFilter = string.Format("[PersonID] = {0}", tbFilterBy.Text);
                    dgvPepolesInfo.DataSource = dvPepole;
                }
                else
                    tbFilterBy.Clear();
            }
            else
            {
                dvPepole.RowFilter = string.Format("[{0}] LIKE '{1}%'", cbFiltersBy.Text, tbFilterBy.Text);
            }


            lblRecordes.Text = "# Records : " + dgvPepolesInfo.RowCount.ToString();
        }

        void _RefereshdgvPepolesInfo()
        {
            PepoleInfo = clsPepole.GetAllPersonsWithDetailse();
            dgvPepolesInfo.DataSource = PepoleInfo;
            dvPepole = PepoleInfo.DefaultView;
            lblRecordes.Text = "# Records : " + dgvPepolesInfo.RowCount.ToString();
        }

        private void frmPepole_Load(object sender, EventArgs e)
        {
            cbFiltersBy.SelectedIndex = 0;
            dgvPepolesInfo.DataSource = PepoleInfo;
            lblRecordes.Text = "# Records : " + dgvPepolesInfo.RowCount.ToString();
        }

        private void tbFiltersBy_TextChanged(object sender, EventArgs e)
        {

            _SearchBy();
            
        }

        private void cbFiltersBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFiltersBy.Text != null && cbFiltersBy.Text != "None")
            {
                tbFilterBy.Visible = true;
                tbFilterBy.Focus();
            }
            else
            {
                _SearchBy();
                tbFilterBy.Visible = false;
                tbFilterBy.Clear();
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson();

            frm.ShowDialog();

            _RefereshdgvPepolesInfo();
        }

        private void showDetailseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonDetailse frm = new frmShowPersonDetailse((int)dgvPepolesInfo.CurrentRow.Cells[0].Value);

            frm.ShowDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson((int)dgvPepolesInfo.CurrentRow.Cells[0].Value);

            frm.ShowDialog();

            _RefereshdgvPepolesInfo();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure do you want delete this Person ?","Warning",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)
                == DialogResult.Yes)
            {
                clsPepole person = clsPepole.FindPerson((int)dgvPepolesInfo.CurrentRow.Cells[0].Value);

                if (person != null)
                {
                    if (person.PersonalPicture != "")
                    {
                        if (File.Exists(person.PersonalPicture)) // if image exist in disk.
                        {
                            File.Delete(person.PersonalPicture); // if person has image will delete image from disk.
                        }
                    }

                    if (clsPepole.DeletePerson((string)dgvPepolesInfo.CurrentRow.Cells[1].Value))
                    {
                        MessageBox.Show("Deleted Successfuly", "Succeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _RefereshdgvPepolesInfo();
                        return;
                    }
                    else
                        MessageBox.Show("you can't delete this person.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void sendPhoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("We have contacted you.", "Succeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("We have contacted you.", "Succeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
