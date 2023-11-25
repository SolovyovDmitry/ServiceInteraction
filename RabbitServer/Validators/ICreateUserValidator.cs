using Models.Requests;

namespace RabbitServer.Validators
{
  public interface ICreateUserValidator
  {
    bool Validate(CreateUserRequest request);
  }
}
