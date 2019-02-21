using Microsoft.EntityFrameworkCore.Migrations;

namespace GroupBuilderPersistence.Migrations
{
    public partial class RoomsRoomCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RoomCode",
                table: "Rooms",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoomCode",
                table: "Rooms");
        }
    }
}
