using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NovoProjeto.Infra.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_ACAO_INVESTIMENTO",
                columns: table => new
                {
                    ACAO_INVESTIMENTO_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("e921b47b-52ee-4071-a752-7364e7a4783d")),
                    CODIGO_ACAO = table.Column<string>(type: "VARCHAR(10)", nullable: false),
                    RAZAO_SOCIAL = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    DATA_INCLUSAO = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 1, 10, 12, 48, 15, 292, DateTimeKind.Local).AddTicks(7886)),
                    DATA_ALTERACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VALIDACAO = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ACAO_INVESTIMENTO", x => x.ACAO_INVESTIMENTO_ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_OPERACAO_INVESTIMENTO",
                columns: table => new
                {
                    ACAO_INVESTIMENTO_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("0dfdd6ea-20fa-42eb-ae9a-569e56dfb4d1")),
                    CODIGO_ACAO = table.Column<string>(type: "VARCHAR(10)", nullable: false),
                    RAZAO_SOCIAL = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    TIPO_OPERACAO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VALOR_ACAO = table.Column<double>(type: "float", nullable: false),
                    QUANTIDADE = table.Column<int>(type: "int", nullable: false),
                    VALOR_TOTAL_OPERACAO = table.Column<double>(type: "float", nullable: false),
                    DATA_INCLUSAO = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 1, 10, 12, 48, 15, 302, DateTimeKind.Local).AddTicks(7442)),
                    DATA_ALTERACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VALIDACAO = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_OPERACAO_INVESTIMENTO", x => x.ACAO_INVESTIMENTO_ID);
                });

            migrationBuilder.InsertData(
                table: "TB_ACAO_INVESTIMENTO",
                columns: new[] { "ACAO_INVESTIMENTO_ID", "CODIGO_ACAO", "DATA_ALTERACAO", "RAZAO_SOCIAL", "VALIDACAO" },
                values: new object[,]
                {
                    { new Guid("3537879f-ed38-48e7-a2c6-b3db2f5af328"), "AAPL", null, "Apple Inc.", false },
                    { new Guid("347410f1-e07a-4728-bdab-4fb8dc864df5"), "AMZN", null, "Amazon.com, Inc.", false },
                    { new Guid("c2ac1ff2-a97d-4eed-9a20-9891867eae21"), "GOOG", null, "Alphabet Inc.", false },
                    { new Guid("3fe9d20e-260c-4272-8a2a-b15612a4a594"), "FB", null, "Meta Platforms, Inc.", false },
                    { new Guid("de583068-aa4f-49a9-8fa4-b29d610f6bf7"), "TSLA", null, "Tesla, Inc.", false },
                    { new Guid("f8c3178a-3920-463d-bc30-1ff181954407"), "NFLX", null, "Netflix Inc.", false },
                    { new Guid("28cb964c-e7e6-481d-b712-336f21008a6c"), "IBM", null, "International Business Machines Corporation", false }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_ACAO_INVESTIMENTO");

            migrationBuilder.DropTable(
                name: "TB_OPERACAO_INVESTIMENTO");
        }
    }
}
