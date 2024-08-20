using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrivingDataAccess;

namespace DrivingBusinessLayer
{
    public class clsCountries
    {
        public int ID { get; set; }

        public string CountryName { get; set; }

        public clsCountries() 
        {

        }

        private clsCountries(int iD, string countryName)
        {
            this.ID = iD;
            this.CountryName = countryName;
        }

        public static clsCountries Find(int CountryID)
        {
            string CountryName = "";

            bool IsFound = clsCountriesData.Find(CountryID, ref CountryName);

            if (IsFound)
                return new clsCountries(CountryID, CountryName);
            else
                return null;

        }
        public static DataTable GetAllCountries()
        {
            return clsCountriesData.GetAllCountries();
        }

        public static int GetCountryID(string countryName)
        {
            return clsCountriesData.GetCountryID(countryName);
        }

    }
}
