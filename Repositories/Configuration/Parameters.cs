using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repositories.Configuration
{
    public static class Parameters
    {
        public static string getConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["biblioteca"].ConnectionString;
        }
    }
}