using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChatServer.Migrations
{
    public partial class added_media : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MainPhotoId",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Media",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ContentType = table.Column<string>(nullable: true),
                    Content = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_MainPhotoId",
                table: "Users",
                column: "MainPhotoId",
                unique: true,
                filter: "[MainPhotoId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Media_MainPhotoId",
                table: "Users",
                column: "MainPhotoId",
                principalTable: "Media",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Media_MainPhotoId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Media");

            migrationBuilder.DropIndex(
                name: "IX_Users_MainPhotoId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MainPhotoId",
                table: "Users");
        }
    }
}
