﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proje000.Data;

#nullable disable

namespace Proje000.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Proje000.Data.Personel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Adres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Aktif")
                        .HasColumnType("bit");

                    b.Property<string>("KullaniciAdi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Soyadi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TakimId")
                        .HasColumnType("int");

                    b.Property<string>("TelefonNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Unvan")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TakimId");

                    b.ToTable("personels");
                });

            modelBuilder.Entity("Proje000.Data.Takim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("TakimAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("YoneticiId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("YoneticiId");

                    b.ToTable("takims");
                });

            modelBuilder.Entity("Proje000.Data.TakimKayit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PersonelId")
                        .HasColumnType("int");

                    b.Property<int>("TakimId")
                        .HasColumnType("int");

                    b.Property<int>("VardiyaId")
                        .HasColumnType("int");

                    b.Property<int>("YoneticiId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonelId");

                    b.HasIndex("TakimId");

                    b.HasIndex("VardiyaId");

                    b.HasIndex("YoneticiId");

                    b.ToTable("takimkayits");
                });

            modelBuilder.Entity("Proje000.Data.Vardiya", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("datetime2");

                    b.Property<string>("VardiyaName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("vardiyas");
                });

            modelBuilder.Entity("Proje000.Data.Yonetici", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Adres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Aktif")
                        .HasColumnType("bit");

                    b.Property<string>("KullaniciAdi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Soyadi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelefonNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Unvan")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("yoneticis");
                });

            modelBuilder.Entity("Proje000.Data.Personel", b =>
                {
                    b.HasOne("Proje000.Data.Takim", "Takim")
                        .WithMany("personels")
                        .HasForeignKey("TakimId");

                    b.Navigation("Takim");
                });

            modelBuilder.Entity("Proje000.Data.Takim", b =>
                {
                    b.HasOne("Proje000.Data.Yonetici", "Yonetici")
                        .WithMany("takims")
                        .HasForeignKey("YoneticiId");

                    b.Navigation("Yonetici");
                });

            modelBuilder.Entity("Proje000.Data.TakimKayit", b =>
                {
                    b.HasOne("Proje000.Data.Personel", "Personel")
                        .WithMany("TakimKayit")
                        .HasForeignKey("PersonelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proje000.Data.Takim", "Takim")
                        .WithMany("TakimKayit")
                        .HasForeignKey("TakimId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proje000.Data.Vardiya", "Vardiya")
                        .WithMany("TakimKayit")
                        .HasForeignKey("VardiyaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proje000.Data.Yonetici", "Yonetici")
                        .WithMany("TakimKayit")
                        .HasForeignKey("YoneticiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Personel");

                    b.Navigation("Takim");

                    b.Navigation("Vardiya");

                    b.Navigation("Yonetici");
                });

            modelBuilder.Entity("Proje000.Data.Personel", b =>
                {
                    b.Navigation("TakimKayit");
                });

            modelBuilder.Entity("Proje000.Data.Takim", b =>
                {
                    b.Navigation("TakimKayit");

                    b.Navigation("personels");
                });

            modelBuilder.Entity("Proje000.Data.Vardiya", b =>
                {
                    b.Navigation("TakimKayit");
                });

            modelBuilder.Entity("Proje000.Data.Yonetici", b =>
                {
                    b.Navigation("TakimKayit");

                    b.Navigation("takims");
                });
#pragma warning restore 612, 618
        }
    }
}
