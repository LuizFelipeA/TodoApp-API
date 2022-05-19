using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;
using Todo.Domain.Shared.Commands;

namespace Todo.Domain.Api.Controllers;

[ApiController]
[Route("todos")]
public class TodoController : ControllerBase
{
    private readonly TodoHandler _handler;

    private readonly ITodoRepository _repository;

    public TodoController(
        TodoHandler handler,
        ITodoRepository repository)
    {
        _handler = handler;
        _repository = repository;
    }

    [HttpGet]
    [Route("todos")]
    public IEnumerable<TodoItem> GetAll()
    {
        var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;

        return _repository.GetAll(user);
    }

    [HttpGet]
    [Route("done")]
    public IEnumerable<TodoItem> GetAllDone()
    {
        var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;

        return _repository.GetAllDone(user);
    }
        

    [HttpGet]
    [Route("undone")]
    public IEnumerable<TodoItem> GetAllUndone()
    {
        var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;

        return _repository.GetAllUndone(user);
    }
    

    [HttpGet]
    [Route("period")]
    public IEnumerable<TodoItem> GetByPeriod()
    {
        var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;

        return _repository.GetByPeriod(user, DateTime.Now.Date, true);
    }
    

    [HttpPost]
    [Route("create-todo")]
    public GenericCommandResult Create(
        [FromBody] CreateTodoCommand command)
    {
        command.User = "Luiz Felipe LP";

        return (GenericCommandResult)_handler.Handle(command);
    }
}

