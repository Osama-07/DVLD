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

namespace DVL_Project
{
    public partial class ctrFindLicense : UserControl
    {
        // Define a custom event handler delegate with parameter.
        public event Action<int> OnFindLicense;
        // Create method to raise event with a parameter.
        protected virtual void FindLicense(int licenseID)
        {
            Action<int> handler = OnFindLicense;

            if (handler != null)
            {
                handler(licenseID); // Raise event with the parameter.
            }

        }

        // Define a custom event handler delegate with parameter.
        public event Action<int> OnResetInfo;
        // Create method to raise event with a parameter.
        protected virtual void ResetInfo(int LicenseID = 0)
        {
            Action<int> handler = OnResetInfo;

            if (handler != null)
            {
                handler(LicenseID); // Raise event with the parameter.
            }

        }

        public ctrFindLicense()
        {
            InitializeComponent();

        }

        bool _SearchLicense()
        {
            if (int.TryParse(tbSearch.Text, out int LicenseID))
            {

                clsLicenses License = clsLicenses.Find(LicenseID);

                if (License != null)
                {
                    ctrDriverLicenseInfo1.LoadDriverLicenseInfo(LicenseID);

                    FindLicense(LicenseID);
                    return true;
                }
                else
                    return false;
            }
            else
                return false;

        }

        public void Reset()
        {
            tbSearch.Clear();
            tbSearch.Focus();
            ctrDriverLicenseInfo1.Reset();
            ResetInfo();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // this Function to invok whenever do you want without need parameters.

            if (!_SearchLicense())
            {
                MessageBox.Show("this Licnese With LicenseID " + tbSearch.Text + " is Not Found", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                Reset();
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(tbSearch.Text, out int LicenseID))
            {
                tbSearch.Clear();
            }
        }

        private void ctrFindLicense_Load(object sender, EventArgs e)
        {
            cbFindBy.SelectedIndex = 0; // select (LicenseID).
        }

        public void LoadLicenseInfo(int LicenseID = -1)
        {
            if (LicenseID > 0)
            {
                tbSearch.Text = LicenseID.ToString();
                btnSearch.PerformClick();
            }
        }

        private void tbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            if (e.KeyChar == (char)13)
            {
                btnSearch.PerformClick();
            }
        }
    }
}
