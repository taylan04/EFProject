using ATCSHARP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ATCSHARP.Data.Configuration {
    public class ReservaConfiguration : IEntityTypeConfiguration<Reserva> {

        public void Configure(EntityTypeBuilder<Reserva> builder) {
            builder.Property(r => r.Id).HasColumnName("Id");
            builder.Property(r => r.ClienteId).HasColumnName("Cliente_Id");
            builder.Property(r => r.PacoteTuristicoId).HasColumnName("Pacote_Turistico_Id");
            builder.Property(r => r.DataReserva).HasColumnName("Data_Reserva");
            builder.HasData(
            new Reserva { Id = 1, ClienteId = 1, PacoteTuristicoId = 1, DataReserva = new DateTime(2025, 6, 20) }, //Taylan
            new Reserva { Id = 2, ClienteId = 2, PacoteTuristicoId = 2, DataReserva = new DateTime(2025, 6, 22) }, //Richard
            new Reserva { Id = 3, ClienteId = 1, PacoteTuristicoId = 3, DataReserva = new DateTime(2025, 7, 1) }, //Taylan
            new Reserva { Id = 4, ClienteId = 3, PacoteTuristicoId = 1, DataReserva = new DateTime(2025, 7, 3) }); //Gui
        }
    }
}
