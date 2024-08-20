using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrivingDataAccess;

namespace DrivingBusinessLayer
{
    public class clsPepole
    {
        enum enMode { AddNew = 1, UpdateMode = 2 };

        private enMode _Mode;

        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string FullName()
        {
            return  FirstName.Trim() + ' ' + SecondName.Trim() + ' ' + ThirdName.Trim() + ' ' + LastName.Trim();
        }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int CountryID { get; set; }
        public clsCountries CountryInfo { get; set; }
        public string Gender { get; set; }
        public string PersonalPicture { get; set; }


        public clsPepole()
        {
            this.PersonID = -1;
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.DateOfBirth = DateTime.MaxValue;
            this.Address = "";
            this.Phone = "";
            this.Email = "";
            this.CountryID = -1;
            this.Gender = "";
            this.PersonalPicture = "";

            _Mode = enMode.AddNew;
        }

        protected clsPepole(int personid, string nationalNo, string firstname, string secondname, string thirdname,
            string lastname, DateTime dateOfBirth, string address, string phone, string email,
            int countryID, string countryname, string gender, string personalPicture)
        {
            this.PersonID = personid;
            this.NationalNo = nationalNo;
            this.FirstName  = firstname;
            this.SecondName = secondname;
            this.ThirdName  = thirdname;
            this.LastName   = lastname;
            this.DateOfBirth = dateOfBirth;
            this.Address = address;
            this.Phone = phone;
            this.Email = email;
            this.CountryID = countryID;
            this.CountryInfo = clsCountries.Find(CountryID);
            this.Gender = gender;
            this.PersonalPicture = personalPicture;

            _Mode = enMode.UpdateMode;
        }


        private bool _AddNewPerson()
        {

            this.PersonID = clsPepoleData.AddNewPerson(this.NationalNo, this.FirstName, this.SecondName, this.ThirdName,
                                                  this.LastName, this.DateOfBirth, this.Email,this.Phone, this.Address,
                                                  this.CountryID, this.Gender, this.PersonalPicture);

            return (this.PersonID != -1);
        }

        private bool _UpdatePerson()
        {

            return (clsPepoleData.UpdatePerson(this.PersonID, this.NationalNo, this.FirstName, this.SecondName,
                                                this.ThirdName, this.LastName, this.DateOfBirth, this.Address,
                                                this.Phone, this.Email, this.CountryID, this.Gender,
                                                this.PersonalPicture));

        }

        public static clsPepole FindPerson(string NationalNo)
        {
            int ID = -1, CountryID = -1;
            string FirstName = ""; string SecondName = ""; string ThirdName = ""; string LastName = "";
            string Address = ""; string Phone = ""; string Email = ""; string Gender = ""; string CountryName = "";
            string PersonalPicture = "";
            DateTime DateOfBeirth = DateTime.Now;

            if (clsPepoleData.Find(ref ID, NationalNo, ref FirstName, ref SecondName, ref ThirdName,
                ref LastName, ref DateOfBeirth, ref Address, ref Phone, ref Email, ref CountryID,
                ref Gender, ref PersonalPicture))
            {

                return new clsPepole(ID, NationalNo, FirstName, SecondName, ThirdName, LastName,
                    DateOfBeirth, Address, Phone, Email, CountryID, CountryName, Gender, PersonalPicture);

            }
            else
                return null;

        }

        public static clsPepole FindPerson(int PersonID)
        {
            int CountryID = -1;
            string NationalNo = ""; string FirstName = ""; string SecondName = ""; string ThirdName = ""; string LastName = "";
            string Address = ""; string Phone = ""; string Email = ""; string Gender = ""; string CountryName = "";
            string PersonalPicture = "";
            DateTime DateOfBeirth = DateTime.Now;

            if (clsPepoleData.Find(PersonID, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName,
                ref LastName, ref DateOfBeirth, ref Address, ref Phone, ref Email, ref CountryID,
                ref Gender, ref PersonalPicture))
            {

                return new clsPepole(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName,
                    DateOfBeirth, Address, Phone, Email, CountryID, CountryName, Gender, PersonalPicture);

            }
            else
                return null;

        }

        public bool Save()
        {

            switch (_Mode)
            {
                case enMode.AddNew:

                    if (_AddNewPerson())
                    {

                        _Mode = enMode.UpdateMode;
                        return true;
                    }
                    else
                        return false;

                case enMode.UpdateMode:

                    return _UpdatePerson();


            }

            return false;
        }

        public static bool DeletePerson(string NationalNo)
        {
            return clsPepoleData.DeletePerson(NationalNo);
        }

        public static bool IsPersonExist(string NationalNo)
        {

            return clsPepoleData.IsPersonExist(NationalNo);

        }

        public static bool IsPersonExist(int PersonID)
        {

            return clsPepoleData.IsPersonExist(PersonID);

        }

        public static DataTable GetAllPersons()
        {
            return clsPepoleData.GetAllPepole();
        }

        public static DataTable GetAllPersonsWithDetailse()
        {
            return clsPepoleData.GetAllPepoleWithDetailse();
        }
    }
}
