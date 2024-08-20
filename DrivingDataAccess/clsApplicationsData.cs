using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static DrivingDataAccess.clsUtilSettings;
using System.Windows.Forms;

namespace DrivingDataAccess
{
    public class clsApplicationsData
    {

        public static int AddNewApplication(int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID,
            byte ApplicationStatus, DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID)
        {
            int ApplicationID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Applications (ApplicantPersonID, ApplicationDate, ApplicationTypeID,
                               ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID)
                             VALUES
                             (@ApplicantPersonID, @ApplicationDate,@ApplicationTypeID, @ApplicationStatus,
                                @LastStatusDate, @PaidFees, @CreatedByUserID)
                            SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            Command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            Command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            Command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            Command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            Command.Parameters.AddWithValue("@PaidFees", PaidFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int applicationiD))
                {

                    ApplicationID = applicationiD;

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

            return ApplicationID;
        }

        public static bool Find(int ApplicationID, ref int ApplicantPersonID, ref DateTime ApplicationDate,
            ref int ApplicationTypeID, ref byte ApplicationStatus, ref DateTime LastStatusDate, ref decimal PaidFees,
            ref int CreatedByUserID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Applications
                             WHERE ApplicationID = @ApplicationID";

            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    ApplicationID = (int)Reader["ApplicationID"];
                    ApplicantPersonID = (int)Reader["ApplicantPersonID"];
                    ApplicationDate = (DateTime)Reader["ApplicationDate"];
                    ApplicationTypeID = (int)Reader["ApplicationTypeID"];
                    ApplicationStatus = (byte)Reader["ApplicationStatus"];
                    LastStatusDate = (DateTime)Reader["LastStatusDate"];
                    PaidFees = (decimal)Reader["PaidFees"];
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

        public static bool IsApplicationExist(int ApplicationID)
        {

            bool IsExist = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT ApplicationID FROM Applications
                             WHERE ApplicationID = @ApplicationID";

            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

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

        public static bool IsHasApplication(int PersonID, int LicenseClassID)
        {
            bool IsExist = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            
            // 0 = New, 1 = Compleate, 2 = Canceled.
            string query = @"SELECT DISTINCT FOUND = 1
                            FROM LicenseClasses INNER JOIN 
					            LocalDrivingLicenseApplications ON LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID
					            INNER JOIN 
					            Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID
					            INNER JOIN 
					            Pepole ON Applications.ApplicantPersonID = Pepole.PersonID
					            WHERE (Applications.ApplicationStatus = 1 OR Applications.ApplicationStatus = 3)
                                        AND Pepole.PersonID = @PersonID AND LicenseClasses.LicenseClassID = @LicenseClassID"; 

            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);


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

        public static bool UpdateApplication(int ApplicationID,  int ApplicantPersonID,  DateTime ApplicationDate,
             int ApplicationTypeID,  Byte ApplicationStatus,  DateTime LastStatusDate, decimal PaidFees,
             int CreatedByUserID)
        {
            bool Updated = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE Applications
                            SET ApplicantPersonID = @ApplicantPersonID,
                                  ApplicationDate = @ApplicationDate,
                                  ApplicationTypeID = @ApplicationTypeID,
                                  ApplicationStatus = @ApplicationStatus,
                                  LastStatusDate = @LastStatusDate,
                                  PaidFees = @PaidFees,
                                  CreatedByUserID = @CreatedByUserID
                            WHERE ApplicationID = @ApplicationID";

            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            Command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            Command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            Command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            Command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            Command.Parameters.AddWithValue("@PaidFees", PaidFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

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

        public static bool DeleteApplication(int ApplicationID)
        {
            bool Deleted = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"DELETE FROM Applications 
                            WHERE ApplicationID = @ApplicationID";

            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

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

        public static bool UpdateStatus(int ApplicationID, int NewStatus)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  Applications  
                            set 
                                ApplicationStatus = @NewStatus, 
                                LastStatusDate = @LastStatusDate
                            where ApplicationID=@ApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@NewStatus", NewStatus);
            command.Parameters.AddWithValue("LastStatusDate", DateTime.Now);


            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                clsUtilSettings.StoreEventInEventLogs(ex.Message, enEventType.Error);
                MessageBox.Show($"Error : {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static DataTable GetAllApplications()
        {
            DataTable ApplicationsInfo = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Applications";

            SqlCommand Command = new SqlCommand(query, Connection);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    ApplicationsInfo.Load(Reader);
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


            return ApplicationsInfo;
        }

        public static DataTable GetAllApplicationsWithDetailse()
        {
            DataTable ApplicationsInfo = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Applications.ApplicationID,
                Pepole.NationalNo, (Trim(Pepole.FirstName) + ' ' + Pepole.SecondName + ' ' + Pepole.ThirdName + ' ' + Pepole.LastName) AS [Full Name],
		                            ApplicationTypes.ApplicationTypeTitle,
		                            CASE 
		                            	WHEN Applications.ApplicationStatus = 1 THEN 'New'
		                            	WHEN Applications.ApplicationStatus = 2 THEN 'Canceled'
		                            	WHEN Applications.ApplicationStatus = 3 THEN 'Compleated'
		                            	ELSE 'NULL'
		                            END AS Status,
		                            Users.Username
                             FROM Applications INNER JOIN 
						                Pepole ON Applications.ApplicantPersonID = Pepole.PersonID
						                INNER JOIN
						                ApplicationTypes ON Applications.ApplicationTypeID = ApplicationTypes.ApplicationTypeID
						                INNER JOIN
						                Users ON Applications.CreatedByUserID = Users.UserID";

            SqlCommand Command = new SqlCommand(query, Connection);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    ApplicationsInfo.Load(Reader);
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


            return ApplicationsInfo;
        }

    }
}
