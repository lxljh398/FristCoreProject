using Microsoft.EntityFrameworkCore;
using MySqlCodeFrist.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MySqlCodeFristConsole
{
    class TestDbContext : DbContext
    {
        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=localhost;database=TestDb;user=root;password=123456;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<User>().HasIndex(u => u.Aaccount).IsUnique();
        }
    }
}
