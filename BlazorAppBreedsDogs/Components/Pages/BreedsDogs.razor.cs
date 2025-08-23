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
    public partial class BreedsDogs : ComponentBase
    {
        [Inject]
        public BreedsDogsServices BreedsDogsServices { get; set; }
        public bool isVisible { get; set; }
        public bool loading { get; set; }

        List<BreedDog> breedsDogs = new List<BreedDog>();
        protected override async Task OnInitializedAsync()
        {
            loading = true;
            breedsDogs = await BreedsDogsServices.GetAllBreeedsDogs();
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

        public async void GetBreedDog()
        {
            breedsDogs.Clear();
            loading = true;
            BreedDog breedDogFiltered = await BreedsDogsServices.GetFillterBreedDog(6);

            breedsDogs.Add(breedDogFiltered);

            if (breedDogFiltered != null)
            {
                isVisible = true;
            }
            else
            {
                isVisible = false;
            }

            loading = false;
            StateHasChanged();
        }
    }
}
 