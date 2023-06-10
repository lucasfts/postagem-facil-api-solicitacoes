using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostagemFacil.Solicitacoes.API.Data.Models;

namespace PostagemFacil.Solicitacoes.API.Data.Configuration
{
    public class TipoCaixaConfiguration : IEntityTypeConfiguration<TipoCaixa>
    {
        public void Configure(EntityTypeBuilder<TipoCaixa> builder)
        {
            builder.HasData(
                new TipoCaixa() { Id = 1, Descricao = "20cm x 20cm x 20cm" },
                new TipoCaixa() { Id = 2, Descricao = "40cm x 40cm x 40cm" },
                new TipoCaixa() { Id = 3, Descricao = "60cm x 60cm x 60cm" });
        }
    }
}
