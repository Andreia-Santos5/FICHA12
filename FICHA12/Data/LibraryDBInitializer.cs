using System;
using FICHA12.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace FICHA12.Data
{
	public static class LibraryDBInitializer
	{
		public static void InsertData(LibraryContext context)
        {
			//Adds a publisher
			var publisher = new Publisher
			{
				Name = "Marine Books"
			};
			context.Publishers.Add(publisher);
			context.SaveChanges();


			//Adds some books
			context.Books.Add(new Book
			{
				ISBN = "978-0544003415",
				Title = "The Lord of the Rings",
				Author = "J.R.R. Tolkien",
				Language = "English",
				Pages = 1216,
				Publisher = publisher
			});

			context.SaveChanges();



        }
	}
}

