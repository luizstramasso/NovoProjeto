using Microsoft.EntityFrameworkCore;
using NovoProjeto.Domain.Models;

namespace NovoProjeto.Infra.Data.Context
{
    public class NovoProjetoContext : DbContext
    {
        public NovoProjetoContext( DbContextOptions<NovoProjetoContext> options ) : base( options ) { }

        public DbSet<AcaoInvestimento> AcoesInvestimentos { get; set; }
        public DbSet<OperacaoInvestimento> OperacoesInvestimentos { get; set; }

        protected override void OnModelCreating( ModelBuilder modelBuilder )
        {
            modelBuilder.ApplyConfigurationsFromAssembly( GetType().Assembly );

            modelBuilder.Entity<AcaoInvestimento>().HasData( DataSeed.AcaoInvestimento() );
        }

    }
}
