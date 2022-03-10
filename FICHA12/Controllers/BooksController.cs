using System;
using FICHA12.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace FICHA12.Controllers
{
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
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

	
}

