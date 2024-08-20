using DrivingDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DrivingBusinessLayer
{
    public class clsLicenses
    {
        enum enMode { AddNew = 0, Update = 1 }

        enMode _Mode;

        public int LicenseID { get; set; }
        public clsApplications Application { get; set; }
        public  clsDrivers Driver { get; set; }
        public clsLicenseClasses LicenseClass {  get; set; }
        public DateTime IssueDate {  get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public decimal PaidFees { get; set; }
        public bool IsActive {  get; set; }
        public byte IssueReason {  get; set; } // 1 = (First Time), 2 = (ReNew), 3 = (Replacement for Lost), 4 = (Replacement for damage).
        public int CreatedByUserID { get; set; }

        public clsLicenses()
        {
            this.LicenseID = -1;
            this.Application = null;
            this.Driver = null;
            this.LicenseClass = null;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.Notes = "";
            this.PaidFees = -1;
            this.IsActive = false;
            this.IssueReason = 0;
            this.CreatedByUserID = -1;

            this._Mode = enMode.AddNew;
        }

        private clsLicenses(int LicenseID, int ApplicationID, int DriverID, int LicenseClassID, DateTime IssueDate,
                        DateTime ExpirationDate, string Notes, decimal PaidFees, bool IsActive, byte IssueReason,
                        int CreatedByUserID)
        {
            this.LicenseID = LicenseID;
            this.Application = clsApplications.Find(ApplicationID);
            this.Driver = clsDrivers.FindDriver(DriverID);
            this.LicenseClass = clsLicenseClasses.Find(LicenseClassID);
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            this.IssueReason = IssueReason;
            this.CreatedByUserID = CreatedByUserID;

            this._Mode = enMode.Update;
        }

        private bool _AddNew()
        {
            this.LicenseID = clsLicensesData.AddNew(this.Application.ApplicationID, this.Driver.DriverID, this.LicenseClass.LicenseClassID,
                                                    this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees, this.IsActive, this.IssueReason,
                                                    this.CreatedByUserID);

            return (this.LicenseID > 0);
        }

        private bool _Update()
        {
            return clsLicensesData.Update(this.LicenseID, this.Application.ApplicationID, this.Driver.DriverID, this.LicenseClass.LicenseClassID,
                                           this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees, this.IsActive, this.IssueReason,
                                           this.CreatedByUserID);
        }

        public bool Save()
        {
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

        public static clsLicenses Find(int LicenseID)
        {
            int ApplicationID = -1, DriverID = -1, LicenseClassID = -1, CreatedByUserID = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            string Notes = "";
            decimal PaidFees = -1;
            bool IsActive = false;
            byte IssueReason = 0;

            if (clsLicensesData.Find(LicenseID, ref ApplicationID, ref DriverID, ref LicenseClassID, ref IssueDate, ref ExpirationDate,
                                    ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID))
            {
                return new clsLicenses(LicenseID, ApplicationID, DriverID, LicenseClassID, IssueDate, ExpirationDate,
                                       Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);
            }
            else
                return null;

        }

        public static clsLicenses FindLicenseByNationalNoAndClassName(string NationalNo, string ClassName)
        {
            int ApplicationID = -1, DriverID = -1, LicenseClassID = -1, CreatedByUserID = -1, LicenseID = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            string Notes = "";
            decimal PaidFees = -1;
            bool IsActive = false;
            byte IssueReason = 0;

            if (clsLicensesData.FindLicenseByNationalNoAndClassName(NationalNo, ClassName, ref LicenseID, ref ApplicationID, ref DriverID,
                                    ref LicenseClassID, ref IssueDate, ref ExpirationDate,
                                    ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID))
            {
                return new clsLicenses(LicenseID, ApplicationID, DriverID, LicenseClassID, IssueDate, ExpirationDate,
                                       Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);
            }
            else
                return null;
        }

        public static bool IsExist(int LicenseID)
        {
            return clsLicensesData.IsExist(LicenseID);
        }

        public static bool IsHasLicense(string NationalNo, int LicenseClassID)
        {
            return clsLicensesData.IsHasLicense(NationalNo, LicenseClassID);
        }

        public static bool Delete(int LicenseID)
        {
            return clsLicensesData.Delete(LicenseID);
        }

        public static DataTable GetAllLicenses()
        {
            return clsLicensesData.GetAllLicenses();
        }

        public static DataTable GetAllLicenses(int PersonID)
        {
            return clsLicensesData.GetAllLicensesByPersonID(PersonID);
        }

        public static DataTable GetDriverLicenseInfo(string NationalNo, string ClassName)
        {
            return clsLicensesData.GetDriverLicenseInfo(NationalNo, ClassName);
        }


    }
}
