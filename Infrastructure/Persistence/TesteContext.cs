using Microsoft.EntityFrameworkCore;
using TesteFullStackPleno.Core.Entities;
using TesteFullStackPleno.Infrastructure.Persistence.Configurations;

namespace TesteFullStackPleno.Infrastructure.Persistence
{
    public class TesteContext : DbContext
    {
        public TesteContext(DbContextOptions<TesteContext> options) : base(options)
        {

        }

        public DbSet<Comportamento> Comportamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ComportamentoConfiguration());
        }
    }
}
