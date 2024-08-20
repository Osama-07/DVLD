using System;
using System.Data;
using System.Data.SqlClient;
using static DrivingDataAccess.clsUtilSettings;
using System.Windows.Forms;

namespace DrivingDataAccess
{
    public class clsPepoleData
    {

        public static int AddNewPerson(string NationalNo, string FirstName, string SecondName, string ThirdName,
            string LastName, DateTime DateOfBirth,string Email, string Phone, string Address, int CountryID,
            string Gender, string PersonalPicture)
        {
            int PersonID = -1;

            string StoredProcedure = "SP_AddNewPerson";

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);



            SqlCommand Command = new SqlCommand(StoredProcedure, Connection);

            Command.CommandType = CommandType.StoredProcedure;

            Command.Parameters.AddWithValue("@NationalNo", NationalNo);
            Command.Parameters.AddWithValue("@FirstName", FirstName);
            Command.Parameters.AddWithValue("@SecondName", SecondName);
            Command.Parameters.AddWithValue("@ThirdName", ThirdName);
            Command.Parameters.AddWithValue("@LastName", LastName);
            Command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            Command.Parameters.AddWithValue("@Email", Email);
            Command.Parameters.AddWithValue("@Phone", Phone);
            Command.Parameters.AddWithValue("@Address", Address);
            Command.Parameters.AddWithValue("@CountryID", CountryID);

            if (Gender == "Male")
            {
                Command.Parameters.AddWithValue("@Gender", 0); // Male = 0.
            }
            else
                Command.Parameters.AddWithValue("@Gender", 1); // Female = 1.

            if (PersonalPicture != "" && PersonalPicture != null)
            {
                Command.Parameters.AddWithValue("@PersonalPicture", PersonalPicture);
            }
            else
                Command.Parameters.AddWithValue("@PersonalPicture", DBNull.Value);

            // Output parameter
            SqlParameter outputParameter = new SqlParameter("@NewPersonID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            Command.Parameters.Add(outputParameter);

            try
            {
                Connection.Open();

                Command.ExecuteNonQuery();

                PersonID = (int)Command.Parameters["@NewPersonID"].Value;

            }
            catch (Exception ex)
            {
                StoreEventInEventLogs("Error AddNew Person " + ex.Message, enEventType.Error);
                MessageBox.Show($"Error AddNew Person : {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Connection.Close();
            }

            return PersonID;
        }

        public static bool Find(ref int PersonID, string NationalNo, ref string FirstName, ref string SecondName,
            ref string ThirdName, ref string LastName, ref DateTime DateOfBirth,
            ref string Address, ref string Phone, ref string Email, ref int CountryID, ref string Gender,
            ref string PersonalPicture)
        {
            bool IsFound = false;

            string StoredProcedure = @"SP_GetPersonByNationalNo";
            
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand Command = new SqlCommand(StoredProcedure, Connection);
            Command.CommandType = CommandType.StoredProcedure;

            Command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    PersonID = (int)Reader["PersonID"];
                    FirstName = (string)Reader["FirstName"];
                    SecondName = (string)Reader["SecondName"];
                    ThirdName = (string)Reader["ThirdName"];
                    LastName = (string)Reader["LastName"];
                    DateOfBirth = (DateTime)Reader["DateOfBirth"];
                    Email = (string)Reader["Email"];
                    Phone = (string)Reader["Phone"];
                    Address = (string)Reader["Address"];
                    CountryID = (int)Reader["CountryID"];
                    
                    if ((byte)Reader["Gender"] == 0)
                    {
                        Gender = "Male";
                    }
                    else
                        Gender = "Female";

                    if (Reader["PersonalPicture"] == DBNull.Value)
                    {
                        PersonalPicture = "";
                    }
                    else
                        PersonalPicture = (string)Reader["PersonalPicture"];

                    IsFound = true;
                }

                Reader.Close();

            }
            catch (Exception ex)
            {
                StoreEventInEventLogs(ex.Message, enEventType.Error);
                MessageBox.Show($"Error : {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Connection.Close();
            }


            return IsFound;
        }

        public static bool Find(int PersonID, ref string NationalNo, ref string FirstName, ref string SecondName,
            ref string ThirdName, ref string LastName, ref DateTime DateOfBirth,
            ref string Address, ref string Phone, ref string Email, ref int CountryID,
            ref string Gender, ref string PersonalPicture)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string StoredProcedure = @"SP_GetPersonByID";

            SqlCommand Command = new SqlCommand(StoredProcedure, Connection);

            Command.CommandType = CommandType.StoredProcedure;

            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    NationalNo = (string)Reader["NationalNo"];
                    FirstName = (string)Reader["FirstName"];
                    SecondName = (string)Reader["SecondName"];
                    ThirdName = (string)Reader["ThirdName"];
                    LastName = (string)Reader["LastName"];
                    DateOfBirth = (DateTime)Reader["DateOfBirth"];
                    Email = (string)Reader["Email"];
                    Phone = (string)Reader["Phone"];
                    Address = (string)Reader["Address"];
                    CountryID = (int)Reader["CountryID"];

                    if ((byte)Reader["Gender"] == 0)
                    {
                        Gender = "Male";
                    }
                    else
                    {
                        Gender = "Female";
                    }

                    if (Reader["PersonalPicture"] == DBNull.Value)
                    {
                        PersonalPicture = "";
                    }
                    else
                        PersonalPicture = (string)Reader["PersonalPicture"];

                    IsFound = true;
                }

                Reader.Close();

            }
            catch (Exception ex)
            {
                StoreEventInEventLogs("Error find person by national no " + ex.Message, enEventType.Error);
                MessageBox.Show($"Error find person by national no : \n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Connection.Close();
            }


            return IsFound;
        }

        public static bool IsPersonExist(string NationalNo)
        {

            bool IsExist = false;

            string StoredProcedure = @"SP_CheckPersonExistsByNationalNo";
            
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand Command = new SqlCommand(StoredProcedure, Connection);
            Command.CommandType = CommandType.StoredProcedure;

            Command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                IsExist = Reader.HasRows;
                Reader.Close();

            }
            catch (Exception ex)
            {
                StoreEventInEventLogs(ex.Message, enEventType.Error);
                MessageBox.Show($"Error : {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Connection.Close();
            }


            return IsExist;
        }

        public static bool IsPersonExist(int PersonID)
        {

            bool IsExist = false;

            string StoredProcedure = @"SP_CheckPersonExists";
            
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand Command = new SqlCommand(StoredProcedure, Connection);
            Command.CommandType = CommandType.StoredProcedure;

            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                IsExist = Reader.HasRows;
                Reader.Close();

            }
            catch (Exception ex)
            {
                StoreEventInEventLogs(ex.Message, enEventType.Error);
                MessageBox.Show($"Error : {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Connection.Close();
            }


            return IsExist;
        }

        public static bool DeletePerson(string NationalNo)
        {
            bool Deleted = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SP_DeletePersonByNationalNo";

            SqlCommand Command = new SqlCommand(query, Connection);
            Command.CommandType = CommandType.StoredProcedure;

            Command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                Connection.Open();

                int rowAffected = Command.ExecuteNonQuery();

                if (rowAffected > 0)
                {
                    Deleted = true;
                }

            }
            catch (Exception ex)
            {
                StoreEventInEventLogs(ex.Message, enEventType.Error);
                MessageBox.Show($"Error : {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Connection.Close();
            }

            return Deleted;
        }

        public static bool UpdatePerson(int PersonID, string NationalNo, string FirstName, string SecondName,
            string ThirdName, string LastName, DateTime DateOfBirth, string Address, string Phone, string Email,
            int CountryID, string Gender, string PersonalPicture)
        {
            bool Updated = false;

            string StoredProcedure = @"SP_UpdatePerson";
            
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand Command = new SqlCommand(StoredProcedure, Connection);
            Command.CommandType = CommandType.StoredProcedure;

            Command.Parameters.AddWithValue("@NationalNo", NationalNo);
            Command.Parameters.AddWithValue("@FirstName", FirstName);
            Command.Parameters.AddWithValue("@SecondName", SecondName);
            Command.Parameters.AddWithValue("@ThirdName", ThirdName);
            Command.Parameters.AddWithValue("@LastName", LastName);
            Command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            Command.Parameters.AddWithValue("@Email", Email);
            Command.Parameters.AddWithValue("@Phone", Phone);
            Command.Parameters.AddWithValue("@Address", Address);
            Command.Parameters.AddWithValue("@CountryID", CountryID);
            
            if (Gender == "Male")
            {
                Command.Parameters.AddWithValue("@Gender", 0); // Male = 0.
            }
            else
                Command.Parameters.AddWithValue("@Gender", 1); // Female = 1.

            if (PersonalPicture == "")
            {
                Command.Parameters.AddWithValue("@PersonalPicture", System.DBNull.Value);
            }
            else
                Command.Parameters.AddWithValue("@PersonalPicture", PersonalPicture);

            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                Connection.Open();

                int rowAffected = Command.ExecuteNonQuery();

                if (rowAffected > 0)
                {
                    Updated = true;
                }

            }
            catch (Exception ex)
            {
                StoreEventInEventLogs("Error Update Person : \n" + ex.Message, enEventType.Error);
                MessageBox.Show($"Error Update Person : \n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Connection.Close();
            }


            return Updated;
        }

        public static DataTable GetAllPepole()
        {
            DataTable PeopleInfo = new DataTable();

            string StoredProcedure = @"SP_GetAllPeople";
            
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand Command = new SqlCommand(StoredProcedure, Connection);
            Command.CommandType = CommandType.StoredProcedure;

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    PeopleInfo.Load(Reader);
                }

                Reader.Close();

            }
            catch (Exception ex)
            {
                StoreEventInEventLogs("Error GetAllPeople " + ex.Message, enEventType.Error);
                MessageBox.Show($"Error GetAllPeople : \n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Connection.Close();
            }


            return PeopleInfo;
        }

        public static DataTable GetAllPepoleWithDetailse()
        {
            DataTable PepoleInfo = new DataTable();

            string StoredProcedure = @"SP_CostumGetAllPeople";
            
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand Command = new SqlCommand(StoredProcedure, Connection);
            Command.CommandType = CommandType.StoredProcedure;

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    PepoleInfo.Load(Reader);
                }

                Reader.Close();

            }
            catch (Exception ex)
            {
                StoreEventInEventLogs("Error CostumGetAllPeople : \n" + ex.Message, enEventType.Error);
                MessageBox.Show($"Error CostumGetAllPeople : \n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Connection.Close();
            }


            return PepoleInfo;
        }


    }
}
