using Todo.Domain.Entities;

namespace Todo.Domain.Tests.Entities;

[TestClass]
public class TodoItemTests
{
    private readonly TodoItem _todoItem = new TodoItem("Title here", DateTime.Now, "Luiz Felipe LP LP");

    [TestMethod]
    [TestCategory("Entities")]
    public void ShouldReturnFalseWhenNewTodoIsConcluded()
        => Assert.AreEqual(false, _todoItem.Done);
}

