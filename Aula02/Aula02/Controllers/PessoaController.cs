using Aula02.Models;
using Aula02.Repositories;
using Aula02.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Aula02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaRepository pessoaRepository;
        private readonly IMemoryCache _memoryCache;

        public PessoaController(IPessoaRepository repository, IMemoryCache memoryCache)
        {
            pessoaRepository = repository;
            _memoryCache = memoryCache;
        }

        [HttpGet]
        public IActionResult BuscarTodas()
        {
            try
            {
                string chaveCache = "pessoas";
                IList<Pessoa> lista;

                if (_memoryCache.TryGetValue(chaveCache, out lista) == false)
                {
                    lista = pessoaRepository.BuscarTodas().ToList();

                    var optionsCache = new MemoryCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2)
                    };

                    _memoryCache.Set(chaveCache, lista, optionsCache);
                }

                return Ok(lista);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                var result = pessoaRepository.BuscarPorId(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Adicionar(Pessoa pessoa)
        {
            try
            {
                var result = pessoaRepository.Adicionar(pessoa);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Alterar(Pessoa pessoa)
        {
            try
            {
                var result = pessoaRepository.Alterar(pessoa);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Excluir(int id)
        {
            try
            {
                var result = pessoaRepository.Excluir(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("fone")]
        public IActionResult BuscarComFone()
        {
            var result = pessoaRepository.BuscarComFone();
            
            return Ok(result);
        }
    }
}
