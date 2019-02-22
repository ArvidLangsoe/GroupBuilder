using Microsoft.EntityFrameworkCore.Migrations;

namespace GroupBuilderPersistence.Migrations
{
    public partial class MM_RoomParticipants_Db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Group_Rooms_RoomId",
                table: "Group");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomParticipant_Rooms_RoomId",
                table: "RoomParticipant");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomParticipant_Users_UserId",
                table: "RoomParticipant");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_RoomParticipant_RoomId_UserId",
                table: "RoomParticipant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomParticipant",
                table: "RoomParticipant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Group",
                table: "Group");

            migrationBuilder.RenameTable(
                name: "RoomParticipant",
                newName: "RoomParticipants");

            migrationBuilder.RenameTable(
                name: "Group",
                newName: "Groups");

            migrationBuilder.RenameIndex(
                name: "IX_Group_RoomId",
                table: "Groups",
                newName: "IX_Groups_RoomId");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_RoomParticipants_RoomId_UserId",
                table: "RoomParticipants",
                columns: new[] { "RoomId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomParticipants",
                table: "RoomParticipants",
                columns: new[] { "UserId", "RoomId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Groups",
                table: "Groups",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Rooms_RoomId",
                table: "Groups",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomParticipants_Rooms_RoomId",
                table: "RoomParticipants",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomParticipants_Users_UserId",
                table: "RoomParticipants",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Rooms_RoomId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomParticipants_Rooms_RoomId",
                table: "RoomParticipants");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomParticipants_Users_UserId",
                table: "RoomParticipants");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_RoomParticipants_RoomId_UserId",
                table: "RoomParticipants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomParticipants",
                table: "RoomParticipants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Groups",
                table: "Groups");

            migrationBuilder.RenameTable(
                name: "RoomParticipants",
                newName: "RoomParticipant");

            migrationBuilder.RenameTable(
                name: "Groups",
                newName: "Group");

            migrationBuilder.RenameIndex(
                name: "IX_Groups_RoomId",
                table: "Group",
                newName: "IX_Group_RoomId");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_RoomParticipant_RoomId_UserId",
                table: "RoomParticipant",
                columns: new[] { "RoomId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomParticipant",
                table: "RoomParticipant",
                columns: new[] { "UserId", "RoomId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Group",
                table: "Group",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Group_Rooms_RoomId",
                table: "Group",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomParticipant_Rooms_RoomId",
                table: "RoomParticipant",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomParticipant_Users_UserId",
                table: "RoomParticipant",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
