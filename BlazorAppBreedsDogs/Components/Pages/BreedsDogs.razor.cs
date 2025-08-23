using BlazorAppBreedsDogs.Models;
using BlazorAppBreedsDogs.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;


namespace BlazorAppBreedsDogs.Components.Pages
{
    public partial class BreedsDogs
    {
        [Inject]
        public BreedsDogsServices BreedsDogsService { get; set; }
        public bool isVisible { get; set; }
        public bool loading { get; set; }

        List<BreedDog> breedsDogs = new List<BreedDog>();
        protected override async Task OnInitializedAsync()
        {
            loading = true;
            breedsDogs = await BreedsDogsService.GetAllBreeedsDogs();
            if (breedsDogs != null && breedsDogs.Count() != 0)
            {
                isVisible = true;
            }
            else
            {
                isVisible = false;
            }

            loading = false;
        }
    }
}
 