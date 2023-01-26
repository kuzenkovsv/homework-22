using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
    public class User : IdentityUser
    {
        public string Id { get; set; }

        public int AccessFailedCount { get; set;}

        public string ConcurrencyStamp { get; set; }

        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public bool LockoutEnabled { get; set; }

        public DateTimeOffset? LockoutEnd { get; set; }

        public string NormalizedEmail { get; set; }

        public string NormalizedUserName { get; set; }

        public string PasswordHash { get; set; }

        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public string SecurityStamp { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public string UserName { get; set; }

        #region Исходники
        //modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
        //        {
        //            b.Property<string>("Id")
        //                .HasColumnType("nvarchar(450)");

        //b.Property<int>("AccessFailedCount")
        //                .HasColumnType("int");

        //b.Property<string>("ConcurrencyStamp")
        //                .IsConcurrencyToken()
        //                .HasColumnType("nvarchar(max)");

        //b.Property<string>("Email")
        //                .HasColumnType("nvarchar(256)")
        //                .HasMaxLength(256);

        //b.Property<bool>("EmailConfirmed")
        //                .HasColumnType("bit");

        //b.Property<bool>("LockoutEnabled")
        //                .HasColumnType("bit");

        //b.Property<DateTimeOffset?>("LockoutEnd")
        //                .HasColumnType("datetimeoffset");

        //b.Property<string>("NormalizedEmail")
        //                .HasColumnType("nvarchar(256)")
        //                .HasMaxLength(256);

        //b.Property<string>("NormalizedUserName")
        //                .HasColumnType("nvarchar(256)")
        //                .HasMaxLength(256);

        //b.Property<string>("PasswordHash")
        //                .HasColumnType("nvarchar(max)");

        //b.Property<string>("PhoneNumber")
        //                .HasColumnType("nvarchar(max)");

        //b.Property<bool>("PhoneNumberConfirmed")
        //                .HasColumnType("bit");

        //b.Property<string>("SecurityStamp")
        //                .HasColumnType("nvarchar(max)");

        //b.Property<bool>("TwoFactorEnabled")
        //                .HasColumnType("bit");

        //b.Property<string>("UserName")
        //                .HasColumnType("nvarchar(256)")
        //                .HasMaxLength(256);

        //b.HasKey("Id");

        //            b.HasIndex("NormalizedEmail")
        //                .HasName("EmailIndex");

        //b.HasIndex("NormalizedUserName")
        //                .IsUnique()
        //                .HasName("UserNameIndex")
        //                .HasFilter("[NormalizedUserName] IS NOT NULL");

        //b.ToTable("AspNetUsers");

            #endregion

    }
}
