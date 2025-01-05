using System.Text.Json;
using static System.Reflection.Metadata.BlobBuilder;

namespace Bibliotekshanteringssystem_AVANCERAD
{
    internal class Savedata
    {
        var json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(FilePath, json);
    }

    public void AddBook()
    {
            Console.Write("Enter the book title: ");
            string title = Console.ReadLine();

            Console.Write("Enter the name of the author: ");
            string author = Console.ReadLine();

            Console.Write("Enter genre: ");
            string genre = Console.ReadLine();

            Console.Write("Enter publicationyear: ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("Enter ISBN: ");
            string isbn = Console.ReadLine();

            int id = Book.Any() ? Book.Max(b => b.Id) + 1 : 1;
            Book.Add(new Book { Id = id, Title = title, Author = author, Genre = genre, PublicationYear = year, Isbn = isbn });

            Console.WriteLine("The book is added.");
    }

    public void AddAuthor()
    {
            Console.Write("Enter the name of the author: ");
            string name = Console.ReadLine();

            Console.Write("Enter the country of the author: ");
            string country = Console.ReadLine();

            int id = Author.Any() ? Author.Max(a => a.Id) + 1 : 1;
            Author.Add(new Author { Id = id, Name = name, Country = country });

            Console.WriteLine("Author is added.");
    }

    public void ListAll()
    {
            Console.WriteLine("\nBöcker:");
            foreach (var book in Book)
            {
                Console.WriteLine($"ID: {book.Id}, Titel: {book.Title}, Författare: {book.Author}, Genre: {book.Genre}, År: {book.PublicationYear}, ISBN: {book.Isbn}, Medelbetyg: {book.AverageRating:F1}");
            }

            Console.WriteLine("\nFörfattare:");
            foreach (var author in Author)
            {
                Console.WriteLine($"ID: {author.Id}, Namn: {author.Name}, Land: {author.Country}");
            }

    }
}