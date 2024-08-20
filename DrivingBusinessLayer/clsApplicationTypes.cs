using DrivingDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingBusinessLayer
{
    public class clsApplicationTypes
    {
        enum enMode { AddNew = 1, Update = 2 }

        enMode _Mode;

        public int ApplicationTypeID { get; set; }
        public string ApplicationTypeTitle { get; set; }
        public decimal ApplicationFees { get; set; }

        public clsApplicationTypes()
        {
            ApplicationTypeID = -1;
            ApplicationTypeTitle = "";
            ApplicationFees = -1;

            _Mode = enMode.AddNew;
        }

        private clsApplicationTypes(int applicationTypeID, string applicationTypeTitle, decimal applicationFees)
        {
            ApplicationTypeID = applicationTypeID;
            ApplicationTypeTitle = applicationTypeTitle;
            ApplicationFees = applicationFees;

            _Mode = enMode.Update;
        }

        private bool _AddNew()
        {
            this.ApplicationTypeID = clsApplicationTypesData.AddNew(this.ApplicationTypeTitle, this.ApplicationFees);

            return (this.ApplicationTypeID > 0);
        }

        private bool _Update()
        {
            return clsApplicationTypesData.Update(this.ApplicationTypeID, this.ApplicationTypeTitle,
                                                    this.ApplicationFees);
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

        public static clsApplicationTypes Find(int applicationTypeID)
        {
            string applicationTypeTitle = "";
            decimal applicationFees = -1;

            if (clsApplicationTypesData.Find(applicationTypeID, ref applicationTypeTitle, ref applicationFees))
            {
                return new clsApplicationTypes(applicationTypeID, applicationTypeTitle, applicationFees);
            }
            else
                return null;
        
        }

        public static DataTable GetAllApplicationTypes()
        {
            return clsApplicationTypesData.GetAllApplicationTypes();
        }  

    }
}
