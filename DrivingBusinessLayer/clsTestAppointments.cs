using DrivingDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static DrivingBusinessLayer.clsApplications;

namespace DrivingBusinessLayer
{
    public class clsTestAppointments
    {
        enum enMode { AddNew = 0, Update = 1}

        enMode _Mode;

        public int TestAppointmentID { get; set; }
        public int TestTypeID { get; set; }
        public clsTestTypes TestType 
        {
            get
            {
                return clsTestTypes.Find((clsTestTypes.enTestTypes)TestTypeID);
            }
        }
        public int LocalDrivingLicenseApplicationID {  get; set; }
        public clsLocalDrivingLicenseApplications LocalDrivingLicenseApplication
        {
            get
            {
                return clsLocalDrivingLicenseApplications.FindLocalDrivignLicenseApplicationByID(LocalDrivingLicenseApplicationID);
            }
        }
        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees { get; set; }
        public clsUsers CreatedByUser { get; set; }
        public bool IsLocked { get; set; }
        public int RetakeTestApplicationID { get; set; }
        public clsApplications RetakeTestApplication
        {
            get
            {
                return clsApplications.Find(RetakeTestApplicationID);
            }
        }

        public int TestID
        {
            get
            {
                return _GetTestID();
            }
        }

        public clsTestAppointments()
        {
            this.TestAppointmentID = -1;
            this.TestTypeID = -1;
            this.LocalDrivingLicenseApplicationID = -1;
            this.AppointmentDate = DateTime.Now;
            this.PaidFees = -1;
            this.CreatedByUser = null;
            this.IsLocked = false;
            this.RetakeTestApplicationID = -1;

            this._Mode = enMode.AddNew;
        }

        private clsTestAppointments(int testAppointmentID, int testTypeID, int localDrivingLicenseApplicationID, DateTime appointmentDate,
                                        decimal paidFees, int createdByUserID, bool isLocked, int RetakeTestApplicationID)
        {
            this.TestAppointmentID = testAppointmentID;
            this.TestTypeID = testTypeID;
            this.LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            this.AppointmentDate = appointmentDate;
            this.PaidFees = paidFees;
            this.CreatedByUser = clsUsers.FindUserByUserID(createdByUserID);
            this.IsLocked = isLocked;
            this.RetakeTestApplicationID = RetakeTestApplicationID;

            _Mode = enMode.Update;
        }

        private bool _AddNew()
        {
            if (this.RetakeTestApplication == null)
            {
                this.TestAppointmentID = clsTestAppointmentsData.AddNew((int)this.TestType.TestTypeID,
                                                                this.LocalDrivingLicenseApplicationID,
                                                                this.AppointmentDate, this.PaidFees, this.CreatedByUser.UserID,
                                                                this.IsLocked, -1);
            }
            else
            {
                this.TestAppointmentID = clsTestAppointmentsData.AddNew((int)this.TestType.TestTypeID,
                                                this.LocalDrivingLicenseApplicationID,
                                                this.AppointmentDate, this.PaidFees, this.CreatedByUser.UserID,
                                                this.IsLocked, this.RetakeTestApplication.ApplicationID);
            }

            return (this.TestAppointmentID > 0);
        }

        private bool _Update()
        {
            if (this.RetakeTestApplication == null)
            {
                return clsTestAppointmentsData.Update(this.TestAppointmentID, (int)this.TestType.TestTypeID,
                                        this.LocalDrivingLicenseApplicationID,
                                        this.AppointmentDate, this.PaidFees, this.CreatedByUser.UserID,
                                        this.IsLocked, -1);
            }
            else
            {
                return clsTestAppointmentsData.Update(this.TestAppointmentID, (int)this.TestType.TestTypeID,
                                                    this.LocalDrivingLicenseApplicationID,
                                                    this.AppointmentDate, this.PaidFees, this.CreatedByUser.UserID,
                                                    this.IsLocked, this.RetakeTestApplication.ApplicationID);
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

        public static clsTestAppointments Find(int testAppointmentID)
        {
            int TestTypeID = -1, LocalDrivingLicenseApplicationID = -1, createdByUserID = -1, RetakeTestApplicationID = -1;
            DateTime appointmentDate = DateTime.Now;
            decimal paidFees = -1;
            bool IsLocked = false;

            if (clsTestAppointmentsData.Find(testAppointmentID, ref TestTypeID, ref LocalDrivingLicenseApplicationID, ref appointmentDate,
                ref paidFees, ref createdByUserID, ref IsLocked, ref RetakeTestApplicationID))
            {
                return new clsTestAppointments(testAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID, appointmentDate,
                                                paidFees, createdByUserID, IsLocked, RetakeTestApplicationID);
            }
            else
                return null;

        }

        public static bool IsExist(int testAppointmentID)
        {
            return clsTestAppointmentsData.IsExist(testAppointmentID);
        }

        public static bool IsFaild(int D_L_AppID, int TestTypeID)
        {
            return clsTestAppointmentsData.IsFaild(D_L_AppID, TestTypeID);
        }

        public static bool Delete(int testAppointmentID)
        {
            return clsTestAppointmentsData.Delete(testAppointmentID);
        }

        public static DataTable GetAllTestAppointmentsByD_L_AppID(int D_L_AppID, int TestTypeID)
        {
            return clsTestAppointmentsData.GetAllTestAppointmentsByD_L_AppID(D_L_AppID, TestTypeID);
        }

        public static DataTable GetAllTestAppointmentsWithDetailse()
        {
            return clsTestAppointmentsData.GetAllTestAppointmentsWithDetailse();
        }

        private int _GetTestID()
        {
            return clsTestAppointmentsData.GetTestID(TestAppointmentID);
        }

    }
}
