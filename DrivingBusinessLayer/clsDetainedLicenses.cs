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
    public class clsDetainedLicenses
    {
        enum enMode { AddNew = 0, Update = 1 }

        enMode _Mode;

        public int DetainID { get; set; }
        public clsLicenses License { get; set; }
        public DateTime DetainDate { get; set; }
        public decimal FineFees { get; set; }
        public clsUsers CreatedByUser { get; set; }
        public bool IsReleased { get; set; }
        public DateTime ReleaseDate { get; set; }
        public clsUsers ReleasedByUser { get; set; }
        public clsApplications ReleaseApplication { get; set; }

        public clsDetainedLicenses()
        {
            this.DetainID = -1;
            this.License = null;
            this.DetainDate = DateTime.Now;
            this.FineFees = -1;
            this.CreatedByUser = null;
            this.IsReleased = false;
            this.ReleaseDate = DateTime.MinValue;
            this.ReleasedByUser = null;
            this.ReleaseApplication = null;

            this._Mode = enMode.AddNew;
        }

        private clsDetainedLicenses(int DetainID, int LicenseID, DateTime DetainDate, decimal FineFees, int CreatedByUserID, bool IsReleased,
                                DateTime ReleaseDate, int ReleaseByUserID, int ReleaseApplicationID)
        {
            this.DetainID = DetainID;
            this.License = clsLicenses.Find(LicenseID);
            this.DetainDate = DetainDate;
            this.FineFees = FineFees;
            this.CreatedByUser = clsUsers.FindUserByUserID(CreatedByUserID);
            this.IsReleased = IsReleased;
            this.ReleaseDate = ReleaseDate;
            
            if (ReleaseByUserID > 0)
            {
                this.ReleasedByUser = clsUsers.FindUserByUserID(ReleaseByUserID);
            }
            else
                this.ReleasedByUser = null;

            if (ReleaseApplicationID > 0)
            {
                this.ReleaseApplication = clsApplications.Find(ReleaseApplicationID);
            }
            else
                this.ReleaseApplication = null;

            this._Mode = enMode.Update;
        }

        private bool _AddNew()
        {
            if (this.ReleaseApplication != null && this.ReleasedByUser != null)
            {
                this.DetainID = clsDetainedLicensesData.AddNew(this.License.LicenseID, this.DetainDate, this.FineFees, this.CreatedByUser.UserID,
                                    this.IsReleased, this.ReleaseDate, this.ReleasedByUser.UserID,
                                    this.ReleaseApplication.ApplicationID);
            }
            else
            {
                this.DetainID = clsDetainedLicensesData.AddNew(this.License.LicenseID, this.DetainDate, this.FineFees,
                                                                this.CreatedByUser.UserID, this.IsReleased,
                                                                DateTime.MinValue, -1, -1);
            }


            return (this.DetainID > 0);
        }

        private bool _Update()
        {
            if (this.ReleaseApplication != null && this.ReleasedByUser != null)
            {
                return clsDetainedLicensesData.Update(this.DetainID, this.License.LicenseID, this.DetainDate, this.FineFees, this.CreatedByUser.UserID,
                            this.IsReleased, this.ReleaseDate, this.ReleasedByUser.UserID, this.ReleaseApplication.ApplicationID);
            }
            else
            {
                return clsDetainedLicensesData.Update(this.DetainID, this.License.LicenseID, this.DetainDate, this.FineFees, this.CreatedByUser.UserID,
                       this.IsReleased, DateTime.MinValue, -1, -1);
            }

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

        public static clsDetainedLicenses Find(int DetainID)
        {
            int LicenseID = -1, CreatedByUserID = -1, ReleaseByUserID = -1, ReleaseApplicationID = -1;
            DateTime DetainDate = DateTime.Now, ReleaseDate = DateTime.Now;
            decimal FineFees = -1;
            bool IsReleased = false;

            if (clsDetainedLicensesData.Find(DetainID, ref LicenseID, ref DetainDate, ref FineFees, ref CreatedByUserID,
                                        ref IsReleased, ref ReleaseDate, ref ReleaseByUserID, ref ReleaseApplicationID))
            {
                return new clsDetainedLicenses(DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID,
                                                IsReleased, ReleaseDate, ReleaseByUserID, ReleaseApplicationID);
            }
            else
                return null;

        }

        public static clsDetainedLicenses GetLicenseDetained(int LicenseID)
        {
            int DetainID = -1, CreatedByUserID = -1, ReleaseByUserID = -1, ReleaseApplicationID = -1;
            DateTime DetainDate = DateTime.Now, ReleaseDate = DateTime.Now;
            decimal FineFees = -1;
            bool IsReleased = false;

            if (clsDetainedLicensesData.GetLicenseDetained(ref DetainID, LicenseID, ref DetainDate, ref FineFees, ref CreatedByUserID,
                                        ref IsReleased, ref ReleaseDate, ref ReleaseByUserID, ref ReleaseApplicationID))
            {
                return new clsDetainedLicenses(DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID,
                                                IsReleased, ReleaseDate, ReleaseByUserID, ReleaseApplicationID);
            }
            else
                return null;
        }

        public static bool IsExist(int DetainID)
        {
            return clsDetainedLicensesData.IsExist(DetainID);
        }

        public static bool IsDetained(int LicenseID)
        {
            return clsDetainedLicensesData.IsDetained(LicenseID);
        }

        public static bool Delete(int DetainID)
        {
            return clsDetainedLicensesData.Delete(DetainID);
        }

        public static DataTable GetAllDetainedLicenses()
        {
            return clsDetainedLicensesData.GetAllDetainedLicenses();
        }

        public static DataTable GetAllDetainedLicensesWithDetailse()
        {
            return clsDetainedLicensesData.GetAllDetainedLicensesWithDetailse();
        }

    }
}
