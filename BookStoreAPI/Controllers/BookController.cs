using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookStoreAPI.Repository;
using BookStoreAPI.Model;

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public readonly IBookRepository _repository;

        public BookController(IBookRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<ActionResult<Book>> Create(Book book)
        {
            var newBook = _repository.Create(book);
            return CreatedAtAction(nameof(Create), new { id = newBook.Id }, newBook);
        }

        [HttpGet]
        public async Task<IEnumerable<Book>> Get()
        {
            return await _repository.Get();
        }

        [HttpGet("(id)")]
        public async Task<ActionResult<Book>> Get(int id)
        {
            return await _repository.Get(id);
        }

        [HttpPut]
        public async Task<ActionResult<Book>> Update (int id,[FromBody]Book book)
        {
            if(id != book.ID)
            {
                return NotFound();
            }

            await _repository.Update(book);

            return NotFound();

        }

        [HttpDelete]
        public async Task<ActionResult<Book>> Delete(int id)
        {
            var bookToDelete = await _repository.Get(id);

            if(bookToDelete == null)
            {
                return NotFound();
            }

            await _repository.Delete(bookToDelete.ID);

            return NoContent();
        }
    }
}
