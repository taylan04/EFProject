using ATCSHARP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ATCSHARP.Data.Configuration {
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente> {

        public void Configure(EntityTypeBuilder<Cliente> builder) {
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.Nome).HasColumnName("Nome_Cliente").HasMaxLength(50);
            builder.Property(c => c.Email).HasColumnName("Email_Cliente").HasMaxLength(50);
            builder.HasData(
            new Cliente { Id = 1, Nome = "Taylan Silva", Email = "taylan@gmail.com" },
            new Cliente { Id = 2, Nome = "Richard Alves", Email = "richard@gmail.com" },
            new Cliente { Id = 3, Nome = "Guilherme Pirozi", Email = "guilherme@gmail.com" });
        }
    }
}
