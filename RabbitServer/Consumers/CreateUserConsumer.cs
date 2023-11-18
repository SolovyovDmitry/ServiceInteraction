using MassTransit;
using Models.Requests;
using Models.Responses;
using RabbitServer.Commands;

namespace RabbitServer.Consumers
{
  public class CreateUserConsumer : IConsumer<CreateUserRequest>
  {
    private readonly ICreateUserCommand _command;
    private readonly ILogger<CreateUserConsumer> _logger;

    public CreateUserConsumer(
      ICreateUserCommand command,
      ILogger<CreateUserConsumer> logger)
    {
      _command = command;
      _logger = logger;
    }

    public Task Consume(ConsumeContext<CreateUserRequest> context)
    {
      _logger.LogInformation("Received request from client in server");

      Guid? userId = _command.Execute(context.Message);

      CreateUserResponse response = new() { UserId = userId };

      context.Respond(response);

      _logger.LogInformation("Responded to client in server");

      // имитация асинхроного выполнения
      return Task.CompletedTask;
    }
  }
}
