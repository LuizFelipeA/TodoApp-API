﻿namespace Todo.Domain.Shared.Entities;

public class Entity : IEquatable<Entity>
{
    public Entity()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; }

    public bool Equals(Entity? other)
    {
        return Id == other?.Id;
    }
}
