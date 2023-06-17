using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostagemFacil.Solicitacoes.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusCancelado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "StatusSolicitacao",
                keyColumn: "Id",
                keyValue: 4,
                column: "Descricao",
                value: "Preparação para postagem");

            migrationBuilder.InsertData(
                table: "StatusSolicitacao",
                columns: new[] { "Id", "Descricao" },
                values: new object[] { 6, "Cancelado" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StatusSolicitacao",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "StatusSolicitacao",
                keyColumn: "Id",
                keyValue: 4,
                column: "Descricao",
                value: "Em Preparação");
        }
    }
}
