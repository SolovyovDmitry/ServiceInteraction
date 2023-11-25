using Models.Requests;
using RabbitServer.Validators;

namespace RabbitServer.Commands
{
  public class CreateUserCommand : ICreateUserCommand
  {
    private readonly ICreateUserValidator _validator;

    public CreateUserCommand(ICreateUserValidator validator)
    {
      _validator = validator;
    }

    // следующий этап после контроллера
    public async Task<Guid?> ExecuteAsync(CreateUserRequest request)
    {
      // валидация

      // мапинг

      bool validationResult = _validator.Validate(request);

      if (!validationResult)
      {
        return null;
      }

      return Guid.NewGuid();
    }
  }
}
