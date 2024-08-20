using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DrivingBusinessLayer;
using DVL_Project.Users_Screens;

namespace DVL_Project
{
    public partial class frmListUsers : Form
    {
        static DataTable ListUsers = clsUsers.GetAllUsers();
        DataView dvListUsers = ListUsers.DefaultView;

        public frmListUsers()
        {
            InitializeComponent();

        }

        void _FilterByIsActive()
        {

            tbSearch.Visible = false;
            cbIsActive.Visible = true;

            if (cbIsActive.Text == "All")
            {
                dvListUsers.RowFilter = "1 = 1";
                dgvListUsers.DataSource = dvListUsers;
                return;
            }

            if (cbIsActive.Text == "Yes")
            {
                dvListUsers.RowFilter = "IsActive = 1";
                dgvListUsers.DataSource = dvListUsers;
                return;
            }

            if (cbIsActive.Text == "No")
            {
                dvListUsers.RowFilter = "IsActive = 0";
                dgvListUsers.DataSource = dvListUsers;
                return;
            }
            
            
        }

        void _SearchBy()
        {
            string Query = "";

            if (cbFilter.Text == "None" || tbSearch.Text == null || tbSearch.Text == "")
            {
                Query = "1 = 1";
                dvListUsers.RowFilter = Query;
                dgvListUsers.DataSource = dvListUsers;
                return;
            }

            if (cbFilter.Text == "UserID")
            {
                if (int.TryParse(tbSearch.Text, out int id))
                {
                    dvListUsers.RowFilter = "UserID = " + id.ToString();
                    dgvListUsers.DataSource = dvListUsers;
                    return;
                }
                else
                {
                    tbSearch.Clear();
                    /*dvListUsers.RowFilter = "UserID = -1";// if the input is not Number will return empty information.
                    dgvListUsers.DataSource = dvListUsers;*/
                    return;
                }
            }

            if (cbFilter.Text == "PersonID")
            {
                if (int.TryParse(tbSearch.Text, out int id))
                {
                    dvListUsers.RowFilter = "PersonID = " + id.ToString();
                    dgvListUsers.DataSource = dvListUsers;
                    return;
                }
                else
                {
                    tbSearch.Clear();
                    /*dvListUsers.RowFilter = "UserID = -1";// if the input is not Number will return empty information.
                    dgvListUsers.DataSource = dvListUsers;*/
                    return;
                }
            }

            if (cbFilter.Text == "FullName")
            {
                dvListUsers.RowFilter = "[Full Name] like '" + tbSearch.Text + "%'";
                dgvListUsers.DataSource = dvListUsers;
                return;
            }

            if (cbFilter.Text == "Username")
            {
                dvListUsers.RowFilter = "Username like '" + tbSearch.Text + "%'";
                dgvListUsers.DataSource = dvListUsers;
                return;
            }

            if (cbFilter.Text == "IsActive")
            {
                _FilterByIsActive();
                return;
            }

        }

        private void UsersForm_Load(object sender, EventArgs e)
        {
            ListUsers = clsUsers.GetAllUsers();
            dvListUsers = ListUsers.DefaultView;

            cbFilter.SelectedIndex = 0; // select "None" filter mode.
            dgvListUsers.DataSource = dvListUsers;
            lblRecords.Text = "# Records : " + dvListUsers.Count.ToString();// output number of record.

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            frmAddEditUser frm = new frmAddEditUser();

            frm.ShowDialog();

            UsersForm_Load(null, null); // update list Users after edit or add user.
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            _SearchBy();
            lblRecords.Text = "# Records : " + dvListUsers.Count.ToString();// output number of record.
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.Text == "None")
            {
                tbSearch.Visible = false; // if filter by = 'None' will hide tbSearch.
                cbIsActive.Visible = false;
                _SearchBy();
            }
            else if (cbFilter.Text == "IsActive")
            {
                tbSearch.Visible = false;
                cbIsActive.Visible = true;
                cbIsActive.SelectedIndex = 0; // select (all) Mode.
            }
            else
            {
                cbIsActive.Visible = false;
                tbSearch.Visible = true; // if filter by != 'None' will Show tbSearch.
                tbSearch.Clear();
                tbSearch.Focus();
            }
        }

        private void showDetailseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowUserDetailse frm = new frmShowUserDetailse((int)dgvListUsers.CurrentRow.Cells["UserID"].Value);

            frm.ShowDialog();
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddNewUser.PerformClick(); // show form frmAddEditUser.
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditUser frm = new frmAddEditUser((int)dgvListUsers.CurrentRow.Cells["UserID"].Value);

            frm.ShowDialog();

            UsersForm_Load(null, null); // update list Users after edit or add user.
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure do you want to delete this user ? ","Warning",
                MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK)
            {

                if (clsUsers.DeleteUser((int)dgvListUsers.CurrentRow.Cells["UserID"].Value))
                {
                    MessageBox.Show("Deleted Successfully ", "Succeded",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    UsersForm_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Delete is failed", "Wrong",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void ChangePasswordToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword((int)dgvListUsers.CurrentRow.Cells[0].Value);

            frm.ShowDialog();
        }

        private void cmsCommandMenu_Opened(object sender, EventArgs e)
        {
            if (dgvListUsers.Rows.Count > 0)
            {
                this.cmsCommandMenu.Enabled = true;

                if (clsGlobal.CurrentUser.Username.ToUpper() != "Admin".ToUpper() &&
                    clsGlobal.CurrentUser.Username.ToUpper() != dgvListUsers.CurrentRow.Cells["Username"].Value.ToString().ToUpper())
                {
                    ChangePasswordToolStripMenuItem1.Enabled = false;
                }
                else
                    ChangePasswordToolStripMenuItem1.Enabled = true;
            }
            else
                this.cmsCommandMenu.Enabled = false;
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilterByIsActive();
        }

    }
}
