using DrivingDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static DrivingBusinessLayer.clsApplications;
using static System.Net.Mime.MediaTypeNames;

namespace DrivingBusinessLayer
{
    public class clsApplications
    {
        public enum enMode { AddNew = 0, UpdateMode = 1 };
        public enum enApplicationStatus { New = 1, Canceled = 2, Compleated = 3 };
        
        public enApplicationStatus ApplicationStatus;
        public string StatusText
        {
            get
            {
                switch (ApplicationStatus)
                {
                    case enApplicationStatus.New:

                        return "New";

                    case enApplicationStatus.Compleated:

                        return "Compleated";

                    case enApplicationStatus.Canceled:

                        return "Canceled";

                    default:

                        return "Unknow";
                }
            }
        }

        public enMode Mode;

        public int ApplicationID { get; set; }
        public int ApplicantPersonID { get; set; }
        public clsPepole PersonInfo 
        {
            get 
            {
                return clsPepole.FindPerson(ApplicantPersonID);
            }
        }
        public DateTime ApplicationDate { get; set; }
        public int ApplicationTypeID { get; set; }
        public clsApplicationTypes ApplicationTypeInfo
        {
            get
            {
                return clsApplicationTypes.Find(ApplicationTypeID);
            }
        }
        public DateTime LastStatusDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUsers CreatedByUser
        {
            get
            {
                return clsUsers.FindUserByUserID(CreatedByUserID);
            }
        }

        public clsApplications()
        {
            this.ApplicationID = -1;
            this.ApplicantPersonID = -1;
            this.ApplicationDate = DateTime.Now;
            this.ApplicationTypeID = -1;
            this.LastStatusDate = DateTime.Now;
            this.PaidFees = -1;
            this.CreatedByUserID = -1;

            this.ApplicationStatus = enApplicationStatus.New;
            this.Mode = enMode.AddNew;
        }

        private clsApplications(int applicationID, int applicantPersoniD, DateTime applicationDate,
            int applicationTypeID, byte applicationStatus, DateTime lastStatusDate, decimal paidFees,
            int createdByUseriD)
        {
            this.ApplicationID = applicationID;
            this.ApplicantPersonID = applicantPersoniD;
            this.ApplicationDate = applicationDate;
            this.ApplicationTypeID = applicationTypeID;
            this.LastStatusDate = lastStatusDate;
            this.PaidFees = paidFees;
            this.CreatedByUserID = createdByUseriD;

            this.ApplicationStatus = (enApplicationStatus)applicationStatus;
            this.Mode = enMode.UpdateMode;
        }

        private bool _AddNewApplication()
        {
            this.ApplicationID = clsApplicationsData.AddNewApplication(this.PersonInfo.PersonID,this.ApplicationDate,
                                 this.ApplicationTypeID, Convert.ToByte(this.ApplicationStatus), this.LastStatusDate,
                                 this.PaidFees, this.CreatedByUserID);

            return (this.ApplicationID > 0);
        }

        private bool _UpdateApplication()
        {
            return clsApplicationsData.UpdateApplication(this.ApplicationID, this.PersonInfo.PersonID, this.ApplicationDate,
                                 this.ApplicationTypeID, Convert.ToByte(this.ApplicationStatus), this.LastStatusDate,
                                 this.PaidFees, this.CreatedByUserID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:

                    if (_AddNewApplication())
                    {
                        this.Mode = enMode.UpdateMode;
                        return true;
                    }
                    else
                        return false;

                case enMode.UpdateMode:

                    if (_UpdateApplication())
                    {
                        return true;
                    }
                    else
                        return false;
            }

            return false;
        }

        public static clsApplications Find(int applicationID)
        {
            int applicationPeronID = -1,applicationTypeID = -1, createdByUserID = -1;
            DateTime applicationDate = DateTime.Now, lastStatusDate = DateTime.Now;
            decimal paidFees = -1;
            byte applicationStatus = 1;

            if (clsApplicationsData.Find(applicationID, ref applicationPeronID, ref applicationDate, ref applicationTypeID, ref applicationStatus,
                ref lastStatusDate, ref paidFees, ref createdByUserID))
            {
                return new clsApplications(applicationID, applicationPeronID, applicationDate, applicationTypeID, applicationStatus,
                lastStatusDate, paidFees, createdByUserID);
            }
            else
                return null;

        }

        public static bool IsApplicationExist(int ApplicationID)
        {
            return clsApplicationsData.IsApplicationExist(ApplicationID);
        }

        public static bool DeleteApplication(int ApplicationID)
        {
            return clsApplicationsData.DeleteApplication(ApplicationID);
        }

        public bool Cancel()
        {
            return clsApplicationsData.UpdateStatus(this.ApplicationID, 2);
        }

        public bool SetCompleated()
        {
            return clsApplicationsData.UpdateStatus(this.ApplicationID, 3);
        }

        public static bool CantEditApplication(int LocalDrivingLicenseApplicationID)
        {
            bool IsExist = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT TOP 1 LocalDrivingLicenseApplicationID FROM TestAppointments
                             WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                IsExist = Reader.HasRows;
                Reader.Close();

            }
            catch
            {
                IsExist = false;
            }
            finally
            {
                Connection.Close();
            }


            return IsExist;
        }

        public static DataTable GetAllApplications()
        {
            return clsApplicationsData.GetAllApplications();
        }

        public static DataTable GetAllApplicationsWithDetailse()
        {
            return clsApplicationsData.GetAllApplicationsWithDetailse();
        }

        public static bool IsHasApplication(int PersonID, int LicenseClassID)
        {
            return clsApplicationsData.IsHasApplication(PersonID, LicenseClassID);
        }

    }
}
