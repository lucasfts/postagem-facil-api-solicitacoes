using Microsoft.EntityFrameworkCore;
using PostagemFacil.Solicitacoes.API.Data.Models;

namespace PostagemFacil.Solicitacoes.API.Data
{
    public class SolictacoesContext : DbContext
    {
        public SolictacoesContext(DbContextOptions<SolictacoesContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Solicitacao> Solictacoes { get; set; }
    }
}
