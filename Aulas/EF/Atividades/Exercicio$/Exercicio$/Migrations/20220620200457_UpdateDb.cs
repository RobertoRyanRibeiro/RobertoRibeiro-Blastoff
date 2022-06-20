using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exercicio_.Migrations
{
    public partial class UpdateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tax",
                table: "Compra");

            migrationBuilder.AlterColumn<float>(
                name: "Preco",
                table: "Produto",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<string>(
                name: "Cep",
                table: "Cliente",
                type: "VARCHAR(9)",
                maxLength: 9,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cep",
                table: "Cliente");

            migrationBuilder.AlterColumn<double>(
                name: "Preco",
                table: "Produto",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<int>(
                name: "Tax",
                table: "Compra",
                type: "INT",
                nullable: false,
                defaultValue: 0);
        }
    }
}
