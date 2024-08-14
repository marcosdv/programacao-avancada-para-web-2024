using Aula02.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Aula02.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OperadoraController : ControllerBase
{
    OperadoraRepository repository;

    public OperadoraController()
    {
        repository = new OperadoraRepository();
    }

    [HttpGet]
    public IActionResult BuscarTodas()
    {
        try
        {
            var lista = repository.BuscarTodas();
            if (lista.Any()) //if (lista.Count > 0)
            {
                return Ok(lista); //StatusCode(200, lista);
            }
            else
            {
                return NoContent(); //StatusCode(204);
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost]
    public IActionResult Adicionar(string nome)
    {
        try
        {
            return Ok(repository.Adicionar(nome));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}