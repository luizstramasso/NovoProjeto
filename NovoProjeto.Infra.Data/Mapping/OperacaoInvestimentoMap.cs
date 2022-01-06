using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NovoProjeto.Domain.Models;
using System;

namespace NovoProjeto.Infra.Data.Mapping
{
    class OperacaoInvestimentoMap : IEntityTypeConfiguration<OperacaoInvestimento>
    {
        public void Configure( EntityTypeBuilder<OperacaoInvestimento> builder )
        {
            builder.ToTable( "TB_OPERACAO_INVESTIMENTO" );

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
                .HasColumnName( "VALIDACAO" )
                .IsRequired();

            builder.Property( x => x.CodigoAcao )
                .HasColumnName( "CODIGO_ACAO" )
                .HasColumnType( "VARCHAR(10)" )
                .IsRequired();

            builder.Property( x => x.RazaoSocial )
                .HasColumnName( "RAZAO_SOCIAL" )
                .HasColumnType( "VARCHAR(255)" )
                .IsRequired();

            builder.Property( x => x.TipoOperacao )
                .HasColumnName( "TIPO_OPERACAO" )
                .HasConversion<string>()
                .IsRequired();

            builder.Property( x => x.ValorAcao )
                .HasColumnName( "VALOR_ACAO" )
                .IsRequired();

            builder.Property( x => x.Quantidade )
                .HasColumnName( "QUANTIDADE" )
                .IsRequired();

            builder.Property( x => x.ValorTotalOperacao )
                .HasColumnName( "VALOR_TOTAL_OPERACAO" )
                .IsRequired();
        }
    }
}
