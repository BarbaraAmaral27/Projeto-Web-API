using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public static class Log
    {
        public static void gravar(Exception ex)
        {
            string nomeArquivoLog = DateTime.Now.ToString("yyyy-MM-dd");
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter($@"{Configuration.Parameters.getCaminhoArquivoLog()}\{nomeArquivoLog}.txt", true))
            {
                sw.WriteLine(mensagem(ex));
            }
        }

        private static string mensagem(Exception ex)
        {
            //boa prática.
            StringBuilder sb = new StringBuilder();
            sb.Append("----------------------------");
            sb.Append("Data:");
            sb.Append(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"));
            sb.Append("- Mensagem: ");
            sb.Append(ex.Message);
            sb.Append("StackTrace: ");
            sb.Append(ex.StackTrace);
            sb.Append("InnerException: ");
            sb.Append(ex.InnerException);
            sb.Append("------------------------------");

            return sb.ToString();

            //Cuidado com muitas concatenações.
            //string mensagem = "----------------------------";
            //mensagem += "Data:";
            //mensagem += DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            //mensagem += "- Mensagem: ";
            //mensagem += ex.Message;
            //mensagem += "StackTrace: ";
            //mensagem += ex.StackTrace;
            //mensagem += "InnerException: ";
            //mensagem += ex.InnerException;
            //mensagem += "------------------------------";
            //return mensagem;

            //boa prática.
            //return $"Data:{DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")} - Mensagem: {ex.Message} - StackTrace: {ex.StackTrace} - InnerException: {ex.InnerException}";
        }

        //sobrecarga criada para gravar logs diferentes de exceção.
        public static void gravar(string texto)
        {

        }
    }
}
