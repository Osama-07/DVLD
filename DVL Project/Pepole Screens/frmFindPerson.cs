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

namespace DVL_Project.Users_Screens
{
    public partial class frmFindPerson : Form
    {
        public delegate void PersonIDBackEventHandler(object sender, int PersonID);

        public event PersonIDBackEventHandler DataPersonBack;

        int _PersonID = -1;

        public frmFindPerson()
        {
            InitializeComponent();
        }

        private void frmFindPerson_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DataPersonBack?.Invoke(this, _PersonID);

            this.Close();
        }

        private void ucFindPerson1_OnFindPerson(int obj)
        {
            int PersonID = obj;

            _PersonID = PersonID;
        }

        private void ucFindPerson1_OnResetInfo(int obj)
        {
            int PersonID = obj;

            _PersonID = PersonID;
        }
    }
}
