using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostagemFacil.Solicitacoes.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_CamposCliente_TabelaSolicitacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Solictacoes",
                newName: "ClienteId");

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "Solictacoes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NomeCliente",
                table: "Solictacoes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "Solictacoes");

            migrationBuilder.DropColumn(
                name: "NomeCliente",
                table: "Solictacoes");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Solictacoes",
                newName: "UsuarioId");
        }
    }
}
