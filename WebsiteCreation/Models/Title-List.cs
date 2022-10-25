using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebsiteCreation.Models
{
    public class Title_List
    {
        public string Id { get; set; }
        public string Title { get; set; }

        [JsonPropertyName("img")]
        public string Image { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public int[] Ratings { get; set; }

        public override string ToString() => JsonSerializer.Serialize<Title_List>(this);
       

    }
}
