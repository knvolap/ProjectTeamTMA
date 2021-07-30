using Microsoft.EntityFrameworkCore;
using ProjectTeamTMA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTeamTMA.DBContexts
{
    public class MyDBContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Map entities to tables  
     
            modelBuilder.Entity<Customer>().ToTable("Customers");

            // Configure Primary Keys  
 
            modelBuilder.Entity<Customer>().HasKey(c => c.IdCustomer).HasName("PK_Customers");

            // Configure columns  
   
            modelBuilder.Entity<Customer>().Property(c => c.IdCustomer).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Customer>().Property(c => c.Role).HasColumnType("varchar(100)").IsRequired();
            modelBuilder.Entity<Customer>().Property(c => c.NameCustomer).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<Customer>().Property(c => c.Phone).HasColumnType("int").IsRequired();
            modelBuilder.Entity<Customer>().Property(c => c.Address).HasColumnType("nvarchar(100)").IsRequired(false);
            modelBuilder.Entity<Customer>().Property(c => c.Account).HasColumnType("varchar(100)").IsRequired();
            modelBuilder.Entity<Customer>().Property(c => c.Password).HasColumnType("varchar(100)").IsRequired();
            modelBuilder.Entity<Customer>().Property(c => c.Status).HasColumnType("bit").IsRequired(false);
            // Configure relationships  
            //modelBuilder.Entity<Customer>().HasOne<Role>().WithMany().HasPrincipalKey(rl => rl.IdRole).HasForeignKey(cs => cs.IdRoles).OnDelete(DeleteBehavior.NoAction).HasConstraintName("FK_Customers_Roles");

        }
    }
}
