using MeusLivros.Domain.Commands.Editora;

namespace MeusLivros.Tests.Commands
{
    [TestClass]
    public class EditoraAlterarCommandTests
    {
        [TestMethod]
        public void DadoUmComandoInvalidoDeveRetornarInvalida()
        {
            var command = new EditoraAlterarCommand(0, "");

            command.Validar();

            Assert.IsTrue(command.isInvalida);
            Assert.IsTrue(command.Notificacoes.Any());
        }

        [TestMethod]
        public void DadoUmComandoValidoDeveRetornarValida()
        {
            var command = new EditoraAlterarCommand(1, "Nome");

            command.Validar();

            Assert.IsTrue(command.isValida);
        }
    }
}
