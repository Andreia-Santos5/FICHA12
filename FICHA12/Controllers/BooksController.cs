using FICHA12.Models;
using FICHA12.Services;
using Microsoft.AspNetCore.Mvc;
namespace FICHA12.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

	public class BooksController: ControllerBase
	{
		private readonly IBookService service;

		public BooksController(IBookService service)
		{
			this.service = service;
		}

		//Get: api/<BooksController>
		[HttpGet]
		public IEnumerable<Book> Get()
		{
			return service.GetAll();
		}

        // GET api/<BooksController>/5
        [HttpGet("{isbn}", Name = "GetByISBN")]
        public IActionResult Get(string isbn)
        {
            Book? book = service.GetByISBN(isbn);
            if (book == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(book);
            }
        }

        [HttpGet("{author}", Name ="GetByAuthor")]
        public IActionResult GetAuthor(string author)
        {
            Book? book = service.GetByAuthor(author);
            if (book == null)
            {
                return NotFound();

            }
            else
            {
                return Ok(author);
            }
        }


        // POST api/<BooksController>
        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            if (book != null)
            {
                Book newBook = service.Create(book);
                return CreatedAtRoute("GetByISBN", new { isbn = newBook.ISBN }, newBook);
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT api/<BooksController>/5
        [HttpPut("{isbn}")]
        public IActionResult Put(string isbn, [FromBody] Book book)
        {
            var bookToUpdate = service.GetByISBN(isbn);
            if (book is not null && bookToUpdate is not null)
            {
                service.Update(isbn, book);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }


        // DELETE api/<BooksController>/5
        [HttpDelete("{isbn}")]
        public IActionResult Delete(string isbn)
        {
            var book = service.GetByISBN(isbn);

            if (book is not null)
            {
                service.DeleteByISBN(isbn);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        //https://localhost:7240/api/Books/978-0544003411/publisherId?publisherId=2
        // PATCH api/<BooksController>/5
        [HttpPatch("{isbn}/publisherId")]
        public IActionResult Patch(string isbn, int publisherId)
        {
            var bookToUpdate = service.GetByISBN(isbn);
            if (bookToUpdate is not null)
            {
                service.UpdatePublisher(isbn, publisherId);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }





    }

	
}

