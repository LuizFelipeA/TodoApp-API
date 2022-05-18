using Todo.Domain.Shared.Entities;

namespace Todo.Domain.Entities;

public class TodoItem : Entity
{
    public TodoItem(
        string title,
        DateTime date,
        string user)
    {
        Title = title;
        Done = false;
        Date = date;
        User = user;
    }

    public string Title { get; private set; }

    public bool Done { get; private set; }

    public DateTime Date { get; }

    public string User { get; }

    public void MarkAsDone()
    {
        Done = false;
    }

    public void UpdateTitle(string title)
    {
        Title = title;
    }
}

