using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        public AppDbContext() : base() { }

        public DbSet<IdentityUser> AspNetUsers { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\\mssqllocaldb;
Database=aspnet-WebApp-0069E248-C00F-4BFE-9785-01E97A9DCDC3;
Trusted_Connection=True;
MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUser>().Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

            modelBuilder.Entity<IdentityUser>().Property<int>("AccessFailedCount")
                        .HasColumnType("int");

            modelBuilder.Entity<IdentityUser>().Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

            modelBuilder.Entity<IdentityUser>().Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

            modelBuilder.Entity<IdentityUser>().Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

            modelBuilder.Entity<IdentityUser>().Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

            modelBuilder.Entity<IdentityUser>().Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

            modelBuilder.Entity<IdentityUser>().Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

            modelBuilder.Entity<IdentityUser>().Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

            modelBuilder.Entity<IdentityUser>().Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

            modelBuilder.Entity<IdentityUser>().Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

            modelBuilder.Entity<IdentityUser>().Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

            modelBuilder.Entity<IdentityUser>().Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

            modelBuilder.Entity<IdentityUser>().Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

            modelBuilder.Entity<IdentityUser>().Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

            modelBuilder.Entity<IdentityUser>().HasKey("Id");

            modelBuilder.Entity<IdentityUser>().HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

            modelBuilder.Entity<IdentityUser>().HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

            modelBuilder.Entity<IdentityUser>().ToTable("AspNetUsers");

        }

    }
}
