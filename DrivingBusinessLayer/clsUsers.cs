using DrivingDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DrivingBusinessLayer
{
    public class clsUsers
    {
        enum enMode { AddNew = 1, UpdateMode = 2 };

        private enMode _Mode;

        public int UserID { get; set; }
        public int PersonID { get; set; }
        public clsPepole PersonInfo { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive {  get; set; }

        public clsUsers()
        {
            this.UserID = -1;
            this.PersonID = -1;
            this.Username = "";
            this.Password = "";
            this.IsActive = false;

            _Mode = enMode.AddNew;
        }

        private clsUsers(int userid, int PersoniD, string username, string password, bool isActive) 
        {
            this.UserID = userid;
            this.PersonID = PersoniD;
            this.PersonInfo = clsPepole.FindPerson(PersoniD);
            this.Username = username;
            this.Password = password;
            this.IsActive = isActive;

            _Mode = enMode.UpdateMode;
        }


        private bool _AddNewUser()
        {

            this.UserID = clsUsersData.AddNewUser(this.PersonID, this.Username, this.Password, this.IsActive);

            return (this.PersonID != -1);
        }

        private bool _UpdateUser()
        {

            return (clsUsersData.UpdateUser(this.UserID, this.Username, this.Password, this.IsActive));

        }

        public static clsUsers FindUserByPersonID(int PersonID)
        {
            int UserID = -1;
            string Password = "", Username = "";
            bool isActive = false;

            if (clsUsersData.FindUserByPersonID(ref UserID, PersonID, ref Username, ref Password, ref isActive))
            {

                return new clsUsers(UserID, PersonID, Username, Password, isActive);

            }
            else
                return null;

        }

        public static clsUsers FindUserByUserID(int UserID)
        {
            int PersonID = -1;
            string Username = "", Password = "";
            bool isActive = false;

            if (clsUsersData.FindUserByUserID(UserID, ref PersonID, ref Username, ref Password, ref isActive))
            {

                return new clsUsers(UserID, PersonID, Username, Password, isActive);

            }
            else
                return null;

        }

        public static clsUsers FindUserByUsernameAndPassword(string Username, string Password)
        {
            int UserID = -1, PersonID = -1;
            bool isActive = false;

            if (clsUsersData.FindUserByUsernameAndPassword(ref UserID, ref PersonID, Username, Password, ref isActive))
            {

                return new clsUsers(UserID, PersonID, Username, Password, isActive);

            }
            else
                return null;
        }

        public bool Save()
        {

            switch (_Mode)
            {
                case enMode.AddNew:

                    if (_AddNewUser())
                    {

                        _Mode = enMode.UpdateMode;
                        return true;
                    }
                    else
                        return false;

                case enMode.UpdateMode:

                    return _UpdateUser();


            }

            return false;
        }

        public static bool DeleteUser(string Username)
        {
            return clsUsersData.DeleteUser(Username);
        }

        public static bool DeleteUser(int UserID)
        {
            return clsUsersData.DeleteUser(UserID);
        }

        public static bool IsUserExistByUsername(string Username)
        {

            return clsUsersData.IsUserExistByUsername(Username);

        }

        public static bool IsUserExistByUserID(int UserID)
        {

            return clsUsersData.IsUserExistByUserID(UserID);

        }

        public static bool IsUserExistByPersonID(int PersonID)
        {
            return clsUsersData.IsUserExistByPersonID(PersonID);
        }

        public static DataTable GetAllUsers()
        {
            return clsUsersData.GetAllUsers();
        }


    }
}
