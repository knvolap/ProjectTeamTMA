﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectTeamTMA.DBContexts;

namespace ProjectTeamTMA.Migrations
{
    [DbContext(typeof(MyDBContext))]
    partial class MyDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.8");

            modelBuilder.Entity("ProjectTeamTMA.Model.BookRoom", b =>
                {
                    b.Property<int>("bookRoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);


                    b.Property<DateTime>("createdTime")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("endDate")
                        .HasColumnType("datetime");

                    b.Property<string>("issue")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("personBookingId")
                        .HasColumnType("int");

                    b.Property<int>("personalApprovedId")
                        .HasColumnType("int");

                    b.Property<int>("roomId")
                        .HasColumnType("int");

                    b.Property<DateTime>("startDay")
                        .HasColumnType("datetime");

                    b.Property<ulong?>("status")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("updatedTime")
                        .HasColumnType("datetime");

                    b.HasKey("bookRoomId")
                        .HasName("PK_BookRooms");



                    b.HasIndex("personBookingId");

                    b.HasIndex("roomId");

                    b.ToTable("BookRoom");
                });

            modelBuilder.Entity("ProjectTeamTMA.Model.Building", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("buildingName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("createdTime")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("updatedTime")
                        .HasColumnType("datetime");

                    b.HasKey("Id")
                        .HasName("PK_Buildings");

                    b.ToTable("Building");
                });

            modelBuilder.Entity("ProjectTeamTMA.Model.Floor", b =>
                {
                    b.Property<int>("floorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("buildingId")
                        .HasColumnType("int");

                    b.Property<DateTime>("createdTime")
                        .HasColumnType("datetime");

                    b.Property<string>("floorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("updatedTime")
                        .HasColumnType("datetime");

                    b.HasKey("floorId")
                        .HasName("PK_Floors");

                    b.HasIndex("buildingId");

                    b.ToTable("Floor");
                });

            modelBuilder.Entity("ProjectTeamTMA.Model.Role", b =>
                {
                    b.Property<int>("roleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("createdTime")
                        .HasColumnType("datetime");

                    b.Property<string>("roleName")
                        .IsRequired()
                        .HasColumnType("char(100)");

                    b.Property<DateTime?>("updatedTime")
                        .HasColumnType("datetime");

                    b.HasKey("roleID")
                        .HasName("PK_IdRole");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("ProjectTeamTMA.Model.Room", b =>
                {
                    b.Property<int>("roomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);



                    b.Property<int>("NumberOfBeds")
                        .HasColumnType("int");

                    b.Property<string>("area")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("createdTime")
                        .HasColumnType("datetime");

                    b.Property<int>("floorId")
                        .HasColumnType("int");

                    b.Property<string>("roomName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<ulong?>("status")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("updatedTime")
                        .HasColumnType("datetime");

                    b.HasKey("roomId")
                        .HasName("PK_Customers");


                    b.HasIndex("floorId");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("ProjectTeamTMA.Model.User", b =>
                {
                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("createdTime")
                        .HasColumnType("datetime");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("passWord")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("phone")
                        .HasColumnType("int");

                    b.Property<string>("role")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<ulong?>("status")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("updatedTime")
                        .HasColumnType("datetime");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("userId")
                        .HasName("PK_Users");



                    b.ToTable("User");
                });

            modelBuilder.Entity("ProjectTeamTMA.Model.BookRoom", b =>
                {

                    b.HasOne("ProjectTeamTMA.Model.User", null)
                        .WithMany()
                        .HasForeignKey("personBookingId")
                        .HasConstraintName("FK_BookRooms_Users")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ProjectTeamTMA.Model.Room", null)
                        .WithMany()
                        .HasForeignKey("roomId")
                        .HasConstraintName("FK_BookRooms_Rooms")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Rooms");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("ProjectTeamTMA.Model.Floor", b =>
                {
                    b.HasOne("ProjectTeamTMA.Model.Building", null)
                        .WithMany()
                        .HasForeignKey("buildingId")
                        .HasConstraintName("FK_Buildings_Floors")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Buildings");
                });

            modelBuilder.Entity("ProjectTeamTMA.Model.Room", b =>
                {


                    b.HasOne("ProjectTeamTMA.Model.Floor", null)
                        .WithMany()
                        .HasForeignKey("floorId")
                        .HasConstraintName("FK_Rooms_Roles")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Floors");
                });



            modelBuilder.Entity("ProjectTeamTMA.Model.Building", b =>
                {
                    b.Navigation("Floors");
                });

            modelBuilder.Entity("ProjectTeamTMA.Model.Floor", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("ProjectTeamTMA.Model.Room", b =>
                {
                    b.Navigation("BookRooms");
                });

            modelBuilder.Entity("ProjectTeamTMA.Model.User", b =>
                {
                    b.Navigation("BookRooms");
                });
#pragma warning restore 612, 618
        }
    }
}
