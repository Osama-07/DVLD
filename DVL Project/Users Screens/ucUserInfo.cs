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
    public partial class ucUserInfo : UserControl
    {
        private clsUsers _User;

        private int _UserID = -1;

        public int UserID
        {
            get { return _User.UserID;}
        }

        public ucUserInfo()
        {
            InitializeComponent();
        }

        public void LoadUserInfoByUserID(int UserID)
        {
            _UserID = UserID;
            _User = clsUsers.FindUserByUserID(UserID);

            if (_User != null)
            {
                _FillUserInfo();
            }
            else
                _Reset();
            
        }

        private void _FillUserInfo()
        {
            ucPersonalInfo1.LoadPersonInfo(_User.PersonID);

            lblUserID.Text = _User.UserID.ToString();
            lblUsername.Text = _User.Username;

            if (_User.IsActive == true)
            {
                lblIsActive.Text = "Yes";
            }
            else
                lblIsActive.Text = "No";

        }

        private void _Reset()
        {
            ucPersonalInfo1.Reset();

            lblUserID.Text = "????";
            lblUsername.Text = "????";
            lblIsActive.Text = "????";

        }

    }
}
