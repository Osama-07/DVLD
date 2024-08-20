using DrivingDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingBusinessLayer
{
    public class clsTests
    {
        enum enMode { AddNew = 0, Update = 1 }

        enMode _Mode;

        public int TestID { get; set; }
        public int TestAppointmentID { get; set; }
        public clsTestAppointments TestAppointment { get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public clsUsers CreatedByUser { get; set; }

        public clsTests()
        {
            this.TestID = -1;
            this.TestAppointmentID = -1;
            this.TestResult = false;
            this.Notes = "";
            this.CreatedByUser = null;

            this._Mode = enMode.AddNew;
        }

        private clsTests(int testID, int testAppointmentID, bool testResult, string notes, int createdByUserID)
        {
            this.TestID = testID;
            this.TestAppointmentID = testAppointmentID;
            this.TestAppointment = clsTestAppointments.Find(testAppointmentID);
            this.TestResult = testResult;
            this.Notes = notes;
            this.CreatedByUser = clsUsers.FindUserByUserID(createdByUserID);

            this._Mode = enMode.Update;
        }

        private bool _AddNew()
        {
            this.TestID = clsTestsData.AddNew(this.TestAppointmentID, this.TestResult, this.Notes,
                                              this.CreatedByUser.UserID);

            return (this.TestID > 0);
        }

        private bool _Update()
        {
            return clsTestsData.Update(this.TestID, this.TestAppointmentID, this.TestResult,
                                        this.Notes, this.CreatedByUser.UserID);
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

        public static clsTests Find(int testID)
        {
            int TestAppointmentID = -1, createdByUserID = -1;
            string Notes = "";
            bool TestResult = false;

            if (clsTestsData.Find(testID, ref TestAppointmentID, ref TestResult, ref Notes, ref createdByUserID))
            {
                return new clsTests(testID, TestAppointmentID, TestResult, Notes, createdByUserID);
            }
            else
                return null;

        }

        public static bool IsPass(int TestAppointmentID)
        {
            return clsTestsData.IsPass(TestAppointmentID);
        }

        public static bool IsExist(int testID)
        {
            return clsTestsData.IsExist(testID);
        }

        public static bool Delete(int testID)
        {
            return clsTests.Delete(testID);
        }

        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            return clsTestsData.GetPassedTestCount(LocalDrivingLicenseApplicationID);
        }

        public static DataTable GetAllTests()
        {
            return clsTestsData.GetAllTests();
        }

    }
}
