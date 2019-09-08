using Microsoft.Extensions.DependencyInjection;
using TesteFullStackPleno.Core.Entities;
using TesteFullStackPleno.Core.Repositories;

namespace TesteFullStackPleno.Infrastructure.Persistence.Repositories
{
    public class ComportamentoRepository : IComportamentoRepository
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public ComportamentoRepository(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public void Add(Comportamento comportamento)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<TesteContext>();

                context.Comportamentos.Add(comportamento);
                context.SaveChanges();
            }
        }
    }
}
