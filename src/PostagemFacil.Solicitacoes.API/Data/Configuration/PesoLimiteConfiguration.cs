using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostagemFacil.Solicitacoes.API.Data.Models;

namespace PostagemFacil.Solicitacoes.API.Data.Configuration
{
    public class PesoLimiteConfiguration : IEntityTypeConfiguration<PesoLimite>
    {
        public void Configure(EntityTypeBuilder<PesoLimite> builder)
        {
            builder.HasData(
                new PesoLimite() { Id = 1, Descricao = "Até 3kg" },
                new PesoLimite() { Id = 2, Descricao = "Entre 3kg e 5kg" },
                new PesoLimite() { Id = 3, Descricao = "Entre 5kg e 10kg" }
            );
        }
    }
}
