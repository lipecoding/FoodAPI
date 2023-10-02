using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodAPI.Migrations
{
    /// <inheritdoc />
    public partial class Enums : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ADDRESS_a_user_id",
                table: "ADDRESS");

            migrationBuilder.DropColumn(
                name: "u_premium",
                table: "USER");

            migrationBuilder.DropColumn(
                name: "o_status",
                table: "ORDER");

            migrationBuilder.DropColumn(
                name: "d_status",
                table: "DELIVERER");

            migrationBuilder.DropColumn(
                name: "d_vehicle",
                table: "DELIVERER");

            migrationBuilder.DropColumn(
                name: "c_categorie",
                table: "COUPON");

            migrationBuilder.DropColumn(
                name: "c_premium",
                table: "COUPON");

            migrationBuilder.DropColumn(
                name: "c_value_type",
                table: "COUPON");

            migrationBuilder.DropColumn(
                name: "cy_plan",
                table: "COMPANY");

            migrationBuilder.DropColumn(
                name: "cy_type",
                table: "COMPANY");

            migrationBuilder.AddColumn<Guid>(
                name: "u_plan_id",
                table: "USER",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "o_status_id",
                table: "ORDER",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "d_status_id",
                table: "DELIVERER",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "d_vehicle_id",
                table: "DELIVERER",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "c_company_type_id",
                table: "COUPON",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "c_plan_id",
                table: "COUPON",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "c_value_type_id",
                table: "COUPON",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "cy_plan_id",
                table: "COMPANY",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "cy_type_id",
                table: "COMPANY",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "COMPANY_PLAN",
                columns: table => new
                {
                    cp_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cp_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMPANY_PLAN", x => x.cp_id);
                });

            migrationBuilder.CreateTable(
                name: "COMPANY_TYPE",
                columns: table => new
                {
                    ct_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ct_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMPANY_TYPE", x => x.ct_id);
                });

            migrationBuilder.CreateTable(
                name: "COUPON_VALUE_TYPE",
                columns: table => new
                {
                    cvt_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cvt_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COUPON_VALUE_TYPE", x => x.cvt_id);
                });

            migrationBuilder.CreateTable(
                name: "DELIVERER_STATUS",
                columns: table => new
                {
                    ds_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ds_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DELIVERER_STATUS", x => x.ds_id);
                });

            migrationBuilder.CreateTable(
                name: "DELIVERER_VEHICLE",
                columns: table => new
                {
                    dv_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    dv_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DELIVERER_VEHICLE", x => x.dv_id);
                });

            migrationBuilder.CreateTable(
                name: "ORDER_STATUS",
                columns: table => new
                {
                    os_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    os_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDER_STATUS", x => x.os_id);
                });

            migrationBuilder.CreateTable(
                name: "USER_PLAN",
                columns: table => new
                {
                    up_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    up_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_PLAN", x => x.up_id);
                });

            migrationBuilder.InsertData(
                table: "COMPANY_PLAN",
                columns: new[] { "cp_id", "cp_name" },
                values: new object[,]
                {
                    { new Guid("5e91e480-098a-42e4-baf4-7e018cded677"), "Basic" },
                    { new Guid("f236b759-d429-4f68-8c39-ec0c2ae339a5"), "Master" }
                });

            migrationBuilder.InsertData(
                table: "COMPANY_TYPE",
                columns: new[] { "ct_id", "ct_name" },
                values: new object[,]
                {
                    { new Guid("a0134aab-9578-4c3c-8246-dc8ce93356e6"), "Restaurant" },
                    { new Guid("b1680308-7124-4dc8-8535-73a0a541d9c4"), "Market" }
                });

            migrationBuilder.InsertData(
                table: "COUPON_VALUE_TYPE",
                columns: new[] { "cvt_id", "cvt_name" },
                values: new object[,]
                {
                    { new Guid("2280e72c-ec3f-48ae-90e9-37962d696b31"), "Percetage" },
                    { new Guid("27fc20a5-9317-456f-8597-22b6eb2a9fa8"), "Value" }
                });

            migrationBuilder.InsertData(
                table: "DELIVERER_STATUS",
                columns: new[] { "ds_id", "ds_name" },
                values: new object[,]
                {
                    { new Guid("17fc6245-94fc-4f1d-9cbe-9b2fca9cd5f2"), "Work" },
                    { new Guid("4688c7bb-1976-45eb-a476-5ed956011b38"), "Online" },
                    { new Guid("b11067d6-ed51-4f44-af40-9c2b1c470c0a"), "Offline" }
                });

            migrationBuilder.InsertData(
                table: "DELIVERER_VEHICLE",
                columns: new[] { "dv_id", "dv_name" },
                values: new object[,]
                {
                    { new Guid("1b5260e2-7241-4592-8622-1f595135d905"), "Bike" },
                    { new Guid("dce05953-739c-4185-869f-ed03bf337d0a"), "Motorcicle" }
                });

            migrationBuilder.InsertData(
                table: "ORDER_STATUS",
                columns: new[] { "os_id", "os_name" },
                values: new object[,]
                {
                    { new Guid("b0190476-b869-44d0-997f-eca6a23a623e"), "Open" },
                    { new Guid("f154a056-a2f0-498e-98c6-7dfc20af60eb"), "Canceled" },
                    { new Guid("faa9c90d-96b2-46dc-a8b0-add2e8a80a32"), "Closed" }
                });

            migrationBuilder.InsertData(
                table: "USER_PLAN",
                columns: new[] { "up_id", "up_name" },
                values: new object[,]
                {
                    { new Guid("0b29113c-f0ae-442c-9dbf-89607be11815"), "Premium" },
                    { new Guid("4079c94f-06e4-4d0b-81eb-6fbd22f1ff66"), "None" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_USER_u_plan_id",
                table: "USER",
                column: "u_plan_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_o_status_id",
                table: "ORDER",
                column: "o_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_DELIVERER_d_status_id",
                table: "DELIVERER",
                column: "d_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_DELIVERER_d_vehicle_id",
                table: "DELIVERER",
                column: "d_vehicle_id");

            migrationBuilder.CreateIndex(
                name: "IX_COUPON_c_company_type_id",
                table: "COUPON",
                column: "c_company_type_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_COUPON_c_plan_id",
                table: "COUPON",
                column: "c_plan_id");

            migrationBuilder.CreateIndex(
                name: "IX_COUPON_c_value_type_id",
                table: "COUPON",
                column: "c_value_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_COMPANY_cy_plan_id",
                table: "COMPANY",
                column: "cy_plan_id");

            migrationBuilder.CreateIndex(
                name: "IX_COMPANY_cy_type_id",
                table: "COMPANY",
                column: "cy_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_ADDRESS_a_user_id",
                table: "ADDRESS",
                column: "a_user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_COMPANY_COMPANY_PLAN_cy_plan_id",
                table: "COMPANY",
                column: "cy_plan_id",
                principalTable: "COMPANY_PLAN",
                principalColumn: "cp_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_COMPANY_COMPANY_TYPE_cy_type_id",
                table: "COMPANY",
                column: "cy_type_id",
                principalTable: "COMPANY_TYPE",
                principalColumn: "ct_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_COUPON_COMPANY_TYPE_c_company_type_id",
                table: "COUPON",
                column: "c_company_type_id",
                principalTable: "COMPANY_TYPE",
                principalColumn: "ct_id");

            migrationBuilder.AddForeignKey(
                name: "FK_COUPON_COUPON_VALUE_TYPE_c_value_type_id",
                table: "COUPON",
                column: "c_value_type_id",
                principalTable: "COUPON_VALUE_TYPE",
                principalColumn: "cvt_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_COUPON_USER_PLAN_c_plan_id",
                table: "COUPON",
                column: "c_plan_id",
                principalTable: "USER_PLAN",
                principalColumn: "up_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DELIVERER_DELIVERER_STATUS_d_status_id",
                table: "DELIVERER",
                column: "d_status_id",
                principalTable: "DELIVERER_STATUS",
                principalColumn: "ds_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DELIVERER_DELIVERER_VEHICLE_d_vehicle_id",
                table: "DELIVERER",
                column: "d_vehicle_id",
                principalTable: "DELIVERER_VEHICLE",
                principalColumn: "dv_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ORDER_ORDER_STATUS_o_status_id",
                table: "ORDER",
                column: "o_status_id",
                principalTable: "ORDER_STATUS",
                principalColumn: "os_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_USER_USER_PLAN_u_plan_id",
                table: "USER",
                column: "u_plan_id",
                principalTable: "USER_PLAN",
                principalColumn: "up_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COMPANY_COMPANY_PLAN_cy_plan_id",
                table: "COMPANY");

            migrationBuilder.DropForeignKey(
                name: "FK_COMPANY_COMPANY_TYPE_cy_type_id",
                table: "COMPANY");

            migrationBuilder.DropForeignKey(
                name: "FK_COUPON_COMPANY_TYPE_c_company_type_id",
                table: "COUPON");

            migrationBuilder.DropForeignKey(
                name: "FK_COUPON_COUPON_VALUE_TYPE_c_value_type_id",
                table: "COUPON");

            migrationBuilder.DropForeignKey(
                name: "FK_COUPON_USER_PLAN_c_plan_id",
                table: "COUPON");

            migrationBuilder.DropForeignKey(
                name: "FK_DELIVERER_DELIVERER_STATUS_d_status_id",
                table: "DELIVERER");

            migrationBuilder.DropForeignKey(
                name: "FK_DELIVERER_DELIVERER_VEHICLE_d_vehicle_id",
                table: "DELIVERER");

            migrationBuilder.DropForeignKey(
                name: "FK_ORDER_ORDER_STATUS_o_status_id",
                table: "ORDER");

            migrationBuilder.DropForeignKey(
                name: "FK_USER_USER_PLAN_u_plan_id",
                table: "USER");

            migrationBuilder.DropTable(
                name: "COMPANY_PLAN");

            migrationBuilder.DropTable(
                name: "COMPANY_TYPE");

            migrationBuilder.DropTable(
                name: "COUPON_VALUE_TYPE");

            migrationBuilder.DropTable(
                name: "DELIVERER_STATUS");

            migrationBuilder.DropTable(
                name: "DELIVERER_VEHICLE");

            migrationBuilder.DropTable(
                name: "ORDER_STATUS");

            migrationBuilder.DropTable(
                name: "USER_PLAN");

            migrationBuilder.DropIndex(
                name: "IX_USER_u_plan_id",
                table: "USER");

            migrationBuilder.DropIndex(
                name: "IX_ORDER_o_status_id",
                table: "ORDER");

            migrationBuilder.DropIndex(
                name: "IX_DELIVERER_d_status_id",
                table: "DELIVERER");

            migrationBuilder.DropIndex(
                name: "IX_DELIVERER_d_vehicle_id",
                table: "DELIVERER");

            migrationBuilder.DropIndex(
                name: "IX_COUPON_c_company_type_id",
                table: "COUPON");

            migrationBuilder.DropIndex(
                name: "IX_COUPON_c_plan_id",
                table: "COUPON");

            migrationBuilder.DropIndex(
                name: "IX_COUPON_c_value_type_id",
                table: "COUPON");

            migrationBuilder.DropIndex(
                name: "IX_COMPANY_cy_plan_id",
                table: "COMPANY");

            migrationBuilder.DropIndex(
                name: "IX_COMPANY_cy_type_id",
                table: "COMPANY");

            migrationBuilder.DropIndex(
                name: "IX_ADDRESS_a_user_id",
                table: "ADDRESS");

            migrationBuilder.DropColumn(
                name: "u_plan_id",
                table: "USER");

            migrationBuilder.DropColumn(
                name: "o_status_id",
                table: "ORDER");

            migrationBuilder.DropColumn(
                name: "d_status_id",
                table: "DELIVERER");

            migrationBuilder.DropColumn(
                name: "d_vehicle_id",
                table: "DELIVERER");

            migrationBuilder.DropColumn(
                name: "c_company_type_id",
                table: "COUPON");

            migrationBuilder.DropColumn(
                name: "c_plan_id",
                table: "COUPON");

            migrationBuilder.DropColumn(
                name: "c_value_type_id",
                table: "COUPON");

            migrationBuilder.DropColumn(
                name: "cy_plan_id",
                table: "COMPANY");

            migrationBuilder.DropColumn(
                name: "cy_type_id",
                table: "COMPANY");

            migrationBuilder.AddColumn<int>(
                name: "u_premium",
                table: "USER",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "o_status",
                table: "ORDER",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "d_status",
                table: "DELIVERER",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "d_vehicle",
                table: "DELIVERER",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "c_categorie",
                table: "COUPON",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "c_premium",
                table: "COUPON",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "c_value_type",
                table: "COUPON",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "cy_plan",
                table: "COMPANY",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "cy_type",
                table: "COMPANY",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ADDRESS_a_user_id",
                table: "ADDRESS",
                column: "a_user_id",
                unique: true);
        }
    }
}
