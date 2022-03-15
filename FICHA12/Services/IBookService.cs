using System;
using FICHA12.Models;

namespace FICHA12
{
	public interface IBookService
	{
		public abstract IEnumerable<Book> GetAll();
		public abstract Book? GetByISBN(string isbn);
		public abstract Book GetByAuthor(string author);
		public abstract Book Create(Book newBook);
		public abstract void DeleteByISBN(string isbn);
		public abstract void Update(string isbn, Book book);
		public abstract void UpdatePublisher(string isbn, int publisherId);
		public abstract void Download();
		









	}
}

