using Aula02.Models;
using System;
using System.Data;
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

        public IList<Operadora> BuscarTodas()
        {
            try
            {
                conexao.Open();

                string sql = "SELECT * FROM TbOperadora";
                using SqlCommand command = new SqlCommand(sql, conexao);
                using SqlDataReader reader = command.ExecuteReader();
                var retorno = new List<Operadora>();

                while (reader.Read())
                {
                    var operadora = new Operadora();
                    operadora.OpeId = reader.GetInt32("OpeId");
                    operadora.OpeNome = reader.GetString("OpeNome");
                    retorno.Add(operadora);
                }

                return retorno;
            }
            finally
            {
                conexao.Close();
            }
        }

        public bool Adicionar(Operadora operadora)
        {
            try
            {
                conexao.Open();

                string sql = "INSERT INTO TbOperadora (OpeNome) VALUES (@OpeNome)";
                using SqlCommand command = new SqlCommand(sql, conexao);
                command.Parameters.AddWithValue("@OpeNome", operadora.OpeNome);
                command.ExecuteNonQuery();

                return true;
            }
            finally
            {
                conexao.Close();
            }
        }

        public bool Alterar(Operadora operadora)
        {
            try
            {
                conexao.Open();

                string sql = @"
                    UPDATE TbOperadora SET
                        OpeNome = @OpeNome
                    WHERE OpeId = @OpeId";

                using var command = new SqlCommand(sql, conexao);
                command.Parameters.AddWithValue("@OpeNome", operadora.OpeNome);
                command.Parameters.AddWithValue("@OpeId", operadora.OpeId);

                command.ExecuteNonQuery();

                return true;
            }
            finally
            {
                conexao.Close();
            }
        }

        public bool Apagar(int codigo)
        {
            try
            {
                conexao.Open();

                string sql = "DELETE FROM TbOperadora WHERE OpeId = @OpeId";
                using var command = new SqlCommand(sql, conexao);
                command.Parameters.AddWithValue("@OpeId", codigo);

                command.ExecuteNonQuery();

                return true;
            }
            finally
            {
                conexao.Close();
            }
        }

        public Operadora? BuscarPorId(int codigo)
        {
            try
            {
                conexao.Open();

                string sql = "SELECT * FROM TbOperadora WHERE OpeId = @OpeId";
                using var command = new SqlCommand(sql, conexao);
                command.Parameters.AddWithValue("@OpeId", codigo);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var operadora = new Operadora {
                        OpeId = reader.GetInt32("OpeId"),
                        OpeNome = reader.GetString("OpeNome")
                    };

                    return operadora;
                }
                return null;
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}