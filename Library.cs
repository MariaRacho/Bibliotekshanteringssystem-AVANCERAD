using System.Text.Json;

namespace Bibliotekshanteringssystem_AVANCERAD
{
    internal class Library
    {
        private const string FilePath = "LibraryData.json";
        public List<Book> Books { get; set; } = new List<Book>();
        public List<Author> Author { get; set; } = new List<Author>();

        public void LoadData()
        {
            if (File.Exists(FilePath))
            {
                string json = File.ReadAllText(FilePath);
                var data = JsonSerializer.Deserialize<Library>(json);
                if (data != null)
                {
                    Books = data.Books;
                    Author = data.Author;
                }
            }
        }
    }
}
