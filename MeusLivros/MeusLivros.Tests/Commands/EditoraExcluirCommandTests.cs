using MeusLivros.Domain.Commands.Editora;

namespace MeusLivros.Tests.Commands
{
    [TestClass]
    public class EditoraExcluirCommandTests
    {
        [TestMethod]
        public void DadoUmComandoInvalidoDeveRetornarInvalida()
        {
            var command = new EditoraExcluirCommand(0);

            command.Validar();

            Assert.IsTrue(command.isInvalida);
            Assert.IsTrue(command.Notificacoes.Any());
        }

        [TestMethod]
        public void DadoUmComandoValidoDeveRetornarValida()
        {
            var command = new EditoraExcluirCommand(1);

            command.Validar();

            Assert.IsTrue(command.isValida);
        }
    }
}
