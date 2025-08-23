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
    public class BreedsDogsServices
    {
        private readonly HttpClient _httpClient;

        public BreedsDogsServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<BreedDog>> GetAllBreeedsDogs()
        {

            var response = await _httpClient.GetAsync("api/breeds-dogs");
            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                List<BreedDog>? breedsDogs = JsonConvert.DeserializeObject<List<BreedDog>>(jsonString);

                return breedsDogs;

            }
            else
            {
                return null;
            }
          
        }

        //public async Task<BreedDog> GetFillterBreedDog()
        //{
        //    using (var )
        //    {

        //    }
        //}
    }
}
