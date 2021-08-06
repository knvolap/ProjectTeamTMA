﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectTeamTMA.Migrations
{
    public partial class DBInit4 : Migration
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    roleName = table.Column<string>(type: "char(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    createdTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    updatedTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdRole", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Floor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    buildingId = table.Column<int>(type: "int", nullable: false),
                    floorName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    createdTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    updatedTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Floors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Floor_Building_buildingId",
                        column: x => x.buildingId,
                        principalTable: "Building",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
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
                    updatedTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Role_roleId",
                        column: x => x.roleId,
                        principalTable: "Role",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
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
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Room_Floor_floorId",
                        column: x => x.floorId,
                        principalTable: "Floor",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BookRoom",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    personBookingId = table.Column<int>(type: "int", nullable: false),
                    personalApprovedId = table.Column<int>(type: "int", nullable: false),
                    roomId = table.Column<int>(type: "int", nullable: false),
                    issue = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    startDay = table.Column<DateTime>(type: "datetime", nullable: false),
                    endDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    startTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    endTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    createdTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    updatedTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    status = table.Column<ulong>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookRooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookRoom_Room_roomId",
                        column: x => x.roomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookRoom_User_personBookingId",
                        column: x => x.personBookingId,
                        principalTable: "User",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Building",
                columns: new[] { "Id", "buildingName", "createdTime", "updatedTime" },
                values: new object[,]
                {
                    { 1, "Toàn nhà 1", new DateTime(2021, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Toàn nhà 2", new DateTime(2021, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Toàn nhà 3", new DateTime(2021, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "createdTime", "roleName", "updatedTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", new DateTime(2021, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2021, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", new DateTime(2021, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Floor",
                columns: new[] { "Id", "buildingId", "createdTime", "floorName", "updatedTime" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tầng 1", new DateTime(2021, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, new DateTime(2021, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tầng 2", new DateTime(2021, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 1, new DateTime(2021, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tầng 3", new DateTime(2021, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 2, new DateTime(2021, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tầng 1", new DateTime(2021, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 2, new DateTime(2021, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tầng 2", new DateTime(2021, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 2, new DateTime(2021, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tầng 3", new DateTime(2021, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "address", "createdTime", "name", "passWord", "phone", "roleId", "status", "updatedTime", "userName" },
                values: new object[,]
                {
                    { 1, "Bình Định", new DateTime(2021, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Võ Lập", "123123", 37516333, 1, 1ul, new DateTime(2021, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "knvolap" },
                    { 2, "Bình Định", new DateTime(2021, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Văn Tính", "123123", 37516444, 2, 1ul, new DateTime(2021, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "vantinh" },
                    { 3, "Đà Nẵng", new DateTime(2021, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thanh Thảo", "123123", 37516555, 2, 1ul, new DateTime(2021, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "thanhthao" }
                });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "Id", "NumberOfBeds", "area", "createdTime", "floorId", "roomName", "status", "updatedTime" },
                values: new object[,]
                {
                    { 1, 2, "40m2", new DateTime(2021, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "A111", 1ul, new DateTime(2021, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, "40m2", new DateTime(2021, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "A112", 1ul, new DateTime(2021, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2, "40m2", new DateTime(2021, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "A212", 1ul, new DateTime(2021, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 2, "40m2", new DateTime(2021, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "A212", 1ul, new DateTime(2021, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookRoom_personBookingId",
                table: "BookRoom",
                column: "personBookingId");

            migrationBuilder.CreateIndex(
                name: "IX_BookRoom_roomId",
                table: "BookRoom",
                column: "roomId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Floor_buildingId",
                table: "Floor",
                column: "buildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_floorId",
                table: "Room",
                column: "floorId");

            migrationBuilder.CreateIndex(
                name: "IX_User_roleId",
                table: "User",
                column: "roleId");
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