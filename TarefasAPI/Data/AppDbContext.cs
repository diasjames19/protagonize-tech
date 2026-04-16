
using Microsoft.EntityFrameworkCore;
using TarefasAPI.Models;

namespace TarefasAPI.Data;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
         : base(options)
        {
        }

        public DbSet<TasksItem> TasksItems { get; set; }
        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<TasksItem>()
        .Property(t => t.Id)
        .ValueGeneratedOnAdd();
}

    }

