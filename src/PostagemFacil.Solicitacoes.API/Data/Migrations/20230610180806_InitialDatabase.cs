using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostagemFacil.Solicitacoes.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PesoLimite",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PesoLimite", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusSolicitacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusSolicitacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoCaixa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCaixa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transportadora",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transportadora", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Solictacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    TransportadoraId = table.Column<int>(type: "int", nullable: false),
                    PesoLimiteId = table.Column<int>(type: "int", nullable: false),
                    TipoCaixaId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    Custo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EtiquetaUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataSolicitacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solictacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Solictacoes_PesoLimite_PesoLimiteId",
                        column: x => x.PesoLimiteId,
                        principalTable: "PesoLimite",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Solictacoes_StatusSolicitacao_StatusId",
                        column: x => x.StatusId,
                        principalTable: "StatusSolicitacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Solictacoes_TipoCaixa_TipoCaixaId",
                        column: x => x.TipoCaixaId,
                        principalTable: "TipoCaixa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Solictacoes_Transportadora_TransportadoraId",
                        column: x => x.TransportadoraId,
                        principalTable: "Transportadora",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Solictacoes_PesoLimiteId",
                table: "Solictacoes",
                column: "PesoLimiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Solictacoes_StatusId",
                table: "Solictacoes",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Solictacoes_TipoCaixaId",
                table: "Solictacoes",
                column: "TipoCaixaId");

            migrationBuilder.CreateIndex(
                name: "IX_Solictacoes_TransportadoraId",
                table: "Solictacoes",
                column: "TransportadoraId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Solictacoes");

            migrationBuilder.DropTable(
                name: "PesoLimite");

            migrationBuilder.DropTable(
                name: "StatusSolicitacao");

            migrationBuilder.DropTable(
                name: "TipoCaixa");

            migrationBuilder.DropTable(
                name: "Transportadora");
        }
    }
}
