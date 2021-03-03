using Newtonsoft.Json;

namespace CopaFilmes.Api.Models
{
    public class Movie
    {
      public string Id { get; set; }
      [JsonProperty("titulo")]
      public string Title { get; set; }

      [JsonProperty("ano")]
      public int Year { get; set; }
      [JsonProperty("nota")]
      public float Score { get; set; }
    }
}
