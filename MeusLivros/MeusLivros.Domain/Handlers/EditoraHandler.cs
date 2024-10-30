using MeusLivros.Domain.Commands;
using MeusLivros.Domain.Commands.Editora;
using MeusLivros.Domain.Commands.Interfaces;
using MeusLivros.Domain.Entities;
using MeusLivros.Domain.Handlers.Interfaces;
using MeusLivros.Domain.Repositories;

namespace MeusLivros.Domain.Handlers
{
    public class EditoraHandler : IHandler<EditoraInserirCommand>
    {
        private readonly IEditoraRepository _editoraRepository;

        public EditoraHandler(IEditoraRepository editoraRepository)
        {
            _editoraRepository = editoraRepository;
        }

        public ICommandResult Execute(EditoraInserirCommand command)
        {
            //Fail Fast Validation
            command.Validar();
            if (command.isInvalida)
            {
                return new CommandResult(false, "Dados incorretos", command.Notificacoes);
            }

            //cria a classe editora com os dados do Command
            var editora = new Editora(command.Nome);

            //salva no banco de dados
            _editoraRepository.Inserir(editora);

            //retorna sucesso na inclsao
            return new CommandResult(true, "Editora inserida", editora);
        }
    }
}