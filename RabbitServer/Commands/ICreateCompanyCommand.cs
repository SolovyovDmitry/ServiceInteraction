using Models.Requests;

namespace RabbitServer.Commands
{
  public interface ICreateCompanyCommand
  {
    Guid? CreateCompany(CreateCompanyPublish publish);
  }
}
