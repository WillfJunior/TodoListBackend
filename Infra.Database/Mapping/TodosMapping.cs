using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Database.Mapping
{
    public class TodosMapping : IEntityTypeConfiguration<Todos>
    {
        public void Configure(EntityTypeBuilder<Todos> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id).ValueGeneratedOnAdd();
            builder.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
