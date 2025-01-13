using System.Text.Json.Serialization;
using static System.Reflection.Metadata.BlobBuilder;

namespace Bibliotekshanteringssystem_AVANCERAD
{
    public class Book
    {
        //Skapar böckernas attributer
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Title")]
        public string Title { get; set; }

        [JsonPropertyName("Author")]
        public string Author { get; set; }

        [JsonPropertyName("Genre")]
        public string Genre { get; set; }

        [JsonPropertyName("PublicationYear")]
        public int PublicationYear { get; set; }

        [JsonPropertyName("ISBN")]
        public string ISBN { get; set; }

        [JsonPropertyName("Reviews")]
        public List<int> Reviews { get; set; }

        public Book(int id, string title, string author, string genre, int publicationYear, string iSBN, List<int> reviews)
        {
            Id = id;
            Title = title;
            Author = author;
            Genre = genre;
            PublicationYear = publicationYear;
            ISBN = iSBN;
            Reviews = reviews;
        }
        public Book()
        {
        }
    }
}
