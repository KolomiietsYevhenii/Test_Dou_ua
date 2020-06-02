using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRabotaUa
{
    static class ConfigurationAccessor
    {
        public static string HomePageUrl => ConfigurationSettings.AppSettings["HomePageUrl"];
    }
}
