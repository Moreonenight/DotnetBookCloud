using DotnetBookCloud.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetBookCloud
{
    public class BookCloudDBContext : DbContext
    {
        public BookCloudDBContext(DbContextOptions<BookCloudDBContext> options)
    : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartItem>(t =>
            {
                t.HasKey(x => new { x.UserId, x.BookId });
            });

            modelBuilder.Entity<OrderItem>(t =>
            {
                t.HasKey(x => new { x.OrderId, x.BookId });
            });
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<CartItem> CartItems { get; set; }
    }
}