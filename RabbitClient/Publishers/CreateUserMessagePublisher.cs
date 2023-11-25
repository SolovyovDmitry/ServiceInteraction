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

    public async Task<CreateUserResponse> SendMessageAsync(CreateUserRequest request)
    {
      _logger.LogInformation("Starting sending request from client");

      Response<CreateUserResponse> result = await _requestClient.GetResponse<CreateUserResponse>(request);

      _logger.LogInformation("Received request from server in client");
      return result.Message;
    }
  }
}
