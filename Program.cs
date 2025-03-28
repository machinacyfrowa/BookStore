using BookStore;
using System.Net.Http.Headers;

//static void Main()
//{

//}

using (var context = new BookStoreContext())
{
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();
    var author = new Author
    {
        Name = "George R.R. Martin",
        Books = new List<Book>()

    };
    Book book = new Book { Title = "Game of Thrones", Author = author };

    context.Authors.Add(author);
    context.Books.Add(book);
    context.SaveChanges();

    var authors = context.Authors.ToList();
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