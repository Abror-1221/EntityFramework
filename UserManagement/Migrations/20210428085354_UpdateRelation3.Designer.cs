﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserManagement.Context;

namespace UserManagement.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20210428085354_UpdateRelation3")]
    partial class UpdateRelation3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UserManagement.Models.Accounts", b =>
                {
                    b.Property<string>("NIK")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NIK");

                    b.ToTable("tb_m_account");
                });

            modelBuilder.Entity("UserManagement.Models.Educations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Degree")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GPA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("University_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("University_Id");

                    b.ToTable("tb_m_education");
                });

            modelBuilder.Entity("UserManagement.Models.Persons", b =>
                {
                    b.Property<string>("NIK")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.HasKey("NIK");

                    b.ToTable("tb_m_person");
                });

            modelBuilder.Entity("UserManagement.Models.Profilings", b =>
                {
                    b.Property<string>("NIK")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("Education_Id")
                        .HasColumnType("int");

                    b.HasKey("NIK");

                    b.HasIndex("Education_Id");

                    b.ToTable("tb_m_profiling");
                });

            modelBuilder.Entity("UserManagement.Models.Universities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tb_m_university");
                });

            modelBuilder.Entity("UserManagement.Models.Accounts", b =>
                {
                    b.HasOne("UserManagement.Models.Persons", "Person")
                        .WithOne("Account")
                        .HasForeignKey("UserManagement.Models.Accounts", "NIK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("UserManagement.Models.Educations", b =>
                {
                    b.HasOne("UserManagement.Models.Universities", "Universities")
                        .WithMany("Educations")
                        .HasForeignKey("University_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Universities");
                });

            modelBuilder.Entity("UserManagement.Models.Profilings", b =>
                {
                    b.HasOne("UserManagement.Models.Educations", "Education_")
                        .WithMany("Profilings")
                        .HasForeignKey("Education_Id");

                    b.HasOne("UserManagement.Models.Accounts", "Account")
                        .WithOne("Profiling")
                        .HasForeignKey("UserManagement.Models.Profilings", "NIK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Education_");
                });

            modelBuilder.Entity("UserManagement.Models.Accounts", b =>
                {
                    b.Navigation("Profiling");
                });

            modelBuilder.Entity("UserManagement.Models.Educations", b =>
                {
                    b.Navigation("Profilings");
                });

            modelBuilder.Entity("UserManagement.Models.Persons", b =>
                {
                    b.Navigation("Account");
                });

            modelBuilder.Entity("UserManagement.Models.Universities", b =>
                {
                    b.Navigation("Educations");
                });
#pragma warning restore 612, 618
        }
    }
}
