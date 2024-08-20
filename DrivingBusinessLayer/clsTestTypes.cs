using DrivingDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingBusinessLayer
{
    public class clsTestTypes
    {
        public enum enMode { AddNew = 1, Update = 2}
        public enMode Mode;

        public enum enTestTypes { Vision = 1, Writing = 2, Street = 3};

        public enTestTypes TestTypeID {  get; set; }
        public string TestTypeTitle {  get; set; }
        public string TestTypeDescription { get; set;}
        public decimal TestTypeFees { get; set; }

        public clsTestTypes()
        {
            this.TestTypeID = clsTestTypes.enTestTypes.Vision;
            this.TestTypeTitle = "";
            this.TestTypeDescription = "";
            this.TestTypeFees = -1;

            Mode = enMode.AddNew;
        }

        private clsTestTypes(enTestTypes TestTypeiD, string TestTypetitle, string TestTypedescription, decimal TestTypefees) 
        {
            this.TestTypeID = TestTypeiD;
            this.TestTypeTitle = TestTypetitle;
            this.TestTypeDescription = TestTypedescription;
            this.TestTypeFees = TestTypefees;

            Mode = enMode.Update;
        }

        private bool _AddNew()
        {
            this.TestTypeID = (clsTestTypes.enTestTypes)clsTestTypesData.AddNew(this.TestTypeTitle, this.TestTypeDescription, this.TestTypeFees);

            return (this.TestTypeID > 0);
        }

        private bool _Update()
        {
            return clsTestTypesData.Update((int)this.TestTypeID, this.TestTypeTitle, this.TestTypeDescription, this.TestTypeFees);
        }

        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:

                    if (_AddNew())
                    {

                        this.Mode = enMode.Update;
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

        public static clsTestTypes Find(clsTestTypes.enTestTypes TestTypeID)
        {
            string TestTypeTitle = "", TestTypeDescription = "";
            decimal TestTypeFees = -1;

            if (clsTestTypesData.Find((int)TestTypeID, ref TestTypeTitle, ref TestTypeDescription, ref TestTypeFees))
            {

                return new clsTestTypes(TestTypeID, TestTypeTitle, TestTypeDescription, TestTypeFees);
            }
            else
                return null;

        }

        public static bool Delete(int TestTypeID)
        {
            return clsTestTypesData.Delete(TestTypeID);
        }

        public static bool IsExist(int TestTypeID)
        {
            return clsTestTypesData.IsExist(TestTypeID);
        }

        public static DataTable GetAllTestTypes()
        {
            return clsTestTypesData.GetAllTestTypes();
        }

    }
}
