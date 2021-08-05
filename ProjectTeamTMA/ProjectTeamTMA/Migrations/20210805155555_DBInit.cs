using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectTeamTMA.Migrations
{
    public partial class DBInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Building",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    buildingName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    createdTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    updatedTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    roleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    roleName = table.Column<string>(type: "char(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    createdTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    updatedTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdRole", x => x.roleID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Floor",
                columns: table => new
                {
                    floorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    buildingId = table.Column<int>(type: "int", nullable: false),
                    floorName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    createdTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    updatedTime = table.Column<DateTime>(type: "datetime", nullable: true),
                 
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Floors", x => x.floorId);
                    table.ForeignKey(
                        name: "FK_Buildings_Floors",
                        column: x => x.buildingId,
                        principalTable: "Building",
                        principalColumn: "Id");

                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    role = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    phone = table.Column<int>(type: "int", nullable: false),
                    address = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    userName = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    passWord = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    status = table.Column<ulong>(type: "bit", nullable: true),
                    createdTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    updatedTime = table.Column<DateTime>(type: "datetime", nullable: true),
                 
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    roomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    floorId = table.Column<int>(type: "int", nullable: false),
                    roomName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    area = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NumberOfBeds = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<ulong>(type: "bit", nullable: true),
                    createdTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    updatedTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    FloorsfloorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.roomId);
                    table.ForeignKey(
                        name: "FK_Rooms_Roles",
                        column: x => x.floorId,
                        principalTable: "Floor",
                        principalColumn: "floorId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BookRoom",
                columns: table => new
                {
                    bookRoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    personBookingId = table.Column<int>(type: "int", nullable: false),
                    personalApprovedId = table.Column<int>(type: "int", nullable: false),
                    roomId = table.Column<int>(type: "int", nullable: false),
                    issue = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    startDay = table.Column<DateTime>(type: "datetime", nullable: false),
                    endDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    createdTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    updatedTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    status = table.Column<ulong>(type: "bit", nullable: true),                  
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookRooms", x => x.bookRoomId);
                    table.ForeignKey(
                        name: "FK_BookRooms_Rooms",
                        column: x => x.roomId,
                        principalTable: "Room",
                        principalColumn: "roomId");
                    table.ForeignKey(
                        name: "FK_BookRooms_Users",
                        column: x => x.personBookingId,
                        principalTable: "User",
                        principalColumn: "userId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_BookRoom_personBookingId",
                table: "BookRoom",
                column: "personBookingId");

            migrationBuilder.CreateIndex(
                name: "IX_BookRoom_roomId",
                table: "BookRoom",
                column: "roomId");

            migrationBuilder.CreateIndex(
                name: "IX_Floor_buildingId",
                table: "Floor",
                column: "buildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_floorId",
                table: "Room",
                column: "floorId");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookRoom");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Floor");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Building");
        }
    }
}
