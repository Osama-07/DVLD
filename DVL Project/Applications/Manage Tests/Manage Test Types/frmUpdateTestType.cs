using DrivingBusinessLayer;
using DVL_Project.Glabal_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVL_Project.Applications.Manage_Test_Types
{
    public partial class frmUpdateTestType : Form
    {
        clsTestTypes _TestType;

        public frmUpdateTestType(clsTestTypes.enTestTypes TestID)
        {
            InitializeComponent();

            if (TestID > 0)
            {
                _TestType = clsTestTypes.Find(TestID);
            }
        }

        private void frmUpdateTestType_Load(object sender, EventArgs e)
        {
            if (_TestType != null)
            {    
                lblTestTypeID.Text = _TestType.TestTypeID.ToString();
                tbTestTypeTitle.Text = _TestType.TestTypeTitle;
                tbTestTypeDescription.Text = _TestType.TestTypeDescription;
                tbTestTypeFees.Text = Convert.ToInt32(_TestType.TestTypeFees).ToString();
            }
        }

        private void tbTestTypeFees_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(tbTestTypeFees.Text, out int Fees))
            {
                tbTestTypeFees.Clear();
            }
        }
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some filds is not valid.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            _TestType.TestTypeTitle = tbTestTypeTitle.Text;
            _TestType.TestTypeDescription = tbTestTypeDescription.Text;
            _TestType.TestTypeFees = Convert.ToDecimal(tbTestTypeFees.Text);

            if (_TestType.Save())
            {
                MessageBox.Show("Updated Test Type Succcessfully.", "Succeeded", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                MessageBox.Show("Unable To Save Modifications.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void tbTestTypeTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbTestTypeTitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbTestTypeTitle, "Title cannot be empty!");
            }
            else
            {
                errorProvider1.SetError(tbTestTypeTitle, null);
            };
        }

        private void tbTestTypeDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbTestTypeDescription.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbTestTypeDescription, "Description cannot be empty!");
            }
            else
            {
                errorProvider1.SetError(tbTestTypeDescription, null);
            };

        }

        private void tbTestTypeFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbTestTypeFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbTestTypeFees, "Fees cannot be empty!");
                return;
            }
            else
            {
                errorProvider1.SetError(tbTestTypeFees, null);

            };


            if (!clsValidation.IsNumber(tbTestTypeFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbTestTypeFees, "Invalid Number.");
            }
            else
            {
                errorProvider1.SetError(tbTestTypeFees, null);
            };
        }
    }
}
