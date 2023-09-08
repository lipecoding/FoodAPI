using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodAPI.Migrations
{
    /// <inheritdoc />
    public partial class DateTimeBirth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Deliverer");

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "Deliverer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DelivererVehicle",
                table: "Deliverer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DelivererMotorcicle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Placa = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    Renavam = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Ano = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    DelivererId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DelivererMotorcicle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DelivererMotorcicle_Deliverer_DelivererId",
                        column: x => x.DelivererId,
                        principalTable: "Deliverer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DelivererMotorcicle_DelivererId",
                table: "DelivererMotorcicle",
                column: "DelivererId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DelivererMotorcicle");

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "Deliverer");

            migrationBuilder.DropColumn(
                name: "DelivererVehicle",
                table: "Deliverer");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "User",
                type: "int",
                maxLength: 3,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Deliverer",
                type: "int",
                maxLength: 3,
                nullable: false,
                defaultValue: 0);
        }
    }
}
