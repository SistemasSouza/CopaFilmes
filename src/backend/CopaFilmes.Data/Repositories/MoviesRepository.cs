using CopaFilme.Business.Interfaces;
using CopaFilme.Business.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace CopaFilmes.Data.Repositories
{
    public class MoviesRepository : IMoviesRepository
    {
        public IList<Movies> GetAllMovies()
        {
            using var client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("http://copafilmes.azurewebsites.net/api/filmes").Result;

            response.EnsureSuccessStatusCode();
            var result = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<IList<Movies>>(result);
        }
    }
}
