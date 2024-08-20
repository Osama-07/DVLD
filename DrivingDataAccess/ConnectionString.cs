
using System.Configuration;

namespace DrivingDataAccess
{
    public static  class clsDataAccessSettings
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

    }
}
