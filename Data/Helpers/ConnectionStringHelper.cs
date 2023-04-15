using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Helpers
{
    internal class ConnectionStringHelper
    {
        public static string GetConnStringFromConfigFile()
        {
            return ConfigurationManager.ConnectionStrings["Todo"].ConnectionString;
        }
    }
}
