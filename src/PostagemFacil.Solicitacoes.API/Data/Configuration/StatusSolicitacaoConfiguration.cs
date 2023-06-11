using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostagemFacil.Solicitacoes.API.Data.Models;

namespace PostagemFacil.Solicitacoes.API.Data.Configuration
{
    public class StatusSolicitacaoConfiguration : IEntityTypeConfiguration<StatusSolicitacao>
    {
        public void Configure(EntityTypeBuilder<StatusSolicitacao> builder)
        {
            builder.HasData(
                new StatusSolicitacao() { Id = 1, Descricao = "Pagamento Pendente" },
                new StatusSolicitacao() { Id = 2, Descricao = "Aguardando Coleta" },
                new StatusSolicitacao() { Id = 3, Descricao = "Coletado" },
                new StatusSolicitacao() { Id = 4, Descricao = "Preparação para postagem" },
                new StatusSolicitacao() { Id = 5, Descricao = "Postado" }
            );
        }
    }
}
