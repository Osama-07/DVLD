using DrivingBusinessLayer;
using DVL_Project.Applications.Driving_Licenses_Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVL_Project.Applications.Manage_Application_Types
{
    public partial class frmInternationalLicenseApplications : Form
    {
        static DataTable dtI_L_Info = clsInternationalLicenses.GetAllInternationalLicenses();
        DataView dvI_L_Info = dtI_L_Info.DefaultView;

        public frmInternationalLicenseApplications()
        {
            InitializeComponent();
        }

        void _ShowLicensesInfo()
        {
            dgvInternationalLicenses.Rows.Clear();

            for (int i = 0; i < dvI_L_Info.Count; i++)
            {

                dgvInternationalLicenses.Rows.Add(dvI_L_Info[i]["InternationalLicenseID"], dvI_L_Info[i]["NationalNo"], dvI_L_Info[i]["FullName"],
                                         dvI_L_Info[i]["IssueDate"], dvI_L_Info[i]["ExpirationDate"], dvI_L_Info[i]["Gender"],
                                         dvI_L_Info[i]["Username"], dvI_L_Info[i]["IsActive"]);

            }
        }

        void _Search()
        {
            string query = "";

            if (cbFiltersBy.Text == "None" || tbSearch.Text == null || tbSearch.Text == ""
                && cbFiltersBy.Text != "Gender" && cbFiltersBy.Text != "IsActive")
            {
                query = "1 = 1";
                dvI_L_Info.RowFilter = query;
                _ShowLicensesInfo();
                return;
            }

            if (cbFiltersBy.Text == "International ID")
            {
                if (int.TryParse(tbSearch.Text, out int ID))
                {
                    query = "InternationalLicenseID = " + ID;
                    dvI_L_Info.RowFilter = query;
                    _ShowLicensesInfo();
                    return;
                }
                else
                    tbSearch.Clear();
            }
            
            if (cbFiltersBy.Text == "NationalNo")
            {
                query = "NationalNo like '" + tbSearch + "%'";
                dvI_L_Info.RowFilter = query;
                _ShowLicensesInfo();
                return;
            }

            if (cbFiltersBy.Text == "Full Name")
            {
                query = "FullName like '" + tbSearch.Text + "%'";
                dvI_L_Info.RowFilter = query;
                _ShowLicensesInfo();
                return;
            }
            
            if (cbFiltersBy.Text == "Gender")
            {
                if (cbGender.Text == "All")
                {
                    query = "1 = 1";
                    dvI_L_Info.RowFilter = query;
                    _ShowLicensesInfo();
                    return;
                }
                else if (cbGender.Text == "Male")
                {          
                    query = "Gender = 'Male'";
                    dvI_L_Info.RowFilter = query;
                    _ShowLicensesInfo();
                    return;         
                }
                else
                {
                    query = "Gender = 'Female'";
                    dvI_L_Info.RowFilter = query;
                    _ShowLicensesInfo();
                    return;
                }
            }

            if (cbFiltersBy.Text == "Username")
            {
                query = "Username like '" + tbSearch.Text + "%'";
                dvI_L_Info.RowFilter = query;
                _ShowLicensesInfo();
                return;
            }

            if (cbFiltersBy.Text == "IsActive")
            {
                if (cbIsActive.Text == "All")
                {
                    query = "1 = 1";
                    dvI_L_Info.RowFilter = query;
                    _ShowLicensesInfo();
                    return;
                }
                else if (cbIsActive.Text == "Yes")
                {
                    query = "IsActive = 1";
                    dvI_L_Info.RowFilter = query;
                    _ShowLicensesInfo();
                    return;
                }
                else
                {
                    query = "IsActive = 0";
                    dvI_L_Info.RowFilter = query;
                    _ShowLicensesInfo();
                    return;
                }
            }

        }

        private void frmInternationalLicenseApplications_Load(object sender, EventArgs e)
        {
            dtI_L_Info = clsInternationalLicenses.GetAllInternationalLicenses();
            dvI_L_Info = dtI_L_Info.DefaultView;

            _ShowLicensesInfo();
            lblRecords.Text = "# Rescords : " + dvI_L_Info.Count.ToString();

            cbFiltersBy.SelectedIndex = 0; // 0 = (None) Mode.
            tbSearch.Clear();
            tbSearch.Visible = false; // hide tbSearch.
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddInternationalLicense_Click(object sender, EventArgs e)
        {
            frmAddInternationalLicenses frm = new frmAddInternationalLicenses();

            frm.ShowDialog();

            frmInternationalLicenseApplications_Load(null, null);
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            _Search();
            lblRecords.Text = "# Rescords : " + dvI_L_Info.Count.ToString();
        }

        private void cbFiltersBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (cbFiltersBy.Text)
            {
                case "None":
                    {
                        tbSearch.Visible = false;
                        cbIsActive.Visible = false;
                        cbGender.Visible = false;
                        _Search();
                        lblRecords.Text = "# Rescords : " + dvI_L_Info.Count.ToString();
                    }
                    break;
                case "Gender":
                    {
                        tbSearch.Visible = false;
                        cbIsActive.Visible = false;
                        cbGender.Visible = true;
                        cbGender.SelectedIndex = 0; // 0 = (All) Mode.
                    }
                    break;
                case "IsActive":
                    {
                        tbSearch.Visible = false;
                        cbIsActive.Visible = true;
                        cbGender.Visible = false;
                        cbIsActive.SelectedIndex = 0; // 0 = (All) Mode.
                    }
                    break;
                
                default:
                    {
                        tbSearch.Visible = true;
                        cbIsActive.Visible = false;
                        cbGender.Visible = false;
                    }
                    break;

            }


        }

        private void cbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Search();
            lblRecords.Text = "# Rescords : " + dvI_L_Info.Count.ToString();
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Search();
            lblRecords.Text = "# Rescords : " + dvI_L_Info.Count.ToString();
        }
    }

}