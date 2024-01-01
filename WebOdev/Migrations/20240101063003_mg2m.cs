using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebOdev.Migrations
{
    public partial class mg2m : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adminler");

            migrationBuilder.DropTable(
                name: "Biletler");

            migrationBuilder.CreateTable(
                name: "AdminTbl",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminTbl", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "BiletTbl",
                columns: table => new
                {
                    BiletId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KalkisYeri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VarisYeri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GidisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DonusTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KalkisSaat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UcakId = table.Column<int>(type: "int", nullable: false),
                    KoltukNumarasi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BiletTbl", x => x.BiletId);
                    table.ForeignKey(
                        name: "FK_BiletTbl_Ucaklar_UcakId",
                        column: x => x.UcakId,
                        principalTable: "Ucaklar",
                        principalColumn: "UcakId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KullaniciTbl",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    IdentityNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KullaniciTbl", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Ucuslar",
                columns: table => new
                {
                    UcusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nereden = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nereye = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GidisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DonusTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KalkisSaat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VarisSaat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UcakId = table.Column<int>(type: "int", nullable: false),
                    doluKoltukSayisi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ucuslar", x => x.UcusId);
                    table.ForeignKey(
                        name: "FK_Ucuslar_Ucaklar_UcakId",
                        column: x => x.UcakId,
                        principalTable: "Ucaklar",
                        principalColumn: "UcakId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Koltuk",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KoltukNo = table.Column<int>(type: "int", nullable: false),
                    Dolumu = table.Column<bool>(type: "bit", nullable: false),
                    UcakId = table.Column<int>(type: "int", nullable: false),
                    UcusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Koltuk", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Koltuk_Ucaklar_UcakId",
                        column: x => x.UcakId,
                        principalTable: "Ucaklar",
                        principalColumn: "UcakId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Koltuk_Ucuslar_UcusId",
                        column: x => x.UcusId,
                        principalTable: "Ucuslar",
                        principalColumn: "UcusId");
                });

            migrationBuilder.CreateTable(
                name: "Sehir",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SehirAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UcusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sehir", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sehir_Ucuslar_UcusId",
                        column: x => x.UcusId,
                        principalTable: "Ucuslar",
                        principalColumn: "UcusId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BiletTbl_UcakId",
                table: "BiletTbl",
                column: "UcakId");

            migrationBuilder.CreateIndex(
                name: "IX_Koltuk_UcakId",
                table: "Koltuk",
                column: "UcakId");

            migrationBuilder.CreateIndex(
                name: "IX_Koltuk_UcusId",
                table: "Koltuk",
                column: "UcusId");

            migrationBuilder.CreateIndex(
                name: "IX_Sehir_UcusId",
                table: "Sehir",
                column: "UcusId");

            migrationBuilder.CreateIndex(
                name: "IX_Ucuslar_UcakId",
                table: "Ucuslar",
                column: "UcakId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminTbl");

            migrationBuilder.DropTable(
                name: "BiletTbl");

            migrationBuilder.DropTable(
                name: "Koltuk");

            migrationBuilder.DropTable(
                name: "KullaniciTbl");

            migrationBuilder.DropTable(
                name: "Sehir");

            migrationBuilder.DropTable(
                name: "Ucuslar");

            migrationBuilder.CreateTable(
                name: "Adminler",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adminler", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "Biletler",
                columns: table => new
                {
                    BiletId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UcakId = table.Column<int>(type: "int", nullable: false),
                    DonusTarihi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GidisTarihi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KalkisSaat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KalkisYeri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VarisYeri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    koltukNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biletler", x => x.BiletId);
                    table.ForeignKey(
                        name: "FK_Biletler_Ucaklar_UcakId",
                        column: x => x.UcakId,
                        principalTable: "Ucaklar",
                        principalColumn: "UcakId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Biletler_UcakId",
                table: "Biletler",
                column: "UcakId");
        }
    }
}
