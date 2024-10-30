using MeusLivros.Domain.Commands.Interfaces;

namespace MeusLivros.Domain.Handlers.Interfaces
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Execute(T command);
    }
}