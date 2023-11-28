using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions<TestContext> options) : base(options) { }

        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tasks>().ToTable("Tasks").HasOne(x => x.User).WithMany(x => x.Tasks);
            modelBuilder.Entity<User>().ToTable("User");
            base.OnModelCreating(modelBuilder);
        }
    }
}
