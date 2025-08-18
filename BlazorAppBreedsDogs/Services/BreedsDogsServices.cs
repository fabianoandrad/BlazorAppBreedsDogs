using BlazorAppBreedsDogs.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorAppBreedsDogs.Services
{
    public class BreedsDogsServices : IBreedsDogsService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private string apiKey = "live_cL4FA4wSlsY8T6N79RJeu4c1jZyIzTo45HSaCKQpUalenl34Bk0t4D25G9wb3ZAH";

        public BreedsDogsServices(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<List<DogBreed>> GetBreeedsDogs()
        {
            using (var httpClient = httpClientFactory.CreateClient())
            {  
                var request = new HttpRequestMessage(HttpMethod.Get, "https://api.thedogapi.com/v1/breeds");
                request.Headers.Add("x-api-key", apiKey);
                var content = new StringContent("", null, "text/plain");
                request.Content = content;
                var response = await httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();
                Console.WriteLine(await response.Content.ReadAsStringAsync());

                var jsonString = await response.Content.ReadAsStringAsync();
                List<DogBreed>? breedsDogs = JsonConvert.DeserializeObject<List<DogBreed>>(jsonString);

                return breedsDogs;
            }
        }
    }
}
