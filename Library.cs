using System.Reflection;
using System.Text.Json;
using static System.Reflection.Metadata.BlobBuilder;
using System.Linq;
using Spectre.Console;
using System.Diagnostics.Metrics;
using System.Xml.Linq;


namespace Bibliotekshanteringssystem_AVANCERAD
{
    internal class Library
    {
        //Skapa både bok lista och författar lista
        public List<Book> Books { get; set; }
        public List<Author> Authors { get; set; }
        public Library(List<Book> booksFromJson, List<Author> authorsFromJson) { Books = booksFromJson; Authors = authorsFromJson; }

        //Metod för att lägga till bok i listan
        public void AddBook()
        {
            Console.Write("Choose a book title: ");
            string title = Console.ReadLine();

            Console.Write("Choose the authors name: ");
            string author = Console.ReadLine();

            Console.Write("Choose genre: ");
            string genre = Console.ReadLine();

            Console.Write("State Publication Year: ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("State ISBN: ");
            string isbn = Console.ReadLine();

            int id = Books.Any() ? Books.Max(b => b.Id) + 1 : 1;
            List<int> reviews = new List<int>(new int[] { 1, 2, 3 });
           
            Books.Add(new Book (id, title, author, genre, year, isbn, reviews));

            Console.WriteLine("The book has been added.");
        }

        //Metod för att lägga till författare i listan
        public void AddAuthor()
        {
            Console.Write("Choose the name of the author: ");
            string name = Console.ReadLine();

            Console.Write("State the country of the author: ");
            string country = Console.ReadLine();

            int id = Authors.Any() ? Authors.Max(a => a.Id) + 1 : 1;

            Authors.Add(new Author (id, name, country));

            Console.WriteLine("The author has been added.");
        }

        //Metod för att uppdatera böckerna
        public void UpdateBook()
        {
            Console.Write("State book-ID to update: ");
            int id = int.Parse(Console.ReadLine());
            var book = Books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                Console.Write("State a new title (leave blank to keep current): ");
                string title = Console.ReadLine();
                if (!string.IsNullOrEmpty(title)) book.Title = title;

                Console.Write("State new author (leave blank to keep current): ");
                string author = Console.ReadLine();
                if (!string.IsNullOrEmpty(author)) book.Author = author;

                Console.Write("State new genre (leave blank to keep current): ");
                string genre = Console.ReadLine();
                if (!string.IsNullOrEmpty(genre)) book.Genre = genre;

                Console.Write("State a new Publication Year (leave blank to keep current): ");
                string yearInput = Console.ReadLine();
                if (int.TryParse(yearInput, out int year)) book.PublicationYear = year;

                Console.WriteLine("Book is updated.");
            }
            else
            {
                Console.WriteLine("Book is not found.");
            }
        }

        //Metod för att uppdatera författarna
        public void UpdateAuthor()
        {
            Console.Write("State author-ID to update: ");
            int id = int.Parse(Console.ReadLine());
            var author = Authors.FirstOrDefault(a => a.Id == id);
            if (author != null)
            {
                Console.Write("State new name (leave blank to keep current): ");
                string name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name)) author.Name = name;

                Console.Write("State a new country (leave blank to keep current): ");
                string country = Console.ReadLine();
                if (!string.IsNullOrEmpty(country)) author.Country = country;

                Console.WriteLine("Author is updated.");
            }
            else
            {
                Console.WriteLine("Author is not found.");
            }
        }

        //Metod för att radera utvalda böcker från listan
        public void RemoveBook()
        {
            Console.Write("State book-ID to remove: ");
            int id = int.Parse(Console.ReadLine());
            var book = Books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                Books.Remove(book);   
                
                Console.WriteLine("Book is removed.");
            }
            else
            {
                Console.WriteLine("Book is not found.");
            }
        }

        //Metod för att radera utvalda författare från listan
        public void RemoveAuthor()
        {
            Console.Write("State author-ID to remove: ");
            int id = int.Parse(Console.ReadLine());
            var author = Authors.FirstOrDefault(a => a.Id == id);
            if (author != null)
            {
                Authors.Remove(author);
                
                Console.WriteLine("Author is removed.");
            }
            else
            {
                Console.WriteLine("Author is not found.");
            }
        }

        //Metod flr att lista alla böcker
        public void ListBooks()
        {
            var table = new Table();
            table.AddColumn("ID");
            table.AddColumn("Title");
            table.AddColumn("Author");
            table.AddColumn("Genre");
            table.AddColumn("Publication Year");
            table.AddColumn("ISBN");
            table.AddColumn("Average Rating");

            foreach (var book in Books)
            {
                var averageRating = book.Reviews.Any() ? book.Reviews.Average().ToString("0.00") : "No Ratings";
                table.AddRow(book.Id.ToString(), book.Title, book.Author, book.Genre, book.PublicationYear.ToString(), book.ISBN.ToString(), averageRating);
            }

            AnsiConsole.Write(table);
        }

        // Metod för att lista alla författare
        public void ListAuthors()
        {
            var table = new Table();
            table.AddColumn("ID");
            table.AddColumn("Name");
            table.AddColumn("Country");

            foreach (var author in Authors)
            {
                table.AddRow(author.Id.ToString(), author.Name, author.Country);
            }

            AnsiConsole.Write(table);
        }

        public void SaveData()
        {
            DataManipulation.SaveData(new LibraryData(Books, Authors));
        }
    }
}

