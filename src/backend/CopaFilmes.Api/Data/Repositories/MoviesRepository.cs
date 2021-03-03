using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using CopaFilmes.Api.Models;
using System.Threading.Tasks;

namespace CopaFilmes.Api.Data.Repositories
{
    public class MoviesRepository : IMoviesRepository
    {
        public Task<IList<Movie>> GetAllMoviesAsync()
        {
            using var client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("http://copafilmes.azurewebsites.net/api/filmes").Result;

            response.EnsureSuccessStatusCode();
            var result = response.Content.ReadAsStringAsync().Result;
            
            return JsonConvert.DeserializeObject<Task<IList<Movie>>>(result);
        }
    }
}
