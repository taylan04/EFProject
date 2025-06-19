using ATCSHARP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ATCSHARP.Data.Configuration {
    public class DestinoConfiguration : IEntityTypeConfiguration<Destino> {

        public void Configure(EntityTypeBuilder<Destino> builder) {
            builder.Property(d => d.Id).HasColumnName("Id");
            builder.Property(d => d.PacoteTuristicoId).HasColumnName("Pacote_Turistico_Id");
            builder.Property(d => d.CidadeDestinoId).HasColumnName("Cidade_Destino_Id");
            builder.HasData(
            //Brasil (comentários para eu lembrar e nao me perder)
            new Destino { Id = 1, PacoteTuristicoId = 1, CidadeDestinoId = 1 }, // Rio
            new Destino { Id = 2, PacoteTuristicoId = 1, CidadeDestinoId = 2 }, // SP

            //Portugal
            new Destino { Id = 3, PacoteTuristicoId = 2, CidadeDestinoId = 3 }, // Lisboa
            new Destino { Id = 4, PacoteTuristicoId = 2, CidadeDestinoId = 4 }, // Porto

            //Suíça
            new Destino { Id = 5, PacoteTuristicoId = 3, CidadeDestinoId = 5 }, // Zurique
            new Destino { Id = 6, PacoteTuristicoId = 3, CidadeDestinoId = 6 }); //Genebra
        }
    }
}
