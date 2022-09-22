using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalWebApp.Migrations
{
    public partial class kjhgfghjhgfd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Science_profils_ProfilId",
                table: "Science");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Science",
                table: "Science");

            migrationBuilder.RenameTable(
                name: "Science",
                newName: "sciences");

            migrationBuilder.RenameIndex(
                name: "IX_Science_ProfilId",
                table: "sciences",
                newName: "IX_sciences_ProfilId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sciences",
                table: "sciences",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_sciences_profils_ProfilId",
                table: "sciences",
                column: "ProfilId",
                principalTable: "profils",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sciences_profils_ProfilId",
                table: "sciences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sciences",
                table: "sciences");

            migrationBuilder.RenameTable(
                name: "sciences",
                newName: "Science");

            migrationBuilder.RenameIndex(
                name: "IX_sciences_ProfilId",
                table: "Science",
                newName: "IX_Science_ProfilId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Science",
                table: "Science",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Science_profils_ProfilId",
                table: "Science",
                column: "ProfilId",
                principalTable: "profils",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
