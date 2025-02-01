using BookShelf.Models;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;


namespace BookShelf.DbContext
{
    public class BookShelfDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        private IConfiguration _configuration { get; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }

        public BookShelfDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            options.UseSqlite(connectionString); 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                Enum.GetValues(typeof(BookCategory))
                .Cast<BookCategory>()
                .Select(e => new Category
                {
                    Id = (int)e,
                    Name = e.ToString()
                })
            );
        }

    }
}
