using System;
using System.Collections.Generic;
using FICHA12.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        // GET api/values/5
        [HttpGet("{isbn}")]
        public IActionResult Get (string isbn)
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

        [HttpGet("{author}")]
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


        // POST api/values
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult PostNewBook([FromBody] Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid book");
            }
            using (var ctx= new LibraryContext())
            {
                ctx.Books.Add(new Book()
                {
                    ISBN = book.ISBN,
                    Title = book.Title,
                    Author = book.Author,
                    Language = book.Language,
                    Pages = book.Pages,
                    Publisher = book.Publisher


                });
                ctx.SaveChanges();
            }
            return Ok();

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(string isbn, [FromBody] Book book)
        {
            if(book.ISBN == null)
            {
                newBook.ISBN = book.ISBN;
                newBook.Title = book.Title;
                newBook.Author = book.Author;
                newBook.Language = book.Language;
                newBook.Pages = book.Pages;
                newBook.Publisher = book.Publisher;
                return newBook;
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }

	
}

