using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostagemFacil.Solicitacoes.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUsuarioIdColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Solictacoes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Solictacoes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
