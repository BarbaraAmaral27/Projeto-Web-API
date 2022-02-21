using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Repositories
{
    public static class Caderno
    {
        public static void save(Models.Caderno caderno)
        {           
            using (SqlConnection conexao = new SqlConnection(Configuration.Parameters.getConnectionString()))
            {
                conexao.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conexao;
                    cmd.CommandText = "insert into caderno (titulo, valor, nrfolhas) values (@titulo, @valor, @nrfolhas);";
                    cmd.Parameters.Add(new SqlParameter("@titulo", System.Data.SqlDbType.VarChar)).Value = caderno.Titulo;
                    cmd.Parameters.Add(new SqlParameter("@valor", System.Data.SqlDbType.Decimal)).Value = caderno.Valor;
                    cmd.Parameters.Add(new SqlParameter("@nrfolhas", System.Data.SqlDbType.Int)).Value = caderno.NrFolhas;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<Models.Caderno> getAll()
        {
            List<Models.Caderno> cadernos = new List<Models.Caderno>(); //nossa lista não pode ser estática.

            using (SqlConnection conexao = new SqlConnection(Configuration.Parameters.getConnectionString()))
            {
                conexao.Open(); //ponte com SGBD
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conexao; // coloquei o comando na ponte com o SGBD
                    cmd.CommandText = "select id, titulo, valor, nrfolhas from caderno;";
                    SqlDataReader dr = cmd.ExecuteReader(); //executei o comando no SGBD e armazenei os dados em memória (dr)
                    while (dr.Read()) //percorri as linhas do dr até atingir o EOF (EOF => Read() => false)
                    {
                        Models.Caderno caderno = new Models.Caderno();
                        caderno.Id = (int) dr["id"]; //obtem o valor id armazenado na linha e atribui ao Id do objeto.
                        caderno.Titulo = (string) dr["titulo"];
                        caderno.Valor = (decimal) dr["valor"];
                        caderno.NrFolhas = (int) dr["nrfolhas"];
                        cadernos.Add(caderno); //atribui o objeto na lista.
                    }
                }
            }
            return cadernos;
        }

        public static Models.Caderno getById(int id)
        {
            Models.Caderno caderno = new Models.Caderno();

            using (SqlConnection conexao = new SqlConnection(Configuration.Parameters.getConnectionString()))
            {
                conexao.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conexao; 
                    cmd.CommandText = "select id, titulo, valor, nrfolhas from caderno where id = @id;";
                    cmd.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int)).Value = id;
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read()) //(dr.HasRows) //while (dr.Read())
                    {
                        caderno.Id = (int)dr["id"];
                        caderno.Titulo = (string)dr["titulo"];
                        caderno.Valor = (decimal)dr["valor"];
                        caderno.NrFolhas = (int)dr["nrfolhas"];
                    }
                }
            }
            return caderno;
        }

        public static void update(Models.Caderno caderno)
        {
            using (SqlConnection conexao = new SqlConnection(Configuration.Parameters.getConnectionString()))
            {
                conexao.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conexao;
                    cmd.CommandText = "update caderno set titulo=@titulo,valor=@valor, nrfolhas=@nrfolhas where id=@id;";
                    cmd.Parameters.Add(new SqlParameter("@titulo", System.Data.SqlDbType.VarChar)).Value = caderno.Titulo;
                    cmd.Parameters.Add(new SqlParameter("@valor", System.Data.SqlDbType.Decimal)).Value = caderno.Valor;
                    cmd.Parameters.Add(new SqlParameter("@nrfolhas", System.Data.SqlDbType.Int)).Value = caderno.NrFolhas;
                    cmd.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int)).Value = caderno.Id;                    
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void deleteById(int id)
        {
            using (SqlConnection conexao = new SqlConnection(Configuration.Parameters.getConnectionString()))
            {
                conexao.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conexao;
                    cmd.CommandText = "delete from caderno where id = @id;";
                    cmd.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int)).Value = id;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}