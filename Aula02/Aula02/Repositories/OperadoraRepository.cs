using System.Data.SqlClient;

namespace Aula02.Repositories
{
    public class OperadoraRepository
    {
        SqlConnection conexao;

        public OperadoraRepository()
        {
            conexao = new SqlConnection(
                @"Server=LABORATORIO-01\SQLEXPRESS;
                  Database=AgendaFoneDb;
                  Trusted_Connection=True;"
            );
        }

        public IList<string> BuscarTodas()
        {
            try
            {
                conexao.Open();

                string sql = "SELECT * FROM TbOperadora";
                using SqlCommand command = new SqlCommand(sql, conexao);
                using SqlDataReader reader = command.ExecuteReader();
                var retorno = new List<string>();

                while (reader.Read())
                {
                    retorno.Add(reader["OpeNome"].ToString() ?? "");
                }

                return retorno;
            }
            finally
            {
                conexao.Close();
            }
        }

        public bool Adicionar(string nome)
        {
            try
            {
                conexao.Open();

                string sql = "INSERT INTO TbOperadora (OpeNome) VALUES (@OpeNome)";
                using SqlCommand command = new SqlCommand(sql, conexao);
                command.Parameters.AddWithValue("@OpeNome", nome);
                command.ExecuteNonQuery();

                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}