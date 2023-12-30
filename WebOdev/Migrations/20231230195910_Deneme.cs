using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebOdev.Migrations
{
    public partial class Deneme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adminler",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adminler", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "Ucaklar",
                columns: table => new
                {
                    UcakId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UcakAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KoltukSayisi = table.Column<int>(type: "int", nullable: false),
                    Fiyat = table.Column<double>(type: "float", nullable: false),
                    doluKoltukSayisi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ucaklar", x => x.UcakId);
                });

            migrationBuilder.CreateTable(
                name: "Biletler",
                columns: table => new
                {
                    BiletId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KalkisYeri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VarisYeri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GidisTarihi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DonusTarihi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KalkisSaat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UcakId = table.Column<int>(type: "int", nullable: false),
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adminler");

            migrationBuilder.DropTable(
                name: "Biletler");

            migrationBuilder.DropTable(
                name: "Ucaklar");
        }
    }
}
