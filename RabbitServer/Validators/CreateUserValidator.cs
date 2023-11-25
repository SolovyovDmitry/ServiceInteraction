using Models.Requests;

namespace RabbitServer.Validators
{
  public class CreateUserValidator : ICreateUserValidator
  {
    public bool Validate(CreateUserRequest request)
    {
      return true;
    }
  }
}
