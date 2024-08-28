using Aula02.Models;

namespace Aula02.Repositories.Interfaces
{
    public interface IPessoaRepository
    {
        public IEnumerable<Pessoa> BuscarTodas();
        public Pessoa? BuscarPorId(int id);
        public int Adicionar(Pessoa pessoa);
        public int Alterar(Pessoa pessoa);
        public int Excluir(int id);
    }
}