using Aula02.Models;
using Aula02.Repositories;
using Aula02.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Aula02.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OperadoraController : ControllerBase
{
    private readonly IOperadoraRepository repository;
    private readonly IMemoryCache _memoryCache;

    public OperadoraController(IOperadoraRepository operadoraRepository,
        IMemoryCache memoryCache)
    {
        repository = operadoraRepository;
        _memoryCache = memoryCache;
    }

    [HttpGet]
    public IActionResult BuscarTodas()
    {
        try
        {
            var chaveCache = "operadoras";
            IList<Operadora> lista;

            if (_memoryCache.TryGetValue(chaveCache, out lista) == false)
            {
                lista = repository.BuscarTodas();

                var optionsCache = new MemoryCacheEntryOptions();
                optionsCache.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);

                _memoryCache.Set(chaveCache, lista, optionsCache);
            }

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