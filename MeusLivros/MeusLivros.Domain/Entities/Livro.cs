namespace MeusLivros.Domain.Entities
{
    public class Livro : Entity
    {
        #region | Propriedades |
        public string Nome { get; set; }
        public DateTime Lancamento { get; set; }
        public int EditoraId { get; set; }
        public Editora Editora { get; set; }
        #endregion

        #region | Contrutores |

        public Livro(string nome, DateTime lancamento, int editoraId)
        {
            Nome = nome;
            Lancamento = lancamento;
            EditoraId = editoraId;
        }

        public Livro(int id, string nome, DateTime lancamento, int editoraId)
        {
            Id = id;
            Nome = nome;
            Lancamento = lancamento;
            EditoraId = editoraId;
        }

        #endregion
    }
}
