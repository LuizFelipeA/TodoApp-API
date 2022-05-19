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
        => _repository.GetAll("Luiz Felipe LP LP");

    [HttpGet]
    [Route("done")]
    public IEnumerable<TodoItem> GetAllDone()
        => _repository.GetAllDone("Luiz Felipe LP LP");

    [HttpGet]
    [Route("undone")]
    public IEnumerable<TodoItem> GetAllUndone()
        => _repository.GetAllUndone("Luiz Felipe LP LP");

    [HttpGet]
    [Route("undone")]
    public IEnumerable<TodoItem> GetByPeriod() 
        => _repository.GetByPeriod("Luiz Felipe LP LP", DateTime.Now.Date, true);

    [HttpPost]
    [Route("create-todo")]
    public GenericCommandResult Create(
        [FromBody] CreateTodoCommand command)
    {
        command.User = "Luiz Felipe LP";

        return (GenericCommandResult)_handler.Handle(command);
    }
}

