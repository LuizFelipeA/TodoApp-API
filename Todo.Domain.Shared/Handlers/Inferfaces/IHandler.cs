using Todo.Domain.Shared.Commands.Interfaces;

namespace Todo.Domain.Shared.Handlers.Inferfaces;

public interface IHandler<T> where T : ICommand
{
    ICommandResult Handle(T command);
}

