using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebOdev.Migrations
{
    public partial class sdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BiletTbl_UcakTbl_UcakId",
                table: "BiletTbl");

            migrationBuilder.DropForeignKey(
                name: "FK_Koltuk_UcakTbl_UcakId",
                table: "Koltuk");

            migrationBuilder.DropForeignKey(
                name: "FK_Sehir_Ucuslar_UcusId",
                table: "Sehir");

            migrationBuilder.DropForeignKey(
                name: "FK_Ucuslar_UcakTbl_UcakId",
                table: "Ucuslar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UcakTbl",
                table: "UcakTbl");

            migrationBuilder.RenameTable(
                name: "UcakTbl",
                newName: "Ucaklar");

            migrationBuilder.AlterColumn<int>(
                name: "UcusId",
                table: "Sehir",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BiletId",
                table: "Koltuk",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "KoltukNumarasi",
                table: "BiletTbl",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ucaklar",
                table: "Ucaklar",
                column: "UcakId");

            migrationBuilder.CreateIndex(
                name: "IX_Koltuk_BiletId",
                table: "Koltuk",
                column: "BiletId");

            migrationBuilder.AddForeignKey(
                name: "FK_BiletTbl_Ucaklar_UcakId",
                table: "BiletTbl",
                column: "UcakId",
                principalTable: "Ucaklar",
                principalColumn: "UcakId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Koltuk_BiletTbl_BiletId",
                table: "Koltuk",
                column: "BiletId",
                principalTable: "BiletTbl",
                principalColumn: "BiletId");

            migrationBuilder.AddForeignKey(
                name: "FK_Koltuk_Ucaklar_UcakId",
                table: "Koltuk",
                column: "UcakId",
                principalTable: "Ucaklar",
                principalColumn: "UcakId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sehir_Ucuslar_UcusId",
                table: "Sehir",
                column: "UcusId",
                principalTable: "Ucuslar",
                principalColumn: "UcusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ucuslar_Ucaklar_UcakId",
                table: "Ucuslar",
                column: "UcakId",
                principalTable: "Ucaklar",
                principalColumn: "UcakId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BiletTbl_Ucaklar_UcakId",
                table: "BiletTbl");

            migrationBuilder.DropForeignKey(
                name: "FK_Koltuk_BiletTbl_BiletId",
                table: "Koltuk");

            migrationBuilder.DropForeignKey(
                name: "FK_Koltuk_Ucaklar_UcakId",
                table: "Koltuk");

            migrationBuilder.DropForeignKey(
                name: "FK_Sehir_Ucuslar_UcusId",
                table: "Sehir");

            migrationBuilder.DropForeignKey(
                name: "FK_Ucuslar_Ucaklar_UcakId",
                table: "Ucuslar");

            migrationBuilder.DropIndex(
                name: "IX_Koltuk_BiletId",
                table: "Koltuk");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ucaklar",
                table: "Ucaklar");

            migrationBuilder.DropColumn(
                name: "BiletId",
                table: "Koltuk");

            migrationBuilder.RenameTable(
                name: "Ucaklar",
                newName: "UcakTbl");

            migrationBuilder.AlterColumn<int>(
                name: "UcusId",
                table: "Sehir",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "KoltukNumarasi",
                table: "BiletTbl",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UcakTbl",
                table: "UcakTbl",
                column: "UcakId");

            migrationBuilder.AddForeignKey(
                name: "FK_BiletTbl_UcakTbl_UcakId",
                table: "BiletTbl",
                column: "UcakId",
                principalTable: "UcakTbl",
                principalColumn: "UcakId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Koltuk_UcakTbl_UcakId",
                table: "Koltuk",
                column: "UcakId",
                principalTable: "UcakTbl",
                principalColumn: "UcakId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sehir_Ucuslar_UcusId",
                table: "Sehir",
                column: "UcusId",
                principalTable: "Ucuslar",
                principalColumn: "UcusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ucuslar_UcakTbl_UcakId",
                table: "Ucuslar",
                column: "UcakId",
                principalTable: "UcakTbl",
                principalColumn: "UcakId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
