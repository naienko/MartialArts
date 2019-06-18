using System;
using System.Collections.Generic;
using System.Text;
using MartialArts.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MartialArts.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Class> Class { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<Form> Form { get; set; }
        public DbSet<Rank> Rank { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Style> Style { get; set; }

        //join tables
        public DbSet<attendance_class> Attendance_Class { get; set; }
        public DbSet<attendance_test> Attendance_Test { get; set; }
        public DbSet<EventStyle> EventStyle { get; set; }
        public DbSet<StudentForms> StudentForms { get; set; }
        public DbSet<StudentStyle> StudentStyle { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Event>()
                .HasMany(i => i.Attendance_Test)
                .WithOne(l => l.Event)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Student>()
                .HasMany(i => i.Attendance_Test)
                .WithOne(l => l.Student)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Class>()
                .HasMany(i => i.Attendance_Classes)
                .WithOne(l => l.Class)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Student>()
                .HasMany(i => i.Attendance_Classes)
                .WithOne(l => l.Student)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Class>()
                .HasOne(i => i.Style)
                .WithMany(l => l.Classes)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Style>()
                .HasMany(i => i.Classes)
                .WithOne(l => l.Style)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Form>()
                .HasMany(i => i.Students)
                .WithOne(l => l.Form)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Student>()
                .HasMany(i => i.Forms)
                .WithOne(l => l.Student)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Style>()
                .HasMany(i => i.Forms)
                .WithOne(l => l.Style)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Form>()
                .HasOne(i => i.Style)
                .WithMany(l => l.Forms)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Style>()
                .HasMany(i => i.Students)
                .WithOne(l => l.Style)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Student>()
                .HasMany(i => i.Styles)
                .WithOne(l => l.Student)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Event>()
                .HasMany(i => i.Style)
                .WithOne(l => l.Event)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Style>()
                .HasMany(i => i.Events)
                .WithOne(l => l.Style)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Rank>()
                .HasOne(i => i.Style)
                .WithMany(l => l.Ranks)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Style>()
                .HasMany(i => i.Ranks)
                .WithOne(l => l.Style)
                .OnDelete(DeleteBehavior.Restrict);

            ApplicationUser user = new ApplicationUser
            {
                FirstName = "Panya",
                LastName = "Farnette",
                Address = "3804 Round Rock Dr Antioch TN 37013",
                Phone = "(615) 438-2777",
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
            var passwordHash = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash.HashPassword(user, "ksama17");
            modelBuilder.Entity<ApplicationUser>().HasData(user);

            modelBuilder.Entity<Student>().HasData(
                new Student()
                {
                    Id = 1,
                    FirstName = "Michael",
                    LastName = "Farnette",
                    Address = "3804 Round Rock",
                    Email = "oddball79@gmail.com",
                    //YYYY-MM-DD HH:MI:SS
                    FirstClass = DateTime.Parse("1990-09-04 00:00:00"),
                    InternalRankId = 2
                },
                new Student()
                {
                    Id = 2,
                    FirstName = "Panya",
                    LastName = "Farnette",
                    Address = "3804 Round Rock",
                    Email = "naienko@gmail.com",
                    //YYYY-MM-DD HH:MI:SS
                    FirstClass = DateTime.Parse("2008-09-04 00:00:00"),
                    InternalRankId = 1
                }
            );

            modelBuilder.Entity<Rank>().HasData(
                new Rank()
                {
                    Id = 1,
                    Name = "Student",
                    TimeInRank = "0 invalid",
                    StyleId = 1
                },
                new Rank()
                {
                    Id = 2,
                    Name = "Senior Instructor",
                    TimeInRank = "0 invalid",
                    StyleId = 1
                },
                new Rank()
                {
                    Id = 3,
                    Name = "White Belt",
                    TimeInRank = "2 months",
                    StyleId = 2
                }
            );

            modelBuilder.Entity<Style>().HasData(
                new Style()
                {
                    Id = 1,
                    Name = "Internal",
                    Description = "pseudo-style to hold ranks internal to the school"
                },
                new Style()
                {
                    Id = 2,
                    Name = "Tae Kwon Do",
                    Description = "A style focused on kicking"
                }
            );

            modelBuilder.Entity<Class>().HasData(
                new Class()
                {
                    Id = 1,
                    StartTime = DateTime.Parse("5:30pm"),
                    EndTime = DateTime.Parse("7:00pm"),
                    DayOfWeek = 2,
                    StyleId = 2
                },
                new Class()
                {
                    Id = 2,
                    StartTime = DateTime.Parse("6:00pm"),
                    EndTime = DateTime.Parse("7:00pm"),
                    DayOfWeek = 3,
                    StyleId = 2
                }
            );

            modelBuilder.Entity<Form>().HasData(
                new Form()
                {
                    Id = 1,
                    Name = "Basic One",
                    StyleId = 2,
                    RankId = 3
                }
            );

            modelBuilder.Entity<Event>().HasData(
                new Event()
                {
                    Id = 1,
                    Title = "Testing",
                    IsTesting = true,
                    StartTime = DateTime.Parse("2019/06/09 9:00am"),
                    EndTime = DateTime.Parse("2019/06/09 5:00pm"),
                    Description = "testing",
                    Location = "4908-B Charlotte Ave Nashville TN 37209",
                    LocationNotes = "parking available across the street",
                    StaffId = 1
                }
            );
        }
    }
}
