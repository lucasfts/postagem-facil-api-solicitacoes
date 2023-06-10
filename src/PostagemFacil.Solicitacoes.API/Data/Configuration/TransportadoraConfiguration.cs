using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostagemFacil.Solicitacoes.API.Data.Models;

namespace PostagemFacil.Solicitacoes.API.Data.Configuration
{
    public class TransportadoraConfiguration : IEntityTypeConfiguration<Transportadora>
    {
        public void Configure(EntityTypeBuilder<Transportadora> builder)
        {
            builder.HasData(
                new Transportadora() { Id = 1, Nome = "Correios" },
                new Transportadora() { Id = 2, Nome = "JadLog" },
                new Transportadora() { Id = 3, Nome = "DHL" },
                new Transportadora() { Id = 4, Nome = "Fedex" }
            );
        }
    }
}
