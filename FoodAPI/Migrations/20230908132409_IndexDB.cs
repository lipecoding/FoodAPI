using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodAPI.Migrations
{
    /// <inheritdoc />
    public partial class IndexDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DelivererMotorcicle_DelivererId",
                table: "DelivererMotorcicle");

            migrationBuilder.RenameIndex(
                name: "IX_CouponUserRel_UserId",
                table: "CouponUserRel",
                newName: "Index_CouponUserRel");

            migrationBuilder.RenameIndex(
                name: "IX_CouponCompanyRel_CompanyId",
                table: "CouponCompanyRel",
                newName: "Index_CouponCompanyRel");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Deliverer",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "Index_User",
                table: "User",
                columns: new[] { "PhoneNumber", "Email" });

            migrationBuilder.CreateIndex(
                name: "Index_Motorcicle",
                table: "DelivererMotorcicle",
                columns: new[] { "DelivererId", "Renavam", "Placa" });

            migrationBuilder.CreateIndex(
                name: "Index_Deliverer",
                table: "Deliverer",
                columns: new[] { "Email", "PhoneNumber" });

            migrationBuilder.CreateIndex(
                name: "Index_Coupon",
                table: "Coupon",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "Index_Company",
                table: "Company",
                column: "Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Index_User",
                table: "User");

            migrationBuilder.DropIndex(
                name: "Index_Motorcicle",
                table: "DelivererMotorcicle");

            migrationBuilder.DropIndex(
                name: "Index_Deliverer",
                table: "Deliverer");

            migrationBuilder.DropIndex(
                name: "Index_Coupon",
                table: "Coupon");

            migrationBuilder.DropIndex(
                name: "Index_Company",
                table: "Company");

            migrationBuilder.RenameIndex(
                name: "Index_CouponUserRel",
                table: "CouponUserRel",
                newName: "IX_CouponUserRel_UserId");

            migrationBuilder.RenameIndex(
                name: "Index_CouponCompanyRel",
                table: "CouponCompanyRel",
                newName: "IX_CouponCompanyRel_CompanyId");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Deliverer",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_DelivererMotorcicle_DelivererId",
                table: "DelivererMotorcicle",
                column: "DelivererId");
        }
    }
}
