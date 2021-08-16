using Microsoft.EntityFrameworkCore;
using ProjectTeamTMA.Data;
using ProjectTeamTMA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTeamTMA.DBContexts
{
    public class MyDBContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }   
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<BookRoom> BookRooms { get; set; }

        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map entities to tables  
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Building>().ToTable("Building");
            modelBuilder.Entity<Floor>().ToTable("Floor");       
            modelBuilder.Entity<Room>().ToTable("Room");
            modelBuilder.Entity<BookRoom>().ToTable("BookRoom");

            // Configure Primary Keys  
            modelBuilder.Entity<Role>().HasKey(rl => rl.Id).HasName("PK_IdRole");
            modelBuilder.Entity<User>().HasKey(u => u.Id).HasName("PK_Users");
            modelBuilder.Entity<Building>().HasKey(b => b.Id).HasName("PK_Buildings");
            modelBuilder.Entity<Floor>().HasKey(f => f.Id).HasName("PK_Floors");       
            modelBuilder.Entity<Room>().HasKey(ro => ro.Id).HasName("PK_Rooms");
            modelBuilder.Entity<BookRoom>().HasKey(bk => bk.Id).HasName("PK_BookRooms");
           
            //// Configure columns  
            //modelBuilder.Entity<Role>().Property(rl => rl.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            //modelBuilder.Entity<Role>().Property(rl => rl.roleName).HasColumnType("char(100)").IsRequired();
            //modelBuilder.Entity<Role>().Property(rl => rl.createdTime).HasColumnType("datetime").IsRequired();
            //modelBuilder.Entity<Role>().Property(rl => rl.updatedTime).HasColumnType("datetime").IsRequired(false);

            //modelBuilder.Entity<User>().Property(u => u.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            //modelBuilder.Entity<User>().Property(u => u.roleId).HasColumnType("int").IsRequired();
            //modelBuilder.Entity<User>().Property(u => u.name).HasColumnType("nvarchar(100)").IsRequired();
            //modelBuilder.Entity<User>().Property(u => u.phone).HasColumnType("int").IsRequired();
            //modelBuilder.Entity<User>().Property(u => u.address).HasColumnType("nvarchar(100)").IsRequired();
            //modelBuilder.Entity<User>().Property(u => u.userName).HasColumnType("varchar(100)").IsRequired();
            //modelBuilder.Entity<User>().Property(u => u.passWord).HasColumnType("varchar(100)").IsRequired();
            //modelBuilder.Entity<User>().Property(u => u.status).HasColumnType("bit").IsRequired(false);
            //modelBuilder.Entity<User>().Property(u => u.createdTime).HasColumnType("datetime").IsRequired();
            //modelBuilder.Entity<User>().Property(u => u.updatedTime).HasColumnType("datetime").IsRequired(false);

            //modelBuilder.Entity<Building>().Property(B => B.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();        
            //modelBuilder.Entity<Building>().Property(B => B.buildingName).HasColumnType("nvarchar(100)").IsRequired();        
            //modelBuilder.Entity<Building>().Property(B => B.createdTime).HasColumnType("datetime").IsRequired();
            //modelBuilder.Entity<Building>().Property(B => B.updatedTime).HasColumnType("datetime").IsRequired(false);

            //modelBuilder.Entity<Floor>().Property(FL => FL.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            //modelBuilder.Entity<Floor>().Property(FL => FL.buildingId).HasColumnType("int").IsRequired();
            //modelBuilder.Entity<Floor>().Property(FL => FL.floorName).HasColumnType("nvarchar(100)").IsRequired();
            //modelBuilder.Entity<Floor>().Property(FL => FL.createdTime).HasColumnType("datetime").IsRequired();
            //modelBuilder.Entity<Floor>().Property(FL => FL.updatedTime).HasColumnType("datetime").IsRequired(false);

            //modelBuilder.Entity<Room>().Property(R => R.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            //modelBuilder.Entity<Room>().Property(R => R.floorId).HasColumnType("int").IsRequired();
            //modelBuilder.Entity<Room>().Property(R => R.roomName).HasColumnType("nvarchar(100)").IsRequired();
            //modelBuilder.Entity<Room>().Property(R => R.area).HasColumnType("varchar(100)").IsRequired();
            //modelBuilder.Entity<Room>().Property(R => R.NumberOfBeds).HasColumnType("int").IsRequired();
            //modelBuilder.Entity<Room>().Property(R => R.status).HasColumnType("bit").IsRequired(false);
            //modelBuilder.Entity<Room>().Property(R => R.createdTime).HasColumnType("datetime").IsRequired();
            //modelBuilder.Entity<Room>().Property(R => R.updatedTime).HasColumnType("datetime").IsRequired(false);

            //modelBuilder.Entity<BookRoom>().Property(BR => BR.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            //modelBuilder.Entity<BookRoom>().Property(BR => BR.personBookingId).HasColumnType("int").IsRequired();
            //modelBuilder.Entity<BookRoom>().Property(BR => BR.personalApprovedId).HasColumnType("int").IsRequired();
            //modelBuilder.Entity<BookRoom>().Property(BR => BR.roomId).HasColumnType("int").IsRequired();
            //modelBuilder.Entity<BookRoom>().Property(BR => BR.issue).HasColumnType("nvarchar(100)").IsRequired();
            //modelBuilder.Entity<BookRoom>().Property(BR => BR.startDay).HasColumnType("datetime").IsRequired();
            //modelBuilder.Entity<BookRoom>().Property(BR => BR.endDate).HasColumnType("datetime").IsRequired(false);
            //modelBuilder.Entity<BookRoom>().Property(BR => BR.startTime).HasColumnType("datetime").IsRequired();
            //modelBuilder.Entity<BookRoom>().Property(BR => BR.endTime).HasColumnType("datetime").IsRequired(false);
            //modelBuilder.Entity<BookRoom>().Property(BR => BR.status).HasColumnType("bit").IsRequired(false);    
            //modelBuilder.Entity<BookRoom>().Property(BR => BR.createdTime).HasColumnType("datetime").IsRequired();
            //modelBuilder.Entity<BookRoom>().Property(BR => BR.updatedTime).HasColumnType("datetime").IsRequired(false);

            //Data seeding -- nhập dữ liệu có sẵn ở file "ModelBuilderExtensions"
            modelBuilder.Seed();

            // Configure relationships  
            //liên kết 1 vs N
            modelBuilder.Entity<Floor>().HasOne(b => b.Buildings).WithMany(b => b.Floors).HasForeignKey(p => p.buildingId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Room>().HasOne(b => b.Floors).WithMany(b => b.Rooms).HasForeignKey(p => p.floorId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<BookRoom>().HasOne(b => b.Users).WithMany(b => b.BookRooms).HasForeignKey(p => p.personBookingId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<User>().HasOne(b => b.Roles).WithMany(b => b.Users).HasForeignKey(p => p.roleId).OnDelete(DeleteBehavior.NoAction);

            // liên kết 1-1
            modelBuilder.Entity<Room>().HasOne<BookRoom>(s => s.BookRooms)
                .WithOne(ad => ad.Rooms).HasForeignKey<BookRoom>(ad => ad.roomId);


            //modelBuilder.Entity<Floor>().HasOne<Building>().WithMany().HasPrincipalKey(b => b.Id).HasForeignKey(f => f.buildingId)
            //                                                                                   .OnDelete(DeleteBehavior.NoAction);
            //modelBuilder.Entity<Room>().HasOne<Floor>().WithMany().HasPrincipalKey(f => f.floorId).HasForeignKey(r =>r.floorId).OnDelete(DeleteBehavior.NoAction);        
            //modelBuilder.Entity<BookRoom>().HasOne<User>().WithMany().HasPrincipalKey(u => u.userId).HasForeignKey(b => b.personBookingId).OnDelete(DeleteBehavior.NoAction);
            //modelBuilder.Entity<BookRoom>().HasOne<Room>().WithMany().HasPrincipalKey(br => br.roomId).HasForeignKey(r => r.roomId).OnDelete(DeleteBehavior.NoAction);           
            //modelBuilder.Entity<User>().HasOne<Role>().WithMany().HasPrincipalKey(rl => rl.roleID).HasForeignKey(u => u.roleId).OnDelete(DeleteBehavior.NoAction).HasConstraintName("FK_Users_Roles");
            //modelBuilder.Entity<BookRoom>().HasOne<Room>().WithOne().HasPrincipalKey(br => br.IdRoom).HasForeignKey(r => r.IdRoom).OnDelete(DeleteBehavior.NoAction).HasConstraintName("FK_BookRooms_Rooms");


        }
    }
}
