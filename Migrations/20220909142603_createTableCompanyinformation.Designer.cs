﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using apisistec.Context;

#nullable disable

namespace apisistec.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220909142603_createTableCompanyinformation")]
    partial class createTableCompanyinformation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("apisistec.Entities.CompanyInformation", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(36)")
                        .HasColumnName("id");

                    b.Property<string>("AboutUs")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("")
                        .HasColumnName("about_Us");

                    b.Property<string>("Devolution")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("longtext")
                        .HasDefaultValue("")
                        .HasColumnName("devolution");

                    b.Property<string>("Direction")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasColumnName("direction");

                    b.Property<string>("Email")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(100)")
                        .HasDefaultValue("")
                        .HasColumnName("email");

                    b.Property<string>("FacebookUrl")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)")
                        .HasDefaultValue("")
                        .HasColumnName("facebook_url");

                    b.Property<string>("Faq")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("")
                        .HasColumnName("faq");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(36)")
                        .HasColumnName("name");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasColumnName("phone");

                    b.Property<string>("Politics")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("politics");

                    b.Property<string>("StoreAddress")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(150)")
                        .HasDefaultValue("")
                        .HasColumnName("store_address");

                    b.Property<string>("TermsAndConditions")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("")
                        .HasColumnName("terms_and_conditions");

                    b.Property<string>("WhatsappMessage")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(250)")
                        .HasDefaultValue("")
                        .HasColumnName("whatsapp_message");

                    b.Property<string>("YoutubeUrl")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)")
                        .HasDefaultValue("")
                        .HasColumnName("youtube_url");

                    b.Property<string>("whatsappNumber")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(10)")
                        .HasDefaultValue("")
                        .HasColumnName("whatsapp_number");

                    b.HasKey("Id");

                    b.ToTable("plnp_company_information", (string)null);
                });

            modelBuilder.Entity("apisistec.Entities.PlanDetail", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("VARCHAR(36)")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)")
                        .HasColumnName("description");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.ToTable("plnp_plandetail", (string)null);
                });

            modelBuilder.Entity("apisistec.Entities.PlanHeader", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("VARCHAR(36)")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("'1990-01-01 00:00:00'");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)")
                        .HasColumnName("description");

                    b.Property<decimal>("DiscountPercent")
                        .HasColumnType("DECIMAL(16,4)")
                        .HasColumnName("discount_percent");

                    b.Property<DateTime>("EndAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasColumnName("end_at")
                        .HasDefaultValueSql("'1990-01-01 00:00:00'");

                    b.Property<decimal>("PastDiscountPercent")
                        .HasColumnType("DECIMAL(16,4)")
                        .HasColumnName("past_discount_percent");

                    b.Property<decimal>("PastPrice")
                        .HasColumnType("DECIMAL(16,4)")
                        .HasColumnName("past_price");

                    b.Property<decimal>("Price")
                        .HasColumnType("DECIMAL(16,4)")
                        .HasColumnName("price");

                    b.Property<int>("RucQty")
                        .HasColumnType("int(4)")
                        .HasColumnName("ruc_qty");

                    b.Property<DateTime>("StartAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasColumnName("start_at")
                        .HasDefaultValueSql("'1990-01-01 00:00:00'");

                    b.Property<int>("State")
                        .HasColumnType("int(1)")
                        .HasColumnName("state")
                        .HasComment("0: DISABLED, 1: ENABLED");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("title");

                    b.Property<int>("TransacctionQty")
                        .HasColumnType("int(4)")
                        .HasColumnName("transacction_qty");

                    b.HasKey("Id");

                    b.ToTable("plnp_planheader", (string)null);
                });

            modelBuilder.Entity("apisistec.Entities.PlanHeaderXDetail", b =>
                {
                    b.Property<string>("PlanHeaderId")
                        .HasColumnType("VARCHAR(36)")
                        .HasColumnName("FK_plan_header");

                    b.Property<string>("PlanDetailId")
                        .HasColumnType("VARCHAR(36)")
                        .HasColumnName("FK_plan_detail");

                    b.Property<int>("Order")
                        .HasColumnType("int(2)")
                        .HasColumnName("order");

                    b.HasKey("PlanHeaderId", "PlanDetailId")
                        .HasName("foreign_keys");

                    b.HasIndex("PlanDetailId");

                    b.ToTable("plnp_planheadersxdetails", (string)null);
                });

            modelBuilder.Entity("apisistec.Entities.senderMailsConfig", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("varchar(36)")
                        .HasColumnName("id");

                    b.Property<string>("host")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasColumnName("host");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasColumnName("password");

                    b.Property<int>("port")
                        .HasColumnType("int(3)")
                        .HasColumnName("port");

                    b.Property<int>("ssl")
                        .HasColumnType("int(1)")
                        .HasColumnName("ssl");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("varchar(80)")
                        .HasColumnName("username");

                    b.HasKey("id");

                    b.ToTable("plnp_senderMailsConfig", (string)null);
                });

            modelBuilder.Entity("apisistec.Entities.TemplateMails", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("varchar(36)")
                        .HasColumnName("name");

                    b.Property<string>("template")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("template");

                    b.HasKey("id");

                    b.ToTable("plnp_TemplateMails", (string)null);
                });

            modelBuilder.Entity("apisistec.Entities.Users", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("VARCHAR(36)")
                        .HasColumnName("id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(25)")
                        .HasColumnName("email");

                    b.Property<int>("EmailVerified")
                        .HasColumnType("int(1)")
                        .HasColumnName("email_verified")
                        .HasComment("0: DISABLED, 1: ENABLED");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(25)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(25)")
                        .HasColumnName("last_name");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("BLOB")
                        .HasColumnName("password_hash");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("BLOB")
                        .HasColumnName("password_salt");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("VARCHAR(15)")
                        .HasColumnName("phone");

                    b.Property<DateTime>("RegistrationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("'1990-01-01 00:00:00'");

                    b.Property<int>("State")
                        .HasColumnType("int(1)")
                        .HasColumnName("state")
                        .HasComment("0: DISABLED, 1: ENABLED");

                    b.HasKey("Id");

                    b.ToTable("plnp_users", (string)null);
                });

            modelBuilder.Entity("apisistec.Entities.PlanHeaderXDetail", b =>
                {
                    b.HasOne("apisistec.Entities.PlanDetail", "Detail")
                        .WithMany("PlanHeaderXDetail")
                        .HasForeignKey("PlanDetailId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("apisistec.Entities.PlanHeader", "Header")
                        .WithMany("PlanHeaderXDetail")
                        .HasForeignKey("PlanHeaderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Detail");

                    b.Navigation("Header");
                });

            modelBuilder.Entity("apisistec.Entities.PlanDetail", b =>
                {
                    b.Navigation("PlanHeaderXDetail");
                });

            modelBuilder.Entity("apisistec.Entities.PlanHeader", b =>
                {
                    b.Navigation("PlanHeaderXDetail");
                });
#pragma warning restore 612, 618
        }
    }
}