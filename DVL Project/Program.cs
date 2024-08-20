using DVL_Project.Applications;
using DVL_Project.Applications.Application_Controls;
using DVL_Project.Applications.Driving_Licenses_Services;
using DVL_Project.Applications.Manage_Application_Types;
using DVL_Project.Drivers_Screens;
using DVL_Project.Login;
using DVL_Project.Users_Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVL_Project
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
            //Application.Run(new frmPepole());
            //Application.Run(new frmAddEditPerson(-1));
            //Application.Run(new frmListUsers("OSKA"));
            //Application.Run(new frmChangePassword("OSKA"));
            //Application.Run(new frmListDrivers());
            //Application.Run(new frmAddNewLocalDriverLicense(-1, 1));
            //Application.Run(new frmLocalDrivingLicenseApplications());
            //Application.Run(new frmDrivingLicenseApplicationInfo(1034,0));
            //Application.Run(new frmShowDriverLicenseInfo("2152048571"));
            //Application.Run(new frmFindLicense());
            //Application.Run(new frmReplacementForLostOrDamagedLicense());
            //Application.Run(new frmAddInternationalLicenses());

        }
    }
}
