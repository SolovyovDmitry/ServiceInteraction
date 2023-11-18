using Microsoft.AspNetCore.Mvc;
using Models.Requests;
using Models.Responses;
using RabbitClient.Publishers;

namespace RabbitClient.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    public IActionResult Post(
      [FromServices] IMessagePublisher<CreateUserRequest, CreateUserResponse> messagePublisher,
      [FromBody] CreateUserRequest request)
    {
      var result = messagePublisher.SendMessage(request);

      if (result.UserId is null)
      {
        return BadRequest("Failed to create user");
      }

      return Created("/users", result.UserId);
    }
  }
}
