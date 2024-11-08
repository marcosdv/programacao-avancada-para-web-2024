using MeusLivros.Domain.Commands.Editora;
using MeusLivros.Domain.Commands.Interfaces;
using MeusLivros.Domain.Handlers;
using MeusLivros.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MeusLivros.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditoraController : ControllerBase
    {
        private readonly EditoraHandler _editoraHandler;
        private readonly IEditoraRepository _repository;

        public EditoraController(EditoraHandler editoraHandler, IEditoraRepository repository)
        {
            _editoraHandler = editoraHandler;
            _repository = repository;
        }

        [HttpPost]
        public ICommandResult Inserir(EditoraInserirCommand command)
        {
            var result = _editoraHandler.Execute(command);
            return result;
        }

        [HttpPut]
        public ICommandResult Alterar(EditoraAlterarCommand command)
        {
            var result = _editoraHandler.Execute(command);
            return result;
        }

        [HttpDelete]
        public ICommandResult Excluir(EditoraExcluirCommand command)
        {
            var result = _editoraHandler.Execute(command);
            return result;
        }

        [HttpGet]
        public IActionResult BuscarTodas()
        {
            var result = _repository.BuscarTodos();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            var result = _repository.BuscarPorId(id);
            return Ok(result);
        }
    }
}
