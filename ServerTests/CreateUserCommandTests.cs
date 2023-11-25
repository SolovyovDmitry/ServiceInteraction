using Models.Requests;
using Moq;
using RabbitServer.Commands;
using RabbitServer.Validators;

namespace ServerTests
{
  public class CreateUserCommandTests
  {
    private Mock<ICreateUserValidator> _createUserValidatorMock;
    private CreateUserCommand _command;


    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
      _createUserValidatorMock = new Mock<ICreateUserValidator>();

      _createUserValidatorMock
        .Setup(x => x.Validate(It.IsAny<CreateUserRequest>()))
        .Returns(true);

      _createUserValidatorMock
        .Setup(x => x.Validate(null))
        .Returns(false);

      _command = new CreateUserCommand(_createUserValidatorMock.Object);
    }

    [SetUp]
    public void SetUp()
    {

    }

    [Test]
    public async Task CreateUserCommandReturnGuidWhenRequestIsOk()
    {
      var request = new CreateUserRequest { FullName = "Abram", Age = 50 };

      var actualResult = await _command.ExecuteAsync(request);

      Assert.IsInstanceOf(typeof(Guid), actualResult);
    }

    [Test]
    public async Task CreateUserCommandReturnNullWhenRequestIsNotOk()
    {
      CreateUserRequest request = null;

      var actualResult = await _command.ExecuteAsync(request);

      Assert.IsNull(actualResult);
    }
  }
}