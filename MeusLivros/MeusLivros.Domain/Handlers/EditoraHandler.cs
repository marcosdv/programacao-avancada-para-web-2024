using MeusLivros.Domain.Commands;
using MeusLivros.Domain.Commands.Editora;
using MeusLivros.Domain.Commands.Interfaces;
using MeusLivros.Domain.Entities;
using MeusLivros.Domain.Handlers.Interfaces;
using MeusLivros.Domain.Repositories;

namespace MeusLivros.Domain.Handlers
{
    public class EditoraHandler : 
        IHandler<EditoraInserirCommand>,
        IHandler<EditoraAlterarCommand>,
        IHandler<EditoraExcluirCommand>
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

        public ICommandResult Execute(EditoraAlterarCommand command)
        {
            //Fail Fast Validation
            command.Validar();
            if (command.isInvalida)
            {
                return new CommandResult(false, "Dados incorretos", command.Notificacoes);
            }

            //cria a classe editora com os dados do Command
            var editora = _editoraRepository.BuscarPorId(command.Id);

            //senao existir, retorna erro
            if (editora == null)
            {
                return new CommandResult(false, "Editora não encontrada", command.Notificacoes);
            }

            editora.Nome = command.Nome;

            //salva no banco de dados
            _editoraRepository.Alterar(editora);

            //retorna sucesso na alteracao
            return new CommandResult(true, "Editora alterada", editora);
        }

        public ICommandResult Execute(EditoraExcluirCommand command)
        {
            //Fail Fast Validation
            command.Validar();
            if (command.isInvalida)
            {
                return new CommandResult(false, "Dados incorretos", command.Notificacoes);
            }

            //cria a classe editora com os dados do Command
            var editora = _editoraRepository.BuscarPorId(command.Id);

            //senao existir, retorna erro
            if (editora == null)
            {
                return new CommandResult(false, "Editora não encontrada", command.Notificacoes);
            }

            //salva no banco de dados
            _editoraRepository.Excluir(editora);

            //retorna sucesso na alteracao
            return new CommandResult(true, "Editora excluída", editora);
        }
    }
}