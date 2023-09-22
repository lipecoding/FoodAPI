using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddressCorrection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ORDER_ADRESS_o_adress_id",
                table: "ORDER");

            migrationBuilder.DropTable(
                name: "ADRESS");

            migrationBuilder.DropColumn(
                name: "d_adressnumber",
                table: "DELIVERER");

            migrationBuilder.RenameColumn(
                name: "o_adress_id",
                table: "ORDER",
                newName: "o_address_id");

            migrationBuilder.RenameIndex(
                name: "IX_ORDER_o_adress_id",
                table: "ORDER",
                newName: "IX_ORDER_o_address_id");

            migrationBuilder.AlterColumn<string>(
                name: "d_password",
                table: "DELIVERER",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AddColumn<int>(
                name: "d_addressnumber",
                table: "DELIVERER",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ADDRESS",
                columns: table => new
                {
                    a_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    a_cep = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    a_street = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    a_address_number = table.Column<int>(type: "int", nullable: false),
                    a_complement = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    a_receiver_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    a_user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADDRESS", x => x.a_id);
                    table.ForeignKey(
                        name: "FK_ADDRESS_USER_a_user_id",
                        column: x => x.a_user_id,
                        principalTable: "USER",
                        principalColumn: "u_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ADDRESS_a_user_id",
                table: "ADDRESS",
                column: "a_user_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ORDER_ADDRESS_o_address_id",
                table: "ORDER",
                column: "o_address_id",
                principalTable: "ADDRESS",
                principalColumn: "a_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ORDER_ADDRESS_o_address_id",
                table: "ORDER");

            migrationBuilder.DropTable(
                name: "ADDRESS");

            migrationBuilder.DropColumn(
                name: "d_addressnumber",
                table: "DELIVERER");

            migrationBuilder.RenameColumn(
                name: "o_address_id",
                table: "ORDER",
                newName: "o_adress_id");

            migrationBuilder.RenameIndex(
                name: "IX_ORDER_o_address_id",
                table: "ORDER",
                newName: "IX_ORDER_o_adress_id");

            migrationBuilder.AlterColumn<string>(
                name: "d_password",
                table: "DELIVERER",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.AddColumn<int>(
                name: "d_adressnumber",
                table: "DELIVERER",
                type: "int",
                maxLength: 6,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ADRESS",
                columns: table => new
                {
                    a_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    a_user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    a_adress_number = table.Column<int>(type: "int", maxLength: 6, nullable: false),
                    a_cep = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    a_complement = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    a_receiver_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    a_street = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADRESS", x => x.a_id);
                    table.ForeignKey(
                        name: "FK_ADRESS_USER_a_user_id",
                        column: x => x.a_user_id,
                        principalTable: "USER",
                        principalColumn: "u_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ADRESS_a_user_id",
                table: "ADRESS",
                column: "a_user_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ORDER_ADRESS_o_adress_id",
                table: "ORDER",
                column: "o_adress_id",
                principalTable: "ADRESS",
                principalColumn: "a_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
