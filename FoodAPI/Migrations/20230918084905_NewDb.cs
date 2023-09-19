using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodAPI.Migrations
{
    /// <inheritdoc />
    public partial class NewDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "COMPANY",
                columns: table => new
                {
                    cy_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cy_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    cy_description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    cy_email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    cy_password = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    cy_cnpj = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    cy_type = table.Column<int>(type: "int", nullable: false),
                    cy_plan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMPANY", x => x.cy_id);
                });

            migrationBuilder.CreateTable(
                name: "DELIVERER",
                columns: table => new
                {
                    d_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    d_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    d_email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    d_password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    d_cnh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    d_cpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    d_birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    d_phonenumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    d_cep = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    d_street = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    d_adressnumber = table.Column<int>(type: "int", maxLength: 6, nullable: false),
                    d_complement = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    d_status = table.Column<int>(type: "int", maxLength: 1, nullable: false),
                    d_vehicle = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DELIVERER", x => x.d_id);
                });

            migrationBuilder.CreateTable(
                name: "USER",
                columns: table => new
                {
                    u_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    u_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    u_email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    u_password = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    u_phonenumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    u_birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    u_cpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    u_premium = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER", x => x.u_id);
                });

            migrationBuilder.CreateTable(
                name: "MENU",
                columns: table => new
                {
                    m_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    m_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    m_description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    m_categories = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    m_price = table.Column<double>(type: "float", nullable: false),
                    m_discount = table.Column<double>(type: "float", nullable: false),
                    m_image = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    m_is_active = table.Column<bool>(type: "bit", nullable: false),
                    m_company_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MENU", x => x.m_id);
                    table.ForeignKey(
                        name: "FK_MENU_COMPANY_m_company_id",
                        column: x => x.m_company_id,
                        principalTable: "COMPANY",
                        principalColumn: "cy_id");
                });

            migrationBuilder.CreateTable(
                name: "DELIVERER_MOTORCICLE",
                columns: table => new
                {
                    dm_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    dm_plate = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    dm_renavam = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    dm_model = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    dm_year = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    dm_brand = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    dm_deliverer_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DELIVERER_MOTORCICLE", x => x.dm_id);
                    table.ForeignKey(
                        name: "FK_DELIVERER_MOTORCICLE_DELIVERER_dm_deliverer_id",
                        column: x => x.dm_deliverer_id,
                        principalTable: "DELIVERER",
                        principalColumn: "d_id");
                });

            migrationBuilder.CreateTable(
                name: "ADRESS",
                columns: table => new
                {
                    a_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    a_cep = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    a_street = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    a_adress_number = table.Column<int>(type: "int", maxLength: 6, nullable: false),
                    a_complement = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    a_receiver_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    a_user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "COUPON",
                columns: table => new
                {
                    c_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    c_code = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    c_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    c_description = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    c_menu_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    c_value = table.Column<double>(type: "float", nullable: false),
                    c_value_type = table.Column<int>(type: "int", nullable: false),
                    c_categorie = table.Column<int>(type: "int", maxLength: 8, nullable: false),
                    c_premium = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COUPON", x => x.c_id);
                    table.ForeignKey(
                        name: "FK_COUPON_MENU_c_menu_id",
                        column: x => x.c_menu_id,
                        principalTable: "MENU",
                        principalColumn: "m_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "COUPON_COMPANY",
                columns: table => new
                {
                    cc_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cc_coupon_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cc_company_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COUPON_COMPANY", x => x.cc_id);
                    table.ForeignKey(
                        name: "FK_COUPON_COMPANY_COMPANY_cc_company_id",
                        column: x => x.cc_company_id,
                        principalTable: "COMPANY",
                        principalColumn: "cy_id");
                    table.ForeignKey(
                        name: "FK_COUPON_COMPANY_COUPON_cc_coupon_id",
                        column: x => x.cc_coupon_id,
                        principalTable: "COUPON",
                        principalColumn: "c_id");
                });

            migrationBuilder.CreateTable(
                name: "COUPON_USER",
                columns: table => new
                {
                    cu_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cu_coupon_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cu_user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COUPON_USER", x => x.cu_id);
                    table.ForeignKey(
                        name: "FK_COUPON_USER_COUPON_cu_coupon_id",
                        column: x => x.cu_coupon_id,
                        principalTable: "COUPON",
                        principalColumn: "c_id");
                    table.ForeignKey(
                        name: "FK_COUPON_USER_USER_cu_user_id",
                        column: x => x.cu_user_id,
                        principalTable: "USER",
                        principalColumn: "u_id");
                });

            migrationBuilder.CreateTable(
                name: "ORDER",
                columns: table => new
                {
                    o_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    o_user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    o_company_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    o_coupon_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    o_deliverer_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    o_adress_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    o_value = table.Column<double>(type: "float", nullable: false),
                    o_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    o_status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDER", x => x.o_id);
                    table.ForeignKey(
                        name: "FK_ORDER_ADRESS_o_adress_id",
                        column: x => x.o_adress_id,
                        principalTable: "ADRESS",
                        principalColumn: "a_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ORDER_COMPANY_o_company_id",
                        column: x => x.o_company_id,
                        principalTable: "COMPANY",
                        principalColumn: "cy_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ORDER_COUPON_o_coupon_id",
                        column: x => x.o_coupon_id,
                        principalTable: "COUPON",
                        principalColumn: "c_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ORDER_DELIVERER_o_deliverer_id",
                        column: x => x.o_deliverer_id,
                        principalTable: "DELIVERER",
                        principalColumn: "d_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ORDER_USER_o_user_id",
                        column: x => x.o_user_id,
                        principalTable: "USER",
                        principalColumn: "u_id");
                });

            migrationBuilder.CreateTable(
                name: "ORDER_ITEM",
                columns: table => new
                {
                    oi_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    oi_menu_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    oi_amount = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    oi_value = table.Column<double>(type: "float", nullable: false),
                    oi_order_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDER_ITEM", x => x.oi_id);
                    table.ForeignKey(
                        name: "FK_ORDER_ITEM_MENU_oi_menu_id",
                        column: x => x.oi_menu_id,
                        principalTable: "MENU",
                        principalColumn: "m_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ORDER_ITEM_ORDER_oi_order_id",
                        column: x => x.oi_order_id,
                        principalTable: "ORDER",
                        principalColumn: "o_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ADRESS_a_user_id",
                table: "ADRESS",
                column: "a_user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Index_Company",
                table: "COMPANY",
                column: "cy_email");

            migrationBuilder.CreateIndex(
                name: "Index_Coupon",
                table: "COUPON",
                column: "c_code");

            migrationBuilder.CreateIndex(
                name: "IX_COUPON_c_menu_id",
                table: "COUPON",
                column: "c_menu_id");

            migrationBuilder.CreateIndex(
                name: "Index_CouponCompany",
                table: "COUPON_COMPANY",
                column: "cc_company_id");

            migrationBuilder.CreateIndex(
                name: "IX_COUPON_COMPANY_cc_company_id",
                table: "COUPON_COMPANY",
                column: "cc_company_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_COUPON_COMPANY_cc_coupon_id",
                table: "COUPON_COMPANY",
                column: "cc_coupon_id");

            migrationBuilder.CreateIndex(
                name: "Index_CouponUser",
                table: "COUPON_USER",
                column: "cu_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_COUPON_USER_cu_coupon_id",
                table: "COUPON_USER",
                column: "cu_coupon_id");

            migrationBuilder.CreateIndex(
                name: "IX_COUPON_USER_cu_user_id",
                table: "COUPON_USER",
                column: "cu_user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Index_Deliverer",
                table: "DELIVERER",
                columns: new[] { "d_email", "d_phonenumber" });

            migrationBuilder.CreateIndex(
                name: "Index_Motorcicle",
                table: "DELIVERER_MOTORCICLE",
                columns: new[] { "dm_deliverer_id", "dm_renavam", "dm_plate" });

            migrationBuilder.CreateIndex(
                name: "IX_DELIVERER_MOTORCICLE_dm_deliverer_id",
                table: "DELIVERER_MOTORCICLE",
                column: "dm_deliverer_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MENU_m_company_id",
                table: "MENU",
                column: "m_company_id");

            migrationBuilder.CreateIndex(
                name: "Index_Order",
                table: "ORDER",
                column: "o_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_o_adress_id",
                table: "ORDER",
                column: "o_adress_id");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_o_company_id",
                table: "ORDER",
                column: "o_company_id");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_o_coupon_id",
                table: "ORDER",
                column: "o_coupon_id");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_o_deliverer_id",
                table: "ORDER",
                column: "o_deliverer_id");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_ITEM_oi_menu_id",
                table: "ORDER_ITEM",
                column: "oi_menu_id");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_ITEM_oi_order_id",
                table: "ORDER_ITEM",
                column: "oi_order_id");

            migrationBuilder.CreateIndex(
                name: "Index_User",
                table: "USER",
                columns: new[] { "u_phonenumber", "u_email" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "COUPON_COMPANY");

            migrationBuilder.DropTable(
                name: "COUPON_USER");

            migrationBuilder.DropTable(
                name: "DELIVERER_MOTORCICLE");

            migrationBuilder.DropTable(
                name: "ORDER_ITEM");

            migrationBuilder.DropTable(
                name: "ORDER");

            migrationBuilder.DropTable(
                name: "ADRESS");

            migrationBuilder.DropTable(
                name: "COUPON");

            migrationBuilder.DropTable(
                name: "DELIVERER");

            migrationBuilder.DropTable(
                name: "USER");

            migrationBuilder.DropTable(
                name: "MENU");

            migrationBuilder.DropTable(
                name: "COMPANY");
        }
    }
}
