using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PostagemFacil.Solicitacoes.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedStatusSolicitacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "StatusSolicitacao",
                columns: new[] { "Id", "Descricao" },
                values: new object[,]
                {
                    { 1, "Pagamento Pendente" },
                    { 2, "Aguardando Coleta" },
                    { 3, "Coletado" },
                    { 4, "Em Preparação" },
                    { 5, "Postado" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StatusSolicitacao",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StatusSolicitacao",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StatusSolicitacao",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "StatusSolicitacao",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "StatusSolicitacao",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
