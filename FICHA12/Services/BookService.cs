using System;
using FICHA12.Models;
using Microsoft.EntityFrameworkCore;

namespace FICHA12.Services
{
	public class BookService:IBookService
	{
        private readonly LibraryContext context;


        public Inumerable<Book> GetAll()
        {
            var books = context.Books.Include(p => p.Publisher);
            return books;
        }

        /*public BookService( LibraryContext context)
		{
            this.context = context;
		}

        public Book Create(Book newBook)
        {
            throw new NotImplementedException();
        }

        public void DeleteByISBN(string isbn)
        {
            throw new NotImplementedException();
        }

        public void Download()
        {
            throw new NotImplementedException();
        }

        public Book GetByAuthor(string author)
        {
            throw new NotImplementedException();
        }

        public Book GetByISBN(string isbn)
        {
            throw new NotImplementedException();
        }

        public void Update(string isbn, Book book)
        {
            throw new NotImplementedException();
        }

        public void UpdatePublisher(string isbn, int publisherId)
        {
            throw new NotImplementedException();
        }*/
    }
}

