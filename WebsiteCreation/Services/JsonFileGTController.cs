using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using WebsiteCreation.Models;

namespace WebsiteCreation.Services
{
    public class JsonFileGTController
    {
        public JsonFileGTController(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName => Path.Combine(WebHostEnvironment.WebRootPath, "data", "title-list.json");

        public IEnumerable<Title_List> GetGames()
        {
            using var jsonFileReader = File.OpenText(JsonFileName);
            return JsonSerializer.Deserialize<Title_List[]>(jsonFileReader.ReadToEnd(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
        }

        public void AddRating(string gameID, int rating)
        {
            var games = GetGames();

            if (games.First(x => x.Id == gameID).Ratings == null)
            {
                games.First(x => x.Id == gameID).Ratings = new int[] { rating };
            }
            else
            {
                var ratings = games.First(x => x.Id == gameID).Ratings.ToList();
                ratings.Add(rating);
                games.First(x => x.Id == gameID).Ratings = ratings.ToArray();
            }

            using var outputStream = File.OpenWrite(JsonFileName);

            JsonSerializer.Serialize<IEnumerable<Title_List>>(
                new Utf8JsonWriter(outputStream, new JsonWriterOptions
                {
                    SkipValidation = true,
                    Indented = true
                }),
                games
            );
        }
    }
}
