using BookStation.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookStation.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;

        public BookRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Book>> GetAllBooks()
        {
            var books = await _context.Books.OrderBy(b => b.Id).ToListAsync();
            return books;
        }

        public async Task<Book> GetOneBook(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book is null)
                return null;

            return book;
        }

        public async Task<List<Book>> AddBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return await _context.Books.ToListAsync();
        }

        public async Task<List<Book>> UpdateBook(int id, Book request)
        {
            var book = await _context.Books.FindAsync(id);

            if (book is null)
                return null;

            book.Name = request.Name;
            book.Author = request.Author;
            book.Review = request.Review;

            await _context.SaveChangesAsync();

            return await _context.Books.ToListAsync();
        }
        public async Task<List<Book>> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book is null)
                return null;

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return await _context.Books.ToListAsync();
        }
    }
}
