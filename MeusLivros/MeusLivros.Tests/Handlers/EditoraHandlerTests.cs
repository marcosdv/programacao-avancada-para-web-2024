using MeusLivros.Domain.Commands;
using MeusLivros.Domain.Commands.Editora;
using MeusLivros.Domain.Handlers;
using MeusLivros.Domain.Repositories;
using MeusLivros.Tests.Repositories;

namespace MeusLivros.Tests.Handlers
{
    [TestClass]
    public class EditoraHandlerTests
    {
        private readonly IEditoraRepository _repository;
        private readonly EditoraHandler _handler;
        public EditoraHandlerTests()
        {
            _repository = new MockEditoraRepository();
            _handler = new EditoraHandler(_repository);
        }

        #region Inserir

        [TestMethod]
        public void DadoUmComandoDeInserirValidoDeveRetornarSucessoTrue()
        {
            var command = new EditoraInserirCommand("Nome");

            var result = _handler.Execute(command);

            Assert.IsTrue((result as CommandResult).Sucesso);
        }

        [TestMethod]
        public void DadoUmComandoDeInserirInvalidoDeveRetornarSucessoFalse()
        {
            var command = new EditoraInserirCommand("");

            var result = _handler.Execute(command);

            Assert.IsFalse((result as CommandResult).Sucesso);
        }

        #endregion

        #region Alterar

        [TestMethod]
        public void DadoUmComandoDeAlterarValidoDeveRetornarSucessoTrue()
        {
            var command = new EditoraAlterarCommand(1, "Nome");

            var result = _handler.Execute(command);

            Assert.IsTrue((result as CommandResult).Sucesso);
        }

        [TestMethod]
        public void DadoUmComandoDeAlterarInvalidoDeveRetornarSucessoFalse()
        {
            var command = new EditoraAlterarCommand(0, "");

            var result = _handler.Execute(command);

            Assert.IsFalse((result as CommandResult).Sucesso);
        }

        [TestMethod]
        public void DadoUmComandoDeAlterarValidoMasComEditoraInexistenteDeveRetornarSucessoFalse()
        {
            var command = new EditoraAlterarCommand(9, "Nome");

            var result = _handler.Execute(command);

            Assert.IsFalse((result as CommandResult).Sucesso);
        }

        #endregion

        #region Excluir

        [TestMethod]
        public void DadoUmComandoDeExcluirValidoDeveRetornarSucessoTrue()
        {
            var command = new EditoraExcluirCommand(1);

            var result = _handler.Execute(command);

            Assert.IsTrue((result as CommandResult).Sucesso);
        }

        [TestMethod]
        public void DadoUmComandoDeExcluirInvalidoDeveRetornarSucessoFalse()
        {
            var command = new EditoraExcluirCommand(0);

            var result = _handler.Execute(command);

            Assert.IsFalse((result as CommandResult).Sucesso);
        }

        [TestMethod]
        public void DadoUmComandoDeExcluirValidoMasComEditoraInexistenteDeveRetornarSucessoFalse()
        {
            var command = new EditoraExcluirCommand(9);

            var result = _handler.Execute(command);

            Assert.IsFalse((result as CommandResult).Sucesso);
        }

        #endregion
    }
}