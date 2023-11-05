using Microsoft.AspNetCore.Mvc;

namespace BookStation.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllBooks();
        Task<Book> GetOneBook(int id);
        Task<List<Book>> AddBook(Book book);
        Task<List<Book>> UpdateBook(int id, Book request);
        Task<List<Book>> DeleteBook(int id);
    }
}
