using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace dot_net_assessment.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ManufacturingProcesses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManufacturingProcesses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Faulty = table.Column<bool>(type: "bit", nullable: false),
                    Dispatched = table.Column<bool>(type: "bit", nullable: false),
                    ManufacturingProcessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ManufacturingProcesses_ManufacturingProcessId",
                        column: x => x.ManufacturingProcessId,
                        principalTable: "ManufacturingProcesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ManufacturingProcesses",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { new Guid("a8fe47fd-0b62-49ae-a229-2790ff04c4d9"), "Elaborado a mano" },
                    { new Guid("d321ce3e-cd2f-4ce0-b8bd-16c28d06e13a"), "Elaborado a mano y a máquina" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ManufacturingProcessId",
                table: "Products",
                column: "ManufacturingProcessId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ManufacturingProcesses");
        }
    }
}
