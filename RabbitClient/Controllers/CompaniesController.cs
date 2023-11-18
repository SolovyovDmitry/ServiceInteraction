using Microsoft.AspNetCore.Mvc;
using Models.Requests;
using RabbitClient.Publishers;

namespace RabbitClient.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class CompaniesController : ControllerBase
  {
    public IActionResult Post(
      [FromServices] IPublish publish,
      [FromBody] CreateCompanyPublish request)
    {
      publish.CreateCompany(request);

      return Ok();
    }
  }
}
