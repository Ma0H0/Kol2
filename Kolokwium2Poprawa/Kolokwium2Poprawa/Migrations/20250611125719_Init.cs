using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kolokwium2Poprawa.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentWeight = table.Column<int>(type: "int", nullable: false),
                    MaxWeight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Title",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Title", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Backpack",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Backpack", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Backpack_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Backpack_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Character_Title",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    TitleId = table.Column<int>(type: "int", nullable: false),
                    AcquiredAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character_Title", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Character_Title_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Character_Title_Title_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Title",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Character",
                columns: new[] { "Id", "CurrentWeight", "FirstName", "LastName", "MaxWeight" },
                values: new object[,]
                {
                    { 1, 3, "John", "Doe", 30 },
                    { 2, 3, "Jane", "Doe", 20 },
                    { 3, 3, "Julie", "Doe", 40 }
                });

            migrationBuilder.InsertData(
                table: "Item",
                columns: new[] { "Id", "Name", "Weight" },
                values: new object[,]
                {
                    { 1, "Apple", 5 },
                    { 2, "Sword", 5 },
                    { 3, "Cactus", 5 }
                });

            migrationBuilder.InsertData(
                table: "Title",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Slayer" },
                    { 2, "The Slayer" },
                    { 3, "The The Slayer" }
                });

            migrationBuilder.InsertData(
                table: "Backpack",
                columns: new[] { "Id", "Amount", "CharacterId", "ItemId" },
                values: new object[,]
                {
                    { 1, 0, 1, 1 },
                    { 2, 0, 3, 3 },
                    { 3, 0, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Character_Title",
                columns: new[] { "Id", "AcquiredAt", "CharacterId", "TitleId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 3, new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Backpack_CharacterId",
                table: "Backpack",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Backpack_ItemId",
                table: "Backpack",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_Title_CharacterId",
                table: "Character_Title",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_Title_TitleId",
                table: "Character_Title",
                column: "TitleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Backpack");

            migrationBuilder.DropTable(
                name: "Character_Title");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "Title");
        }
    }
}
