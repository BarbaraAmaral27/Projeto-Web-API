using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepositoriesEntity.Configuration
{
    public static class Parameters
    {
        public static string getChaveConexao()
        {
            return System.Configuration.ConfigurationManager.AppSettings["chaveConexao"]; //professorestahdesacanagem
        }
    }
}