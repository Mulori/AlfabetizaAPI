using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AlfabetizaAPI.Migrations
{
    public partial class Tabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "varchar(100)", nullable: false),
                    email = table.Column<string>(type: "varchar(100)", nullable: false),
                    password = table.Column<string>(type: "varchar(1000)", nullable: false),
                    type_account = table.Column<int>(type: "integer", nullable: false),
                    birth_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Community",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "varchar(100)", nullable: false),
                    max_user = table.Column<int>(type: "integer", nullable: false),
                    is_private = table.Column<int>(type: "integer", nullable: false),
                    password = table.Column<string>(type: "varchar(1000)", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Community", x => x.id);
                    table.ForeignKey(
                        name: "FK_Community_User_user_id",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserCommunity",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    community_id = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCommunity", x => x.id);
                    table.ForeignKey(
                        name: "FK_UserCommunity_Community_community_id",
                        column: x => x.community_id,
                        principalTable: "Community",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCommunity_User_user_id",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Community_user_id",
                table: "Community",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserCommunity_community_id",
                table: "UserCommunity",
                column: "community_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserCommunity_user_id",
                table: "UserCommunity",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserCommunity");

            migrationBuilder.DropTable(
                name: "Community");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
