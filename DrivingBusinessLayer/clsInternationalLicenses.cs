using DrivingDataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingBusinessLayer
{
    public class clsInternationalLicenses : clsApplications
    {
        enum enMode { AddNew = 0, Update = 1 }

        enMode _Mode;

        public int InternationalLicenseID { get; set; }
        public int DriverID { get; set; }
        public clsDrivers DriverInfo { get; set; }
        public clsLicenses LocalLicenseInfo { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }

        public clsInternationalLicenses()
        {
            this.InternationalLicenseID = -1;
            this.ApplicationID = -1;
            this.DriverInfo = null;
            this.LocalLicenseInfo = null;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.IsActive = false;
            this.CreatedByUserID = -1;

            this._Mode = enMode.AddNew;
        }

        private clsInternationalLicenses(int applicationID, int applicantPersoniD, DateTime applicationDate, int applicationTypeID,
                                        byte applicationStatus, DateTime lastStatusDate, decimal paidFees, int createdByUseriD,
                                        int InternationalLicenseID, int ApplicationID, int DriverID, int LocalLicenseID, DateTime IssueDate,
                                        DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {
            base.ApplicationID = applicationID;
            base.ApplicantPersonID = applicantPersoniD;
            base.ApplicationDate = applicationDate;
            base.ApplicationTypeID = applicationTypeID;
            base.ApplicationStatus = (clsApplications.enApplicationStatus)applicationStatus;
            base.LastStatusDate = lastStatusDate;
            base.PaidFees = paidFees;
            base.CreatedByUserID = createdByUseriD;


            this.InternationalLicenseID = InternationalLicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.DriverInfo = clsDrivers.FindDriver(DriverID);
            this.LocalLicenseInfo = clsLicenses.Find(LocalLicenseID);
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IsActive = IsActive;
            this.CreatedByUserID = CreatedByUserID;

            this._Mode = enMode.Update;
        }

        private bool _AddNew()
        {
            this.InternationalLicenseID = clsInternationalLicensesData.AddNew(this.ApplicationID,
                                            this.DriverInfo.DriverID, this.LocalLicenseInfo.LicenseID,
                                           this.IssueDate, this.ExpirationDate, this.IsActive,
                                           this.CreatedByUser.UserID);

            return (this.InternationalLicenseID > 0);
        }

        private bool _Update()
        {
            return clsInternationalLicensesData.Update(this.InternationalLicenseID, this.ApplicationID,
                                            this.DriverInfo.DriverID, this.LocalLicenseInfo.LicenseID,
                                           this.IssueDate, this.ExpirationDate, this.IsActive,
                                           this.CreatedByUser.UserID);
        }

        public bool Save()
        {
            base.Mode = (clsApplications.enMode) Mode;
            if (!base.Save())
                return false;


            switch (_Mode)
            {
                case enMode.AddNew:

                    if (_AddNew())
                    {
                        this._Mode = enMode.Update;
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

        public static clsInternationalLicenses Find(int InternationalLicenseID)
        {
            int ApplicationID = -1, DriverID = -1, LocalLicenseID = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            bool IsActive = false;
            int CreatedByUserID = -1;

            if (clsInternationalLicensesData.Find(InternationalLicenseID, ref ApplicationID, ref DriverID,
                                                    ref LocalLicenseID, ref IssueDate, ref ExpirationDate,
                                                    ref IsActive, ref CreatedByUserID))
            {
                clsApplications Application = clsApplications.Find(ApplicationID);

                return new clsInternationalLicenses(Application.ApplicationID, Application.ApplicantPersonID,Application.ApplicationDate,
                                                    Application.ApplicationTypeID, (byte)Application.ApplicationStatus, Application.LastStatusDate,
                                                    Application.PaidFees, Application.CreatedByUserID,
                                                    InternationalLicenseID, ApplicationID, DriverID, LocalLicenseID, IssueDate,
                                                    ExpirationDate, IsActive, CreatedByUserID);
            }
            else
                return null;

        }

        public static bool IsExist(int InternationalLicenseID)
        {
            return clsInternationalLicensesData.IsExist(InternationalLicenseID);
        }

        public static bool IsHasLicense(int DriverID)
        {
            return clsInternationalLicensesData.IsHasLicense(DriverID);
        }

        public static bool Delete(int InternationalLicenseID)
        {
            return clsInternationalLicensesData.Delete(InternationalLicenseID);
        }

        public static DataTable GetAllInternationalLicensesByNationalNo(string NationalNo)
        {
            return clsInternationalLicensesData.GetAllInternationalLicensesByNationalNo(NationalNo);
        }

        public static DataTable GetAllInternationalLicensesByPersonID(int PersonID)
        {
            return clsInternationalLicensesData.GetAllInternationalLicensesByPersonID(PersonID);
        }

        public static DataTable GetAllInternationalLicenses()
        {
            return clsInternationalLicensesData.GetAllInternationalLicenses();
        }

    }
}
