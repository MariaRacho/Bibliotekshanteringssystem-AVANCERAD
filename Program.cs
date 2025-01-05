using System.Runtime.InteropServices;

namespace Bibliotekshanteringssystem_AVANCERAD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            bool running = true;
            while (running)
            {
                Console.WriteLine("Add new book");
                Console.WriteLine("Add new author");
                Console.WriteLine("Update book info");
                Console.WriteLine("Update author info");
                Console.WriteLine("Delete book");
                Console.WriteLine("Delete author");
                Console.WriteLine("List of all books and authors");
                Console.WriteLine("Search and filter books");
                Console.WriteLine("Exit and save the data");

                Console.WriteLine("Choose an option");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        library.AddBook();
                        break;

                    case "2":
                        library.AddAuthor();
                        break;

                    case "3":
                        library.UpdateBook();
                        break;

                    case "4":
                        library.UpdateAuthor();
                        break;

                    case "5":
                        library.RemoveBook();
                        break;

                    case "6":
                        library.RemoveAuthor();
                        break;

                    case "7":
                        library.ListAll();
                        break;

                    case "8":
                        library.SearchAndFilter();
                        break;

                    case "9":
                        library.SaveData();
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choose. Please try again.");
                        break;


                }
            }
        }
    }
}
