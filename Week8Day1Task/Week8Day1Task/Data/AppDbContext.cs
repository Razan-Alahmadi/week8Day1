using System.Collections.Generic;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Week8Day1Task.Models;

namespace Week8Day1Task.Data
{
    public class AppDbContext: DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Models.User> Users { get; set; }
        public DbSet<Models.Order> Orders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne(order => order.User)
                .WithMany(user => user.Orders)
                .HasForeignKey(order => order.UserId);
        }

    }
}
