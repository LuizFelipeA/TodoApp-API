using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.Queries;

[TestClass]
public class TodoQueriesTests
{
    private List<TodoItem> _items;

    public TodoQueriesTests()
    {
        _items = new List<TodoItem>();
        _items.Add(new TodoItem("Task 1", DateTime.Now, "user A"));
        _items.Add(new TodoItem("Task 2", DateTime.Now, "user B"));
        _items.Add(new TodoItem("Task 3", DateTime.Now, "user A"));
        _items.Add(new TodoItem("Task 4", DateTime.Now, "user D"));
        _items.Add(new TodoItem("Task 5", DateTime.Now, "user E"));
    }

    [TestMethod]
    [TestCategory("Queries")]
    public void ShouldReturnOnly()
    {
        var result = _items.AsQueryable().Where(TodoQueries.GetAll("user A"));
        Assert.AreEqual(2, result.Count());
    }
}

