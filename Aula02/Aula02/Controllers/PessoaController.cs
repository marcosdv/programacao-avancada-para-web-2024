using Aula02.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Aula02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        PessoaRepository pessoaRepository;

        public PessoaController()
        {
            pessoaRepository = new PessoaRepository();
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
    }
}
