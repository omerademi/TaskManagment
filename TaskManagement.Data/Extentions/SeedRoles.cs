using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Entities;

namespace TaskManagement.Data.Extentions
{
   public static class SeedRoles
    {
        public static void Roles(this ModelBuilder modelBuilder)
        {
            #region Create roles
            modelBuilder
                .Entity<UserRole>()
                .HasData(new IdentityRole
                {
                    Id = "a5e38752-84ae-4352-a0b6-bf47b3fd460a",
                    Name = "Manager",
                    NormalizedName = "MANAGER"
                });

            modelBuilder
              .Entity<UserRole>()
              .HasData(new IdentityRole
              {
                  Id = "d90e75c6-7da9-490e-aeb0-3d8c4827e193",
                  Name = "Employee",
                  NormalizedName = "EMPLOYEE"
              });
            #endregion

            #region Create Users
            var hasher = new PasswordHasher<User>();

            var adminOmer = new User
            {
                Id = "69e7930c-3df5-4261-99cf-0352eb018a91",
                UserName = "omer@manager.com",
                NormalizedUserName = "OMER@MANAGER.COM",
                Email = "omer@manager.com",
                NormalizedEmail = "OMER@MANAGER.COM",
                SecurityStamp = "7I5VNHIJTSZNOT3KDWKNFUV5PVYBHGXN",
                LockoutEnabled = true
            };

            var employeeTranquila = new User
            {
                Id = "9009a034-7f66-455f-b76f-4f873dc93741",
                UserName = "tranquila@employee.com",
                NormalizedUserName = "TRANQUILA@EMPLOYEE.COM",
                Email = "tranquila@employee.com",
                NormalizedEmail = "TRANQUILA@EMPLOYEE.COM",
                SecurityStamp = "7I5VNHIJTSZNOT3KDWKNUUV5PVYBHGXN",
                LockoutEnabled = true
            };

            var employeeHeksos = new User
            {
                Id = "4a55904b-910e-46c3-8df7-a138a2b73a8a",
                UserName = "heksos@employee.com",
                NormalizedUserName = "HEKSOS@EMPLOYEE.COM",
                Email = "heksos@employee.com",
                NormalizedEmail = "HEKSOS@EMPLOYEE.COM",
                SecurityStamp = "7I5VNHIJTSZNOT3KDWKNULV5PVYBHGXN",
                LockoutEnabled = true
            };
            #endregion

            #region Set passwords of users
            adminOmer.PasswordHash = hasher
                .HashPassword(adminOmer, "12345");

            employeeTranquila.PasswordHash = hasher
                .HashPassword(employeeTranquila, "12345");

            employeeHeksos.PasswordHash = hasher
                .HashPassword(employeeHeksos, "12345");
            #endregion

            #region Set user to role
            modelBuilder.Entity<User>()
                .HasData(adminOmer); 
            modelBuilder.Entity<User>()
                .HasData(employeeTranquila);
            modelBuilder.Entity<User>()
               .HasData(employeeHeksos);


            modelBuilder
                .Entity<IdentityUserRole<string>>()
                .HasData(new IdentityUserRole<string>
                { UserId = adminOmer.Id, RoleId = "a5e38752-84ae-4352-a0b6-bf47b3fd460a" });

            modelBuilder
               .Entity<IdentityUserRole<string>>()
               .HasData(new IdentityUserRole<string>
               { UserId = employeeTranquila.Id, RoleId = "d90e75c6-7da9-490e-aeb0-3d8c4827e193" });

            modelBuilder
               .Entity<IdentityUserRole<string>>()
               .HasData(new IdentityUserRole<string>
               { UserId = employeeHeksos.Id, RoleId = "d90e75c6-7da9-490e-aeb0-3d8c4827e193" });
            #endregion
        }
    }
}
