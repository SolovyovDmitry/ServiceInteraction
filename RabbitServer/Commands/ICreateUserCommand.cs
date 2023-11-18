using Models.Requests;

namespace RabbitServer.Commands
{
  public interface ICreateUserCommand
  {
    Guid? Execute(CreateUserRequest request);
  }
}
