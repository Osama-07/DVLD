using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DrivingDataAccess.clsUtilSettings;
using System.Windows.Forms;

namespace DrivingDataAccess
{
    public class clsLicenseClassesData
    {
        public static bool Find(int LicenseClassID, ref string ClassName, ref string ClassDescription, ref byte MinimumAllowedAge,
                                    ref byte DefaultValidityLength, ref decimal ClassFees)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM LicenseClasses 
                             WHERE LicenseClassID = @LicenseClassID";

            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    ClassName = (string)Reader["ClassName"];
                    ClassDescription = (string)Reader["ClassDescription"];
                    MinimumAllowedAge = (byte)Reader["MinimumAllowedAge"];
                    DefaultValidityLength = (byte)Reader["DefaultValidityLength"];
                    ClassFees = (decimal)Reader["ClassFees"];

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

        public static DataTable GetAllLicenseClasses()
        {
            DataTable LicenseClasses = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM LicenseClasses";

            SqlCommand Command = new SqlCommand(query, Connection);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    LicenseClasses.Load(Reader);
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

            return LicenseClasses;
        }

        public static int GetLicenseClassID(string ClassName)
        {
            int LicenseClassID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT LicenseClassID FROM LicenseClasses
                             WHERE ClassName = @ClassName";

            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@ClassName", ClassName);

            try
            {
                Connection.Open();

                object result = Command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int LicenseClassid))
                {

                    LicenseClassID = LicenseClassid;

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


            return LicenseClassID;

        }

        public static bool IsHasLicenseClass(int PersonID, int LicenseClass)
        {
            bool IsHas = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT TOP 1 FOUND = 1 
                             FROM Licenses INNER JOIN 
						                    Drivers ON Drivers.PersonID = @PersonID
						                    INNER JOIN 
						                    LicenseClasses ON Licenses.LicenseClass = LicenseClasses.LicenseClassID
						    WHERE LicenseClass = @LicenseClass";

            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@DriverID", PersonID);
            Command.Parameters.AddWithValue("@LicenseClass", LicenseClass);

            try
            {
                Connection.Open();

                object result = Command.ExecuteScalar();

                if (result != null)
                {
                    IsHas = true;
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


            return IsHas;
        }
    }
}
