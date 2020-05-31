using System.Configuration;

namespace TestDou.Ua
{
    static class ConfigurationAccessor
    {
        public static string HomePageUrl => ConfigurationSettings.AppSettings["HomePageUrl"];

        public static string JobPageUrl => ConfigurationSettings.AppSettings["JobPageUrl"];

        public static string CalendarPageUrl => ConfigurationSettings.AppSettings["CalendarPageUrl"];

        public static string JobPageTitle => ConfigurationSettings.AppSettings["JobPageTitle"];
    }
}
