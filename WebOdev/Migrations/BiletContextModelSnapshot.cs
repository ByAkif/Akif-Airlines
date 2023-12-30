﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebOdev.Models;

#nullable disable

namespace WebOdev.Migrations
{
    [DbContext(typeof(BiletContext))]
    partial class BiletContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebOdev.Models.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminId"), 1L, 1);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdminId");

                    b.ToTable("Adminler");
                });

            modelBuilder.Entity("WebOdev.Models.Bilet", b =>
                {
                    b.Property<int>("BiletId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BiletId"), 1L, 1);

                    b.Property<string>("DonusTarihi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GidisTarihi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KalkisSaat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KalkisYeri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UcakId")
                        .HasColumnType("int");

                    b.Property<string>("VarisYeri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("koltukNo")
                        .HasColumnType("int");

                    b.HasKey("BiletId");

                    b.HasIndex("UcakId");

                    b.ToTable("Biletler");
                });

            modelBuilder.Entity("WebOdev.Models.Ucak", b =>
                {
                    b.Property<int>("UcakId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UcakId"), 1L, 1);

                    b.Property<double>("Fiyat")
                        .HasColumnType("float");

                    b.Property<int>("KoltukSayisi")
                        .HasColumnType("int");

                    b.Property<string>("UcakAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("doluKoltukSayisi")
                        .HasColumnType("int");

                    b.HasKey("UcakId");

                    b.ToTable("Ucaklar");
                });

            modelBuilder.Entity("WebOdev.Models.Bilet", b =>
                {
                    b.HasOne("WebOdev.Models.Ucak", "Ucak")
                        .WithMany()
                        .HasForeignKey("UcakId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ucak");
                });
#pragma warning restore 612, 618
        }
    }
}
