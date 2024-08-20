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
    public partial class frmShowUserDetailse : Form
    {
        
        private int _UserID = -1;

        public frmShowUserDetailse(int UserID)
        {
            InitializeComponent();

            _UserID = UserID;

        }

        private void ShowUserDetailse_Load(object sender, EventArgs e)
        {

            ucUserInfo1.LoadUserInfoByUserID(_UserID);
            
        }
    }
}
