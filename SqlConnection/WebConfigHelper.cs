using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace SqlConnection
{
    public class WebConfigHelper
    {
        private readonly static string DBConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        private readonly static string DBProviderName = ConfigurationManager.ConnectionStrings["ConnectionString"].ProviderName;
        public static string GetConnectionString
        {
            get { return DBConnectionString; }
        }
        public static string GetProviderName
        {
            get { return DBProviderName; }
        }
    }
}
