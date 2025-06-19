using ATCSHARP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ATCSHARP.Data.Configuration {
    public class PaisConfiguration : IEntityTypeConfiguration<PaisDestino> {

        public void Configure(EntityTypeBuilder<PaisDestino> builder) {
            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.Nome).HasColumnName("Nome_Pais").HasMaxLength(50);
            builder.HasData(
                new PaisDestino { Id = 1, Nome = "Brasil" },
                new PaisDestino { Id = 2, Nome = "Portugal" },
                new PaisDestino { Id = 3, Nome = "Suíça" }
            );
        }
    }
}
