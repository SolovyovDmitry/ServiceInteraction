using Models.Requests;

namespace RabbitServer.Commands
{
  public class CreateCompanyCommand : ICreateCompanyCommand
  {
    public Guid? CreateCompany(CreateCompanyPublish publish)
    {
      return Guid.NewGuid();
    }
  }
}
