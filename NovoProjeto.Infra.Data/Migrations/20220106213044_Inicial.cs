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
                    ACAO_INVESTIMENTO_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("715b8039-667c-4366-9f8b-34fc5dd965bb")),
                    CODIGO_ACAO = table.Column<string>(type: "VARCHAR(10)", nullable: false),
                    RAZAO_SOCIAL = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    DATA_INCLUSAO = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 1, 6, 18, 30, 44, 149, DateTimeKind.Local).AddTicks(6497)),
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
                    ACAO_INVESTIMENTO_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("bca2cc03-0613-4d01-9b12-dbb12ec95126")),
                    CODIGO_ACAO = table.Column<string>(type: "VARCHAR(10)", nullable: false),
                    RAZAO_SOCIAL = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    TIPO_OPERACAO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VALOR_ACAO = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QUANTIDADE = table.Column<int>(type: "int", nullable: false),
                    VALOR_TOTAL_OPERACAO = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DATA_INCLUSAO = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 1, 6, 18, 30, 44, 185, DateTimeKind.Local).AddTicks(7648)),
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
                    { new Guid("23dc4f1d-e629-401b-88e5-c318c39d088c"), "AAPL", null, "Apple Inc.", false },
                    { new Guid("587577d8-9536-42e7-8812-6ec57709ddc8"), "AMZN", null, "Amazon.com, Inc.", false },
                    { new Guid("21681a43-4dec-4f8d-888d-c23b4c9dae66"), "GOOG", null, "Alphabet Inc.", false },
                    { new Guid("f3fce418-7b32-4349-aa40-1a8a7aac94a1"), "FB", null, "Meta Platforms, Inc.", false },
                    { new Guid("a60019f0-03d9-4a24-9067-e30fedaed429"), "TSLA", null, "Tesla, Inc.", false },
                    { new Guid("6f024bc4-1a16-4e05-8a23-5732d66b0d9d"), "NFLX", null, "Netflix Inc.", false },
                    { new Guid("dfc9d16a-3321-46e3-9188-5f4a13508a9d"), "IBM", null, "International Business Machines Corporation", false }
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
