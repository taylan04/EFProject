using ATCSHARP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ATCSHARP.Data.Configuration {
    public class PacoteConfiguration : IEntityTypeConfiguration<PacoteTuristico> {

        public void Configure(EntityTypeBuilder<PacoteTuristico> builder) {
            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.Titulo).HasColumnName("Titulo_Pacote").HasMaxLength(50);
            builder.Property(p => p.Descricao).HasColumnName("Descricao_Pacote");
            builder.Property(p => p.DataInicio).HasColumnName("Data_Inicio");
            builder.Property(p => p.CapacidadeMaxima).HasColumnName("Capacidade_Maxima");
            builder.Property(p => p.Preco).HasColumnName("Preco_Pacote");
            builder.Property(p => p.DeleteAt).HasColumnName("DeleteAt");
            builder.HasData(
            new PacoteTuristico {
                Id = 1,
                Titulo = "Pacote Rio Verão",
                Descricao = "Desfrute do melhor do Rio de Janeiro e São Paulo",
                DataInicio = new DateTime(2025, 12, 10),
                CapacidadeMaxima = 20,
                Preco = 1500,
                DeleteAt = null },

            new PacoteTuristico {
                Id = 2,
                Titulo = "Descubra Portugal",
                Descricao = "A história e charme de Lisboa e Porto",
                DataInicio = new DateTime(2025, 10, 5),
                CapacidadeMaxima = 15,
                Preco = 1800,
                DeleteAt = null },

            new PacoteTuristico {
                Id = 3,
                Titulo = "Alpes Suíços",
                Descricao = "Explore Zurique e Genebra",
                DataInicio = new DateTime(2026, 1, 15),
                CapacidadeMaxima = 10,
                Preco = 2500,
                DeleteAt = null }
            );
        }
    }
}
