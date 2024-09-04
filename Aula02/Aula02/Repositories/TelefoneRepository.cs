using Aula02.Models;
using Aula02.Repositories.Interfaces;
using Dapper;
using System.Data.SqlClient;

namespace Aula02.Repositories
{
    public class TelefoneRepository : ITelefoneRepository
    {
        private readonly SqlConnection _connection;

        public TelefoneRepository(IConfiguration config)
        {
            var connectionString = config.GetConnectionString("conexao");
            _connection = new SqlConnection(connectionString);
        }

        public IEnumerable<Telefone> BuscarTodos()
        {
            return _connection.Query<Telefone>("SELECT * FROM TbTelefone");
        }

        public Telefone? BuscarPorId(int id)
        {
            string sql = "SELECT * FROM TbTelefone WHERE TelId = @id";
            var parametros = new { id };

            return _connection.QueryFirst<Telefone>(sql, parametros);
        }

        public int Adicionar(Telefone telefone)
        {
            var sql = "INSERT INTO TbTelefone (TelNumero, OpeId, PesId) " +
                      "VALUES (@TelNumero, @OpeId, @PesId)";
            var parametros = new
            {
                telefone.TelNumero,
                telefone.OpeId,
                telefone.PesId
            };

            return _connection.Execute(sql, parametros);
        }

        public int Alterar(Telefone telefone)
        {
            var sql = @"UPDATE TbTelefone SET
                            TelNumero = @TelNumero,
                            OpeId = @OpeId,
                            PesId = @PesId
                        WHERE TelId = @TelId ";

            var parametros = new
            {
                telefone.TelId,
                telefone.TelNumero,
                telefone.OpeId,
                telefone.PesId
            };

            return _connection.Execute(sql, parametros);
        }

        public int Excluir(int id)
        {
            var sql = "DELETE FROM TbTelefone WHERE TelId = @id";
            var parametros = new { id };

            return _connection.Execute(sql, parametros);
        }
    }
}