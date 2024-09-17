using Aula02.Models;
using Aula02.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aula02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelefoneController : ControllerBase
    {
        private readonly ITelefoneRepository _telefoneRepository;

        public TelefoneController(ITelefoneRepository telefoneRepository)
        {
            _telefoneRepository = telefoneRepository;
        }

        //[HttpGet]
        //public IActionResult BuscarTodos() => Ok(_telefoneRepository.BuscarTodos());

        [HttpGet]
        public IActionResult BuscarTodos()
        {
            var telefones = _telefoneRepository.BuscarTodos();
            return Ok(telefones);
        }

        [HttpPost]
        public IActionResult Adicionar(Telefone telefone)
        {
            var result = _telefoneRepository.Adicionar(telefone);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Alterar(Telefone telefone)
        {
            var result = _telefoneRepository.Alterar(telefone);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            var result = _telefoneRepository.Excluir(id);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            var result = _telefoneRepository.BuscarPorId(id);
            return Ok(result);
        }
    }
}