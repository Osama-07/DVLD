using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using static DrivingDataAccess.clsUtilSettings;
using System.Windows.Forms;

namespace DrivingDataAccess
{
    public class clsLicensesData
    {
        public static int AddNew(int ApplicationID, int DriverID, int LicenseClassID, DateTime IssueDate, DateTime ExpirationDate,
                                string Notes, decimal PaidFees, bool IsActive, byte IssueReason, int CreatedByUserID)
        {
            int LicenseID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Licenses (ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate,
                                                    Notes, PaidFees, IsActive, IssueReason, CreatedByUserID)
                             VALUES
                             (@ApplicationID, @DriverID, @LicenseClass, @IssueDate, @ExpirationDate,
                                                    @Notes, @PaidFees, @IsActive, @IssueReason, @CreatedByUserID)
                            SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("@DriverID", DriverID);
            Command.Parameters.AddWithValue("@LicenseClass", LicenseClassID);
            Command.Parameters.AddWithValue("@IssueDate", IssueDate);
            Command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            
            if (Notes == "")
            {
                Command.Parameters.AddWithValue("@Notes", DBNull.Value);
            }
            else
                Command.Parameters.AddWithValue("@Notes", Notes);

            Command.Parameters.AddWithValue("@PaidFees", PaidFees);
            Command.Parameters.AddWithValue("@IsActive", IsActive);
            Command.Parameters.AddWithValue("@IssueReason", IssueReason);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int LicenseiD))
                {

                    LicenseID = LicenseiD;

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

            return LicenseID;
        }

        public static bool Find(int LicenseID, ref int ApplicationID, ref int DriverID, ref int LicenseClassID, ref DateTime IssueDate,
                        ref DateTime ExpirationDate, ref string Notes, ref decimal PaidFees, ref bool IsActive, ref byte IssueReason,
                        ref int CreatedByUserID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Licenses
                             WHERE LicenseID = @LicenseID AND IsActive = 1";

            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    ApplicationID = (int)Reader["ApplicationID"];
                    DriverID = (int)Reader["DriverID"];
                    LicenseClassID = (int)Reader["LicenseClass"];
                    IssueDate = (DateTime)Reader["IssueDate"];
                    ExpirationDate = (DateTime)Reader["ExpirationDate"];
                    
                    if (Reader["Notes"] == DBNull.Value)
                    {
                        Notes = "No Notes";
                    }
                    else
                        Notes = (string)Reader["Notes"];

                    PaidFees = (decimal)Reader["PaidFees"];
                    IsActive = (bool)Reader["IsActive"];
                    IssueReason = (byte)Reader["IssueReason"];
                    CreatedByUserID = (int)Reader["CreatedByUserID"];

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

        public static bool FindLicenseByNationalNoAndClassName(string NationalNo, string ClassName, ref int LicenseID, ref int ApplicationID,
                            ref int DriverID, ref int LicenseClassID, ref DateTime IssueDate, ref DateTime ExpirationDate, ref string Notes,
                            ref decimal PaidFees, ref bool IsActive, ref byte IssueReason, ref int CreatedByUserID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Licenses.* 
                             FROM Licenses INNER JOIN
                                            Drivers ON Licenses.DriverID = Drivers.DriverID
                                            INNER JOIN 
                                            Pepole ON Drivers.PersonID = Pepole.PersonID
                                            INNER JOIN
                                            LicenseClasses ON LicenseClasses.LicenseClassID = Licenses.LicenseClass
                             WHERE NationalNo = @NationalNo AND ClassName = @ClassName";

            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@NationalNo", NationalNo);
            Command.Parameters.AddWithValue("@ClassName", ClassName);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    LicenseID = (int)Reader["LicenseID"];
                    ApplicationID = (int)Reader["ApplicationID"];
                    DriverID = (int)Reader["DriverID"];
                    LicenseClassID = (int)Reader["LicenseClass"];
                    IssueDate = (DateTime)Reader["IssueDate"];
                    ExpirationDate = (DateTime)Reader["ExpirationDate"];

                    if (Reader["Notes"] == DBNull.Value)
                    {
                        Notes = "No Notes";
                    }
                    else
                        Notes = (string)Reader["Notes"];

                    PaidFees = (decimal)Reader["PaidFees"];
                    IsActive = (bool)Reader["IsActive"];
                    IssueReason = (byte)Reader["IssueReason"];
                    CreatedByUserID = (int)Reader["CreatedByUserID"];

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

        public static bool IsExist(int LicenseID)
        {
            bool IsExist = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT FOUND = 1 FROM Licenses
                             WHERE LicenseID = @LicenseID";

            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@LicenseID", LicenseID);

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

        public static bool Update(int LicenseID, int ApplicationID, int DriverID, int LicenseClassID, DateTime IssueDate,
                        DateTime ExpirationDate, string Notes, decimal PaidFees, bool IsActive, byte IssueReason,
                        int CreatedByUserID)
        {
            bool Updated = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE Licenses
                            SET ApplicationID = @ApplicationID,
                                  DriverID = @DriverID,
                                  LicenseClass = @LicenseClassID,
                                  IssueDate = @IssueDate,
                                  ExpirationDate = @ExpirationDate,
                                  Notes = @Notes,
                                  PaidFees = @PaidFees,
                                  IsActive = @IsActive,
                                  IssueReason = @IssueReason,
                                  CreatedByUserID = @CreatedByUserID
                            WHERE LicenseID = @LicenseID";

            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("@DriverID", DriverID);
            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            Command.Parameters.AddWithValue("@IssueDate", IssueDate);
            Command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            
            if (Notes == "")
            {
                Command.Parameters.AddWithValue("@Notes", DBNull.Value);
            }
            else
                Command.Parameters.AddWithValue("@Notes", Notes);
            
            Command.Parameters.AddWithValue("@PaidFees", PaidFees);
            Command.Parameters.AddWithValue("@IsActive", IsActive);
            Command.Parameters.AddWithValue("@IssueReason", IssueReason);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            Command.Parameters.AddWithValue("@LicenseID", LicenseID);

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

        public static bool IsHasLicense(string NationalNo, int LicenseClassID)
        {
            bool IsExist = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT      FOUND = 1
                             FROM Licenses INNER JOIN
                                            Drivers ON Licenses.DriverID = Drivers.DriverID
                                            INNER JOIN
                                            Pepole ON Drivers.PersonID = Pepole.PersonID
						                    INNER JOIN 
						                    LicenseClasses ON Licenses.LicenseClass = LicenseClasses.LicenseClassID
						    WHERE Licenses.IsActive = 1 AND Pepole.NationalNo = @NationalNo AND LicenseClasses.LicenseClassID = @LicenseClassID";

            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
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
                clsUtilSettings.StoreEventInEventLogs(ex.Message, enEventType.Error);
                MessageBox.Show($"Error Licenses : {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Connection.Close();
            }


            return IsExist;
        }

        public static bool Delete(int LicenseID)
        {
            bool Deleted = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"DELETE FROM Licenses 
                            WHERE LicenseID = @LicenseID";

            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@LicenseID", LicenseID);

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

        public static DataTable GetAllLicenses()
        {
            DataTable LicensesInfo = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Licenses";

            SqlCommand Command = new SqlCommand(query, Connection);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    LicensesInfo.Load(Reader);
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


            return LicensesInfo;
        }

        public static DataTable GetAllLicensesByPersonID(int PersonID)
        {
            DataTable LicensesInfo = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Licenses.*
                            FROM Licenses INNER JOIN 
							              Drivers ON Licenses.DriverID = Drivers.DriverID
							              INNER JOIN 
							              Pepole ON Drivers.PersonID = Pepole.PersonID
					        WHERE Pepole.PersonID = @PersonID
                            ORDER BY LicenseID DESC";

            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    LicensesInfo.Load(Reader);
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


            return LicensesInfo;
        }

        public static DataTable GetDriverLicenseInfo(string NationalNo, string ClassName)
        {
            DataTable LicensesInfo = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM DriverLicenseInfo
                            WHERE IsActive = 'Yes' AND NationalNo = @NationalNo AND ClassName = @ClassName";

            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@NationalNo", NationalNo);
            Command.Parameters.AddWithValue("@ClassName", ClassName);


            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    LicensesInfo.Load(Reader);
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


            return LicensesInfo;
        }

    }
}
