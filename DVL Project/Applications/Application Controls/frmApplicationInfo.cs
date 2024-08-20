using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVL_Project.Applications
{
    public partial class frmApplicationInfo : Form
    {
        int _ApplicationID;

        public frmApplicationInfo(int ApplicationID)
        {
            InitializeComponent();

            _ApplicationID = ApplicationID;
        }

        private void frmApplicationInfo_Load(object sender, EventArgs e)
        {
            ctrlApplicationInfo1.LoadApplicationInfo(_ApplicationID);
        }

        private void btnClose2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
