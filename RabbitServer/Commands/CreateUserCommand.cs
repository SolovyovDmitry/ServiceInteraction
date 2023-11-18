using Models.Requests;

namespace RabbitServer.Commands
{
  public class CreateUserCommand : ICreateUserCommand
  {
    // следующий этап после контроллера
    public Guid? Execute(CreateUserRequest request)
    {
      // валидация

      // мапинг

      bool validationResult = Validate(request);

      if (!validationResult)
      {
        return null;
      }

      return Guid.NewGuid();
    }

    private bool Validate(CreateUserRequest request)
    {
      return false;
    }
  }
}
