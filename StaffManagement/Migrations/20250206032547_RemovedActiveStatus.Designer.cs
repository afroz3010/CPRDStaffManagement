﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StaffManagement.Data;

#nullable disable

namespace StaffManagement.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250206032547_RemovedActiveStatus")]
    partial class RemovedActiveStatus
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StaffManagement.Models.Grant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Grants");
                });

            modelBuilder.Entity("StaffManagement.Models.Staff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CertificationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("StaffManagement.Models.StaffGrant", b =>
                {
                    b.Property<int>("StaffId")
                        .HasColumnType("int");

                    b.Property<int>("GrantId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("StaffId", "GrantId");

                    b.HasIndex("GrantId");

                    b.ToTable("StaffGrants");
                });

            modelBuilder.Entity("StaffManagement.Models.StaffGrant", b =>
                {
                    b.HasOne("StaffManagement.Models.Grant", "Grant")
                        .WithMany("StaffGrants")
                        .HasForeignKey("GrantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StaffManagement.Models.Staff", "Staff")
                        .WithMany("StaffGrants")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grant");

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("StaffManagement.Models.Grant", b =>
                {
                    b.Navigation("StaffGrants");
                });

            modelBuilder.Entity("StaffManagement.Models.Staff", b =>
                {
                    b.Navigation("StaffGrants");
                });
#pragma warning restore 612, 618
        }
    }
}
