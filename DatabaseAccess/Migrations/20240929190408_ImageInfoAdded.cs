using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseAccess.Migrations
{
    /// <inheritdoc />
    public partial class ImageInfoAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Cars_CarId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_CarId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "IsPrimary",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Images",
                newName: "Urls");

            migrationBuilder.AddColumn<Guid>(
                name: "ImageInfoId",
                table: "Cars",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ImageInfoId",
                table: "Cars",
                column: "ImageInfoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Images_ImageInfoId",
                table: "Cars",
                column: "ImageInfoId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Images_ImageInfoId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_ImageInfoId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ImageInfoId",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "Urls",
                table: "Images",
                newName: "Url");

            migrationBuilder.AddColumn<bool>(
                name: "IsPrimary",
                table: "Images",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Images_CarId",
                table: "Images",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Cars_CarId",
                table: "Images",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
