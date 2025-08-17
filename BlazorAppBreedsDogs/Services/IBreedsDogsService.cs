using BlazorAppBreedsDogs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BlazorAppBreedsDogs.Services.BreedsDogsServices;

namespace BlazorAppBreedsDogs.Services
{
    public interface IBreedsDogsService
    {
        Task<List<DogBreed>> GetBreeedsDogs();
    }
}
