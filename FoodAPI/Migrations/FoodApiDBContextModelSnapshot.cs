﻿// <auto-generated />
using System;
using FoodAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FoodAPI.Migrations
{
    [DbContext(typeof(FoodApiDBContext))]
    partial class FoodApiDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FoodAPI.Model.Address", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("a_id");

                    b.Property<int>("AddressNumber")
                        .HasColumnType("int")
                        .HasColumnName("a_address_number");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)")
                        .HasColumnName("a_cep");

                    b.Property<string>("Complement")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("a_complement");

                    b.Property<string>("ReceiverName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("a_receiver_name");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("a_street");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("a_user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ADDRESS");
                });

            modelBuilder.Entity("FoodAPI.Model.Company", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("cy_id");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)")
                        .HasColumnName("cy_cnpj");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasColumnName("cy_description");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("cy_email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("cy_name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)")
                        .HasColumnName("cy_password");

                    b.Property<int>("Plan")
                        .HasColumnType("int")
                        .HasColumnName("cy_plan");

                    b.Property<int>("Type")
                        .HasColumnType("int")
                        .HasColumnName("cy_type");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Email" }, "Index_Company");

                    b.ToTable("COMPANY");
                });

            modelBuilder.Entity("FoodAPI.Model.Coupon", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("c_id");

                    b.Property<int>("Categorie")
                        .HasColumnType("int")
                        .HasColumnName("c_categorie");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("c_code");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasColumnName("c_description");

                    b.Property<Guid?>("MenuID")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("c_menu_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("c_name");

                    b.Property<int>("Premium")
                        .HasColumnType("int")
                        .HasColumnName("c_premium");

                    b.Property<int>("V_Type")
                        .HasColumnType("int")
                        .HasColumnName("c_value_type");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("c_value");

                    b.HasKey("Id");

                    b.HasIndex("MenuID");

                    b.HasIndex(new[] { "Code" }, "Index_Coupon");

                    b.ToTable("COUPON");
                });

            modelBuilder.Entity("FoodAPI.Model.CouponCompanyRel", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("cc_id");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("cc_company_id");

                    b.Property<Guid>("CouponId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("cc_coupon_id");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId")
                        .IsUnique();

                    b.HasIndex("CouponId");

                    b.HasIndex(new[] { "CompanyId" }, "Index_CouponCompany");

                    b.ToTable("COUPON_COMPANY");
                });

            modelBuilder.Entity("FoodAPI.Model.CouponUserRel", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("cu_id");

                    b.Property<Guid>("CouponId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("cu_coupon_id");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("cu_user_id");

                    b.HasKey("Id");

                    b.HasIndex("CouponId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.HasIndex(new[] { "UserId" }, "Index_CouponUser");

                    b.ToTable("COUPON_USER");
                });

            modelBuilder.Entity("FoodAPI.Model.Deliverer", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("d_id");

                    b.Property<int>("AddressNumber")
                        .HasColumnType("int")
                        .HasColumnName("d_addressnumber");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2")
                        .HasColumnName("d_birthday");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)")
                        .HasColumnName("d_cep");

                    b.Property<string>("CNH")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("d_cnh");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)")
                        .HasColumnName("d_cpf");

                    b.Property<string>("Complement")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("d_complement");

                    b.Property<int>("DelivererVehicle")
                        .HasColumnType("int")
                        .HasColumnName("d_vehicle");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("d_email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("d_name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)")
                        .HasColumnName("d_password");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)")
                        .HasColumnName("d_phonenumber");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("d_status");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("d_street");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Email", "PhoneNumber" }, "Index_Deliverer");

                    b.ToTable("DELIVERER");
                });

            modelBuilder.Entity("FoodAPI.Model.DelivererMotorcicle", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("dm_id");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("dm_brand");

                    b.Property<Guid>("DelivererId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("dm_deliverer_id");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("dm_model");

                    b.Property<string>("Plate")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)")
                        .HasColumnName("dm_plate");

                    b.Property<string>("Renavam")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)")
                        .HasColumnName("dm_renavam");

                    b.Property<int>("Year")
                        .HasColumnType("int")
                        .HasColumnName("dm_year");

                    b.HasKey("Id");

                    b.HasIndex("DelivererId")
                        .IsUnique();

                    b.HasIndex(new[] { "DelivererId", "Renavam", "Plate" }, "Index_Motorcicle");

                    b.ToTable("DELIVERER_MOTORCICLE");
                });

            modelBuilder.Entity("FoodAPI.Model.Item", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("oi_id");

                    b.Property<int>("Amount")
                        .HasColumnType("int")
                        .HasColumnName("oi_amount");

                    b.Property<Guid>("MenuId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("oi_menu_id");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("oi_order_id");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("oi_value");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.HasIndex("OrderId");

                    b.ToTable("ORDER_ITEM");
                });

            modelBuilder.Entity("FoodAPI.Model.Menu", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("m_id");

                    b.Property<string>("Categories")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("m_categories");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("m_company_id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasColumnName("m_description");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("m_discount");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("m_image");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("m_is_active");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("m_name");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("m_price");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("MENU");
                });

            modelBuilder.Entity("FoodAPI.Model.Order", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("o_id");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("o_address_id");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("o_company_id");

                    b.Property<Guid>("CouponId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("o_coupon_id");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("o_date");

                    b.Property<Guid>("DelivererId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("o_deliverer_id");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("o_status");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("o_user_id");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("o_value");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("CouponId");

                    b.HasIndex("DelivererId");

                    b.HasIndex(new[] { "UserId" }, "Index_Order");

                    b.ToTable("ORDER");
                });

            modelBuilder.Entity("FoodAPI.Model.User", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("u_id");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2")
                        .HasColumnName("u_birthday");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)")
                        .HasColumnName("u_cpf");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("u_email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("u_name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)")
                        .HasColumnName("u_password");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)")
                        .HasColumnName("u_phonenumber");

                    b.Property<int>("Premium")
                        .HasColumnType("int")
                        .HasColumnName("u_premium");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "PhoneNumber", "Email" }, "Index_User");

                    b.ToTable("USER");
                });

            modelBuilder.Entity("FoodAPI.Model.Address", b =>
                {
                    b.HasOne("FoodAPI.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FoodAPI.Model.Coupon", b =>
                {
                    b.HasOne("FoodAPI.Model.Menu", "Menu")
                        .WithMany()
                        .HasForeignKey("MenuID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menu");
                });

            modelBuilder.Entity("FoodAPI.Model.CouponCompanyRel", b =>
                {
                    b.HasOne("FoodAPI.Model.Company", "Company")
                        .WithOne()
                        .HasForeignKey("FoodAPI.Model.CouponCompanyRel", "CompanyId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FoodAPI.Model.Coupon", "Coupon")
                        .WithMany("CompanyRel")
                        .HasForeignKey("CouponId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Coupon");
                });

            modelBuilder.Entity("FoodAPI.Model.CouponUserRel", b =>
                {
                    b.HasOne("FoodAPI.Model.Coupon", "Coupon")
                        .WithMany("UserRel")
                        .HasForeignKey("CouponId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FoodAPI.Model.User", "User")
                        .WithOne()
                        .HasForeignKey("FoodAPI.Model.CouponUserRel", "UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Coupon");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FoodAPI.Model.DelivererMotorcicle", b =>
                {
                    b.HasOne("FoodAPI.Model.Deliverer", "Deliverer")
                        .WithOne()
                        .HasForeignKey("FoodAPI.Model.DelivererMotorcicle", "DelivererId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Deliverer");
                });

            modelBuilder.Entity("FoodAPI.Model.Item", b =>
                {
                    b.HasOne("FoodAPI.Model.Menu", "Menu")
                        .WithMany()
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodAPI.Model.Order", "Order")
                        .WithMany("Itens")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Menu");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("FoodAPI.Model.Menu", b =>
                {
                    b.HasOne("FoodAPI.Model.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("FoodAPI.Model.Order", b =>
                {
                    b.HasOne("FoodAPI.Model.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodAPI.Model.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodAPI.Model.Coupon", "Coupon")
                        .WithMany()
                        .HasForeignKey("CouponId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodAPI.Model.Deliverer", "Deliverer")
                        .WithMany()
                        .HasForeignKey("DelivererId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodAPI.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Company");

                    b.Navigation("Coupon");

                    b.Navigation("Deliverer");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FoodAPI.Model.Coupon", b =>
                {
                    b.Navigation("CompanyRel");

                    b.Navigation("UserRel");
                });

            modelBuilder.Entity("FoodAPI.Model.Order", b =>
                {
                    b.Navigation("Itens");
                });
#pragma warning restore 612, 618
        }
    }
}
