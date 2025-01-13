using System.Text.Json;
using System.Xml;
using static System.Reflection.Metadata.BlobBuilder;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Bibliotekshanteringssystem_AVANCERAD
{
    public class DataManipulation
    {
        public static LibraryData ReadData()
        {
            string filePath = "data.json";

            try
            {
                // Read the JSON file
                string jsonData = File.ReadAllText(filePath);

                // Deserialize the JSON data into objects
                var allBooksAndAuthors = JsonSerializer.Deserialize<LibraryData>(jsonData);

                return allBooksAndAuthors;

            }
            catch (Exception ex)
            {
                throw new Exception("Går inte läsa från JSON fil");
            }
        }

        public static void SaveData(LibraryData data)
        {
            string filePath = "data.json";

            try
            {
                // Serialisera objektet till JSON-sträng
                string jsonData = JsonSerializer.Serialize(data, new JsonSerializerOptions
                {
                    WriteIndented = true // Gör JSON lättläst
                });

                // Skriv till filen
                File.WriteAllText(filePath, jsonData);

                Console.WriteLine("Data har sparats framgångsrikt.");
            }
            catch (Exception ex)
            {
                throw new Exception("Kunde inte spara data till JSON fil", ex);
            }
        }

    }
}
    