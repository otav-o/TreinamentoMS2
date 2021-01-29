using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkEDAO.Migrations
{
    public partial class xxxy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoItens_Produtos_ProdutoId",
                table: "PedidoItens");

            migrationBuilder.DropIndex(
                name: "IX_PedidoItens_ProdutoId",
                table: "PedidoItens");

            migrationBuilder.AlterColumn<string>(
                name: "ProdutoId",
                table: "PedidoItens",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProdutoId",
                table: "PedidoItens",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PedidoItens_ProdutoId",
                table: "PedidoItens",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoItens_Produtos_ProdutoId",
                table: "PedidoItens",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "ProdutoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
