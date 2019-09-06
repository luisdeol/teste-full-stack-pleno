using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TesteFullStackPleno.Infrastructure.Services;

namespace TesteFullStackPleno.Application
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddRabbitMq(this IServiceCollection services, IConfiguration configuration)
        {
            var rabbitMqService = new RabbitMqService();

            rabbitMqService.Consume();

            return services;
        }
    }
}
