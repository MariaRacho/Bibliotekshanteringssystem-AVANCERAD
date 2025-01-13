using System.Text.Json.Serialization;

namespace Bibliotekshanteringssystem_AVANCERAD
{
    public class LibraryData
    {
        [JsonPropertyName("Books")]
        public List<Book> Books { get; set; }

        [JsonPropertyName("Authors")]
        public List<Author> Authors { get; set; }

        public LibraryData(List<Book> AllBooks, List<Author> AllAuthors ) { Books = AllBooks; Authors = AllAuthors; }
        public LibraryData() { }
    }
}