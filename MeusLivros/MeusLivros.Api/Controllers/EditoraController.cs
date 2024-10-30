using MeusLivros.Domain.Commands.Editora;
using MeusLivros.Domain.Commands.Interfaces;
using MeusLivros.Domain.Handlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeusLivros.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditoraController : ControllerBase
    {
        private readonly EditoraHandler _editoraHandler;

        public EditoraController(EditoraHandler editoraHandler)
        {
            _editoraHandler = editoraHandler;
        }

        [HttpPost]
        public ICommandResult Inserir(EditoraInserirCommand command)
        {
            var result = _editoraHandler.Execute(command);
            return result;
        }
    }
}
