using Aula01.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aula01.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CalculadoraController : ControllerBase
    {
        [HttpGet("Somar/{n1}/{n2}")]
        public float Somar(float n1, float n2)
        {
            return n1 + n2;
        }

        [HttpPost("Subtrair/{n1}/{n2}")]
        public float Subtrair(float n1, float n2)
        {
            return n1 - n2;
        }

        [HttpPut("Multiplicar")]
        public float Multiplicar(Valores valores)
        {
            return valores.N1 * valores.N2;
        }

        [HttpDelete("Dividir")]
        public IActionResult Dividir(Valores valores)
        {
            try
            {
                if (valores.N1 == 0 && valores.N2 == 0)
                {
                    return NoContent();
                }

                if (valores.N2 == 0)
                {
                    return BadRequest("N2 nao pode ser zero");
                }

                return Ok(valores.N1 / valores.N2);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, ex.Message);
            }
        }
    }
}
