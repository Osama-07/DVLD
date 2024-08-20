using DrivingDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DrivingBusinessLayer
{
    public class clsLocalDrivingLicenseApplications : clsApplications
    {
        public enum enMode { AddNew = 0, Update = 1 }

        public enMode Mode;

        public int LocalDrivingLicenseApplicationID {  get; set; }

        public int LicenseClassID { get; set; }
        public clsLicenseClasses LicenseClass
        {
            get
            {
                return clsLicenseClasses.Find(LicenseClassID);
            }
        }

        public string FullName
        {
            get
            {
                return base.PersonInfo.FullName();
            }
        }

        public clsLocalDrivingLicenseApplications()
        {
            this.LocalDrivingLicenseApplicationID = -1;
            this.LicenseClassID = -1;

            Mode = enMode.AddNew;
        }

        private clsLocalDrivingLicenseApplications(int localDrivingLicenseApplicationID, int applicationID, int applicantPersoniD,
                        DateTime applicationDate, int applicationTypeID, byte applicationStatus, DateTime lastStatusDate, decimal paidFees,
                        int createdByUseriD, int licenseClassID)
        {
            this.LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            this.ApplicationID = applicationID;
            this.ApplicantPersonID = applicantPersoniD;
            this.ApplicationDate = applicationDate;
            this.ApplicationTypeID = applicationTypeID;
            this.ApplicationStatus = (clsApplications.enApplicationStatus)applicationStatus;
            this.LastStatusDate = lastStatusDate;
            this.PaidFees = paidFees;
            this.CreatedByUserID = createdByUseriD;
            this.LicenseClassID = licenseClassID;

            Mode = enMode.Update;
        }

        private bool _AddNew()
        {
            this.LocalDrivingLicenseApplicationID =
                clsLocalDrivingLicenseApplicationData.AddNew
                                                        (this.ApplicationID, this.LicenseClassID);

            return (this.LocalDrivingLicenseApplicationID > 0);
        }

        private bool _Update()
        {
            return clsLocalDrivingLicenseApplicationData.Update(this.LocalDrivingLicenseApplicationID, this.ApplicationID,
                                                                this.LicenseClassID);
        }

        public bool Save()
        {
            base.Mode = (clsApplications.enMode) Mode;
            if (!base.Save())
                return false;

            switch(Mode)
            {
                case enMode.AddNew:

                    if (_AddNew())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                
                case enMode.Update:

                    if (_Update())
                    {
                        return true;
                    }
                    else
                        return false;

            }

            return false;
        }

        public static clsLocalDrivingLicenseApplications FindLocalDrivignLicenseApplicationByID(int localDrivingLicenseApplicationID)
        {
            int ApplicationiD = -1, LicenseClassiD = -1;

            bool IsFound = clsLocalDrivingLicenseApplicationData.FindLocalDrivignLicenseApplicationByID(localDrivingLicenseApplicationID, ref ApplicationiD
                                                                                                         , ref LicenseClassiD);

            if (IsFound)
            {
                clsApplications Application = clsApplications.Find(ApplicationiD);


                return new clsLocalDrivingLicenseApplications(localDrivingLicenseApplicationID, Application.ApplicationID, Application.ApplicantPersonID,
                        Application.ApplicationDate, Application.ApplicationTypeID, (byte)Application.ApplicationStatus, Application.LastStatusDate,
                        Application.PaidFees, Application.CreatedByUserID, LicenseClassiD);

            }
            else
                return null;
        }

        public static clsLocalDrivingLicenseApplications FindLocalDrivignLicenseApplicationByApplicationID(int ApplicationID)
        {
            int localDrivingLicenseApplicationID = -1, LicenseClassiD = -1;

            bool IsFound = clsLocalDrivingLicenseApplicationData.FindLocalDrivignLicenseApplicationByApplicationID(ApplicationID, ref localDrivingLicenseApplicationID,
                                                                                                                                    ref LicenseClassiD);

            if (IsFound)
            {
                clsApplications Application = clsApplications.Find(ApplicationID);


                return new clsLocalDrivingLicenseApplications(localDrivingLicenseApplicationID, Application.ApplicationID, Application.ApplicantPersonID,
                        Application.ApplicationDate, Application.ApplicationTypeID, (byte)Application.ApplicationStatus, Application.LastStatusDate,
                        Application.PaidFees, Application.CreatedByUserID, LicenseClassiD);

            }
            else
                return null;
        }

        public static bool Delete(int localDrivingLicenseApplicationID)
        {
            return clsLocalDrivingLicenseApplicationData.Delete(localDrivingLicenseApplicationID);
        }

        public static bool IsExist(int localDrivingLicenseApplicationID)
        {
            return clsLocalDrivingLicenseApplicationData.IsExist(localDrivingLicenseApplicationID);
        }

        public static int GetLicenseClassID(int ApplicationID)
        {
            return clsLocalDrivingLicenseApplicationData.GetLicenseClassID(ApplicationID);
        }

        public bool DoesPassedTestType(int TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.DoesPassedTestType(this.LocalDrivingLicenseApplicationID, TestTypeID);
        }

        public static bool DoesPassedTestType(int localDrivingLicenseApplicationID, int TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.DoesPassedTestType(localDrivingLicenseApplicationID, TestTypeID);
        }

        public int TotalTrialsPerTest(int TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.TotalTrialsPerTest(this.LocalDrivingLicenseApplicationID, TestTypeID);
        }

        public static int TotalTrialsPerTest(int localDrivingLicenseApplicationID, int TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.TotalTrialsPerTest(localDrivingLicenseApplicationID, TestTypeID);
        }

        public bool AttendedTest(int TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.TotalTrialsPerTest(this.LocalDrivingLicenseApplicationID, TestTypeID) > 0;
        }

        public static bool AttendedTest(int localDrivingLicenseApplicationID, int TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.TotalTrialsPerTest(localDrivingLicenseApplicationID, TestTypeID) > 0;
        }

        public bool IsThereAnActiveScheduledTest(int TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.IsThereAnActiveScheduledTest(this.LocalDrivingLicenseApplicationID, TestTypeID);
        }

        public static bool IsThereAnActiveScheduledTest(int localDrivingLicenseApplicationID, int TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.IsThereAnActiveScheduledTest(localDrivingLicenseApplicationID, TestTypeID);
        }

        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            return clsLocalDrivingLicenseApplicationData.GetAllLocalDrivingLicenseApplications();
        }

    }
}