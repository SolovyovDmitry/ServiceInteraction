using Models.Requests;

namespace RabbitClient.Publishers
{
  public interface IPublish
  {
    void CreateCompany(CreateCompanyPublish request);
  }
}
