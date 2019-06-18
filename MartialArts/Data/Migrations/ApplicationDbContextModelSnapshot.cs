﻿// <auto-generated />
using System;
using MartialArts.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MartialArts.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MartialArts.Models.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DayOfWeek");

                    b.Property<DateTime>("EndTime");

                    b.Property<DateTime>("StartTime");

                    b.Property<int>("StyleId");

                    b.HasKey("Id");

                    b.HasIndex("StyleId");

                    b.ToTable("Class");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DayOfWeek = 2,
                            EndTime = new DateTime(2019, 6, 18, 19, 0, 0, 0, DateTimeKind.Unspecified),
                            StartTime = new DateTime(2019, 6, 18, 17, 30, 0, 0, DateTimeKind.Unspecified),
                            StyleId = 2
                        },
                        new
                        {
                            Id = 2,
                            DayOfWeek = 3,
                            EndTime = new DateTime(2019, 6, 18, 19, 0, 0, 0, DateTimeKind.Unspecified),
                            StartTime = new DateTime(2019, 6, 18, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            StyleId = 2
                        });
                });

            modelBuilder.Entity("MartialArts.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndTime");

                    b.Property<bool>("IsTesting");

                    b.Property<string>("Location");

                    b.Property<string>("LocationNotes");

                    b.Property<int>("StaffId");

                    b.Property<DateTime>("StartTime");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("StaffId");

                    b.ToTable("Event");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "testing",
                            EndTime = new DateTime(2019, 6, 9, 17, 0, 0, 0, DateTimeKind.Unspecified),
                            IsTesting = true,
                            Location = "4908-B Charlotte Ave Nashville TN 37209",
                            LocationNotes = "parking available across the street",
                            StaffId = 1,
                            StartTime = new DateTime(2019, 6, 9, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Testing"
                        });
                });

            modelBuilder.Entity("MartialArts.Models.EventStyle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EventId");

                    b.Property<int>("StyleId");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("StyleId");

                    b.ToTable("EventStyle");
                });

            modelBuilder.Entity("MartialArts.Models.Form", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("RankId");

                    b.Property<int>("StyleId");

                    b.HasKey("Id");

                    b.HasIndex("RankId");

                    b.HasIndex("StyleId");

                    b.ToTable("Form");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Basic One",
                            RankId = 3,
                            StyleId = 2
                        });
                });

            modelBuilder.Entity("MartialArts.Models.Rank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("StyleId");

                    b.Property<string>("TimeInRank")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("StyleId");

                    b.ToTable("Rank");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Student",
                            StyleId = 1,
                            TimeInRank = "0 invalid"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Senior Instructor",
                            StyleId = 1,
                            TimeInRank = "0 invalid"
                        },
                        new
                        {
                            Id = 3,
                            Name = "White Belt",
                            StyleId = 2,
                            TimeInRank = "2 months"
                        });
                });

            modelBuilder.Entity("MartialArts.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<DateTime>("FirstClass");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<int>("InternalRankId");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("Phone");

                    b.HasKey("Id");

                    b.HasIndex("InternalRankId");

                    b.ToTable("Student");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = false,
                            Address = "3804 Round Rock",
                            Email = "oddball79@gmail.com",
                            FirstClass = new DateTime(1990, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Michael",
                            InternalRankId = 2,
                            LastName = "Farnette"
                        },
                        new
                        {
                            Id = 2,
                            Active = false,
                            Address = "3804 Round Rock",
                            Email = "naienko@gmail.com",
                            FirstClass = new DateTime(2008, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Panya",
                            InternalRankId = 1,
                            LastName = "Farnette"
                        });
                });

            modelBuilder.Entity("MartialArts.Models.StudentForms", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FormId");

                    b.Property<int>("StudentId");

                    b.Property<int>("StyleId");

                    b.HasKey("Id");

                    b.HasIndex("FormId");

                    b.HasIndex("StudentId");

                    b.HasIndex("StyleId");

                    b.ToTable("StudentForms");
                });

            modelBuilder.Entity("MartialArts.Models.StudentStyle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RankId");

                    b.Property<int>("StudentId");

                    b.Property<int>("StyleId");

                    b.HasKey("Id");

                    b.HasIndex("RankId");

                    b.HasIndex("StudentId");

                    b.HasIndex("StyleId");

                    b.ToTable("StudentStyle");
                });

            modelBuilder.Entity("MartialArts.Models.Style", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Style");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "pseudo-style to hold ranks internal to the school",
                            Name = "Internal"
                        },
                        new
                        {
                            Id = 2,
                            Description = "A style focused on kicking",
                            Name = "Tae Kwon Do"
                        });
                });

            modelBuilder.Entity("MartialArts.Models.attendance_class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClassId");

                    b.Property<DateTime>("Date");

                    b.Property<int>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("StudentId");

                    b.ToTable("Attendance_Class");
                });

            modelBuilder.Entity("MartialArts.Models.attendance_test", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EventId");

                    b.Property<int>("StudentId");

                    b.Property<bool>("did_pass");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("StudentId");

                    b.ToTable("Attendance_Test");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("MartialArts.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("Phone");

                    b.HasDiscriminator().HasValue("ApplicationUser");

                    b.HasData(
                        new
                        {
                            Id = "8927b935-ed00-4063-951e-5e6e8aee8d1e",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "164ec6fe-9318-4437-947c-6fd7fe856e45",
                            Email = "admin@admin.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@ADMIN.COM",
                            NormalizedUserName = "ADMIN@ADMIN.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAELugKhT8st27f4mi3gZARhDnzPoT6rAdZV3Y1GptzRF3W2cLY4Jp2jffa+YCByQxnA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "cf932f17-8443-452e-b71e-75c19d0c97e0",
                            TwoFactorEnabled = false,
                            UserName = "admin@admin.com",
                            Address = "3804 Round Rock Dr Antioch TN 37013",
                            FirstName = "Panya",
                            LastName = "Farnette",
                            Phone = "(615) 438-2777"
                        });
                });

            modelBuilder.Entity("MartialArts.Models.Class", b =>
                {
                    b.HasOne("MartialArts.Models.Style", "Style")
                        .WithMany("Classes")
                        .HasForeignKey("StyleId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("MartialArts.Models.Event", b =>
                {
                    b.HasOne("MartialArts.Models.Student", "Staff")
                        .WithMany()
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MartialArts.Models.EventStyle", b =>
                {
                    b.HasOne("MartialArts.Models.Event", "Event")
                        .WithMany("Style")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("MartialArts.Models.Style", "Style")
                        .WithMany("Events")
                        .HasForeignKey("StyleId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("MartialArts.Models.Form", b =>
                {
                    b.HasOne("MartialArts.Models.Rank", "Rank")
                        .WithMany()
                        .HasForeignKey("RankId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MartialArts.Models.Style", "Style")
                        .WithMany("Forms")
                        .HasForeignKey("StyleId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("MartialArts.Models.Rank", b =>
                {
                    b.HasOne("MartialArts.Models.Style", "Style")
                        .WithMany("Ranks")
                        .HasForeignKey("StyleId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("MartialArts.Models.Student", b =>
                {
                    b.HasOne("MartialArts.Models.Rank", "InternalRank")
                        .WithMany()
                        .HasForeignKey("InternalRankId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MartialArts.Models.StudentForms", b =>
                {
                    b.HasOne("MartialArts.Models.Form", "Form")
                        .WithMany("Students")
                        .HasForeignKey("FormId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("MartialArts.Models.Student", "Student")
                        .WithMany("Forms")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("MartialArts.Models.Style", "Style")
                        .WithMany("StudentForms")
                        .HasForeignKey("StyleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MartialArts.Models.StudentStyle", b =>
                {
                    b.HasOne("MartialArts.Models.Rank", "Rank")
                        .WithMany("Students")
                        .HasForeignKey("RankId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MartialArts.Models.Student", "Student")
                        .WithMany("Styles")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("MartialArts.Models.Style", "Style")
                        .WithMany("Students")
                        .HasForeignKey("StyleId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("MartialArts.Models.attendance_class", b =>
                {
                    b.HasOne("MartialArts.Models.Class", "Class")
                        .WithMany("Attendance_Classes")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("MartialArts.Models.Student", "Student")
                        .WithMany("Attendance_Classes")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("MartialArts.Models.attendance_test", b =>
                {
                    b.HasOne("MartialArts.Models.Event", "Event")
                        .WithMany("Attendance_Test")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("MartialArts.Models.Student", "Student")
                        .WithMany("Attendance_Test")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
