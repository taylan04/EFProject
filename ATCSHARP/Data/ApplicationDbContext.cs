using ATCSHARP.Data.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ATCSHARP.Models;
using System;

namespace ATCSHARP.Data
{
    public class ApplicationDbContext : IdentityDbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new PaisConfiguration());
            modelBuilder.ApplyConfiguration(new CidadeConfiguration()); 
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());   
            modelBuilder.ApplyConfiguration(new DestinoConfiguration());   
            modelBuilder.ApplyConfiguration(new PacoteConfiguration());     
            modelBuilder.ApplyConfiguration(new ReservaConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<PaisDestino> Paises { get; set; }
        public DbSet<CidadeDestino> Cidades { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Destino> Destinos { get; set; }
        public DbSet<PacoteTuristico> Pacotes { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
    }
}
