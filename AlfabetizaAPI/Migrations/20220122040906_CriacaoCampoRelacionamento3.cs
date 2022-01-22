using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlfabetizaAPI.Migrations
{
    public partial class CriacaoCampoRelacionamento3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Community_Users_user_id",
                table: "Community");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCommunity_Users_user_id",
                table: "UserCommunity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Community_User_user_id",
                table: "Community",
                column: "user_id",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCommunity_User_user_id",
                table: "UserCommunity",
                column: "user_id",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Community_User_user_id",
                table: "Community");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCommunity_User_user_id",
                table: "UserCommunity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Community_Users_user_id",
                table: "Community",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCommunity_Users_user_id",
                table: "UserCommunity",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
