using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;
using Todo.Domain.Shared.Commands;
using Todo.Domain.Shared.Commands.Interfaces;
using Todo.Domain.Shared.Handlers.Inferfaces;

namespace Todo.Domain.Handlers;

public class TodoHandler :
        Notifiable<Notification>,
        IHandler<CreateTodoCommand>
{
    private readonly ITodoRepository _todoRepository;

    public TodoHandler(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public ICommandResult Handle(CreateTodoCommand command)
    {
        // Fail fast validation
        command.Validade();
        if (!command.IsValid)
            return new GenericCommandResult(
                false,
                "Ops, looks like your task is incorrect!",
                command.Notifications);

        var todoItem = new TodoItem(
            title: command.Title,
            date: command.Date,
            user: command.User);

        _todoRepository.Create(todoItem);

        return new GenericCommandResult(
            success: true,
            message: "Task saved!",
            data: todoItem);

    }
}

