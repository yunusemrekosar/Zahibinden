using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zahibinden.Migrations
{
    public partial class mig4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Adverts_AdvertId",
                table: "Image");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Image",
                table: "Image");

            migrationBuilder.RenameTable(
                name: "Image",
                newName: "Images");

            migrationBuilder.RenameIndex(
                name: "IX_Image_AdvertId",
                table: "Images",
                newName: "IX_Images_AdvertId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                table: "Images",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Adverts_AdvertId",
                table: "Images",
                column: "AdvertId",
                principalTable: "Adverts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Adverts_AdvertId",
                table: "Images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Images",
                table: "Images");

            migrationBuilder.RenameTable(
                name: "Images",
                newName: "Image");

            migrationBuilder.RenameIndex(
                name: "IX_Images_AdvertId",
                table: "Image",
                newName: "IX_Image_AdvertId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Image",
                table: "Image",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Adverts_AdvertId",
                table: "Image",
                column: "AdvertId",
                principalTable: "Adverts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
