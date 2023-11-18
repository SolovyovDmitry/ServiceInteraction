using MassTransit;
using Models.Requests;
using Models.Responses;

namespace RabbitClient.Publishers
{
  public class CreateUserMessagePublisher : IMessagePublisher<CreateUserRequest, CreateUserResponse>
  {
    private readonly IRequestClient<CreateUserRequest> _requestClient;
    private readonly ILogger<CreateUserMessagePublisher> _logger;


    public CreateUserMessagePublisher(
      IRequestClient<CreateUserRequest> requestClient,
      ILogger<CreateUserMessagePublisher> logger)
    {
      _requestClient = requestClient;
      _logger = logger;
    }

    public CreateUserResponse SendMessage(CreateUserRequest request)
    {
      _logger.LogInformation("Starting sending request from client");

      Response<CreateUserResponse> result = _requestClient.GetResponse<CreateUserResponse>(request).Result;

      _logger.LogInformation("Received request from server in client");
      return result.Message;
    }
  }
}
