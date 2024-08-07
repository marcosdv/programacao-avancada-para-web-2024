using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Aula02.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OperadoraController : ControllerBase
{
    SqlConnection conexao;

    public OperadoraController()
    {
        conexao = new SqlConnection(
@"Server=WINMACDELL-PRFO\SQLEXPRESS;
Database=AgendaFoneDb;
Trusted_Connection=True;"
        );

        conexao.Open();
    }

    [HttpGet]
    public IList<string> BuscarTodas()
    {
        string sql = "SELECT * FROM TbOperadora";
        var command = new SqlCommand(sql, conexao);

        SqlDataReader reader = command.ExecuteReader();

        var retorno = new List<string>();

        while (reader.Read())
        {
            //string nome = reader.GetString(1);
            string nome = reader["OpeNome"].ToString() ?? "";
            
            retorno.Add(nome);
        }

        return retorno;
    }
}