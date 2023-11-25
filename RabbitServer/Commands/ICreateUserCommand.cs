using Models.Requests;

namespace RabbitServer.Commands
{
  public interface ICreateUserCommand
  {
    Task<Guid?> ExecuteAsync(CreateUserRequest request);
  }
}
