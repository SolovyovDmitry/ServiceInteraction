using MassTransit;
using Models.Requests;

namespace RabbitClient.Publishers
{
  public class Publish : IPublish
  {
    private readonly IBus _bus;
    private readonly ILogger<Publish> _logger;

    public Publish(
      IBus bus,
      ILogger<Publish> logger)
    {
      _bus = bus;
      _logger = logger;
    }

    public void CreateCompany(CreateCompanyPublish request)
    {
      _logger.LogInformation("Publishing CreateCompanyRequest...");

      _bus.Publish(request).ConfigureAwait(true);

      _logger.LogInformation("CreateCompanyRequest was published");

    }
  }
}
