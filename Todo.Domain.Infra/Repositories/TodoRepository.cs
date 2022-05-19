using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;
using Todo.Domain.Infra.Context;
using Todo.Domain.Queries;
using Todo.Domain.Repositories;

namespace Todo.Domain.Infra.Repositories;

public class TodoRepository : ITodoRepository
{
    private readonly TodoContext _context;

    public TodoRepository(TodoContext context)
    {
        _context = context;
    }

    public void Create(TodoItem todo)
    {
        _context.Todos.Add(todo);
        _context.SaveChanges();
    }

    public IEnumerable<TodoItem> GetAll(string user)
        => _context.Todos
            .AsNoTracking()
            .Where(TodoQueries.GetAll(user))
            .OrderBy(x => x.Date);

    public IEnumerable<TodoItem> GetAllDone(string user)
        => _context.Todos
            .AsNoTracking()
            .Where(TodoQueries.GetAllDone(user))
            .OrderBy(x => x.Date);

    public IEnumerable<TodoItem> GetAllUndone(string user)
        => _context.Todos
            .AsNoTracking()
            .Where(TodoQueries.GetAllUndone(user))
            .OrderBy(x => x.Date);

    public TodoItem GetById(Guid id, string User)
        => _context.Todos
            .AsNoTracking()
            .Where(TodoQueries.GetById(id, User))
            .OrderBy(x => x.Date).First();

    public IEnumerable<TodoItem> GetByPeriod(string user, DateTime date, bool done)
        => _context.Todos
            .AsNoTracking()
            .Where(TodoQueries.GetByPeriod(user, date, done))
            .OrderBy(x => x.Date);

    public void Update(TodoItem todo)
    {
        _context.Update(todo);
        _context.SaveChanges();
    }
}