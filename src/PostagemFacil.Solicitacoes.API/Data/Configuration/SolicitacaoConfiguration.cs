using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostagemFacil.Solicitacoes.API.Data.Models;

namespace PostagemFacil.Solicitacoes.API.Data.Configuration
{
    public class SolicitacaoConfiguration : IEntityTypeConfiguration<Solicitacao>
    {
        public void Configure(EntityTypeBuilder<Solicitacao> builder)
        {
            builder.HasOne(x => x.Transportadora);
            builder.HasOne(x => x.TipoCaixa);
            builder.HasOne(x => x.PesoLimite);
            builder.HasOne(x => x.Status);
        }
    }
}
