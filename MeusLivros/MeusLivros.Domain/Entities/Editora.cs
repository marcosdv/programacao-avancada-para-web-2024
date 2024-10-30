namespace MeusLivros.Domain.Entities
{
    public class Editora : Entity
    {
        #region | Propriedades |

        public string Nome { get; set; }
        public IList<Livro> Livros { get; set; }

        #endregion

        #region | Construtores |

        public Editora(string nome)
        {
            Nome = nome;
            Livros = new List<Livro>();
        }
        public Editora(int id, string nome)
        {
            Id = id;
            Nome = nome;
            Livros = new List<Livro>();
        }

        #endregion
    }
}