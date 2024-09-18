namespace Aula02.Models
{
    public class Pessoa
    {
        public int PesId { get; set; }
        public string PesNome { get; set; }
        public IList<Telefone> Telefones { get; private set; } = new List<Telefone>();

        public void AddTelefone(Telefone telefone)
        {
            Telefones.Add(telefone);
        }
    }
}