﻿using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Tests.Repositories;

public class FakeTodoRepository : ITodoRepository
{
    public void Create(TodoItem todo)
    {
        
    }

    public TodoItem GetById(Guid id, string User)
    {
        return null;
    }

    public void Update(TodoItem todo)
    {
        
    }
}

