using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NovoProjeto.Domain.Models;
using System;

namespace NovoProjeto.Infra.Data.Mapping
{
    class AcaoInvestimentoMap : IEntityTypeConfiguration<AcaoInvestimento>
    {
        public void Configure( EntityTypeBuilder<AcaoInvestimento> builder )
        {
            builder.ToTable( "TB_ACAO_INVESTIMENTO" );

            builder.Property( x => x.ID )
                .HasColumnName( "ACAO_INVESTIMENTO_ID" )
                .HasDefaultValue( Guid.NewGuid() )
                .IsRequired();

            builder.Property( x => x.DataInclusao )
                .HasColumnName( "DATA_INCLUSAO" )
                .HasDefaultValue( DateTime.Now )
                .IsRequired();

            builder.Property( x => x.DataAlteracao )
                .HasColumnName( "DATA_ALTERACAO" );

            builder.Property( x => x.Validacao )
                .HasColumnName( "VALIDACAO" );

            builder.Property( x => x.RazaoSocial )
                .HasColumnName( "RAZAO_SOCIAL" )
                .HasColumnType( "VARCHAR(255)" )
                .IsRequired();

            builder.Property( x => x.CodigoAcao )
                .HasColumnName( "CODIGO_ACAO" )
                .HasColumnType( "VARCHAR(10)" )
                .IsRequired();
        }
    }
}
