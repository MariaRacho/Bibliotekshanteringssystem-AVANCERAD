using System.Diagnostics.Metrics;
using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace Bibliotekshanteringssystem_AVANCERAD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Välkommen till till bibliotek
            Console.WriteLine("Welcome to the library");

            //DataManipulation.ReadData();

            LibraryData listsFromJson = DataManipulation.ReadData();
            // iställer för void och att skriva ut
            // du ska ändra så att den här metoden returnerar listorna (books och authors)
            // för att sen, när du deklarerar din Library,
            // du har en konstruktor som tar emot dessa listor och
            // sätter värde till de listorna som du använder för CRUD

            //Skapar biblioteket
            // how it should look like 
            Library library = new Library(listsFromJson.Books, listsFromJson.Authors);

            //Lista för vad du ska kunna göra och välja mellan
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

                Console.WriteLine("Choose an option please");
                string choice = Console.ReadLine();

                //Skapar alla mina case för vad man skall kunna göra i biblioteket
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
                        library.ListBooks();
                        break;

                    case "8":
                        library.ListAuthors();
                        break;

                    case "9":
                        library.SaveData();
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please choose again.");
                        break;

                }
            }
        }
    }
}
