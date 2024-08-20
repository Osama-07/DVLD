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

namespace DVL_Project.Applications.Manage_Application_Types
{
    public partial class frmUpdateApplicationTypes : Form
    {
        clsApplicationTypes _ApplicationType;

        public frmUpdateApplicationTypes(int ApplicationTypeID)
        {
            InitializeComponent();

            if (ApplicationTypeID > 0)
            {
                _ApplicationType = clsApplicationTypes.Find(ApplicationTypeID);
            }

        }

        bool _TextBoxValidating(TextBox textBox)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                errorProvider1.SetError(textBox, "you Must enter the Required Text.");
                return false;
            }
            else
            {
                errorProvider1.SetError(textBox, "");
                return true;
            }

        }

        bool _CheckBeforeSave()
        {
            if (_TextBoxValidating(tbApplicationTypeTitle))
            {
                if (_TextBoxValidating(tbApplicationTypeFees))
                {
                    _ApplicationType.ApplicationTypeTitle = tbApplicationTypeTitle.Text;
                    _ApplicationType.ApplicationFees = Convert.ToDecimal(tbApplicationTypeFees.Text);

                    return true;
                }
                else
                    return false;
            }
            else
                return false;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_CheckBeforeSave())
            {
                if (_ApplicationType.Save())
                {
                    MessageBox.Show("Updated Application Type Succcessfully.", "Succeeded",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Unable To Save Modifications.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Enter the Information Correctly.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void tbApplicationTypeTitle_Validating(object sender, CancelEventArgs e)
        {
            _TextBoxValidating((TextBox)sender);
        }

        private void tbApplicationTypeFees_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(tbApplicationTypeFees.Text, out int Fees))
            {
                tbApplicationTypeFees.Clear();
            }
        }

        private void frmUpdateApplicationTypes_Load(object sender, EventArgs e)
        {
            lblApplicationTypeID.Text = _ApplicationType.ApplicationTypeID.ToString();
            tbApplicationTypeTitle.Text = _ApplicationType.ApplicationTypeTitle;
            tbApplicationTypeFees.Text = Convert.ToInt32(_ApplicationType.ApplicationFees).ToString();
        }
    }
}
