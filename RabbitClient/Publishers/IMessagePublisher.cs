namespace RabbitClient.Publishers
{
  public interface IMessagePublisher<T, U>
  {
    U SendMessage(T request);
  }
}
