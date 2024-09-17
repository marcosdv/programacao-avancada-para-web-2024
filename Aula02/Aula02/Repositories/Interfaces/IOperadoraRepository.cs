using Aula02.Models;

namespace Aula02.Repositories.Interfaces
{
    public interface IOperadoraRepository
    {
        public IList<Operadora> BuscarTodas();
        public Operadora? BuscarPorId(int codigo);

        public bool Adicionar(Operadora operadora);
        public bool Alterar(Operadora operadora);
        public bool Apagar(int codigo);
    }
}