using DrivingBusinessLayer;
using System.Reflection;
using Util;

namespace DVL_Project.Users_Screens
{
    public class clsGlobal
    {
        private static string SourceName = Assembly.GetExecutingAssembly().GetName().Name;
        private static string Location = Assembly.GetExecutingAssembly().Location;
        private static string DestinationFolder = @"D:\DVLD Images\";

        public enum enTestType { VisionTest = 1, WritingTest = 2, StreetTest = 3 };

        public static enTestType TestType;

        public static clsUsers CurrentUser;

        public static clsUtil util = new clsUtil(SourceName, Location, DestinationFolder);

    }
}
