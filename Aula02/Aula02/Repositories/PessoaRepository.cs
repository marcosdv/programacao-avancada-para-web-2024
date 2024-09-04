using Aula02.Models;
using Aula02.Repositories.Interfaces;
using Dapper;
using System.Data.SqlClient;

namespace Aula02.Repositories
{
    //Dapper
    public class PessoaRepository : IPessoaRepository
    {
        SqlConnection conexao;

        public PessoaRepository(IConfiguration config)
        {
            var connectionString = config.GetConnectionString("conexao");
            conexao = new SqlConnection(connectionString);
        }

        public IEnumerable<Pessoa> BuscarTodas()
        {
            return conexao.Query<Pessoa>("SELECT * FROM TbPessoa");
        }

        public Pessoa? BuscarPorId(int id)
        {
            var sql = "SELECT * FROM TbPessoa WHERE PesId = @PesId";
            var parametros = new { PesId = id };

            //return conexao.Query<Pessoa>(sql, parametros).FirstOrDefault();
            return conexao.QueryFirstOrDefault<Pessoa>(sql, parametros);
        }

        public int Adicionar(Pessoa pessoa)
        {
            var sql = "INSERT INTO TbPessoa (PesNome) VALUES (@PesNome)";
            var parametros = new { pessoa.PesNome };

            return conexao.Execute(sql, parametros);
        }

        public int Alterar(Pessoa pessoa)
        {
            var sql = "UPDATE TbPessoa SET PesNome = @PesNome WHERE PesId = @PesId";
            var parametros = new { pessoa.PesNome, pessoa.PesId };

            return conexao.Execute(sql, parametros);
        }

        public int Excluir(int id)
        {
            var sql = "DELETE FROM TbPessoa WHERE PesId = @id";
            var parametros = new { id };

            return conexao.Execute(sql, parametros);
        }
    }
}