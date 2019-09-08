using Microsoft.Extensions.DependencyInjection;
using TesteFullStackPleno.Core.Repositories;
using TesteFullStackPleno.Infrastructure.Persistence.Repositories;
using TesteFullStackPleno.Infrastructure.Services;

namespace TesteFullStackPleno.Application
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddMessageQueueService(this IServiceCollection services)
        {
            services.AddScoped<IMessageQueueService, RabbitMqService>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IComportamentoRepository, ComportamentoRepository>();

            return services;
        }
    }
}
