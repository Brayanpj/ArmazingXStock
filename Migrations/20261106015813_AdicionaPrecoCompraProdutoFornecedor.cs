using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArmazingXStock.Api.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaPrecoCompraProdutoFornecedor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PrecoCompra",
                table: "ProdutosFornecedores",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrecoCompra",
                table: "ProdutosFornecedores");
        }
    }
}
