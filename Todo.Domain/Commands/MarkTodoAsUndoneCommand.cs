using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Shared.Commands.Interfaces;

namespace Todo.Domain.Commands;

public class MarkTodoAsUndoneCommand : Notifiable<Notification>, ICommand
{
    public MarkTodoAsUndoneCommand()
    {
    }

    public MarkTodoAsUndoneCommand(Guid id, string user)
    {
        Id = id;
        User = user;
    }

    public Guid Id { get; set; }

    public string User { get; set; }

    public void Validade()
    {
        AddNotifications(
            new Contract<MarkTodoAsDoneCommand>()
                .Requires()
                .IsGreaterThan(User, 6, "User", "Invalid User."));
    }
}

