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
                name: "Buildings",
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
                name: "Roles",
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
                name: "Floors",
                columns: table => new
                {
                    floorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    buildingId = table.Column<int>(type: "int", nullable: false),
                    floorName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    createdTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    updatedTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    BuildingsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Floors", x => x.floorId);
                    table.ForeignKey(
                        name: "FK_Buildings_Floors",
                        column: x => x.buildingId,
                        principalTable: "Buildings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Floors_Buildings_BuildingsId",
                        column: x => x.BuildingsId,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    roleId = table.Column<int>(type: "int", nullable: false),
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
                    RolesroleID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.userId);
                    table.ForeignKey(
                        name: "FK_Customers_Roles_RolesroleID",
                        column: x => x.RolesroleID,
                        principalTable: "Roles",
                        principalColumn: "roleID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Roles",
                        column: x => x.roleId,
                        principalTable: "Roles",
                        principalColumn: "roleID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Rooms",
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
                    updatedTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.roomId);
                    table.ForeignKey(
                        name: "FK_Rooms_Floors_floorId",
                        column: x => x.floorId,
                        principalTable: "Floors",
                        principalColumn: "floorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rooms_Roles",
                        column: x => x.roomId,
                        principalTable: "Floors",
                        principalColumn: "floorId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BookRooms",
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
                    UsersuserId = table.Column<int>(type: "int", nullable: true),
                    RoomsroomId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookRooms", x => x.bookRoomId);
                    table.ForeignKey(
                        name: "FK_BookRooms_Customers_UsersuserId",
                        column: x => x.UsersuserId,
                        principalTable: "Customers",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookRooms_Rooms",
                        column: x => x.roomId,
                        principalTable: "Rooms",
                        principalColumn: "roomId");
                    table.ForeignKey(
                        name: "FK_BookRooms_Rooms_RoomsroomId",
                        column: x => x.RoomsroomId,
                        principalTable: "Rooms",
                        principalColumn: "roomId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookRooms_Users",
                        column: x => x.bookRoomId,
                        principalTable: "Customers",
                        principalColumn: "userId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_BookRooms_roomId",
                table: "BookRooms",
                column: "roomId");

            migrationBuilder.CreateIndex(
                name: "IX_BookRooms_RoomsroomId",
                table: "BookRooms",
                column: "RoomsroomId");

            migrationBuilder.CreateIndex(
                name: "IX_BookRooms_UsersuserId",
                table: "BookRooms",
                column: "UsersuserId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_roleId",
                table: "Customers",
                column: "roleId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_RolesroleID",
                table: "Customers",
                column: "RolesroleID");

            migrationBuilder.CreateIndex(
                name: "IX_Floors_buildingId",
                table: "Floors",
                column: "buildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Floors_BuildingsId",
                table: "Floors",
                column: "BuildingsId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_floorId",
                table: "Rooms",
                column: "floorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookRooms");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Floors");

            migrationBuilder.DropTable(
                name: "Buildings");
        }
    }
}
