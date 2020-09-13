using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Formula1Teams",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    FoundationDate = table.Column<DateTime>(nullable: false),
                    Victories = table.Column<int>(nullable: false),
                    IsFeePaid = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formula1Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Salt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Password", "Salt", "UserName" },
                values: new object[] { new Guid("5f048b89-2a6d-4c8c-87d6-36af392a0b22"), "C3UHzqkH+okmnWowSkCMG1IlR595O5RabswweZpEhSw=", new byte[] { 89, 85, 85, 51, 253, 91, 26, 26, 167, 189, 72, 116, 17, 165, 33, 168 }, "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Formula1Teams_Id",
                table: "Formula1Teams",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Id",
                table: "User",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Formula1Teams");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
