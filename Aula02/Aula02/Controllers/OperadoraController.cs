using Aula02.Models;
using Aula02.Repositories;
using Microsoft.AspNetCore.Mvc;

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
    public IActionResult Adicionar([FromBody] Operadora operadora)
    {
        try
        {
            return Ok(repository.Adicionar(operadora));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut]
    public IActionResult Alterar(Operadora operadora)
    {
        try
        {
            var result = repository.Alterar(operadora);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete]
    public IActionResult Apagar(int codigo)
    {
        try
        {
            var result = repository.Apagar(codigo);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    
    [HttpGet("{codigo}")]
    public IActionResult BuscarPorId(int codigo)
    {
        try
        {
            var result = repository.BuscarPorId(codigo);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}