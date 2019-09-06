using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteFullStackPleno.Core.Entities;

namespace TesteFullStackPleno.Infrastructure.Persistence.Configurations
{
    public class ComportamentoConfiguration : IEntityTypeConfiguration<Comportamento>
    {
        public void Configure(EntityTypeBuilder<Comportamento> builder)
        {
            builder.ToTable("db_Comportamento");

            builder.HasKey(c => c.Id);
        }
    }
}
