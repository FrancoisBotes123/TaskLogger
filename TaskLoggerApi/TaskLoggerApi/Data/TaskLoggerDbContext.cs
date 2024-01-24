using Microsoft.EntityFrameworkCore;
using TaskLoggerApi.Models;


namespace TaskLoggerApi.Data
{
    public class TaskLoggerDbContext : DbContext
    {

        public TaskLoggerDbContext(DbContextOptions<TaskLoggerDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Groups> Groups { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User to Task relationship
            modelBuilder.Entity<User>()
                .HasMany(u => u.Tasks)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId);

            // Pool to Manager (User) relationship
            modelBuilder.Entity<Groups>()
                .HasOne(p => p.Manager)
                .WithMany()
                .HasForeignKey(p => p.ManagerId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete

            // If a user can belong to multiple pools, a junction table is needed
            modelBuilder.Entity<Groups>()
                .HasMany(p => p.Users)
                .WithMany(u => u.Groups)
                .UsingEntity(j => j.ToTable("UserPools")); // This creates a junction table named 'UserPools'
        }
    }
}
