using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PostagemFacil.Solicitacoes.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PesoLimite",
                columns: new[] { "Id", "Descricao" },
                values: new object[,]
                {
                    { 1, "Até 3kg" },
                    { 2, "Entre 3kg e 5kg" },
                    { 3, "Entre 5kg e 10kg" }
                });

            migrationBuilder.InsertData(
                table: "TipoCaixa",
                columns: new[] { "Id", "Descricao" },
                values: new object[,]
                {
                    { 1, "20cm x 20cm x 20cm" },
                    { 2, "40cm x 40cm x 40cm" },
                    { 3, "60cm x 60cm x 60cm" }
                });

            migrationBuilder.InsertData(
                table: "Transportadora",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Correios" },
                    { 2, "JadLog" },
                    { 3, "DHL" },
                    { 4, "Fedex" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PesoLimite",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PesoLimite",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PesoLimite",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TipoCaixa",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TipoCaixa",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TipoCaixa",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Transportadora",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Transportadora",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Transportadora",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Transportadora",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
