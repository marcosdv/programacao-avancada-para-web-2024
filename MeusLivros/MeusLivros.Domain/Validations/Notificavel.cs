namespace MeusLivros.Domain.Validations
{
    public abstract class Notificavel
    {
        private readonly List<string> _notificacoes;

        public Notificavel()
        {
            _notificacoes = new List<string>();
        }

        public void AddNotificacao(string notificacao)
        {
            _notificacoes.Add(notificacao);
        }

        public IReadOnlyCollection<string> Notificacoes => _notificacoes;

        public bool isInvalida => _notificacoes.Any();

        public bool isValida => !isInvalida;
    }
}