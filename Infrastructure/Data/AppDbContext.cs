using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Core.Entities.Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            this.SeedUsers(builder);
            this.SeedRoles(builder);
            this.SeedUserRoles(builder);
        }

        private void SeedUsers(ModelBuilder builder)
        {
            AppUser user = new AppUser()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                UserName = "admin@mindweb.app",
                NormalizedUserName = "ADMIN@MINDWEB.APP",
                Email = "admin@mindweb.app",
                NormalizedEmail = "ADMIN@MINDWEB.APP",
                LockoutEnabled = false,
                PhoneNumber = "1234567890",
                FirstName = "Super",
                LastName = "Administrator",
                MiddleName = string.Empty,
                IsGranted = true,
                UserStatus = true,
                UserType = "Admin"
            };

            PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();
            user.PasswordHash = passwordHasher.HashPassword(user, "Admin*123");


            builder.Entity<AppUser>().HasData(user);
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "fab4fac1-c546-41de-aebc-a14da6895711", Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                new IdentityRole() { Id = "c7b013f0-5201-4317-abd8-c211f91b7330", Name = "User", ConcurrencyStamp = "2", NormalizedName = "User" }
                );
        }

        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "fab4fac1-c546-41de-aebc-a14da6895711", UserId = "b74ddd14-6340-4840-95c2-db12554843e5" }
                );
        }

    }
}
