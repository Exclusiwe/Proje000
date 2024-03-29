﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proje000.Migrations
{
    /// <inheritdoc />
    public partial class DataBaseD1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "vardiyas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VardiyaName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vardiyas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "yoneticis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Soyadi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unvan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_yoneticis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "takims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TakimAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YoneticiId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_takims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_takims_yoneticis_YoneticiId",
                        column: x => x.YoneticiId,
                        principalTable: "yoneticis",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "personels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Soyadi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unvan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    TakimId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_personels_takims_TakimId",
                        column: x => x.TakimId,
                        principalTable: "takims",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "takimkayits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelId = table.Column<int>(type: "int", nullable: false),
                    TakimId = table.Column<int>(type: "int", nullable: false),
                    VardiyaId = table.Column<int>(type: "int", nullable: false),
                    YoneticiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_takimkayits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_takimkayits_personels_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "personels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_takimkayits_takims_TakimId",
                        column: x => x.TakimId,
                        principalTable: "takims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_takimkayits_vardiyas_VardiyaId",
                        column: x => x.VardiyaId,
                        principalTable: "vardiyas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_takimkayits_yoneticis_YoneticiId",
                        column: x => x.YoneticiId,
                        principalTable: "yoneticis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_personels_TakimId",
                table: "personels",
                column: "TakimId");

            migrationBuilder.CreateIndex(
                name: "IX_takimkayits_PersonelId",
                table: "takimkayits",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_takimkayits_TakimId",
                table: "takimkayits",
                column: "TakimId");

            migrationBuilder.CreateIndex(
                name: "IX_takimkayits_VardiyaId",
                table: "takimkayits",
                column: "VardiyaId");

            migrationBuilder.CreateIndex(
                name: "IX_takimkayits_YoneticiId",
                table: "takimkayits",
                column: "YoneticiId");

            migrationBuilder.CreateIndex(
                name: "IX_takims_YoneticiId",
                table: "takims",
                column: "YoneticiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "takimkayits");

            migrationBuilder.DropTable(
                name: "personels");

            migrationBuilder.DropTable(
                name: "vardiyas");

            migrationBuilder.DropTable(
                name: "takims");

            migrationBuilder.DropTable(
                name: "yoneticis");
        }
    }
}
