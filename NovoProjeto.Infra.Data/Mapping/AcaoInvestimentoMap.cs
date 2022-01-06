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
            builder.ToTable( "AcaoInvestimento" );

            builder.Property( x => x.ID )
                .HasColumnName( "ACAO_INVESTIMENTO_ID" )
                .HasColumnType( "UNIQUEIDENTIFIER" )
                .HasDefaultValue( Guid.NewGuid() )
                .IsRequired();

            builder.Property( x => x.DataInclusao )
                .HasColumnName( "DATA_INCLUSAO" )
                .HasColumnType( "DATETIME" )
                .HasDefaultValue( DateTime.Now )
                .IsRequired();

            builder.Property( x => x.DataAlteracao )
                .HasColumnName( "DATA_ALTERACAO" )
                .HasColumnType( "DATETIME" );

            builder.Property( x => x.Validacao )
                .HasColumnName( "VALIDACAO" )
                .HasColumnType( "BIT" )
                .HasDefaultValue( true )
                .IsRequired();

            builder.Property( x => x.RazaoSocial )
                .HasColumnName( "RAZAO_SOCIAL" )
                .HasColumnType( "VARCHAR(255)" )
                .HasMaxLength( 255 )
                .IsRequired();

            builder.Property( x => x.TipoOperacao )
                .HasColumnName( "TIPO_OPERACAO" )
                .HasConversion<string>()
                .IsRequired();

            builder.Property( x => x.ValorAcao )
                .HasColumnName( "VALOR_ACAO" )
                .HasColumnType( "DECIMAL(6,2" )
                .IsRequired();

            builder.Property( x => x.Quantidade )
                .HasColumnName( "QUANTIDADE" )
                .HasColumnType( "INT" )
                .IsRequired();

            builder.Property( x => x.ValorTotalOperacao )
                .HasColumnName( "VALOR_TOTAL_OPERACAO" )
                .HasColumnType( "DECIMAL(10,2)" )
                .IsRequired();
        }
    }
}
