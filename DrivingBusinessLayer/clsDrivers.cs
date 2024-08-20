using DrivingDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DrivingBusinessLayer
{
    public class clsDrivers
    {
        enum enMode { AddNew = 1, UpdateMode = 2 };

        private enMode _Mode;

        public int DriverID { get; set; }
        public clsPepole Person { get; set; }
        public clsUsers CreatedByUser { get; set; }
        public DateTime CreatedDate { get; set; }


        public clsDrivers(): base()
        {

            this.DriverID = -1;
            this.Person = null;
            this.CreatedByUser = null;
            this.CreatedDate = DateTime.Now;

            _Mode = enMode.AddNew;
        }

        private clsDrivers(int Driverid, int personid, int CreatedByUseriD, DateTime createdDate)
        {
            this.DriverID = Driverid;
            this.Person = clsPepole.FindPerson(personid);
            this.CreatedByUser = clsUsers.FindUserByUserID(CreatedByUseriD);
            this.CreatedDate = createdDate;

            _Mode = enMode.UpdateMode;
        }


        private bool _AddNewDriver()
        {

            this.DriverID = clsDriversData.AddNewDriver(this.Person.PersonID, this.CreatedByUser.UserID,
                                                        this.CreatedDate);

            return (this.DriverID != -1);
        }

        private bool _UpdateDriver()
        {

            return (clsDriversData.UpdateDriver(this.DriverID, this.Person.PersonID, this.CreatedByUser.UserID,
                                                this.CreatedDate));

        }

        public static clsDrivers FindDriver(int DriverID)
        {
            int PersonID = -1, CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.Now;

            if (clsDriversData.Find(DriverID, ref PersonID, ref CreatedByUserID, ref CreatedDate))
            {

                return new clsDrivers(DriverID, PersonID, CreatedByUserID, CreatedDate);

            }
            else
                return null;

        }

        public static clsDrivers FindDriver(string NationalNo)
        {
            int DriverID = -1, PersonID = -1, CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.Now;

            if (clsDriversData.Find(NationalNo, ref DriverID, ref PersonID, ref CreatedByUserID, ref CreatedDate))
            {

                return new clsDrivers(DriverID, PersonID, CreatedByUserID, CreatedDate);

            }
            else
                return null;
        }

        public bool Save()
        {

            switch (_Mode)
            {
                case enMode.AddNew:

                    if (_AddNewDriver())
                    {

                        _Mode = enMode.UpdateMode;
                        return true;
                    }
                    else
                        return false;

                case enMode.UpdateMode:

                    return _UpdateDriver();


            }

            return false;
        }

        public static bool DeleteDriver(int DriverID)
        {
            return clsDriversData.DeleteDriver(DriverID);
        }

        public static bool IsDriverExist(int DriverID)
        {

            return clsDriversData.IsDriverExist(DriverID);

        }

        public static DataTable GetAllDrivers()
        {
            return clsDriversData.GetAllDrivers();
        }

        public static DataTable GetAllDriversWithDetailse()
        {
            return clsDriversData.GetAllDriversWithDetailse();
        }
    }
}
