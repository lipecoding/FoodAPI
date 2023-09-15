using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodAPI.Migrations
{
    /// <inheritdoc />
    public partial class Coupon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Error",
                table: "CouponCompanyRel");

            migrationBuilder.CreateIndex(
                name: "IX_CouponUserRel_UserId",
                table: "CouponUserRel",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CouponCompanyRel_CompanyId",
                table: "CouponCompanyRel",
                column: "CompanyId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CouponUserRel_UserId",
                table: "CouponUserRel");

            migrationBuilder.DropIndex(
                name: "IX_CouponCompanyRel_CompanyId",
                table: "CouponCompanyRel");

            migrationBuilder.AddColumn<string>(
                name: "Error",
                table: "CouponCompanyRel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
