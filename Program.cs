﻿using BookStore;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

//static void Main()
//{

//}

using (var context = new BookStoreContext())
{
    //context.Database.EnsureDeleted();
    context.Database.EnsureCreated();
    var author = new Author
    {
        Name = "George R.R. Martin",
        Books = new List<Book>
        {
            new Book { Title = "Game of Thrones" },
            new Book { Title = "Clash of Kings" }
        }


    };

    context.Authors.Add(author);
    context.SaveChanges();

    var authors = context.Authors.Include(a => a.Books).ToList();
    foreach(var a in authors)
    {
        Console.WriteLine("Autor: " + a.Name);
        Console.WriteLine("Książki: ");
        foreach (var b in a.Books)
        {
            Console.WriteLine("   " + b.Title);
        }
    }
}