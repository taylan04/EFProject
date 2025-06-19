using ATCSHARP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ATCSHARP.Data.Configuration {
    public class CidadeConfiguration : IEntityTypeConfiguration<CidadeDestino> {

        public void Configure(EntityTypeBuilder<CidadeDestino> builder) {
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.Nome).HasColumnName("Nome_Cidade").HasMaxLength(50);
            builder.Property(c => c.PaisDestinoId).HasColumnName("Pais_Destino_Id");
            builder.HasData(
            new CidadeDestino { Id = 1, Nome = "Rio de Janeiro", PaisDestinoId = 1 },
            new CidadeDestino { Id = 2, Nome = "São Paulo", PaisDestinoId = 1 },
            new CidadeDestino { Id = 3, Nome = "Lisboa", PaisDestinoId = 2 },
            new CidadeDestino { Id = 4, Nome = "Porto", PaisDestinoId = 2 },
            new CidadeDestino { Id = 5, Nome = "Zurique", PaisDestinoId = 3 },
            new CidadeDestino { Id = 6, Nome = "Genebra", PaisDestinoId = 3 });
        }
    }
}
