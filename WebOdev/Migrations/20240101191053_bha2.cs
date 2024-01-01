using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebOdev.Migrations
{
    public partial class bha2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Koltuk_Ucuslar_UcusId",
                table: "Koltuk");

            migrationBuilder.DropForeignKey(
                name: "FK_Sehir_Ucuslar_UcusId",
                table: "Sehir");

            migrationBuilder.DropIndex(
                name: "IX_Sehir_UcusId",
                table: "Sehir");

            migrationBuilder.DropIndex(
                name: "IX_Koltuk_UcusId",
                table: "Koltuk");

            migrationBuilder.DropColumn(
                name: "UcusId",
                table: "Sehir");

            migrationBuilder.DropColumn(
                name: "UcusId",
                table: "Koltuk");

            migrationBuilder.AddColumn<int>(
                name: "SehirId",
                table: "Ucuslar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "koltukId",
                table: "Ucuslar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ucuslar_koltukId",
                table: "Ucuslar",
                column: "koltukId");

            migrationBuilder.CreateIndex(
                name: "IX_Ucuslar_SehirId",
                table: "Ucuslar",
                column: "SehirId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ucuslar_Koltuk_koltukId",
                table: "Ucuslar",
                column: "koltukId",
                principalTable: "Koltuk",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ucuslar_Sehir_SehirId",
                table: "Ucuslar",
                column: "SehirId",
                principalTable: "Sehir",
                principalColumn: "SehirId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ucuslar_Koltuk_koltukId",
                table: "Ucuslar");

            migrationBuilder.DropForeignKey(
                name: "FK_Ucuslar_Sehir_SehirId",
                table: "Ucuslar");

            migrationBuilder.DropIndex(
                name: "IX_Ucuslar_koltukId",
                table: "Ucuslar");

            migrationBuilder.DropIndex(
                name: "IX_Ucuslar_SehirId",
                table: "Ucuslar");

            migrationBuilder.DropColumn(
                name: "SehirId",
                table: "Ucuslar");

            migrationBuilder.DropColumn(
                name: "koltukId",
                table: "Ucuslar");

            migrationBuilder.AddColumn<int>(
                name: "UcusId",
                table: "Sehir",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UcusId",
                table: "Koltuk",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sehir_UcusId",
                table: "Sehir",
                column: "UcusId");

            migrationBuilder.CreateIndex(
                name: "IX_Koltuk_UcusId",
                table: "Koltuk",
                column: "UcusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Koltuk_Ucuslar_UcusId",
                table: "Koltuk",
                column: "UcusId",
                principalTable: "Ucuslar",
                principalColumn: "UcusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sehir_Ucuslar_UcusId",
                table: "Sehir",
                column: "UcusId",
                principalTable: "Ucuslar",
                principalColumn: "UcusId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
