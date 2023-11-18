using MassTransit;
using Models.Requests;
using Models.Responses;
using RabbitClient.Publishers;

namespace RabbitClient
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var builder = WebApplication.CreateBuilder(args);

      // Add services to the container.

      builder.Services.AddControllers();

      builder.Services.AddSingleton<IPublish, Publish>();

      builder.Services.AddScoped<
        IMessagePublisher<CreateUserRequest, CreateUserResponse>,
        CreateUserMessagePublisher>();

      try
      {
        builder.Services.AddMassTransit(x =>
        {
          x.UsingRabbitMq((context, cfg) =>
          {
            cfg.Host("localhost");
            cfg.ConfigureEndpoints(context);
          });
        });
      }
      catch (Exception)
      {

        throw new Exception("Failed to connect to rabbitmq");
      }

      var app = builder.Build();

      // Configure the HTTP request pipeline.

      app.UseAuthorization();

      app.MapControllers();

      app.Run();
    }
  }
}
