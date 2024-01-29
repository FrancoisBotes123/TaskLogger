using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskLoggerApi.Models;
using TaskLoggerApi.Models.Tasks;
using TaskLoggerApi.Models.User;


namespace TaskLoggerApi.Data
{
    public class TaskLoggerDbContext : IdentityDbContext<AppUser, AppRole, int, 
        IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>,
        IdentityUserToken<int>>
    {

        public TaskLoggerDbContext(DbContextOptions<TaskLoggerDbContext> options) : base(options)
        {
        }

        public DbSet<Taskss> Tasks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User to Task relationship
            modelBuilder.Entity<AppUser>()
                .HasMany(u => u.Tasks)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId);

            modelBuilder.Entity<AppUser>()
                .HasMany(ur => ur.Roles)
                .WithOne(u => u.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();

            modelBuilder.Entity<AppRole>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();

        }
    }
}
