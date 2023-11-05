using BookStation.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAllBooks()
        {
            var books  = await _bookRepository.GetAllBooks();

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(books);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetOneBook(int id)
        {
            var result = await _bookRepository.GetOneBook(id);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Book>>> AddBook(Book book)
        {
            var resut = await _bookRepository.AddBook(book);
            return Ok(resut);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Book>>> UpdateBook(int id, Book request)
        {
            var result = await _bookRepository.UpdateBook(id, request);

            if (result is null)
                return NotFound();
           
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Book>>> DeleteBook(int id)
        {
            var result = await _bookRepository.DeleteBook(id);

            if(result is null)
                return NotFound();

            return Ok(result);
        }
    }
}
