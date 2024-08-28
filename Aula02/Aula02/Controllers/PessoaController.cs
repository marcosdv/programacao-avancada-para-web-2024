using Aula02.Models;
using Aula02.Repositories;
using Aula02.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Aula02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaRepository pessoaRepository;

        public PessoaController(IPessoaRepository repository)
        {
            pessoaRepository = repository;
        }

        [HttpGet]
        public IActionResult BuscarTodas()
        {
            try
            {
                var lista = pessoaRepository.BuscarTodas();
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
    }
}
