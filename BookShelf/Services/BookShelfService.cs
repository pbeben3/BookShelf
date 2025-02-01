using BookShelf.DbContext;
using BookShelf.Models;
using Microsoft.EntityFrameworkCore;


namespace BookShelf.Services
{
    public class BookShelfService
    {
        private readonly BookShelfDbContext _context;

        public BookShelfService(BookShelfDbContext context)
        {
            _context = context;
        }

        public async Task<Book?> GetRandomBookAsync()
        {
            var books = await _context.Books
                                       .Include(b => b.Category)  
                                       .ToListAsync();

            if (books.Count == 0) return null;

            var random = new Random();
            return books[random.Next(books.Count)];
        }

        public async Task<List<Book>> GetBooksByCategoryAsync(BookCategory bookCategory)
        {
            return await _context.Books
                .Where(book => book.CategoryId == (int)bookCategory)
                .ToListAsync();
        }


        public async Task AddBookAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int categoryId)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);
        }
        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        //public async Task DeleteBookAsync(int bookId)
        //{
        //    var book = await _context.Books.FindAsync(bookId);
        //    if (book != null)
        //    {
        //        _context.Books.Remove(book);
        //        await _context.SaveChangesAsync();
        //    }
        //}

        //public async Task<List<Book>> GetAllBooksAsync()
        //{
        //    return await _context.Books.ToListAsync();
        //}





    }

}
