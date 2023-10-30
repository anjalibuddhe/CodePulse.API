using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CodePulse.API.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var readerRoleId = "9593b5cb-d6c3-45ef-8869-67c211952b00";
            var writerRoleId = "ad2d3724-5637-42cd-af35-257dee76068c";
            //create reader and writer role

            var roles = new List<IdentityRole>
            {
                new IdentityRole()
                {
                    Id=readerRoleId,
                    Name="Reader",
                    NormalizedName="Reader".ToUpper(),
                    ConcurrencyStamp=readerRoleId
                },
                new IdentityRole()
                {
                    Id=writerRoleId,
                    Name="Writer",
                    NormalizedName="Writer".ToUpper(),
                    ConcurrencyStamp=writerRoleId
                }
            };

            //Seed the role

            builder.Entity<IdentityRole>().HasData(roles);


            //create an admin User
            var adminUserId = "9c6fd07f-5760-4237-99ed-ab5bf8ffdeeb";
            var admin =new IdentityUser
            {
                Id = adminUserId,
                UserName = "admin@demo.com",
                Email = "admin@demo.com",
                NormalizedUserName = "ADMIN@DEMO.COM",
                NormalizedEmail= "ADMIN@DEMO.COM"
            };
            admin.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(admin, "Admin@123");

            builder.Entity<IdentityUser>().HasData(admin);



            //give roles to admin


            var adminRoles = new List<IdentityUserRole<string>>()
            {
                new()
                {
                    UserId = adminUserId,
                    RoleId = readerRoleId
                },
                new()
                {
                    UserId = adminUserId,
                    RoleId = writerRoleId
                }
            };

            builder.Entity<IdentityUserRole<string>>().HasData(adminRoles);

        }

    }
}
