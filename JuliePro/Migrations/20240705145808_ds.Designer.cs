﻿// <auto-generated />
using System;
using JuliePro.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JuliePro.Migrations
{
    [DbContext(typeof(JulieProDbContext))]
    [Migration("20240705145808_ds")]
    partial class ds
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("JuliePro.Models.Certification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CertificationCenter")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Certifications");
                });

            modelBuilder.Entity("JuliePro.Models.Discipline", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Parent_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Parent_Id");

                    b.ToTable("Disciplines");
                });

            modelBuilder.Entity("JuliePro.Models.Record", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Discipline_Id")
                        .HasColumnType("int");

                    b.Property<int?>("Trainer_Id")
                        .HasColumnType("int");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Discipline_Id");

                    b.HasIndex("Trainer_Id");

                    b.ToTable("Records");
                });

            modelBuilder.Entity("JuliePro.Models.Trainer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Biography")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Discipline_Id")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int>("Genre")
                        .HasColumnType("int");

                    b.Property<bool>("IsFavorite")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Photo")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.HasIndex("Discipline_Id");

                    b.ToTable("Trainers");
                });

            modelBuilder.Entity("JuliePro.Models.TrainerCertification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Certification_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCertification")
                        .HasColumnType("datetime2");

                    b.Property<int>("Trainer_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Certification_Id");

                    b.HasIndex("Trainer_Id");

                    b.ToTable("TrainerCertifications");
                });

            modelBuilder.Entity("JuliePro.Models.Discipline", b =>
                {
                    b.HasOne("JuliePro.Models.Discipline", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("Parent_Id");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("JuliePro.Models.Record", b =>
                {
                    b.HasOne("JuliePro.Models.Discipline", "Discipline")
                        .WithMany("TrainerPersonalRecords")
                        .HasForeignKey("Discipline_Id");

                    b.HasOne("JuliePro.Models.Trainer", "Trainer")
                        .WithMany("Records")
                        .HasForeignKey("Trainer_Id");

                    b.Navigation("Discipline");

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("JuliePro.Models.Trainer", b =>
                {
                    b.HasOne("JuliePro.Models.Discipline", "Discipline")
                        .WithMany("Trainers")
                        .HasForeignKey("Discipline_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Discipline");
                });

            modelBuilder.Entity("JuliePro.Models.TrainerCertification", b =>
                {
                    b.HasOne("JuliePro.Models.Certification", "Certification")
                        .WithMany("TrainerCertifications")
                        .HasForeignKey("Certification_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JuliePro.Models.Trainer", "Trainer")
                        .WithMany("TrainerCertifications")
                        .HasForeignKey("Trainer_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Certification");

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("JuliePro.Models.Certification", b =>
                {
                    b.Navigation("TrainerCertifications");
                });

            modelBuilder.Entity("JuliePro.Models.Discipline", b =>
                {
                    b.Navigation("Children");

                    b.Navigation("TrainerPersonalRecords");

                    b.Navigation("Trainers");
                });

            modelBuilder.Entity("JuliePro.Models.Trainer", b =>
                {
                    b.Navigation("Records");

                    b.Navigation("TrainerCertifications");
                });
#pragma warning restore 612, 618
        }
    }
}
