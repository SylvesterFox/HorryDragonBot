﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DragonData.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Guilds",
                columns: table => new
                {
                    guildID = table.Column<ulong>(type: "INTEGER", nullable: false),
                    guildName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guilds", x => x.guildID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userID = table.Column<ulong>(type: "INTEGER", nullable: false),
                    username = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userID);
                });

            migrationBuilder.CreateTable(
                name: "GuildBlockLists",
                columns: table => new
                {
                    blockID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    guildID = table.Column<ulong>(type: "INTEGER", nullable: false),
                    blockTag = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuildBlockLists", x => x.blockID);
                    table.ForeignKey(
                        name: "FK_GuildBlockLists_Guilds_guildID",
                        column: x => x.guildID,
                        principalTable: "Guilds",
                        principalColumn: "guildID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "blocklists",
                columns: table => new
                {
                    blockID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    userID = table.Column<ulong>(type: "INTEGER", nullable: false),
                    blockTag = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blocklists", x => x.blockID);
                    table.ForeignKey(
                        name: "FK_blocklists_Users_userID",
                        column: x => x.userID,
                        principalTable: "Users",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_blocklists_userID",
                table: "blocklists",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_GuildBlockLists_guildID",
                table: "GuildBlockLists",
                column: "guildID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "blocklists");

            migrationBuilder.DropTable(
                name: "GuildBlockLists");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Guilds");
        }
    }
}
