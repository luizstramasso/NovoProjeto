using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NovoProjeto.Infra.Data.Migrations
{
    public partial class ValidacaoTrue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TB_ACAO_INVESTIMENTO",
                keyColumn: "ACAO_INVESTIMENTO_ID",
                keyValue: new Guid("28cb964c-e7e6-481d-b712-336f21008a6c"));

            migrationBuilder.DeleteData(
                table: "TB_ACAO_INVESTIMENTO",
                keyColumn: "ACAO_INVESTIMENTO_ID",
                keyValue: new Guid("347410f1-e07a-4728-bdab-4fb8dc864df5"));

            migrationBuilder.DeleteData(
                table: "TB_ACAO_INVESTIMENTO",
                keyColumn: "ACAO_INVESTIMENTO_ID",
                keyValue: new Guid("3537879f-ed38-48e7-a2c6-b3db2f5af328"));

            migrationBuilder.DeleteData(
                table: "TB_ACAO_INVESTIMENTO",
                keyColumn: "ACAO_INVESTIMENTO_ID",
                keyValue: new Guid("3fe9d20e-260c-4272-8a2a-b15612a4a594"));

            migrationBuilder.DeleteData(
                table: "TB_ACAO_INVESTIMENTO",
                keyColumn: "ACAO_INVESTIMENTO_ID",
                keyValue: new Guid("c2ac1ff2-a97d-4eed-9a20-9891867eae21"));

            migrationBuilder.DeleteData(
                table: "TB_ACAO_INVESTIMENTO",
                keyColumn: "ACAO_INVESTIMENTO_ID",
                keyValue: new Guid("de583068-aa4f-49a9-8fa4-b29d610f6bf7"));

            migrationBuilder.DeleteData(
                table: "TB_ACAO_INVESTIMENTO",
                keyColumn: "ACAO_INVESTIMENTO_ID",
                keyValue: new Guid("f8c3178a-3920-463d-bc30-1ff181954407"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DATA_INCLUSAO",
                table: "TB_OPERACAO_INVESTIMENTO",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 10, 12, 53, 44, 104, DateTimeKind.Local).AddTicks(864),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 1, 10, 12, 48, 15, 302, DateTimeKind.Local).AddTicks(7442));

            migrationBuilder.AlterColumn<Guid>(
                name: "ACAO_INVESTIMENTO_ID",
                table: "TB_OPERACAO_INVESTIMENTO",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("262eb2f2-fb94-4414-92fb-6f955aeb5021"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("0dfdd6ea-20fa-42eb-ae9a-569e56dfb4d1"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DATA_INCLUSAO",
                table: "TB_ACAO_INVESTIMENTO",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 10, 12, 53, 44, 93, DateTimeKind.Local).AddTicks(1467),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 1, 10, 12, 48, 15, 292, DateTimeKind.Local).AddTicks(7886));

            migrationBuilder.AlterColumn<Guid>(
                name: "ACAO_INVESTIMENTO_ID",
                table: "TB_ACAO_INVESTIMENTO",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("09efbfa4-27aa-45ae-b118-f7d43ad39c56"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("e921b47b-52ee-4071-a752-7364e7a4783d"));

            migrationBuilder.InsertData(
                table: "TB_ACAO_INVESTIMENTO",
                columns: new[] { "ACAO_INVESTIMENTO_ID", "CODIGO_ACAO", "DATA_ALTERACAO", "RAZAO_SOCIAL", "VALIDACAO" },
                values: new object[,]
                {
                    { new Guid("9dfeb225-bcd5-484b-93ac-9a6ac89ec9b8"), "AAPL", null, "Apple Inc.", true },
                    { new Guid("ea276203-7052-4460-b311-1fcdc92b7f5b"), "AMZN", null, "Amazon.com, Inc.", true },
                    { new Guid("eba9ddf2-1301-47b5-9068-7837b63641a8"), "GOOG", null, "Alphabet Inc.", true },
                    { new Guid("e4c00ff7-047a-4352-9422-518f04345de2"), "FB", null, "Meta Platforms, Inc.", true },
                    { new Guid("e4421514-4cd2-4fe5-be26-60ce02465783"), "TSLA", null, "Tesla, Inc.", true },
                    { new Guid("f0cd6974-2906-41b6-b635-aa7c0137ada3"), "NFLX", null, "Netflix Inc.", true },
                    { new Guid("3ce34685-39c6-4da2-8d6f-ebbf525c7b17"), "IBM", null, "International Business Machines Corporation", true }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TB_ACAO_INVESTIMENTO",
                keyColumn: "ACAO_INVESTIMENTO_ID",
                keyValue: new Guid("3ce34685-39c6-4da2-8d6f-ebbf525c7b17"));

            migrationBuilder.DeleteData(
                table: "TB_ACAO_INVESTIMENTO",
                keyColumn: "ACAO_INVESTIMENTO_ID",
                keyValue: new Guid("9dfeb225-bcd5-484b-93ac-9a6ac89ec9b8"));

            migrationBuilder.DeleteData(
                table: "TB_ACAO_INVESTIMENTO",
                keyColumn: "ACAO_INVESTIMENTO_ID",
                keyValue: new Guid("e4421514-4cd2-4fe5-be26-60ce02465783"));

            migrationBuilder.DeleteData(
                table: "TB_ACAO_INVESTIMENTO",
                keyColumn: "ACAO_INVESTIMENTO_ID",
                keyValue: new Guid("e4c00ff7-047a-4352-9422-518f04345de2"));

            migrationBuilder.DeleteData(
                table: "TB_ACAO_INVESTIMENTO",
                keyColumn: "ACAO_INVESTIMENTO_ID",
                keyValue: new Guid("ea276203-7052-4460-b311-1fcdc92b7f5b"));

            migrationBuilder.DeleteData(
                table: "TB_ACAO_INVESTIMENTO",
                keyColumn: "ACAO_INVESTIMENTO_ID",
                keyValue: new Guid("eba9ddf2-1301-47b5-9068-7837b63641a8"));

            migrationBuilder.DeleteData(
                table: "TB_ACAO_INVESTIMENTO",
                keyColumn: "ACAO_INVESTIMENTO_ID",
                keyValue: new Guid("f0cd6974-2906-41b6-b635-aa7c0137ada3"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DATA_INCLUSAO",
                table: "TB_OPERACAO_INVESTIMENTO",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 10, 12, 48, 15, 302, DateTimeKind.Local).AddTicks(7442),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 1, 10, 12, 53, 44, 104, DateTimeKind.Local).AddTicks(864));

            migrationBuilder.AlterColumn<Guid>(
                name: "ACAO_INVESTIMENTO_ID",
                table: "TB_OPERACAO_INVESTIMENTO",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("0dfdd6ea-20fa-42eb-ae9a-569e56dfb4d1"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("262eb2f2-fb94-4414-92fb-6f955aeb5021"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DATA_INCLUSAO",
                table: "TB_ACAO_INVESTIMENTO",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 10, 12, 48, 15, 292, DateTimeKind.Local).AddTicks(7886),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 1, 10, 12, 53, 44, 93, DateTimeKind.Local).AddTicks(1467));

            migrationBuilder.AlterColumn<Guid>(
                name: "ACAO_INVESTIMENTO_ID",
                table: "TB_ACAO_INVESTIMENTO",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("e921b47b-52ee-4071-a752-7364e7a4783d"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("09efbfa4-27aa-45ae-b118-f7d43ad39c56"));

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
    }
}
