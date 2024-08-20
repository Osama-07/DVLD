using DrivingDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingBusinessLayer
{
    public class clsLicenseClasses
    {
        public int LicenseClassID {  get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public byte MinimumAllowedAge { get; set; }
        public byte DefaultValidityLength { get; set; }
        public decimal ClassFees { get; set; }

        public clsLicenseClasses()
        {
            this.LicenseClassID = -1;
            this.ClassName = "";
            this.ClassDescription = "";
            this.MinimumAllowedAge = 0;
            this.DefaultValidityLength = 0;
            this.ClassFees = -1;
        }

        public clsLicenseClasses(int licenseClassID, string className, string classDescription, byte minimumAllowedAge,
                                 byte defaultValidityLength, decimal classFees)
        {
            this.LicenseClassID = licenseClassID;
            this.ClassName = className;
            this.ClassDescription = classDescription;
            this.MinimumAllowedAge = minimumAllowedAge;
            this.DefaultValidityLength = defaultValidityLength;
            this.ClassFees = classFees;
        }

        public static clsLicenseClasses Find(int LicenseClassID)
        {
            string ClassName = "", ClassDescription = "";
            byte MinimumAllwedAge = 0, DefaultValidityLength = 0;
            decimal ClassFees = -1;

            if (clsLicenseClassesData.Find(LicenseClassID, ref ClassName, ref ClassDescription, ref MinimumAllwedAge, ref DefaultValidityLength,
                ref ClassFees))
            {

                return new clsLicenseClasses(LicenseClassID, ClassName, ClassDescription, MinimumAllwedAge, DefaultValidityLength, ClassFees);

            }
            else
                return new clsLicenseClasses(LicenseClassID, ClassName, ClassDescription, MinimumAllwedAge, DefaultValidityLength, ClassFees);

        }

        public static DataTable GetAllLinceseClasses()
        {
            return clsLicenseClassesData.GetAllLicenseClasses();
        }

        public static int GetLicenseClassID(string ClassName)
        {
            return clsLicenseClassesData.GetLicenseClassID(ClassName);
        }

        public static bool IsHasLicenseClass(int PersonID, int LicenseClass)
        {
            return clsLicenseClassesData.IsHasLicenseClass(PersonID, LicenseClass);
        }

    }
}
