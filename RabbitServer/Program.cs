using MassTransit;
using RabbitServer.Commands;
using RabbitServer.Validators;

namespace RabbitServer
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var builder = WebApplication.CreateBuilder(args);

      // Add services to the container.

      builder.Services.AddControllers();

      builder.Services.AddScoped<ICreateUserCommand, CreateUserCommand>();
      builder.Services.AddScoped<ICreateCompanyCommand, CreateCompanyCommand>();
      builder.Services.AddScoped<ICreateUserValidator, CreateUserValidator>();


      try
      {
        builder.Services.AddMassTransit(x =>
        {
          x.AddConsumers(typeof(Program).Assembly);

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
