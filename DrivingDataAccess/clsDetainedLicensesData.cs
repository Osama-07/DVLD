using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using static DrivingDataAccess.clsUtilSettings;
using System.Windows.Forms;

namespace DrivingDataAccess
{
    public class clsDetainedLicensesData
    {
        public static int AddNew(int LicenseID, DateTime DetainDate, decimal FineFees, int CreatedByUserID, bool IsReleased,
                                DateTime ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID)
        {
            int DetainID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO DetainedLicenses (LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased,
                                                            ReleaseDate, ReleasedByUserID, ReleaseApplicationID)
                             VALUES
                             (@LicenseID, @DetainDate, @FineFees, @CreatedByUserID, @IsReleased,
                               @ReleaseDate, @ReleasedByUserID, @ReleaseApplicationID)
                            SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@LicenseID", LicenseID);
            Command.Parameters.AddWithValue("@DetainDate", DetainDate);
            Command.Parameters.AddWithValue("@FineFees", FineFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("@IsReleased", IsReleased);
            
            if (ReleaseDate != DateTime.MinValue)
            {
                Command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
            }
            else
                Command.Parameters.AddWithValue("@ReleaseDate", DBNull.Value);

            if (ReleasedByUserID > 0)
            {
                Command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
            }
            else
                Command.Parameters.AddWithValue("@ReleasedByUserID", DBNull.Value);

            if (ReleaseApplicationID > 0)
            {
                Command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);
            }
            else
                Command.Parameters.AddWithValue("@ReleaseApplicationID", DBNull.Value);


            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int DetainiD))
                {

                    DetainID = DetainiD;

                }


            }
            catch (Exception ex)
            {
                clsUtilSettings.StoreEventInEventLogs(ex.Message, enEventType.Error);
                MessageBox.Show($"Error : {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Connection.Close();
            }

            return DetainID;
        }

        public static bool Find(int DetainID, ref int LicenseID, ref DateTime DetainDate, ref decimal FineFees, ref int CreatedByUserID,
                            ref bool IsReleased, ref DateTime ReleaseDate, ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM DetainedLicenses
                             WHERE DetainID = @DetainID";

            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@DetainID", DetainID);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    LicenseID = (int)Reader["LicenseID"];
                    DetainDate = (DateTime)Reader["DetainDate"];
                    FineFees = (decimal)Reader["FineFees"];
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                    IsReleased = (bool)Reader["IsReleased"];

                    if (Reader["ReleaseDate"] != DBNull.Value)
                    {
                        ReleaseDate = (DateTime)Reader["ReleaseDate"];
                    }
                    else
                        ReleaseDate = DateTime.MinValue;

                    if (Reader["ReleasedByUserID"] != DBNull.Value)
                    {
                        ReleasedByUserID = (int)Reader["ReleasedByUserID"];
                    }
                    else
                        ReleasedByUserID = -1;

                    if (Reader["ReleaseApplicationID"] != DBNull.Value)
                    {
                        ReleaseApplicationID = (int)Reader["ReleaseApplicationID"];
                    }
                    else
                        ReleaseApplicationID = -1;

                    IsFound = true;
                }

                Reader.Close();

            }
            catch (Exception ex)
            {
                clsUtilSettings.StoreEventInEventLogs(ex.Message, enEventType.Error);
                MessageBox.Show($"Error : {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Connection.Close();
            }


            return IsFound;
        }
        
        public static bool GetLicenseDetained(ref int DetainID, int LicenseID, ref DateTime DetainDate, ref decimal FineFees, ref int CreatedByUserID,
                            ref bool IsReleased, ref DateTime ReleaseDate, ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM DetainedLicenses
                             WHERE LicenseID = @LicenseID AND IsReleased = 0";

            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    DetainID = (int)Reader["DetainID"];
                    DetainDate = (DateTime)Reader["DetainDate"];
                    FineFees = (decimal)Reader["FineFees"];
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                    IsReleased = (bool)Reader["IsReleased"];

                    if (Reader["ReleaseDate"] != DBNull.Value)
                    {
                        ReleaseDate = (DateTime)Reader["ReleaseDate"];
                    }
                    else
                        ReleaseDate = DateTime.MinValue;

                    if (Reader["ReleasedByUserID"] != DBNull.Value)
                    {
                        ReleasedByUserID = (int)Reader["ReleasedByUserID"];
                    }
                    else
                        ReleasedByUserID = -1;

                    if (Reader["ReleaseApplicationID"] != DBNull.Value)
                    {
                        ReleaseApplicationID = (int)Reader["ReleaseApplicationID"];
                    }
                    else
                        ReleaseApplicationID = -1;


                    IsFound = true;
                }

                Reader.Close();

            }
            catch (Exception ex)
            {
                clsUtilSettings.StoreEventInEventLogs(ex.Message, enEventType.Error);
                MessageBox.Show($"Error : {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Connection.Close();
            }


            return IsFound;
        }

        public static bool IsExist(int DetainID)
        {
            bool IsExist = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT FOUND = 1 FROM DetainedLicenses
                             WHERE DetainID = @DetainID";

            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@DetainID", DetainID);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                IsExist = Reader.HasRows;
                Reader.Close();

            }
            catch (Exception ex)
            {
                clsUtilSettings.StoreEventInEventLogs(ex.Message, enEventType.Error);
                MessageBox.Show($"Error : {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Connection.Close();
            }


            return IsExist;
        }

        public static bool Update(int DetainID, int LicenseID, DateTime DetainDate, decimal FineFees, int CreatedByUserID,
                                bool IsReleased, DateTime ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID)
        {
            bool Updated = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE DetainedLicenses
                            SET LicenseID = @LicenseID,
                                  DetainDate = @DetainDate,
                                  FineFees = @FineFees,
                                  CreatedByUserID = @CreatedByUserID,
                                  IsReleased = @IsReleased,
                                  ReleaseDate = @ReleaseDate,
                                  ReleasedByUserID = @ReleasedByUserID,
                                  ReleaseApplicationID = @ReleaseApplicationID
                            WHERE DetainID = @DetainID";

            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@LicenseID", LicenseID);
            Command.Parameters.AddWithValue("@DetainDate", DetainDate);
            Command.Parameters.AddWithValue("@FineFees", FineFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("@IsReleased", IsReleased);
            
            if (ReleaseDate != DateTime.MinValue)
            {
                Command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
            }
            else
                Command.Parameters.AddWithValue("@ReleaseDate", DBNull.Value);

            if (ReleasedByUserID > 0)
            {
                Command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
            }
            else
                Command.Parameters.AddWithValue("@ReleasedByUserID", DBNull.Value);

            if (ReleaseApplicationID > 0)
            {
                Command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);
            }
            else
                Command.Parameters.AddWithValue("@ReleaseApplicationID", DBNull.Value);


            Command.Parameters.AddWithValue("@DetainID", DetainID);

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
                clsUtilSettings.StoreEventInEventLogs(ex.Message, enEventType.Error);
                MessageBox.Show($"Error : {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Connection.Close();
            }


            return Updated;
        }

        public static bool Delete(int DetainID)
        {
            bool Deleted = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"DELETE FROM DetainedLicenses 
                            WHERE DetainID = @DetainID";

            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@DetainID", DetainID);

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
                clsUtilSettings.StoreEventInEventLogs(ex.Message, enEventType.Error);
                MessageBox.Show($"Error : {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Connection.Close();
            }

            return Deleted;
        }

        public static bool IsDetained(int LicenseID)
        {
            bool IsDetained = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT FOUND = 1 
                             FROM DetainedLicenses INNER JOIN 
                                                Licenses ON DetainedLicenses.LicenseID = Licenses.LicenseID
                                                INNER JOIN
                                                LicenseClasses ON Licenses.LicenseClass = LicenseClasses.LicenseClassID
                   WHERE (DetainedLicenses.LicenseID = @LicenseID) AND (DetainedLicenses.IsReleased = 0)";

            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                IsDetained = Reader.HasRows;
                Reader.Close();

            }
            catch (Exception ex)
            {
                clsUtilSettings.StoreEventInEventLogs(ex.Message, enEventType.Error);
                MessageBox.Show($"Error : {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Connection.Close();
            }


            return IsDetained;
        }

        public static DataTable GetAllDetainedLicenses()
        {
            DataTable DetainesInfo = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM DetainedLicenses";

            SqlCommand Command = new SqlCommand(query, Connection);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    DetainesInfo.Load(Reader);
                }

                Reader.Close();

            }
            catch (Exception ex)
            {
                clsUtilSettings.StoreEventInEventLogs(ex.Message, enEventType.Error);
                MessageBox.Show($"Error : {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Connection.Close();
            }


            return DetainesInfo;
        }

        public static DataTable GetAllDetainedLicensesWithDetailse()
        {
            DataTable DetainesInfo = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT DetainedLicenses.DetainID, DetainedLicenses.LicenseID, Pepole.NationalNo, 
            (Trim(Pepole.FirstName) + ' ' + Pepole.SecondName + ' ' + Pepole.ThirdName + ' ' + Pepole.LastName) AS FullName,
            Users.Username,
            CASE
                WHEN DetainedLicenses.IsReleased = 0 THEN 'No'
                WHEN DetainedLicenses.IsReleased = 1 THEN 'Yes'
            END AS IsReleased
            FROM DetainedLicenses INNER JOIN 
                                    Licenses ON DetainedLicenses.LicenseID = Licenses.LicenseID
                                  INNER JOIN
                                    Drivers ON Licenses.DriverID = Drivers.DriverID
                                  INNER JOIN 
                                    Pepole ON Drivers.PersonID = Pepole.PersonID
                                  INNER JOIN 
                                    Users ON DetainedLicenses.CreatedByUserID = Users.UserID";

            SqlCommand Command = new SqlCommand(query, Connection);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    DetainesInfo.Load(Reader);
                }

                Reader.Close();

            }
            catch (Exception ex)
            {
                clsUtilSettings.StoreEventInEventLogs(ex.Message, enEventType.Error);
                MessageBox.Show($"Error : {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Connection.Close();
            }


            return DetainesInfo;
        }

    }
}
