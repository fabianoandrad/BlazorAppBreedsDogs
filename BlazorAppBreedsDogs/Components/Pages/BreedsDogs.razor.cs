using BlazorAppBreedsDogs.Models;
using BlazorAppBreedsDogs.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BlazorAppBreedsDogs.Components.Pages
{
    public partial class BreedsDogs
    {
        [Inject]
        IBreedsDogsService BreedsDogsService { get; set; }
        public BreedsDogs()
        {

        }

        List<DogBreed> breedsDogs = new List<DogBreed>();
        protected override async Task OnInitializedAsync()
        {
           breedsDogs = await BreedsDogsService.GetBreeedsDogs();
        }
    }
}
