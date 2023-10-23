// <copyright file="20231021133707_Initial.cs" company="Николаев А.М.">
// Copyright (c) Николаев А.М.. All rights reserved.
// </copyright>

#nullable disable

namespace ORM.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;
    using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "inventories",
                columns: table => new
                {
                    InventoryCode = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("inventory_code", x => x.InventoryCode);
                });

            migrationBuilder.CreateTable(
                name: "reading_rooms",
                columns: table => new
                {
                    ReadingRoomCode = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("reading_room_code", x => x.ReadingRoomCode);
                });

            migrationBuilder.CreateTable(
                name: "documents",
                columns: table => new
                {
                    DocumentCode = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    InventoryCode = table.Column<int>(type: "integer", nullable: false),
                    ReadingRoomCode = table.Column<int>(type: "integer", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("document_code", x => x.DocumentCode);
                    table.ForeignKey(
                        name: "fk_documents_inventories",
                        column: x => x.InventoryCode,
                        principalTable: "inventories",
                        principalColumn: "InventoryCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_documents_reading_rooms",
                        column: x => x.ReadingRoomCode,
                        principalTable: "reading_rooms",
                        principalColumn: "ReadingRoomCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_documents_InventoryCode",
                table: "documents",
                column: "InventoryCode");

            migrationBuilder.CreateIndex(
                name: "IX_documents_ReadingRoomCode",
                table: "documents",
                column: "ReadingRoomCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "documents");

            migrationBuilder.DropTable(
                name: "inventories");

            migrationBuilder.DropTable(
                name: "reading_rooms");
        }
    }
}
