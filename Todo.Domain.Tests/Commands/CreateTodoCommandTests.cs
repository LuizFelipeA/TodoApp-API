using Todo.Domain.Commands;

namespace Todo.Domain.Tests.Commands;

[TestClass]
public class CreateTodoCommandTests
{
    private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", "", DateTime.Now);

    private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Task Title", "Luiz Felipe LP LP", DateTime.Now);

    public CreateTodoCommandTests()
    {
        _invalidCommand.Validade();
        _validCommand.Validade();
    }

    [TestMethod]
    [TestCategory("Commands")]
    public void ReturnFalseWhenCommandIsNotValid()
        => Assert.AreEqual(false, _invalidCommand.IsValid);

    [TestMethod]
    [TestCategory("Commands")]
    public void ReturnTrueWhenCommandIsValid()
        => Assert.AreEqual(true, _validCommand.IsValid);
}

