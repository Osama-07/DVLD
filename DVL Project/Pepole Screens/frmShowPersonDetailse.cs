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
    public partial class frmShowPersonDetailse : Form
    {

        public frmShowPersonDetailse(int PersonID)
        {
            InitializeComponent();

            ucPersonalInfo1.LoadPersonInfo(PersonID);
        }

        public frmShowPersonDetailse(string NationalNo)
        {
            InitializeComponent();

            ucPersonalInfo1.LoadPersonInfo(NationalNo);
        }

        private void frmShowPersonDetailse_Load(object sender, EventArgs e)
        {
        }
    }
}
