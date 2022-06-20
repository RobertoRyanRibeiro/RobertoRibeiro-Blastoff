using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exercicio_.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Cpf = table.Column<string>(type: "VARCHAR(15)", maxLength: 15, nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    Telefone = table.Column<string>(type: "VARCHAR(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Cpf);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    Tipo = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    Preco = table.Column<double>(type: "float", nullable: false),
                    Quant = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Compra",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data_Compra = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Quant = table.Column<int>(type: "INT", nullable: false),
                    Tax = table.Column<int>(type: "INT", nullable: false),
                    Cliente_Cpf = table.Column<string>(type: "VARCHAR(15)", maxLength: 15, nullable: false),
                    Produto_Id = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compra_Cliente_Cliente_Cpf",
                        column: x => x.Cliente_Cpf,
                        principalTable: "Cliente",
                        principalColumn: "Cpf",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Compra_Produto_Produto_Id",
                        column: x => x.Produto_Id,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compra_Cliente_Cpf",
                table: "Compra",
                column: "Cliente_Cpf");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_Produto_Id",
                table: "Compra",
                column: "Produto_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Compra");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Produto");
        }
    }
}
