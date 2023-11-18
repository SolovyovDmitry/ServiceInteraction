using MassTransit;
using Models.Requests;
using RabbitServer.Commands;

namespace RabbitServer.Consumers
{
  public class CreateCompanyConsumer : IConsumer<CreateCompanyPublish>
  {
    private readonly ICreateCompanyCommand _command;
    private readonly ILogger<CreateCompanyConsumer> _logger;

    public CreateCompanyConsumer(
      ICreateCompanyCommand command,
      ILogger<CreateCompanyConsumer> logger)
    {
      _command = command;
      _logger = logger;
    }

    public Task Consume(ConsumeContext<CreateCompanyPublish> context)
    {
      _logger.LogInformation("Received publish from client");
      var companyId = _command.CreateCompany(context.Message);

      _logger.LogInformation($"Company with Id: {companyId} was created");

      return Task.CompletedTask;
    }
  }
}
