using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Shared.Commands.Interfaces;

namespace Todo.Domain.Commands;

public class CreateTodoCommand : Notifiable<Notification>, ICommand
{
    public CreateTodoCommand() { }

    public CreateTodoCommand(string title, string user, DateTime date)
    {
        Title = title;
        User = user;
        Date = date;
    }

    public string Title { get; set; }

    public string User { get; set; }

    public DateTime Date { get; set; }

    public void Validade()
    {
        // Design by contracts
        AddNotifications(new Contract<CreateTodoCommand>()
            .Requires()
            .IsGreaterThan(Title, 3, "Title", "Please, describe your task.")
            .IsGreaterThan(User, 6, "User", "Invalid User."));
    }
}

