using System;
using FICHA12.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FICHA12.Data
{
    public static class LibraryExtension
    {
        public static void CreateDbIfNotExists(this IHost host)
        {
            {
                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    var context = services.GetRequiredService<LibraryContext>();
                    // Creates the database if not exists
                    if (context.Database.EnsureCreated())
                    {
                        LibraryDBInitializer.InsertData(context);
                    }
                }
            }
        }
    }
}

