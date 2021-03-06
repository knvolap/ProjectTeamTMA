using Microsoft.EntityFrameworkCore;
using ProjectTeamTMA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTeamTMA.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //seed data for Language
            //modelBuilder.Entity<Language>().HasData(
            //    new Language() { Id = "vi-VN", Name = "Tiếng Việt", IsDefault = true },
            //    new Language() { Id = "en-US", Name = "English", IsDefault = true });

            //seed data for Building
            //modelBuilder.Entity<Building>().HasData(
            //    new Building()
            //    {
            //        Id = 1,
            //        buildingName = "Toàn nhà 1",
            //        createdTime = DateTime.Parse("2021 - 07 - 05 00:00:00"),
            //        updatedTime = DateTime.Parse("2021 - 07 - 05 00:00:00")
            //    },
            //     new Building()
            //     {
            //         Id = 2,
            //         buildingName = "Toàn nhà 2",
            //         createdTime = DateTime.Parse("2021 - 07 - 05 00:00:00"),
            //         updatedTime = DateTime.Parse("2021 - 07 - 05 00:00:00")

            //     },
            //    new Building()
            //    {
            //        Id = 3,
            //        buildingName = "Toàn nhà 3",
            //        createdTime = DateTime.Parse("2021 - 07 - 05 00:00:00"),
            //        updatedTime = DateTime.Parse("2021 - 07 - 05 00:00:00")
            //    }) ;

            //modelBuilder.Entity<Floor>().HasData(
            //   new Floor()
            //   {
            //       Id = 1,
            //       buildingId = 1,
            //       floorName = "Tầng 1",
            //       createdTime = DateTime.Parse("2021 - 07 - 05 00:00:00"),
            //       updatedTime = DateTime.Parse("2021 - 07 - 05 00:00:00")
            //   },
            //   new Floor()
            //   {
            //       Id = 2,
            //       buildingId = 1,
            //       floorName = "Tầng 2",
            //       createdTime = DateTime.Parse("2021 - 07 - 05 00:00:00"),
            //       updatedTime = DateTime.Parse("2021 - 07 - 05 00:00:00")
            //   },
            //   new Floor()
            //   {
            //       Id = 3,
            //       buildingId = 1,
            //       floorName = "Tầng 3",
            //       createdTime = DateTime.Parse("2021 - 07 - 05 00:00:00"),
            //       updatedTime = DateTime.Parse("2021 - 07 - 05 00:00:00")
            //   },
            //   new Floor()
            //   {
            //       Id = 4,
            //       buildingId = 2,
            //       floorName = "Tầng 1",
            //       createdTime = DateTime.Parse("2021 - 07 - 05 00:00:00"),
            //       updatedTime = DateTime.Parse("2021 - 07 - 05 00:00:00")
            //   },
            //   new Floor()
            //   {
            //       Id = 5,
            //       buildingId = 2,
            //       floorName = "Tầng 2",
            //       createdTime = DateTime.Parse("2021 - 07 - 05 00:00:00"),
            //       updatedTime = DateTime.Parse("2021 - 07 - 05 00:00:00")
            //   },
            //   new Floor()
            //   {
            //       Id = 6,
            //       buildingId = 2,
            //       floorName = "Tầng 3",
            //       createdTime = DateTime.Parse("2021 - 07 - 05 00:00:00"),
            //       updatedTime = DateTime.Parse("2021 - 07 - 05 00:00:00")
            //   });

            //modelBuilder.Entity<Room>().HasData(
            //  new Room()
            //  {
            //      Id = 1,
            //      floorId = 1,
            //      roomName = "A111",
            //      area = "40m2",
            //      NumberOfBeds = 2,
            //      status = true,
            //      createdTime = DateTime.Parse("2021 - 07 - 05 00:00:00"),
            //      updatedTime = DateTime.Parse("2021 - 07 - 05 00:00:00")
            //  },
            //  new Room()
            //  {
            //      Id = 2,
            //      floorId = 1,
            //      roomName = "A112",
            //      area = "40m2",
            //      NumberOfBeds = 2,
            //      status = true,
            //      createdTime = DateTime.Parse("2021 - 07 - 05 00:00:00"),
            //      updatedTime = DateTime.Parse("2021 - 07 - 05 00:00:00")
            //  },
            //  new Room()
            //  {
            //      Id = 3,
            //      floorId = 1,
            //      roomName = "A212",
            //      area = "40m2",
            //      NumberOfBeds = 2,
            //      status = true,
            //      createdTime = DateTime.Parse("2021 - 07 - 05 00:00:00"),
            //      updatedTime = DateTime.Parse("2021 - 07 - 05 00:00:00")
            //  },
            //  new Room()
            //  {
            //      Id = 4,
            //      floorId = 1,
            //      roomName = "A212",
            //      area = "40m2",
            //      NumberOfBeds = 2,
            //      status = true,
            //      createdTime = DateTime.Parse("2021 - 07 - 05 00:00:00"),
            //      updatedTime = DateTime.Parse("2021 - 07 - 05 00:00:00")
            //  });

            //modelBuilder.Entity<Role>().HasData(
            //new Role()
            //{
            //    Id = 1,
            //    roleName = "Admin",
            //    createdTime = DateTime.Parse("2021 - 07 - 05 00:00:00"),
            //    updatedTime = DateTime.Parse("2021 - 07 - 05 00:00:00")
            //},
            // new Role()
            // {
            //     Id = 2,
            //     roleName = "User",
            //     createdTime = DateTime.Parse("2021 - 07 - 05 00:00:00"),
            //     updatedTime = DateTime.Parse("2021 - 07 - 05 00:00:00")
            // });


            //modelBuilder.Entity<User>().HasData(
            // new User()
            // {
            //     Id = 1,
            //     roleId = 1,
            //     name = "Võ Lập",
            //     phone = 037516333,
            //     address = "Bình Định",
            //     userName = "knvolap",
            //     passWord = "123123",
            //     status = true,
            //     createdTime = DateTime.Parse("2021 - 07 - 05 00:00:00"),
            //     updatedTime = DateTime.Parse("2021 - 07 - 05 00:00:00")
            // },
            // new User()
            // {
            //     Id = 2,
            //     roleId = 2,
            //     name = "Văn Tính",
            //     phone = 037516444,
            //     address = "Bình Định",
            //     userName = "vantinh",
            //     passWord = "123123",
            //     status = true,
            //     createdTime = DateTime.Parse("2021 - 07 - 05 00:00:00"),
            //     updatedTime = DateTime.Parse("2021 - 07 - 05 00:00:00")
            // },
            // new User()
            // {
            //     Id = 3,
            //     roleId = 2,
            //     name = "Thanh Thảo",
            //     phone = 037516555,
            //     address = "Đà Nẵng",
            //     userName = "thanhthao",
            //     passWord = "123123",
            //     status = true,
            //     createdTime = DateTime.Parse("2021 - 07 - 05 00:00:00"),
            //     updatedTime = DateTime.Parse("2021 - 07 - 05 00:00:00")
            // });
        }
    }
}
