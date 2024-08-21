using Aula02.Models;
using Dapper;
using System.Data.SqlClient;

namespace Aula02.Repositories
{
    public class PessoaRepository
    {
        SqlConnection conexao;

        public PessoaRepository()
        {
            conexao = new SqlConnection(
                @"Server=LABORATORIO-01\SQLEXPRESS;
                  Database=AgendaFoneDb;
                  Trusted_Connection=True;"
            );
        }

        public IEnumerable<Pessoa> BuscarTodas()
        {
            return conexao.Query<Pessoa>("SELECT * FROM TbPessoa");
        }
    }
}