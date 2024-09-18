using Aula02.Models;

namespace Aula02.Repositories.Interfaces
{
    public interface ITelefoneRepository
    {
        IEnumerable<Telefone> BuscarTodos();
        Telefone? BuscarPorId(int id);

        int Adicionar(Telefone telefone);
        int Alterar(Telefone telefone);
        int Excluir(int id);
    }
}