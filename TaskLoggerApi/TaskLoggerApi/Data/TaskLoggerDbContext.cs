using Microsoft.EntityFrameworkCore;
using TaskLoggerApi.Models;
using TaskLoggerApi.Models.User;


namespace TaskLoggerApi.Data
{
    public class TaskLoggerDbContext : DbContext
    {

        public TaskLoggerDbContext(DbContextOptions<TaskLoggerDbContext> options) : base(options)
        {
        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Groups> Groups { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User to Task relationship
            modelBuilder.Entity<AppUser>()
                .HasMany(u => u.Tasks)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId);

            // Pool to Manager (User) relationship
            modelBuilder.Entity<Groups>()
                .HasOne(p => p.Manager)
                .WithMany()
                .HasForeignKey(p => p.ManagerId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete

            // If a user can belong to multiple groups, a junction table is needed
            modelBuilder.Entity<Groups>()
                .HasMany(p => p.Users)
                .WithMany(u => u.Groups)
                .UsingEntity(j => j.ToTable("UserGroups")); // This creates a junction table named 'UserGroups'

           /* // Seed data
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, UserName = "admin", Role = UserRole.Admin },
                new User { UserId = 2, UserName = "manager", Role = UserRole.Manager },
                new User { UserId = 3, UserName = "user", Role = UserRole.User }
            );

            modelBuilder.Entity<Groups>().HasData(
                new Groups { GroupsId = 1, GroupsName = "Development", ManagerId = 2 }
            );

            modelBuilder.Entity<Tasks>().HasData(
                new Tasks { TasksId = 1, Title = "Initial Task", Description = "This is a seeded task", IsCompleted = false, CreatedDate = DateTime.Now, UserId = 3 }
            );*/
        }
    }
}
