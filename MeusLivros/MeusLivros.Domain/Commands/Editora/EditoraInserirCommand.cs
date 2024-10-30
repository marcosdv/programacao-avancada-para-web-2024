using MeusLivros.Domain.Commands.Interfaces;
using MeusLivros.Domain.Validations;

namespace MeusLivros.Domain.Commands.Editora
{
    public class EditoraInserirCommand : Notificavel, ICommand
    {
        public EditoraInserirCommand(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; set; }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Nome.Trim()))
            {
                AddNotificacao("O nome da editora é obrigátorio!");
            }
        }
    }
}
