using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Shared.Commands;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests.Handlers;

[TestClass]
public class CreateTodoHandlerTests
{
    private readonly TodoHandler _todoHandler = new TodoHandler(new FakeTodoRepository());

    private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", "", DateTime.Now);

    private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Task Title", "Luiz Felipe LP LP", DateTime.Now);

    [TestMethod]
    [TestCategory("Handlers")]
    public void ShouldReturnFalseWhenCommandIsNotValid()
    {
        var result =  (GenericCommandResult)_todoHandler.Handle(_invalidCommand);

        Assert.AreEqual(false, result.Success);
    }

    [TestMethod]
    [TestCategory("Handlers")]
    public void ShouldReturnTrueAndCreateTodoWhenCommandIsValid()
    {
        var result = (GenericCommandResult)_todoHandler.Handle(_validCommand);

        Assert.AreEqual(true, result.Success);
    }
}