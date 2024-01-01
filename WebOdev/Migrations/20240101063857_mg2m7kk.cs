using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebOdev.Migrations
{
    public partial class mg2m7kk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BiletTbl_Ucaklar_UcakId",
                table: "BiletTbl");

            migrationBuilder.DropForeignKey(
                name: "FK_Koltuk_Ucaklar_UcakId",
                table: "Koltuk");

            migrationBuilder.DropForeignKey(
                name: "FK_Ucuslar_Ucaklar_UcakId",
                table: "Ucuslar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ucaklar",
                table: "Ucaklar");

            migrationBuilder.RenameTable(
                name: "Ucaklar",
                newName: "UcakTbl");

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
                name: "FK_Ucuslar_UcakTbl_UcakId",
                table: "Ucuslar",
                column: "UcakId",
                principalTable: "UcakTbl",
                principalColumn: "UcakId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BiletTbl_UcakTbl_UcakId",
                table: "BiletTbl");

            migrationBuilder.DropForeignKey(
                name: "FK_Koltuk_UcakTbl_UcakId",
                table: "Koltuk");

            migrationBuilder.DropForeignKey(
                name: "FK_Ucuslar_UcakTbl_UcakId",
                table: "Ucuslar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UcakTbl",
                table: "UcakTbl");

            migrationBuilder.RenameTable(
                name: "UcakTbl",
                newName: "Ucaklar");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ucaklar",
                table: "Ucaklar",
                column: "UcakId");

            migrationBuilder.AddForeignKey(
                name: "FK_BiletTbl_Ucaklar_UcakId",
                table: "BiletTbl",
                column: "UcakId",
                principalTable: "Ucaklar",
                principalColumn: "UcakId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Koltuk_Ucaklar_UcakId",
                table: "Koltuk",
                column: "UcakId",
                principalTable: "Ucaklar",
                principalColumn: "UcakId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ucuslar_Ucaklar_UcakId",
                table: "Ucuslar",
                column: "UcakId",
                principalTable: "Ucaklar",
                principalColumn: "UcakId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
