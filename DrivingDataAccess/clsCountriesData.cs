using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static DrivingDataAccess.clsUtilSettings;
using System.Windows.Forms;

namespace DrivingDataAccess
{
    public class clsCountriesData
    {
        public static bool Find(int CountryID, ref string CountryName)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Countries
                             WHERE CountryID = @CountryID";

            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@CountryID", CountryID);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    CountryName = (string)Reader["CountryName"];

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

        public static DataTable GetAllCountries()
        {
            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT CountryName FROM Countries";

            SqlCommand Command = new SqlCommand(query, Connection);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dt.Load(Reader);
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

            return dt;
        }

        public static int GetCountryID(string countryName)
        {
            int CountryID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT CountryID FROM Countries
                             WHERE CountryName = @CountryName";

            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@CountryName", countryName);

            try
            {
                Connection.Open();

                object result = Command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int Countryid))
                {

                    CountryID = Countryid;

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


            return CountryID;
        }

    }
}
