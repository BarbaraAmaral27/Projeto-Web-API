using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Utils.Configuration
{
    public static class Parameters
    {
        public static string getCaminhoArquivoLog()
        {
            return System.Configuration.ConfigurationManager.AppSettings["caminhoArquivoLog"];
        }
    }
}