using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebOdev.Migrations
{
    public partial class bha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Sehir",
                newName: "SehirId");

            migrationBuilder.AddColumn<int>(
                name: "SehirId",
                table: "BiletTbl",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BiletTbl_SehirId",
                table: "BiletTbl",
                column: "SehirId");

            migrationBuilder.AddForeignKey(
                name: "FK_BiletTbl_Sehir_SehirId",
                table: "BiletTbl",
                column: "SehirId",
                principalTable: "Sehir",
                principalColumn: "SehirId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BiletTbl_Sehir_SehirId",
                table: "BiletTbl");

            migrationBuilder.DropIndex(
                name: "IX_BiletTbl_SehirId",
                table: "BiletTbl");

            migrationBuilder.DropColumn(
                name: "SehirId",
                table: "BiletTbl");

            migrationBuilder.RenameColumn(
                name: "SehirId",
                table: "Sehir",
                newName: "Id");
        }
    }
}
