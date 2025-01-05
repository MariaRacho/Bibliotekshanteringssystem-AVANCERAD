namespace Bibliotekshanteringssystem_AVANCERAD
{
    internal class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string PublicationYear { get; set; }
        public string ISBN { get; set; }
        public List<int> Reviews { get; set; } = new List<int>();

        public double AverageRating => Reviews.Any() ? Reviews.Average() : 0;
    }
}
