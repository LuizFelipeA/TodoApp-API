using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Shared.Commands.Interfaces;

namespace Todo.Domain.Commands;

public class UpdateTodoCommand : Notifiable<Notification>, ICommand
{
    public UpdateTodoCommand() { }

    public UpdateTodoCommand(Guid id, string title, string user)
    {
        Id = id;
        Title = title;
        User = user;
    }

    public Guid Id { get; set; }

    public string Title { get; set; }

    public string User { get; set; }

    public void Validade()
    {
        AddNotifications(
            new Contract<UpdateTodoCommand>()
            .Requires()
            .IsGreaterThan(Title, 3, "Title", "Please, describe your task.")
            .IsGreaterThan(User, 6, "User", "Invalid user."));
    }
}

