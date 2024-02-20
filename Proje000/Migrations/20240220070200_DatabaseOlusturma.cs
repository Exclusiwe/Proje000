using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proje000.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseOlusturma : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "personels",
                columns: table => new
                {
                    PersonelId = table.Column<int>(type: "int", nullable: false)
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
                    table.PrimaryKey("PK_personels", x => x.PersonelId);
                });

            migrationBuilder.CreateTable(
                name: "takims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TakimAdi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_takims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "vardiyas",
                columns: table => new
                {
                    VardiyaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VardiyaName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vardiyas", x => x.VardiyaId);
                });

            migrationBuilder.CreateTable(
                name: "yoneticils",
                columns: table => new
                {
                    YoneticiId = table.Column<int>(type: "int", nullable: false)
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
                    table.PrimaryKey("PK_yoneticils", x => x.YoneticiId);
                });

            migrationBuilder.CreateTable(
                name: "takimkayits",
                columns: table => new
                {
                    TakimKayitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    TakimId = table.Column<int>(type: "int", nullable: false),
                    VardiyaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_takimkayits", x => x.TakimKayitId);
                    table.ForeignKey(
                        name: "FK_takimkayits_personels_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "personels",
                        principalColumn: "PersonelId",
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
                        principalColumn: "VardiyaId",
                        onDelete: ReferentialAction.Cascade);
                });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "takimkayits");

            migrationBuilder.DropTable(
                name: "yoneticils");

            migrationBuilder.DropTable(
                name: "personels");

            migrationBuilder.DropTable(
                name: "takims");

            migrationBuilder.DropTable(
                name: "vardiyas");
        }
    }
}
