using Worker.Application.Common.Messaging.Events;
using Worker.Application.Workers.EventHandlers.Integration;
using Worker.API.Exceptions;
using Worker.Application.Common.Messaging;

namespace Worker.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddExceptionHandler<CustomExceptionHandler>();

        //services.AddHealthChecks().AddSqlServer(configuration.GetConnectionString("Database")!);

        return services;
    }

    public static WebApplication UseApiServices(this WebApplication app)
    {
        var eventBus = app.Services.GetRequiredService<IEventBus>();

        eventBus.SubscribeAsync<WorkerAcceptedEvent, WorkerAcceptedEventHandler>("worker_status_queue");

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Worker API");
                c.RoutePrefix = string.Empty; // Redireciona a url / para o Swagger
            });
        }

        app.UseExceptionHandler(options => { });

        app.MapControllers();

        //app.UseHealthChecks("/health",
        //   new HealthCheckOptions
        //   {
        //       ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        //   });

        return app;
    }
}
