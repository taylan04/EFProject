using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ATCSHARP.Data.Migrations
{
    /// <inheritdoc />
    public partial class ImplementandoautenticaçãomodelsdbContextecrud : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome_Cliente = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email_Cliente = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pacotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo_Pacote = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descricao_Pacote = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data_Inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Capacidade_Maxima = table.Column<int>(type: "int", nullable: false),
                    Preco_Pacote = table.Column<double>(type: "float", nullable: false),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacotes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome_Pais = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cliente_Id = table.Column<int>(type: "int", nullable: false),
                    Pacote_Turistico_Id = table.Column<int>(type: "int", nullable: false),
                    Data_Reserva = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservas_Clientes_Cliente_Id",
                        column: x => x.Cliente_Id,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservas_Pacotes_Pacote_Turistico_Id",
                        column: x => x.Pacote_Turistico_Id,
                        principalTable: "Pacotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome_Cidade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Pais_Destino_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cidades_Paises_Pais_Destino_Id",
                        column: x => x.Pais_Destino_Id,
                        principalTable: "Paises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Destinos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pacote_Turistico_Id = table.Column<int>(type: "int", nullable: false),
                    Cidade_Destino_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Destinos_Cidades_Cidade_Destino_Id",
                        column: x => x.Cidade_Destino_Id,
                        principalTable: "Cidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Destinos_Pacotes_Pacote_Turistico_Id",
                        column: x => x.Pacote_Turistico_Id,
                        principalTable: "Pacotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "Email_Cliente", "Nome_Cliente" },
                values: new object[,]
                {
                    { 1, "taylan@gmail.com", "Taylan Silva" },
                    { 2, "richard@gmail.com", "Richard Alves" },
                    { 3, "guilherme@gmail.com", "Guilherme Pirozi" }
                });

            migrationBuilder.InsertData(
                table: "Pacotes",
                columns: new[] { "Id", "Capacidade_Maxima", "Data_Inicio", "DeleteAt", "Descricao_Pacote", "Preco_Pacote", "Titulo_Pacote" },
                values: new object[,]
                {
                    { 1, 20, new DateTime(2025, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Desfrute do melhor do Rio de Janeiro e São Paulo", 1500.0, "Pacote Rio Verão" },
                    { 2, 15, new DateTime(2025, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A história e charme de Lisboa e Porto", 1800.0, "Descubra Portugal" },
                    { 3, 10, new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Explore Zurique e Genebra", 2500.0, "Alpes Suíços" }
                });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "Nome_Pais" },
                values: new object[,]
                {
                    { 1, "Brasil" },
                    { 2, "Portugal" },
                    { 3, "Suíça" }
                });

            migrationBuilder.InsertData(
                table: "Cidades",
                columns: new[] { "Id", "Nome_Cidade", "Pais_Destino_Id" },
                values: new object[,]
                {
                    { 1, "Rio de Janeiro", 1 },
                    { 2, "São Paulo", 1 },
                    { 3, "Lisboa", 2 },
                    { 4, "Porto", 2 },
                    { 5, "Zurique", 3 },
                    { 6, "Genebra", 3 }
                });

            migrationBuilder.InsertData(
                table: "Reservas",
                columns: new[] { "Id", "Cliente_Id", "Data_Reserva", "Pacote_Turistico_Id" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 2, new DateTime(2025, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, 1, new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, 3, new DateTime(2025, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                table: "Destinos",
                columns: new[] { "Id", "Cidade_Destino_Id", "Pacote_Turistico_Id" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 2 },
                    { 4, 4, 2 },
                    { 5, 5, 3 },
                    { 6, 6, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cidades_Pais_Destino_Id",
                table: "Cidades",
                column: "Pais_Destino_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Destinos_Cidade_Destino_Id",
                table: "Destinos",
                column: "Cidade_Destino_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Destinos_Pacote_Turistico_Id",
                table: "Destinos",
                column: "Pacote_Turistico_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_Cliente_Id",
                table: "Reservas",
                column: "Cliente_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_Pacote_Turistico_Id",
                table: "Reservas",
                column: "Pacote_Turistico_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Destinos");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Cidades");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Pacotes");

            migrationBuilder.DropTable(
                name: "Paises");
        }
    }
}
